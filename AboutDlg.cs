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
using System.Reflection;
using System.Windows.Forms;

namespace DiskTracker
{
    public sealed partial class AboutDlg : Form
    {
        public AboutDlg()
        {
            InitializeComponent();

            btnClose.Image = DTHelper.LoadResourceImage("DiskTracker.Resources.btn_accept.gif");

            Text = "About";
            btnClose.Text = "Close";

            Assembly assembly = typeof(DTHelper).Assembly;
            lblProduct.Text = assembly.GetName().Name;
            lblVersion.Text = @"Version " + assembly.GetName().Version;
            lblCopyright.Text = DTHelper.GetAppCopyright();

            lblProjSite.Text = "https://github.com/Serg-Norseman/DiskTracker";
            lblMail.Text = "https://github.com/Serg-Norseman/DiskTracker/issues";
        }

        private void lblMail_Click(object sender, EventArgs e)
        {
            Label lbl = sender as Label;
            if (lbl != null) {
                DTHelper.LoadExtFile(lbl.Text);
            }
        }
    }
}
