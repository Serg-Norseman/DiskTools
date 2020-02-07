/*
 *  "FileChecker".
 *  Copyright (C) 2018 by Sergey V. Zhdanovskih.
 *
 *  This program is free software: you can redistribute it and/or modify
 *  it under the terms of the GNU General Public License as published by
 *  the Free Software Foundation, either version 3 of the License, or
 *  (at your option) any later version.
 *
 *  This program is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *  GNU General Public License for more details.
 *
 *  You should have received a copy of the GNU General Public License
 *  along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */

using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace FileChecker
{
    public enum ProcessorCore : int
    {
        Core1 = 0x1,
        Core2 = 0x2,
        Core3 = 0x4,
        Core4 = 0x8,
        Core5 = 0x10,
        Core6 = 0x20,
        Core7 = 0x40,
        Core8 = 0x80,
    }

    public static class FCCore
    {
        public static readonly ProcessorCore[] CORES = new ProcessorCore[] {
            ProcessorCore.Core1,
            ProcessorCore.Core2,
            ProcessorCore.Core3,
            ProcessorCore.Core4,
            ProcessorCore.Core5,
            ProcessorCore.Core6,
            ProcessorCore.Core7,
            ProcessorCore.Core8,
        };

        public static int GetProcessorsCount()
        {
            int processors = 1;
            string processorsStr = System.Environment.GetEnvironmentVariable("NUMBER_OF_PROCESSORS");
            if (processorsStr != null) processors = int.Parse(processorsStr);
            return processors;
        }

        public static void CalculateFileHash(ThreadFileObj fileObj)
        {
            string fileName = fileObj.FileName;
            IUserForm userForm = fileObj.UserForm;

            byte[] buffer;
            byte[] oldBuffer;
            int bytesRead;
            int oldBytesRead;
            long size;
            long totalBytesRead = 0;

            using (Stream stream = File.OpenRead(fileName))
                using (HashAlgorithm hashAlgorithm = GetHashAlgorithm(ChecksumType.MD5)) {
                size = stream.Length;

                buffer = new byte[4096];
                bytesRead = stream.Read(buffer, 0, buffer.Length);
                totalBytesRead += bytesRead;

                do {
                    oldBytesRead = bytesRead;
                    oldBuffer = buffer;

                    buffer = new byte[4096];
                    bytesRead = stream.Read(buffer, 0, buffer.Length);
                    totalBytesRead += bytesRead;

                    if (bytesRead == 0) {
                        hashAlgorithm.TransformFinalBlock(oldBuffer, 0, oldBytesRead);
                    } else {
                        hashAlgorithm.TransformBlock(oldBuffer, 0, oldBytesRead, oldBuffer, 0);
                    }

                    int progress = (size == 0) ? 0 : (int)((double)totalBytesRead * 100 / size);
                    fileObj.Progress = progress;
                    userForm.ReportProgress(fileObj);
                } while (bytesRead != 0);

                fileObj.Hash = hashAlgorithm.Hash;
                userForm.ReportHash(fileObj);
            }
        }

        public static string Hash2Str(byte[] hash)
        {
            StringBuilder sb = new StringBuilder();
            foreach (byte b in hash) {
                sb.AppendFormat("{0:X2}", b);
            }
            return sb.ToString();
        }

        public static byte[] Str2Hash(string hex)
        {
            int charsNum = hex.Length;
            byte[] bytes = new byte[charsNum / 2];
            for (int i = 0; i < charsNum; i += 2) bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            return bytes;
        }

        public static HashAlgorithm GetHashAlgorithm(ChecksumType checksumType)
        {
            HashAlgorithm result = null;
            switch (checksumType) {
                case ChecksumType.MD5:
                    result = MD5.Create();
                    break;

                case ChecksumType.SHA1:
                    result = SHA1.Create();
                    break;

                case ChecksumType.SHA256:
                    result = SHA256.Create();
                    break;

                case ChecksumType.SHA512:
                    result = SHA512.Create();
                    break;
            }
            return result;
        }

        public static bool CheckAttributes(FileAttributes attrs, bool showHidden)
        {
            if (attrs.HasFlag(FileAttributes.ReparsePoint)) {
                return false;
            }

            if (!attrs.HasFlag(FileAttributes.Directory)) {
                if (!showHidden && (attrs.HasFlag(FileAttributes.Hidden) || attrs.HasFlag(FileAttributes.System))) {
                    return false;
                }
            }

            return true;
        }
    }
}
