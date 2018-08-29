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
        private readonly Dictionary<string, Color> fColorScheme;
        private readonly TreeMapViewer fDataMap;

        private bool fEnableColorscheme = true;
        private bool fShowFreeSpace = true;
        private bool fShowFileSize = true;
        private bool fShowHiddenFiles = true;

        public Dictionary<string, Color> Colorscheme
        {
            get { return fColorScheme; }
        }

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

            fColorScheme = new Dictionary<string, Color>();

            LoadOptions(DTHelper.GetAppPath() + "DiskTracker.ini");

            fDataMap = new TreeMapViewer();
            fDataMap.Dock = DockStyle.Fill;
            fDataMap.MouseoverHighlight = true;
            fDataMap.OnHintRequest += OnHintRequest;
            fDataMap.MouseMove += OnMouseMove;
            fDataMap.ContextMenuStrip = mnuTreeMap;
            Controls.Add(fDataMap);
            Controls.SetChildIndex(fDataMap, 0);

            tsbRefresh.Image = DTHelper.LoadResourceImage("DiskTracker.Resources.btn_refresh.gif");
            tsbOptions.Image = DTHelper.LoadResourceImage("DiskTracker.Resources.btn_tools.gif");
            tsbAbout.Image = DTHelper.LoadResourceImage("DiskTracker.Resources.btn_help.gif");

            if (fColorScheme.Count <= 0) {
                ResetColorScheme();
            }

            UpdateDisksList();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveOptions(DTHelper.GetAppPath() + "DiskTracker.ini");
        }

        internal void ResetColorScheme()
        {
            fColorScheme.Clear();

            fColorScheme.Add("zip", Color.BlueViolet);
            fColorScheme.Add("rar", Color.BlueViolet);
            fColorScheme.Add("7z", Color.BlueViolet);
            fColorScheme.Add("lzma", Color.BlueViolet);

            fColorScheme.Add("cab", Color.Fuchsia);
            fColorScheme.Add("iso", Color.Fuchsia);
            fColorScheme.Add("msi", Color.Fuchsia);
            fColorScheme.Add("msp", Color.Fuchsia);

            fColorScheme.Add("vdi", Color.LimeGreen);

            fColorScheme.Add("avi", Color.GreenYellow);
            fColorScheme.Add("mpg", Color.GreenYellow);
            fColorScheme.Add("mp4", Color.GreenYellow);
            fColorScheme.Add("mpeg", Color.GreenYellow);
            fColorScheme.Add("wmv", Color.GreenYellow);
            fColorScheme.Add("fbr", Color.GreenYellow);
            fColorScheme.Add("mov", Color.GreenYellow);
            fColorScheme.Add("mkv", Color.GreenYellow);

            fColorScheme.Add("wav", Color.MediumSeaGreen);
            fColorScheme.Add("mp3", Color.MediumSeaGreen);
            fColorScheme.Add("wma", Color.MediumSeaGreen);
            fColorScheme.Add("ape", Color.MediumSeaGreen);

            fColorScheme.Add("bmp", Color.PaleVioletRed);
            fColorScheme.Add("jpg", Color.PaleVioletRed);
            fColorScheme.Add("jpeg", Color.PaleVioletRed);
            fColorScheme.Add("gif", Color.PaleVioletRed);
            fColorScheme.Add("png", Color.PaleVioletRed);
            fColorScheme.Add("tif", Color.PaleVioletRed);
            fColorScheme.Add("tiff", Color.PaleVioletRed);
            fColorScheme.Add("pcx", Color.PaleVioletRed);

            fColorScheme.Add("ost", Color.BlueViolet);

            fColorScheme.Add("accdb", Color.MediumVioletRed);
            fColorScheme.Add("csv", Color.MediumVioletRed);
            fColorScheme.Add("cpy", Color.MediumVioletRed);
            fColorScheme.Add("db", Color.MediumVioletRed);
            fColorScheme.Add("dbf", Color.MediumVioletRed);
            fColorScheme.Add("mdb", Color.MediumVioletRed);

            fColorScheme.Add("doc", Color.DodgerBlue);
            fColorScheme.Add("docx", Color.DodgerBlue);
            fColorScheme.Add("xls", Color.DodgerBlue);
            fColorScheme.Add("xlsx", Color.DodgerBlue);
            fColorScheme.Add("ppt", Color.DodgerBlue);
            fColorScheme.Add("pptx", Color.DodgerBlue);
            fColorScheme.Add("pdf", Color.DodgerBlue);
            fColorScheme.Add("rtf", Color.DodgerBlue);
            fColorScheme.Add("txt", Color.DodgerBlue);
            fColorScheme.Add("djvu", Color.DodgerBlue);
            fColorScheme.Add("fb2", Color.DodgerBlue);

            fColorScheme.Add("vsd", Color.RoyalBlue);
            fColorScheme.Add("vsdx", Color.RoyalBlue);
            fColorScheme.Add("dwg", Color.RoyalBlue);
            fColorScheme.Add("pdi", Color.RoyalBlue);
            fColorScheme.Add("svg", Color.RoyalBlue);

            fColorScheme.Add("htm", Color.DeepSkyBlue);
            fColorScheme.Add("html", Color.DeepSkyBlue);
            fColorScheme.Add("chm", Color.DeepSkyBlue);
            fColorScheme.Add("css", Color.DeepSkyBlue);
            fColorScheme.Add("js", Color.DeepSkyBlue);

            fColorScheme.Add("exe", Color.Aquamarine);
            fColorScheme.Add("dll", Color.Aquamarine);
            fColorScheme.Add("pdb", Color.Aquamarine);
            fColorScheme.Add("ocx", Color.Aquamarine);
            fColorScheme.Add("sys", Color.Aquamarine);
            fColorScheme.Add("cpl", Color.Aquamarine);
            fColorScheme.Add("jar", Color.Aquamarine);

            fColorScheme.Add("ini", Color.Crimson);
            fColorScheme.Add("xml", Color.Crimson);
            fColorScheme.Add("yml", Color.Crimson);
            fColorScheme.Add("yaml", Color.Crimson);

            fColorScheme.Add("ttf", Color.Indigo);
            fColorScheme.Add("fnt", Color.Indigo);
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

        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            var curItem = fDataMap.CurrentItem;
            string curFile = (curItem == null) ? "-" : curItem.Name + ", " + FileHelper.FileSizeToStr((long)curItem.Size);

            var upperItem = fDataMap.UpperItem;
            string upDir = (upperItem == null) ? "-" : upperItem.Name + ", " + FileHelper.FileSizeToStr((long)upperItem.GetCalcSize());

            tslblBasePath.Text = upDir;
            tslblCurFile.Text = curFile;
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


        public void LoadOptions(IniFile ini)
        {
            if (ini == null)
                throw new ArgumentNullException("ini");

            fEnableColorscheme = ini.ReadBool("Common", "EnableColorscheme", true);
            fShowFreeSpace = ini.ReadBool("Common", "ShowFreeSpace", true);
            fShowFileSize = ini.ReadBool("Common", "ShowFileSize", true);
            fShowHiddenFiles = ini.ReadBool("Common", "ShowHiddenFiles", true);

            fColorScheme.Clear();
            int num = ini.ReadInteger("ColorScheme", "ExtCount", 0);
            for (int i = 0; i < num; i++) {
                string si = i.ToString();
                string ext = ini.ReadString("ColorScheme", "Ext" + si, "");
                int color = ini.ReadInteger("ColorScheme", "Color" + si, 0);

                if (!string.IsNullOrEmpty(ext) && color != 0) {
                    fColorScheme.Add(ext, Color.FromArgb(color));
                }
            }
        }

        public void SaveOptions(IniFile ini)
        {
            if (ini == null)
                throw new ArgumentNullException("ini");

            ini.WriteBool("Common", "EnableColorscheme", fEnableColorscheme);
            ini.WriteBool("Common", "ShowFreeSpace", fShowFreeSpace);
            ini.WriteBool("Common", "ShowFileSize", fShowFileSize);
            ini.WriteBool("Common", "ShowHiddenFiles", fShowHiddenFiles);

            ini.WriteInteger("ColorScheme", "ExtCount", fColorScheme.Count);
            int i = 0;
            foreach (var pair in fColorScheme) {
                string si = i.ToString();
                ini.WriteString("ColorScheme", "Ext" + si, pair.Key);
                ini.WriteInteger("ColorScheme", "Color" + si, pair.Value.ToArgb());
                i += 1;
            }
        }

        public void LoadOptions(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
                throw new ArgumentNullException("fileName");

            try {
                IniFile ini = new IniFile(fileName);
                try {
                    LoadOptions(ini);
                } finally {
                    ini.Dispose();
                }
            } catch (Exception ex) {
                //Logger.LogWrite("DiskTracker.LoadFromFile(): " + ex.Message);
            }
        }

        public void SaveOptions(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
                throw new ArgumentNullException("fileName");

            try {
                IniFile ini = new IniFile(fileName);

                try {
                    SaveOptions(ini);
                } finally {
                    ini.Dispose();
                }
            } catch (Exception ex) {
                //Logger.LogWrite("DiskTracker.SaveToFile(): " + ex.Message);
            }
        }
    }
}
