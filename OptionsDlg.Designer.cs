namespace DiskTracker
{
	partial class OptionsDlg
	{
		private System.Windows.Forms.Button btnAccept;
		private System.Windows.Forms.Button btnCancel;
        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.CheckBox chkShowFreeSpace;
        private System.Windows.Forms.CheckBox chkShowHiddenFiles;
        private System.Windows.Forms.CheckBox chkMaximumDepth;
        private System.Windows.Forms.CheckBox chkShowFileSize;
        private System.Windows.Forms.CheckBox chkEnableColorscheme;

        private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.btnAccept = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.chkShowFreeSpace = new System.Windows.Forms.CheckBox();
            this.chkShowHiddenFiles = new System.Windows.Forms.CheckBox();
            this.chkMaximumDepth = new System.Windows.Forms.CheckBox();
            this.chkShowFileSize = new System.Windows.Forms.CheckBox();
            this.chkEnableColorscheme = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnAccept
            // 
            this.btnAccept.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAccept.Location = new System.Drawing.Point(247, 201);
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
            this.btnCancel.Location = new System.Drawing.Point(371, 201);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(113, 30);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkShowFreeSpace
            // 
            this.chkShowFreeSpace.AutoSize = true;
            this.chkShowFreeSpace.Location = new System.Drawing.Point(12, 12);
            this.chkShowFreeSpace.Name = "chkShowFreeSpace";
            this.chkShowFreeSpace.Size = new System.Drawing.Size(153, 21);
            this.chkShowFreeSpace.TabIndex = 7;
            this.chkShowFreeSpace.Text = "Show free diskspace";
            this.chkShowFreeSpace.UseVisualStyleBackColor = true;
            // 
            // chkShowHiddenFiles
            // 
            this.chkShowHiddenFiles.AutoSize = true;
            this.chkShowHiddenFiles.Location = new System.Drawing.Point(12, 39);
            this.chkShowHiddenFiles.Name = "chkShowHiddenFiles";
            this.chkShowHiddenFiles.Size = new System.Drawing.Size(209, 21);
            this.chkShowHiddenFiles.TabIndex = 7;
            this.chkShowHiddenFiles.Text = "Show hidden and system files";
            this.chkShowHiddenFiles.UseVisualStyleBackColor = true;
            // 
            // chkMaximumDepth
            // 
            this.chkMaximumDepth.AutoSize = true;
            this.chkMaximumDepth.Enabled = false;
            this.chkMaximumDepth.Location = new System.Drawing.Point(12, 66);
            this.chkMaximumDepth.Name = "chkMaximumDepth";
            this.chkMaximumDepth.Size = new System.Drawing.Size(129, 21);
            this.chkMaximumDepth.TabIndex = 7;
            this.chkMaximumDepth.Text = "Maximum depth";
            this.chkMaximumDepth.UseVisualStyleBackColor = true;
            // 
            // chkShowFileSize
            // 
            this.chkShowFileSize.AutoSize = true;
            this.chkShowFileSize.Location = new System.Drawing.Point(12, 93);
            this.chkShowFileSize.Name = "chkShowFileSize";
            this.chkShowFileSize.Size = new System.Drawing.Size(108, 21);
            this.chkShowFileSize.TabIndex = 7;
            this.chkShowFileSize.Text = "Show file size";
            this.chkShowFileSize.UseVisualStyleBackColor = true;
            // 
            // chkEnableColorscheme
            // 
            this.chkEnableColorscheme.AutoSize = true;
            this.chkEnableColorscheme.Location = new System.Drawing.Point(12, 120);
            this.chkEnableColorscheme.Name = "chkEnableColorscheme";
            this.chkEnableColorscheme.Size = new System.Drawing.Size(151, 21);
            this.chkEnableColorscheme.TabIndex = 7;
            this.chkEnableColorscheme.Text = "Enable colorscheme";
            this.chkEnableColorscheme.UseVisualStyleBackColor = true;
            // 
            // OptionsDlg
            // 
            this.AcceptButton = this.btnAccept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(496, 243);
            this.Controls.Add(this.chkEnableColorscheme);
            this.Controls.Add(this.chkShowFileSize);
            this.Controls.Add(this.chkMaximumDepth);
            this.Controls.Add(this.chkShowHiddenFiles);
            this.Controls.Add(this.chkShowFreeSpace);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.btnCancel);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OptionsDlg";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Options";
            this.ResumeLayout(false);
            this.PerformLayout();
		}
    }
}
