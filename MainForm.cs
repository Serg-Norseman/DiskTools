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
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace FileChecker
{
    public partial class MainForm : Form, IUserForm
    {
        private readonly SynchronizationContext syncContext;

        private string folderName;

        public MainForm()
        {
            InitializeComponent();
            syncContext = SynchronizationContext.Current;

            DefineProcessorsCount();
        }

        private void DefineProcessorsCount()
        {
            int processors = 1;
            string processorsStr = System.Environment.GetEnvironmentVariable("NUMBER_OF_PROCESSORS");
            if (processorsStr != null) processors = int.Parse(processorsStr);
            Text = "ProcessorsCount: " + processors;
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            using (var fldDlg = new FolderBrowserDialog()) {
                if (fldDlg.ShowDialog() == DialogResult.OK) {
                    folderName = fldDlg.SelectedPath;
                    Process();
                }
            }
        }

        private void Process()
        {
            
        }

        public void ReportHash(byte[] hashResult)
        {
            syncContext.Post(UpdateHash, hashResult);
        }

        private void UpdateHash(object state)
        {
            byte[] hashResult = (byte[])state;

            StringBuilder sb;
            sb = new StringBuilder();

            ProgressPercentage.Visible = false;
            ProgressBar.Visible = false;
            StatusText.Text = "";

            foreach (byte b in hashResult) {
                sb.AppendFormat("{0:X2}", b);
            }
            HashTextbox.Text = sb.ToString();
        }

        public void ReportProgress(int progress)
        {
            syncContext.Post(UpdateProgress, progress);
        }

        private void UpdateProgress(object state)
        {
            int progress = (int)state;
            ProgressBar.Value = progress;
            ProgressPercentage.Text = progress + "%";
        }

        private void SelectFileButton_Click(object sender, EventArgs e)
        {
            if (OpenFileDialog.ShowDialog() != System.Windows.Forms.DialogResult.OK) {
                return;
            }

            FileTextBox.Text = OpenFileDialog.FileName;
 
            ProgressPercentage.Visible = true;
            ProgressBar.Visible = true;
            StatusText.Text = "Computing hash...";

            DistributedThread thread = new DistributedThread(ParameterizedThreadProc);
            thread.ProcessorAffinity = 2;
            thread.ManagedThread.Name = "ThreadOnCPU2";
            thread.Start(new ThreadFileObj(FileTextBox.Text, this));
        }

        public static void ParameterizedThreadProc(object obj)
        {
            string fileName = ((ThreadFileObj)obj).FileName;
            IUserForm userForm = ((ThreadFileObj)obj).UserForm;

            byte[] buffer;
            byte[] oldBuffer;
            int bytesRead;
            int oldBytesRead;
            long size;
            long totalBytesRead = 0;

            using (Stream stream = File.OpenRead(fileName)) using (HashAlgorithm hashAlgorithm = MD5.Create()) {
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

                    int progress = (int)((double)totalBytesRead * 100 / size);
                    userForm.ReportProgress(progress);
                } while (bytesRead != 0);

                userForm.ReportHash(hashAlgorithm.Hash);
            }
        }
    }
}
