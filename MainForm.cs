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
using System.IO;
using System.Linq;
using System.Windows.Forms;
using BSLib.DataViz.TreeMap;

namespace DiskTracker
{
    public partial class MainForm : Form
    {
        private TreeMapViewer fDataMap;

        public MainForm()
        {
            InitializeComponent();

            fDataMap = new TreeMapViewer();
            fDataMap.Dock = DockStyle.Fill;
            Controls.Add(fDataMap);

            UpdateDisksList();
        }

        private void UpdateDisksList()
        {
            DriveInfo[] allDrives = DriveInfo.GetDrives();

            tscmbDisk.Items.Clear();
            foreach (DriveInfo d in allDrives) {
                if (d.IsReady) {
                    tscmbDisk.Items.Add(new DiskItem(string.Format("{0} [{1}], {2}, {3}", d.Name, d.VolumeLabel, d.DriveType, d.DriveFormat), d));
                }

                /*WriteLine("Drive {0}", d.Name);
                WriteLine("  Drive type: {0}", d.DriveType);
                if (d.IsReady == true) {
                    WriteLine("  Volume label: {0}", d.VolumeLabel);
                    WriteLine("  File system: {0}", d.DriveFormat);
                    WriteLine(
                        "  Available space to current user:{0, 15} bytes",
                        d.AvailableFreeSpace);

                    WriteLine(
                        "  Total available space:          {0, 15} bytes",
                        d.TotalFreeSpace);

                    WriteLine(
                        "  Total size of drive:            {0, 15} bytes ",
                        d.TotalSize);
                }*/
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

            try {
                DiskItem item = tscmbDisk.SelectedItem as DiskItem;
                DriveInfo di = item.Tag as DriveInfo;
                DirectoryInfo rootDir = di.RootDirectory;
                tslblPath.Text = rootDir.FullName;

                //string name = string.Format(hint, groupNum, groupSize, quality.ToString("0.00"));

                //CreateItem(null, name, groupSize, quality);
            } finally {
            }

            fDataMap.UpdateView();
        }

        private static void WalkDirectoryTree(DirectoryInfo root)
        {
            FileInfo[] files = null;
            DirectoryInfo[] subDirs = null;

            // First, process all the files directly under this folder
            try {
                files = root.GetFiles("*.*");
            }
            // This is thrown if even one of the files requires permissions greater
            // than the application provides.
            catch (UnauthorizedAccessException e) {
                // This code just writes out the message and continues to recurse.
                // You may decide to do something different here. For example, you
                // can try to elevate your privileges and access the file again.
                //log.Add(e.Message);
            } catch (DirectoryNotFoundException e) {
                Console.WriteLine(e.Message);
            }

            if (files != null) {
                foreach (FileInfo fi in files) {
                    // In this example, we only access the existing FileInfo object. If we
                    // want to open, delete or modify the file, then
                    // a try-catch block is required here to handle the case
                    // where the file has been deleted since the call to TraverseTree().
                    Console.WriteLine(fi.FullName);
                }

                // Now find all the subdirectories under this directory.
                subDirs = root.GetDirectories();

                foreach (System.IO.DirectoryInfo dirInfo in subDirs) {
                    // Resursive call for each subdirectory.
                    WalkDirectoryTree(dirInfo);
                }
            }            
        }

        private void tscmbDisk_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateTreeMap();
        }
    }
}
