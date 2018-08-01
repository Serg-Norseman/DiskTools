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
using System.IO;
using System.Linq;
using System.Windows.Forms;
using BSLib.Controls;
using BSLib.DataViz.TreeMap;

namespace DiskTracker
{
    public partial class MainForm : Form
    {
        private TreeMapViewer fDataMap;
        private OptionsPicker fOptionsPicker;

        private bool fShowFreeSpace = true;

        public MainForm()
        {
            InitializeComponent();

            fDataMap = new TreeMapViewer();
            fDataMap.Dock = DockStyle.Fill;
            Controls.Add(fDataMap);
            Controls.SetChildIndex(fDataMap, 0);

            CreateOptionsControl();

            UpdateDisksList();
        }

        private void CreateOptionsControl()
        {
            var tsControlHost = new ToolStripOptionsPicker();
            fOptionsPicker = tsControlHost.OptionsPicker;

            toolStrip1.SuspendLayout();
            toolStrip1.Items.Add(tsControlHost);
            toolStrip1.ResumeLayout();

            fOptionsPicker.Items = new string[] { "Show free space" };
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

            //double wavelength = Spectrum.ColdWavelength + (Spectrum.WavelengthMaximum - Spectrum.ColdWavelength) * (1.0f - quality);
            //item.Color = Spectrum.WavelengthToRGB(wavelength);

            return item;
        }

        private void UpdateTreeMap()
        {
            fDataMap.Model.Clear();
            fDataMap.Invalidate();

            DiskItem item = tscmbDisk.SelectedItem as DiskItem;
            DriveInfo di = item.Tag as DriveInfo;
            DirectoryInfo rootDir = di.RootDirectory;
            tslblPath.Text = rootDir.FullName;

            WalkDirectoryTree(rootDir, di.TotalSize - di.TotalFreeSpace, di.TotalFreeSpace);

            fDataMap.UpdateView();
        }

        private class DirStackItem
        {
            public MapItem Parent;
            public DirectoryInfo DirInfo;

            public DirStackItem(MapItem parent, DirectoryInfo dirInfo)
            {
                Parent = parent;
                DirInfo = dirInfo;
            }
        }

        private void WalkDirectoryTree(DirectoryInfo root, double allocatedSpace, double freeSpace)
        {
            double allocatedFiles = 0.0d;
            UpdateProgress(0, 0);

            Stack<DirStackItem> dirStack = new Stack<DirStackItem>(20);

            dirStack.Push(new DirStackItem(null, root));

            while (dirStack.Count > 0) {
                DirStackItem stackItem = dirStack.Pop();

                DirectoryInfo currentDir = stackItem.DirInfo;
                if ((currentDir.Attributes & FileAttributes.ReparsePoint) == FileAttributes.ReparsePoint) {
                    continue;
                }

                if (currentDir == root && fShowFreeSpace) {
                    CreateItem(stackItem.Parent, "FreeSpace", freeSpace, 0.0f);
                }

                var dirItem = CreateItem(stackItem.Parent, currentDir.FullName, 0.0f, 0.0f);

                try {
                    FileInfo[] files = currentDir.GetFiles("*.*");

                    foreach (FileInfo file in files) {
                        try {
                            if ((file.Attributes & FileAttributes.ReparsePoint) == FileAttributes.ReparsePoint) {
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
                    tsProgress.Value = value;
                    break;
            }
        }

        private void tscmbDisk_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateTreeMap();
        }
    }
}
