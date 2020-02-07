﻿/*
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
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FileChecker
{
    public sealed class Digest
    {
        private readonly List<ThreadFileObj> fFiles;
        private readonly List<string> fFolders;

        public List<ThreadFileObj> Files
        {
            get { return fFiles; }
        }

        public List<string> Folders
        {
            get { return fFolders; }
        }

        public Digest()
        {
            fFiles = new List<ThreadFileObj>();
            fFolders = new List<string>();
        }

        public void Clear()
        {
            fFiles.Clear();
            fFolders.Clear();
        }

        public void ReadDigest(string fileName)
        {
            if (string.IsNullOrEmpty(fileName) || !File.Exists(fileName)) {
                return;
            }

            Clear();
            using (var sw = new StreamReader(fileName, Encoding.UTF8)) {
                string line;
                while (!string.IsNullOrEmpty(line = sw.ReadLine())) {
                    switch (line[0]) {
                        case ';': // comment
                            break;

                        case '*': // folder
                            fFolders.Add(line.Substring(1));
                            break;

                        default: // file
                            int pos = line.IndexOf(" *");
                            string fName, fHash;
                            fName = line.Substring(pos + 2);
                            fHash = line.Substring(0, pos);
                            byte[] hash = FCCore.Str2Hash(fHash);
                            var fileObj = new ThreadFileObj(fName, hash);
                            fFiles.Add(fileObj);
                            break;
                    }
                }
            }
        }

        public void WriteDigest(string fileName, bool updateMode = false)
        {
            if (string.IsNullOrEmpty(fileName)) {
                return;
            }

            using (var sw = new StreamWriter(fileName, false, Encoding.UTF8)) {
                sw.WriteLine("; Checksums generated by FileChecker 0.1.0.0");
                sw.WriteLine("; " + DateTime.Now.ToString());

                for (int i = 0; i < fFolders.Count; i++) {
                    string folder = fFolders[i];
                    sw.WriteLine("*" + folder);
                }

                int filesNum = 0;
                foreach (var fileObj in fFiles) {
                    if (!updateMode || fileObj.FileType != FileType.Missing) {
                        filesNum += 1;
                        sw.WriteLine(FCCore.Hash2Str(fileObj.Hash) + " *" + fileObj.FileName);
                    }
                }

                sw.WriteLine("; " + filesNum + " files hashed.");
            }
        }
    }
}
