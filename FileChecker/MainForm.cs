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
using System.IO;
using System.Threading;
using System.Windows.Forms;
using BSLib;
using EXControls;

namespace FileChecker
{
    public partial class MainForm : Form, IUserForm
    {
        private readonly SynchronizationContext fSyncContext;
        private readonly int fProcessorCores;

        private int fCompleted;
        private bool[] fCoreBusy;
        private string fLastFolder;
        private int fLastIndex;
        private bool fCheckMode;
        private bool fShowOnlyChanges;

        private readonly Digest fCurrentDigest;
        private readonly Digest fPreviousDigest;

        EXListViewItem[] fListItems;
        ProgressBar[] fProgressBars;

        public MainForm()
        {
            InitializeComponent();
            fSyncContext = SynchronizationContext.Current;
            fCurrentDigest = new Digest();
            fPreviousDigest = new Digest();

            fProcessorCores = FCCore.GetProcessorsCount();
            fCoreBusy = new bool[fProcessorCores];
            Array.Clear(fCoreBusy, 0, fProcessorCores);

            Text = "ProcessorsCount: " + fProcessorCores;

            lvFolders.Columns.Add("Folder", 300);

            exListView1.Columns.Add("File", 200);
            exListView1.Columns.Add("Progress", 200);

            lvFiles.Columns.Add("File", 400);
            lvFiles.Columns.Add("Hash", 300);
            lvFiles.Columns.Add("Type", 200);

            fListItems = new EXListViewItem[fProcessorCores];
            fProgressBars = new ProgressBar[fProcessorCores];
            for (int i = 0; i < fProcessorCores; i++) {
                EXListViewItem item = new EXListViewItem("Item " + i);
                EXControlListViewSubItem cs = new EXControlListViewSubItem();
                ProgressBar b = new ProgressBar();
                b.Minimum = 0;
                b.Maximum = 100;
                b.Step = 1;
                item.SubItems.Add(cs);
                exListView1.AddControlToSubItem(b, cs);
                exListView1.Items.Add(item);

                fListItems[i] = item;
                fProgressBars[i] = b;
            }
        }

        private void SetUpdateMode(bool hasChanges)
        {
            btnUpdate.Enabled = hasChanges;
        }

        private void btnCreateDigest_Click(object sender, EventArgs e)
        {
            // select checksum digest's file
            using (var dlg = new SaveFileDialog()) {
                dlg.Filter = "FileChecker hash files (*.fhx)|*.fhx";
                if (dlg.ShowDialog() == DialogResult.OK) {
                    txtDigestFile.Text = dlg.FileName;
                    SetUpdateMode(false);
                    CreateDigest();
                }
            }
        }

        private void btnTestDigest_Click(object sender, EventArgs e)
        {
            fShowOnlyChanges = chkOnlyChanges.Checked;

            // select checksum digest's file
            using (var dlg = new OpenFileDialog()) {
                dlg.Filter = "FileChecker hash files (*.fhx)|*.fhx";
                if (dlg.ShowDialog() == DialogResult.OK) {
                    txtDigestFile.Text = dlg.FileName;
                    SetUpdateMode(false);
                    TestDigest();
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            fPreviousDigest.WriteDigest(txtDigestFile.Text, true);
            SetUpdateMode(false);
        }

        private void btnSelectFolder_Click(object sender, EventArgs e)
        {
            using (var fldDlg = new FolderBrowserDialog()) {
                fldDlg.SelectedPath = fLastFolder;
                if (fldDlg.ShowDialog() == DialogResult.OK) {
                    fLastFolder = fldDlg.SelectedPath;

                    fCurrentDigest.Folders.Add(fLastFolder);
                    lvFolders.Items.Add(fLastFolder);

                    lvFolders.Update();
                }
            }
        }

        private void FillFilesList()
        {
            lvFiles.BeginUpdate();
            for (int i = 0; i < fCurrentDigest.Files.Count; i++) {
                var item = lvFiles.Items.Add(fCurrentDigest.Files[i].FileName);
                item.SubItems.Add("");
            }
            lvFiles.EndUpdate();
        }

        private void TestDigest()
        {
            fCheckMode = true;

            fPreviousDigest.ReadDigest(txtDigestFile.Text);

            lvFolders.Items.Clear();
            foreach (string folder in fPreviousDigest.Folders) {
                lvFolders.Items.Add(folder);
            }
            lvFolders.Update();

            fCurrentDigest.Folders.Clear();
            fCurrentDigest.Folders.AddRange(fPreviousDigest.Folders);

            GenerateDigest();
        }

        private void CompareDigests()
        {
            fCurrentDigest.Files.Sort((x, y) => string.Compare(x.FileName, y.FileName, StringComparison.InvariantCulture));
            fPreviousDigest.Files.Sort((x, y) => string.Compare(x.FileName, y.FileName, StringComparison.InvariantCulture));

            bool hasChanges = false;

            foreach (var prevFile in fPreviousDigest.Files) {
                var currFile = fCurrentDigest.Files.Find(x => x.FileName.Equals(prevFile.FileName));
                if (currFile == null) {
                    prevFile.FileType = FileType.Missing;
                    hasChanges = true;
                } else {
                    if (Algorithms.ArraysEqual(prevFile.Hash, currFile.Hash)) {
                        prevFile.FileType = FileType.Identical;
                    } else {
                        prevFile.FileType = FileType.DifferentChecksum;
                        prevFile.Hash = currFile.Hash;
                        hasChanges = true;
                    }
                }
            }

            foreach (var newFile in fCurrentDigest.Files) {
                var prevFile = fPreviousDigest.Files.Find(x => x.FileName.Equals(newFile.FileName));
                if (prevFile == null) {
                    newFile.FileType = FileType.New;
                    fPreviousDigest.Files.Add(newFile);
                    hasChanges = true;
                }
            }

            lvFiles.Items.Clear();
            foreach (var fileObj in fPreviousDigest.Files) {
                if (!fShowOnlyChanges || fileObj.FileType != FileType.Identical) {
                    var item = lvFiles.Items.Add(fileObj.FileName);
                    item.SubItems.Add(FCCore.Hash2Str(fileObj.Hash));
                    item.SubItems.Add(fileObj.FileType.ToString());
                }
            }
            lvFiles.Update();

            SetUpdateMode(hasChanges);
        }

        private readonly ManualResetEvent initEvent = new ManualResetEvent(false);
        private bool fEmptyList;

        private void CreateDigest()
        {
            fCheckMode = false;
            GenerateDigest();
        }

        private void GenerateDigest()
        {
            fCurrentDigest.Files.Clear();
            for (int i = 0; i < lvFolders.Items.Count; i++) {
                string folder = lvFolders.Items[i].Text;
                WalkDirectoryTree(fCurrentDigest.Files, new DirectoryInfo(folder), true);
            }

            FillFilesList();
            fLastIndex = -1;
            fEmptyList = false;
            initEvent.Set();
            ProgressBar.Value = 0;
            ProgressBar.Maximum = fCurrentDigest.Files.Count;
            ProgressBar.Visible = true;
            fCompleted = 0;

            new Thread(() => {
                while (!fEmptyList) {
                    if (initEvent.WaitOne()) {
                        lock (fCurrentDigest.Files) {
                            lock (fCoreBusy) {
                                int freeCore = GetFreeCore();
                                while (freeCore >= 0) {
                                    if (fLastIndex >= fCurrentDigest.Files.Count - 1) {
                                        fEmptyList = true;
                                        break;
                                    }
                                    fLastIndex += 1;

                                    fCoreBusy[freeCore] = true;
                                    CreateFileHashThread(fLastIndex, freeCore, fCurrentDigest.Files[fLastIndex]);

                                    freeCore = GetFreeCore();
                                }
                            }
                        }

                        initEvent.Reset();
                    }
                }
            }).Start();
        }

        private void WalkDirectoryTree(List<ThreadFileObj> resultFiles, DirectoryInfo root, bool showHidden)
        {
            UpdateProgress(0, "Folder scanning");

            var dirStack = new Stack<DirectoryInfo>();
            dirStack.Push(root);

            while (dirStack.Count > 0) {
                DirectoryInfo currentDir = dirStack.Pop();

                if (!FCCore.CheckAttributes(currentDir.Attributes, showHidden)) {
                    continue;
                }

                try {
                    FileInfo[] files = currentDir.GetFiles("*.*");
                    foreach (FileInfo file in files) {
                        try {
                            if (!FCCore.CheckAttributes(file.Attributes, showHidden)) {
                                continue;
                            }

                            int index = resultFiles.Count;
                            resultFiles.Add(new ThreadFileObj(index, -1, file.FullName, this));

                            UpdateProgress(1, file.FullName);
                        } catch (FileNotFoundException) {
                        }
                    }
                } catch (UnauthorizedAccessException) {
                } catch (DirectoryNotFoundException) {
                }

                try {
                    DirectoryInfo[] subDirs = currentDir.GetDirectories();
                    foreach (DirectoryInfo dir in subDirs) {
                        dirStack.Push(dir);
                    }
                } catch (UnauthorizedAccessException) {
                } catch (DirectoryNotFoundException) {
                }
            }

            UpdateProgress(2, "");
        }

        private void UpdateProgress(int action, string value)
        {
            switch (action) {
                case 0:
                case 2:
                    StatusText.Text = value;
                    //tsProgress.Maximum = 100;
                    //tsProgress.Value = 0;
                    break;

                case 1:
                    StatusText.Text = value;
                    /*if (value >= tsProgress.Minimum && value <= tsProgress.Maximum) {
                        tsProgress.Value = value;
                    }*/
                    break;
            }
        }

        private int GetFreeCore()
        {
            for (int i = 0; i < fCoreBusy.Length; i++) {
                if (!fCoreBusy[i]) {
                    return i;
                }
            }
            return -1;
        }

        #region Thread's reporting functions

        void IUserForm.ReportHash(ThreadFileObj fileObj)
        {
            fSyncContext.Post(UpdateHash, fileObj);

            lock (fCoreBusy) {
                int threadCore = fileObj.Core;
                fCoreBusy[threadCore] = false;
            }

            initEvent.Set();

            //var core = FCCore.CORES[fileObj.Core];
            //fSyncContext.Post(UpdateLog, core.ToString() + ", FileHash (" + fileObj.FileName + "): " + FCCore.Hash2Str(fileObj.Hash));
        }

        private void UpdateHash(object state)
        {
            ThreadFileObj fileObj = (ThreadFileObj)state;

            int core = fileObj.Core;
            fProgressBars[core].Value = 0;
            fListItems[core].Text = "?";
            exListView1.Update();

            lvFiles.Items[fileObj.Index].SubItems[1].Text = FCCore.Hash2Str(fileObj.Hash);
            lvFiles.Update();

            fCompleted += 1;
            ProgressBar.Value = fCompleted;

            if (fCompleted == fCurrentDigest.Files.Count) {
                if (fCheckMode) {
                    CompareDigests();
                } else {
                    fCurrentDigest.WriteDigest(txtDigestFile.Text);
                }

                ProgressBar.Value = 0;
            }
        }

        void IUserForm.ReportProgress(ThreadFileObj fileObj)
        {
            fSyncContext.Post(UpdateProgress, fileObj);
        }

        private void UpdateProgress(object state)
        {
            ThreadFileObj fileObj = (ThreadFileObj)state;
            fProgressBars[fileObj.Core].Value = fileObj.Progress;
        }

        void IUserForm.ReportStart(ThreadFileObj fileObj)
        {
            fSyncContext.Post(UpdateStart, fileObj);
        }

        private void UpdateStart(object state)
        {
            ThreadFileObj fileObj = (ThreadFileObj)state;
            fListItems[fileObj.Core].Text = fileObj.FileName;
            exListView1.Update();
        }

        void IUserForm.ReportLog(string msg)
        {
            fSyncContext.Post(UpdateLog, msg);
        }

        private void UpdateLog(object state)
        {
            string msg = (string)state;
            //textBox2.AppendText(msg + "\r\n");
        }

        #endregion

        #region Calculate file's hashes

        private void CreateFileHashThread(int index, int coreNum, ThreadFileObj fileObj)
        {
            ProcessorCore core = FCCore.CORES[coreNum];
            ((IUserForm)this).ReportLog(core.ToString() + ", Processing: " + fileObj.FileName);

            fileObj.Core = coreNum;
            ((IUserForm)this).ReportStart(fileObj);

            DistributedThread thread = new DistributedThread(ParameterizedThreadProc);
            thread.ProcessorAffinity = (int)core;
            thread.Start(fileObj);
        }

        private static void ParameterizedThreadProc(object obj)
        {
            var fileObj = ((ThreadFileObj)obj);
            FCCore.CalculateFileHash(fileObj);
        }

        #endregion
    }
}
