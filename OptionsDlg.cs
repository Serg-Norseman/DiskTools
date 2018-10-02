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
using System.Drawing;
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
            chkSkipSize.Checked = fMainForm.SkipSmaller;
            nudSize.Value = fMainForm.SkipSmallerSize;

            UpdateColorscheme();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            try {
                fMainForm.ShowFreeSpace = chkShowFreeSpace.Checked;
                fMainForm.ShowFileSize = chkShowFileSize.Checked;
                fMainForm.EnableColorscheme = chkEnableColorscheme.Checked;
                fMainForm.ShowHiddenFiles = chkShowHiddenFiles.Checked;
                fMainForm.SkipSmaller = chkSkipSize.Checked;
                fMainForm.SkipSmallerSize = (int)nudSize.Value;

                DialogResult = DialogResult.OK;
            } catch (Exception) {
                DialogResult = DialogResult.None;
            }
        }

        private void UpdateColorscheme()
        {
            lstColors.Items.Clear();
            foreach (var pair in fMainForm.Colorscheme) {
                lstColors.Items.Add(pair.Key);
            }
        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            using (var dlg = new ColorDialog()) {
                dlg.Color = btnColor.BackColor;
                if (dlg.ShowDialog() == DialogResult.OK) {
                    btnColor.BackColor = dlg.Color;

                    if (fMainForm.Colorscheme.ContainsKey(txtExt.Text)) {
                        fMainForm.Colorscheme[txtExt.Text] = btnColor.BackColor;
                        UpdateColorscheme();
                    }
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtExt.Text)) {
                fMainForm.Colorscheme.Add(txtExt.Text, btnColor.BackColor);
                UpdateColorscheme();
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (lstColors.SelectedIndex >= 0 && lstColors.SelectedIndex < lstColors.Items.Count) {
                string ext = lstColors.Items[lstColors.SelectedIndex].ToString();
                fMainForm.Colorscheme.Remove(ext);
                UpdateColorscheme();
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            fMainForm.ResetColorScheme();
            UpdateColorscheme();
        }

        private void lstColors_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstColors.SelectedIndex >= 0 && lstColors.SelectedIndex < lstColors.Items.Count) {
                string ext = lstColors.Items[lstColors.SelectedIndex].ToString();
                var item = fMainForm.Colorscheme[ext];
                txtExt.Text = ext;
                btnColor.BackColor = item;
            }
        }

        private SolidBrush BackBrushSelected = new SolidBrush(Color.FromKnownColor(KnownColor.Highlight));
        private SolidBrush ForeBrushSelected = new SolidBrush(Color.White);
        private SolidBrush ForeBrush = new SolidBrush(Color.Black);

        private void lstColors_DrawItem(object sender, DrawItemEventArgs e)
        {
            string ext = lstColors.Items[e.Index].ToString();
            var item = fMainForm.Colorscheme[ext];

            e.DrawBackground();
            bool selected = ((e.State & DrawItemState.Selected) == DrawItemState.Selected);

            int index = e.Index;
            if (index >= 0 && index < lstColors.Items.Count) {
                string text = lstColors.Items[index].ToString();
                Graphics g = e.Graphics;

                //background:
                SolidBrush backgroundBrush;
                if (selected)
                    backgroundBrush = BackBrushSelected;
                else backgroundBrush = new SolidBrush(item);
                g.FillRectangle(backgroundBrush, e.Bounds);

                //text:
                SolidBrush foregroundBrush = (selected) ? ForeBrushSelected : ForeBrush;
                g.DrawString(text, e.Font, foregroundBrush, lstColors.GetItemRectangle(index).Location);
            }
        }
    }
}
