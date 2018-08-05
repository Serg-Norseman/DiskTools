/*
 *  "DiskTracker".
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
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using BSLib;
using BSLib.DataViz.TreeMap;

namespace DiskTracker
{
    public partial class MainForm : Form
    {
        private Dictionary<string, Color> fColorScheme;
        private TreeMapViewer fDataMap;

        private bool fEnableColorscheme = true;
        private bool fShowFreeSpace = true;
        private bool fShowFileSize = true;
        private bool fShowHiddenFiles = true;

        public bool EnableColorscheme
        {
            get { return fEnableColorscheme; }
            set { fEnableColorscheme = value; }
        }

        public bool ShowFreeSpace
        {
            get { return fShowFreeSpace; }
            set { fShowFreeSpace = value; }
        }

        public bool ShowFileSize
        {
            get { return fShowFileSize; }
            set { fShowFileSize = value; }
        }

        public bool ShowHiddenFiles
        {
            get { return fShowHiddenFiles; }
            set { fShowHiddenFiles = value; }
        }


        public MainForm()
        {
            InitializeComponent();

            fDataMap = new TreeMapViewer();
            fDataMap.Dock = DockStyle.Fill;
            fDataMap.MouseoverHighlight = true;
            fDataMap.OnHintRequest += OnHintRequest;
            fDataMap.ContextMenuStrip = mnuTreeMap;
            Controls.Add(fDataMap);
            Controls.SetChildIndex(fDataMap, 0);

            tsbRefresh.Image = DTHelper.LoadResourceImage("DiskTracker.Resources.btn_refresh.gif");
            tsbOptions.Image = DTHelper.LoadResourceImage("DiskTracker.Resources.btn_tools.gif");
            tsbAbout.Image = DTHelper.LoadResourceImage("DiskTracker.Resources.btn_help.gif");

            UpdateColorScheme();
            UpdateDisksList();
        }

        private void UpdateColorScheme()
        {
            fColorScheme = new Dictionary<string, Color>();
            fColorScheme.Add("zip", Color.BlueViolet);
            fColorScheme.Add("rar", Color.BlueViolet);
            fColorScheme.Add("cab", Color.BlueViolet);

            fColorScheme.Add("iso", Color.Fuchsia);

            fColorScheme.Add("vdi", Color.LimeGreen);

            fColorScheme.Add("avi", Color.GreenYellow);
            fColorScheme.Add("mpg", Color.GreenYellow);
            fColorScheme.Add("mp4", Color.GreenYellow);
            fColorScheme.Add("mpeg", Color.GreenYellow);
            fColorScheme.Add("wmv", Color.GreenYellow);
            fColorScheme.Add("fbr", Color.GreenYellow);
            fColorScheme.Add("mov", Color.GreenYellow);

            fColorScheme.Add("wav", Color.MediumSeaGreen);
            fColorScheme.Add("mp3", Color.MediumSeaGreen);
            fColorScheme.Add("wma", Color.MediumSeaGreen);

            fColorScheme.Add("bmp", Color.PaleVioletRed);
            fColorScheme.Add("jpg", Color.PaleVioletRed);
            fColorScheme.Add("jpeg", Color.PaleVioletRed);
            fColorScheme.Add("gif", Color.PaleVioletRed);
            fColorScheme.Add("png", Color.PaleVioletRed);
            fColorScheme.Add("tif", Color.PaleVioletRed);
            fColorScheme.Add("tiff", Color.PaleVioletRed);
            fColorScheme.Add("pcx", Color.PaleVioletRed);

            fColorScheme.Add("mdb", Color.DodgerBlue);
            fColorScheme.Add("doc", Color.DodgerBlue);
            fColorScheme.Add("xls", Color.DodgerBlue);
            fColorScheme.Add("docx", Color.DodgerBlue);
            fColorScheme.Add("xlsx", Color.DodgerBlue);

            fColorScheme.Add("exe", Color.Aquamarine);
            fColorScheme.Add("dll", Color.Aquamarine);
        }

        private void UpdateDisksList()
        {
            tscmbDisk.Items.Clear();

            DriveInfo[] allDrives = DriveInfo.GetDrives();
            foreach (DriveInfo d in allDrives) {
                if (d.IsReady) {
                    tscmbDisk.Items.Add(new DiskItem(string.Format("{0} [{1}], {2}, {3}", d.Name, d.VolumeLabel, d.DriveType, d.DriveFormat), d));
                }
            }
        }

        private MapItem CreateItem(MapItem parent, string name, double size, float quality)
        {
            var item = fDataMap.Model.CreateItem(parent, name, size) as SimpleItem;

            if (fEnableColorscheme) {
                string ext = Path.GetExtension(name).TrimStart('.').ToLowerInvariant();
                Color color;
                if (!fColorScheme.TryGetValue(ext, out color)) {
                    color = Color.Silver;
                }
                item.Color = color;
            } else {
                item.Color = Color.Silver;
            }

            //double wavelength = Spectrum.ColdWavelength + (Spectrum.WavelengthMaximum - Spectrum.ColdWavelength) * (1.0f - quality);
            //item.Color = Spectrum.WavelengthToRGB(wavelength);

            return item;
        }

        private void UpdateTreeMap()
        {
            fDataMap.Model.Clear();

            DiskItem item = tscmbDisk.SelectedItem as DiskItem;
            if (item != null) {
                DriveInfo di = item.Tag as DriveInfo;
                DirectoryInfo rootDir = di.RootDirectory;
                WalkDirectoryTree(rootDir, di.TotalSize - di.TotalFreeSpace, di.TotalFreeSpace);
            }

            fDataMap.UpdateView();
        }

        private bool CheckAttributes(FileAttributes attrs)
        {
            if (attrs.HasFlag(FileAttributes.ReparsePoint)) {
                return false;
            }

            if (!attrs.HasFlag(FileAttributes.Directory)) {
                if (!fShowHiddenFiles && (attrs.HasFlag(FileAttributes.Hidden) || attrs.HasFlag(FileAttributes.System))) {
                    return false;
                }
            }

            return true;
        }

        private void WalkDirectoryTree(DirectoryInfo root, double allocatedSpace, double freeSpace)
        {
            double allocatedFiles = 0.0d;
            MapItem rootItem = null;
            UpdateProgress(0, 0);

            Stack<DirStackItem> dirStack = new Stack<DirStackItem>(20);

            dirStack.Push(new DirStackItem(null, root));

            while (dirStack.Count > 0) {
                DirStackItem stackItem = dirStack.Pop();

                DirectoryInfo currentDir = stackItem.DirInfo;
                if (!CheckAttributes(currentDir.Attributes)) {
                    continue;
                }

                var dirItem = CreateItem(stackItem.Parent, currentDir.FullName, 0.0f, 0.0f);
                if (currentDir == root) {
                    rootItem = dirItem;

                    if (fShowFreeSpace) {
                        CreateItem(dirItem, "FreeSpace", freeSpace, 0.0f);
                    }
                }

                try {
                    FileInfo[] files = currentDir.GetFiles("*.*");

                    foreach (FileInfo file in files) {
                        try {
                            if (!CheckAttributes(file.Attributes)) {
                                continue;
                            }

                            CreateItem(dirItem, file.FullName, file.Length, 0.0f);

                            allocatedFiles += file.Length;
                            UpdateProgress(1, (int)(allocatedFiles / allocatedSpace * 100));
                        } catch (FileNotFoundException) {
                        }
                    }
                } catch (UnauthorizedAccessException) {
                } catch (DirectoryNotFoundException) {
                }

                try {
                    DirectoryInfo[] subDirs = currentDir.GetDirectories();

                    foreach (DirectoryInfo dir in subDirs) {
                        dirStack.Push(new DirStackItem(dirItem, dir));
                    }
                } catch (UnauthorizedAccessException) {
                } catch (DirectoryNotFoundException) {
                }
            }

            UpdateProgress(2, 0);
            SetRoot(rootItem);
        }

        private void OnHintRequest(object sender, HintRequestEventArgs args)
        {
            args.Hint = args.MapItem.Name;
            if (fShowFileSize) {
                args.Hint += "\r\n" + FileHelper.FileSizeToStr((long)args.MapItem.Size);
            }
        }

        private void UpdateProgress(int action, int value)
        {
            switch (action) {
                case 0:
                case 2:
                    tsProgress.Maximum = 100;
                    tsProgress.Value = 0;
                    break;

                case 1:
                    if (value >= tsProgress.Minimum && value <= tsProgress.Maximum) {
                        tsProgress.Value = value;
                    }
                    break;
            }
        }

        private void tscmbDisk_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateTreeMap();
        }

        private void tsbAbout_Click(object sender, EventArgs e)
        {
            using (var dlg = new AboutDlg()) {
                dlg.ShowDialog();
            }
        }

        private void tsbOptions_Click(object sender, EventArgs e)
        {
            using (var dlg = new OptionsDlg(this)) {
                if (dlg.ShowDialog() == DialogResult.OK) {
                    UpdateTreeMap();
                }
            }
        }

        private void tsbRefresh_Click(object sender, EventArgs e)
        {
            UpdateTreeMap();
        }

        private void miOpenFile_Click(object sender, EventArgs e)
        {
            if (fDataMap.CurrentItem != null) {
                DTHelper.LoadExtFile(fDataMap.CurrentItem.Name);
            }
        }

        private void miExplore_Click(object sender, EventArgs e)
        {
            if (fDataMap.CurrentItem != null) {
                string path = Path.GetDirectoryName(fDataMap.CurrentItem.Name);
                DTHelper.LoadExtFile(path);
            }
        }

        private void miProperties_Click(object sender, EventArgs e)
        {
            if (fDataMap.CurrentItem != null) {
                Process.Start(new ProcessStartInfo("file://" + fDataMap.CurrentItem.Name) { UseShellExecute = true, Verb = "properties" });
            }
        }

        private void SetPath(string path)
        {
            tslblPath.Text = string.Format("Path: {0}", path);
        }

        private void SetRoot(MapItem rootItem)
        {
            fDataMap.RootItem = rootItem;
            SetPath(rootItem.Name);
        }

        private void miDownLevel_Click(object sender, EventArgs e)
        {
            if (fDataMap.UpperItem != null && Directory.Exists(fDataMap.UpperItem.Name)) {
                SetRoot(fDataMap.UpperItem);
            }
        }

        private void miUpLevel_Click(object sender, EventArgs e)
        {
            if (fDataMap.RootItem != null) {
                var parent = fDataMap.RootItem.Parent;

                if (parent != null && Directory.Exists(parent.Name)) {
                    SetRoot(parent);
                }
            }
        }

        private void miDownToFile_Click(object sender, EventArgs e)
        {
            if (fDataMap.CurrentItem != null && File.Exists(fDataMap.CurrentItem.Name)) {
                var parent = fDataMap.CurrentItem.Parent;

                if (parent != null && Directory.Exists(parent.Name)) {
                    SetRoot(parent);
                }
            }
        }

        private void miUpToRoot_Click(object sender, EventArgs e)
        {
            var item = fDataMap.RootItem;
            while (item.Parent != null) {
                item = item.Parent;
            }
            if (item != null && Directory.Exists(item.Name)) {
                SetRoot(item);
            }
        }

        private void mnuTreeMap_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            bool hasItem = (fDataMap.CurrentItem != null);

            miOpenFile.Enabled = hasItem;
            miExplore.Enabled = hasItem;
            miProperties.Enabled = hasItem;

            miDownLevel.Enabled = (fDataMap.UpperItem != null);
            miUpLevel.Enabled = (fDataMap.RootItem != null);
            miDownToFile.Enabled = hasItem;
            miUpToRoot.Enabled = (fDataMap.RootItem != null);
        }
    }
}
