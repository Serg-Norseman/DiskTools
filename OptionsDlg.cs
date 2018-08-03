/*
 *  "GEDKeeper", the personal genealogical database editor.
 *  Copyright (C) 2009-2018 by Sergey V. Zhdanovskih.
 *
 *  This file is part of "GEDKeeper".
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
using System.Windows.Forms;

namespace DiskTracker
{
    public sealed partial class OptionsDlg : Form
    {
        private readonly MainForm fMainForm;

        public OptionsDlg()
        {
            InitializeComponent();

            btnAccept.Image = DTHelper.LoadResourceImage("DiskTracker.Resources.btn_accept.gif");
            btnCancel.Image = DTHelper.LoadResourceImage("DiskTracker.Resources.btn_cancel.gif");
        }

        public OptionsDlg(MainForm mainForm) : this()
        {
            fMainForm = mainForm;

            UpdateView();
        }

        public void UpdateView()
        {
            chkShowFreeSpace.Checked = fMainForm.ShowFreeSpace;
            chkShowFileSize.Checked = fMainForm.ShowFileSize;
            chkEnableColorscheme.Checked = fMainForm.EnableColorscheme;
            chkShowHiddenFiles.Checked = fMainForm.ShowHiddenFiles;
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            try {
                fMainForm.ShowFreeSpace = chkShowFreeSpace.Checked;
                fMainForm.ShowFileSize = chkShowFileSize.Checked;
                fMainForm.EnableColorscheme = chkEnableColorscheme.Checked;
                fMainForm.ShowHiddenFiles = chkShowHiddenFiles.Checked;

                DialogResult = DialogResult.OK;
            } catch (Exception) {
                DialogResult = DialogResult.None;
            }
        }
    }
}
