namespace DiskTracker
{
	partial class OptionsDlg
	{
		private System.Windows.Forms.Button btnAccept;
		private System.Windows.Forms.Button btnCancel;
        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.ToolTip toolTip1;

        private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.btnAccept = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tcOptions = new System.Windows.Forms.TabControl();
            this.tabCommon = new System.Windows.Forms.TabPage();
            this.chkEnableColorscheme = new System.Windows.Forms.CheckBox();
            this.chkShowFileSize = new System.Windows.Forms.CheckBox();
            this.chkMaximumDepth = new System.Windows.Forms.CheckBox();
            this.chkShowHiddenFiles = new System.Windows.Forms.CheckBox();
            this.chkShowFreeSpace = new System.Windows.Forms.CheckBox();
            this.tabColorscheme = new System.Windows.Forms.TabPage();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnColor = new System.Windows.Forms.Button();
            this.txtExt = new System.Windows.Forms.TextBox();
            this.lblExt = new System.Windows.Forms.Label();
            this.lstColors = new System.Windows.Forms.ListBox();
            this.chkSkipSize = new System.Windows.Forms.CheckBox();
            this.nudSize = new System.Windows.Forms.NumericUpDown();
            this.tcOptions.SuspendLayout();
            this.tabCommon.SuspendLayout();
            this.tabColorscheme.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSize)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAccept
            // 
            this.btnAccept.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAccept.Location = new System.Drawing.Point(225, 318);
            this.btnAccept.Margin = new System.Windows.Forms.Padding(2);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(114, 30);
            this.btnAccept.TabIndex = 5;
            this.btnAccept.Text = "Accept";
            this.btnAccept.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(344, 318);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(112, 30);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tcOptions
            // 
            this.tcOptions.Controls.Add(this.tabCommon);
            this.tcOptions.Controls.Add(this.tabColorscheme);
            this.tcOptions.Location = new System.Drawing.Point(16, 16);
            this.tcOptions.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tcOptions.Name = "tcOptions";
            this.tcOptions.SelectedIndex = 0;
            this.tcOptions.Size = new System.Drawing.Size(440, 295);
            this.tcOptions.TabIndex = 8;
            // 
            // tabCommon
            // 
            this.tabCommon.BackColor = System.Drawing.SystemColors.Control;
            this.tabCommon.Controls.Add(this.nudSize);
            this.tabCommon.Controls.Add(this.chkSkipSize);
            this.tabCommon.Controls.Add(this.chkEnableColorscheme);
            this.tabCommon.Controls.Add(this.chkShowFileSize);
            this.tabCommon.Controls.Add(this.chkMaximumDepth);
            this.tabCommon.Controls.Add(this.chkShowHiddenFiles);
            this.tabCommon.Controls.Add(this.chkShowFreeSpace);
            this.tabCommon.Location = new System.Drawing.Point(4, 26);
            this.tabCommon.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabCommon.Name = "tabCommon";
            this.tabCommon.Padding = new System.Windows.Forms.Padding(12, 12, 12, 12);
            this.tabCommon.Size = new System.Drawing.Size(432, 265);
            this.tabCommon.TabIndex = 0;
            this.tabCommon.Text = "Common";
            // 
            // chkEnableColorscheme
            // 
            this.chkEnableColorscheme.AutoSize = true;
            this.chkEnableColorscheme.Location = new System.Drawing.Point(15, 120);
            this.chkEnableColorscheme.Margin = new System.Windows.Forms.Padding(2);
            this.chkEnableColorscheme.Name = "chkEnableColorscheme";
            this.chkEnableColorscheme.Size = new System.Drawing.Size(151, 21);
            this.chkEnableColorscheme.TabIndex = 8;
            this.chkEnableColorscheme.Text = "Enable colorscheme";
            this.chkEnableColorscheme.UseVisualStyleBackColor = true;
            // 
            // chkShowFileSize
            // 
            this.chkShowFileSize.AutoSize = true;
            this.chkShowFileSize.Location = new System.Drawing.Point(15, 94);
            this.chkShowFileSize.Margin = new System.Windows.Forms.Padding(2);
            this.chkShowFileSize.Name = "chkShowFileSize";
            this.chkShowFileSize.Size = new System.Drawing.Size(108, 21);
            this.chkShowFileSize.TabIndex = 9;
            this.chkShowFileSize.Text = "Show file size";
            this.chkShowFileSize.UseVisualStyleBackColor = true;
            // 
            // chkMaximumDepth
            // 
            this.chkMaximumDepth.AutoSize = true;
            this.chkMaximumDepth.Enabled = false;
            this.chkMaximumDepth.Location = new System.Drawing.Point(15, 68);
            this.chkMaximumDepth.Margin = new System.Windows.Forms.Padding(2);
            this.chkMaximumDepth.Name = "chkMaximumDepth";
            this.chkMaximumDepth.Size = new System.Drawing.Size(129, 21);
            this.chkMaximumDepth.TabIndex = 10;
            this.chkMaximumDepth.Text = "Maximum depth";
            this.chkMaximumDepth.UseVisualStyleBackColor = true;
            // 
            // chkShowHiddenFiles
            // 
            this.chkShowHiddenFiles.AutoSize = true;
            this.chkShowHiddenFiles.Location = new System.Drawing.Point(15, 41);
            this.chkShowHiddenFiles.Margin = new System.Windows.Forms.Padding(2);
            this.chkShowHiddenFiles.Name = "chkShowHiddenFiles";
            this.chkShowHiddenFiles.Size = new System.Drawing.Size(209, 21);
            this.chkShowHiddenFiles.TabIndex = 11;
            this.chkShowHiddenFiles.Text = "Show hidden and system files";
            this.chkShowHiddenFiles.UseVisualStyleBackColor = true;
            // 
            // chkShowFreeSpace
            // 
            this.chkShowFreeSpace.AutoSize = true;
            this.chkShowFreeSpace.Location = new System.Drawing.Point(15, 15);
            this.chkShowFreeSpace.Margin = new System.Windows.Forms.Padding(2);
            this.chkShowFreeSpace.Name = "chkShowFreeSpace";
            this.chkShowFreeSpace.Size = new System.Drawing.Size(153, 21);
            this.chkShowFreeSpace.TabIndex = 12;
            this.chkShowFreeSpace.Text = "Show free diskspace";
            this.chkShowFreeSpace.UseVisualStyleBackColor = true;
            // 
            // tabColorscheme
            // 
            this.tabColorscheme.BackColor = System.Drawing.SystemColors.Control;
            this.tabColorscheme.Controls.Add(this.btnReset);
            this.tabColorscheme.Controls.Add(this.btnRemove);
            this.tabColorscheme.Controls.Add(this.btnAdd);
            this.tabColorscheme.Controls.Add(this.btnColor);
            this.tabColorscheme.Controls.Add(this.txtExt);
            this.tabColorscheme.Controls.Add(this.lblExt);
            this.tabColorscheme.Controls.Add(this.lstColors);
            this.tabColorscheme.Location = new System.Drawing.Point(4, 26);
            this.tabColorscheme.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabColorscheme.Name = "tabColorscheme";
            this.tabColorscheme.Padding = new System.Windows.Forms.Padding(12, 12, 12, 12);
            this.tabColorscheme.Size = new System.Drawing.Size(432, 265);
            this.tabColorscheme.TabIndex = 1;
            this.tabColorscheme.Text = "Colorscheme";
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(260, 218);
            this.btnReset.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(149, 29);
            this.btnReset.TabIndex = 3;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(260, 181);
            this.btnRemove.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(149, 29);
            this.btnRemove.TabIndex = 3;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(260, 145);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(149, 29);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnColor
            // 
            this.btnColor.Location = new System.Drawing.Point(260, 70);
            this.btnColor.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnColor.Name = "btnColor";
            this.btnColor.Size = new System.Drawing.Size(149, 29);
            this.btnColor.TabIndex = 3;
            this.btnColor.Text = "Color";
            this.btnColor.UseVisualStyleBackColor = true;
            this.btnColor.Click += new System.EventHandler(this.btnColor_Click);
            // 
            // txtExt
            // 
            this.txtExt.Location = new System.Drawing.Point(260, 36);
            this.txtExt.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtExt.Name = "txtExt";
            this.txtExt.Size = new System.Drawing.Size(148, 24);
            this.txtExt.TabIndex = 2;
            // 
            // lblExt
            // 
            this.lblExt.AutoSize = true;
            this.lblExt.Location = new System.Drawing.Point(256, 16);
            this.lblExt.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblExt.Name = "lblExt";
            this.lblExt.Size = new System.Drawing.Size(68, 17);
            this.lblExt.TabIndex = 1;
            this.lblExt.Text = "Extension";
            // 
            // lstColors
            // 
            this.lstColors.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.lstColors.FormattingEnabled = true;
            this.lstColors.Location = new System.Drawing.Point(16, 16);
            this.lstColors.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lstColors.Name = "lstColors";
            this.lstColors.Size = new System.Drawing.Size(232, 225);
            this.lstColors.TabIndex = 0;
            this.lstColors.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.lstColors_DrawItem);
            this.lstColors.SelectedIndexChanged += new System.EventHandler(this.lstColors_SelectedIndexChanged);
            // 
            // chkSkipSize
            // 
            this.chkSkipSize.AutoSize = true;
            this.chkSkipSize.Location = new System.Drawing.Point(15, 145);
            this.chkSkipSize.Margin = new System.Windows.Forms.Padding(2);
            this.chkSkipSize.Name = "chkSkipSize";
            this.chkSkipSize.Size = new System.Drawing.Size(157, 21);
            this.chkSkipSize.TabIndex = 8;
            this.chkSkipSize.Text = "Skip files smaller than";
            this.chkSkipSize.UseVisualStyleBackColor = true;
            // 
            // nudSize
            // 
            this.nudSize.Location = new System.Drawing.Point(199, 144);
            this.nudSize.Maximum = new decimal(new int[] {
            -727379968,
            232,
            0,
            0});
            this.nudSize.Name = "nudSize";
            this.nudSize.Size = new System.Drawing.Size(139, 24);
            this.nudSize.TabIndex = 13;
            this.nudSize.Value = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            // 
            // OptionsDlg
            // 
            this.AcceptButton = this.btnAccept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(472, 362);
            this.Controls.Add(this.tcOptions);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.btnCancel);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OptionsDlg";
            this.Padding = new System.Windows.Forms.Padding(12, 12, 12, 12);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Options";
            this.tcOptions.ResumeLayout(false);
            this.tabCommon.ResumeLayout(false);
            this.tabCommon.PerformLayout();
            this.tabColorscheme.ResumeLayout(false);
            this.tabColorscheme.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSize)).EndInit();
            this.ResumeLayout(false);

		}

        private System.Windows.Forms.TabControl tcOptions;
        private System.Windows.Forms.TabPage tabCommon;
        private System.Windows.Forms.CheckBox chkEnableColorscheme;
        private System.Windows.Forms.CheckBox chkShowFileSize;
        private System.Windows.Forms.CheckBox chkMaximumDepth;
        private System.Windows.Forms.CheckBox chkShowHiddenFiles;
        private System.Windows.Forms.CheckBox chkShowFreeSpace;
        private System.Windows.Forms.TabPage tabColorscheme;
        private System.Windows.Forms.TextBox txtExt;
        private System.Windows.Forms.Label lblExt;
        private System.Windows.Forms.ListBox lstColors;
        private System.Windows.Forms.Button btnColor;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.NumericUpDown nudSize;
        private System.Windows.Forms.CheckBox chkSkipSize;
    }
}
