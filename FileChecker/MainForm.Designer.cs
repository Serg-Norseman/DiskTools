namespace FileChecker
{
    partial class MainForm
    {
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar ProgressBar;
        private System.Windows.Forms.ToolStripStatusLabel ProgressPercentage;
        private System.Windows.Forms.ToolStripStatusLabel StatusText;
        private System.Windows.Forms.Button btnCreateDigest;
        private System.ComponentModel.IContainer components = null;
        private EXControls.EXListView exListView1;
        private EXControls.EXListView lvFiles;
        private System.Windows.Forms.TextBox txtDigestFile;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage pageDigest;
        private System.Windows.Forms.Label lblFiles;
        private System.Windows.Forms.Label lblCalculations;
        private System.Windows.Forms.Label lblFolders;
        private EXControls.EXListView lvFolders;
        private System.Windows.Forms.Button btnSelectFolder;
        private System.Windows.Forms.Button btnTestDigest;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.CheckBox chkOnlyChanges;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.ProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.ProgressPercentage = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatusText = new System.Windows.Forms.ToolStripStatusLabel();
            this.txtDigestFile = new System.Windows.Forms.TextBox();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.pageDigest = new System.Windows.Forms.TabPage();
            this.chkOnlyChanges = new System.Windows.Forms.CheckBox();
            this.btnSelectFolder = new System.Windows.Forms.Button();
            this.lblFiles = new System.Windows.Forms.Label();
            this.lblCalculations = new System.Windows.Forms.Label();
            this.lblFolders = new System.Windows.Forms.Label();
            this.lvFiles = new EXControls.EXListView();
            this.lvFolders = new EXControls.EXListView();
            this.exListView1 = new EXControls.EXListView();
            this.btnCreateDigest = new System.Windows.Forms.Button();
            this.btnTestDigest = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.pageDigest.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ProgressBar,
            this.ProgressPercentage,
            this.StatusText});
            this.statusStrip1.Location = new System.Drawing.Point(0, 601);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1267, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // ProgressBar
            // 
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(133, 22);
            this.ProgressBar.Visible = false;
            // 
            // ProgressPercentage
            // 
            this.ProgressPercentage.Name = "ProgressPercentage";
            this.ProgressPercentage.Size = new System.Drawing.Size(0, 17);
            this.ProgressPercentage.Visible = false;
            // 
            // StatusText
            // 
            this.StatusText.Name = "StatusText";
            this.StatusText.Size = new System.Drawing.Size(1247, 17);
            this.StatusText.Spring = true;
            this.StatusText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDigestFile
            // 
            this.txtDigestFile.Location = new System.Drawing.Point(16, 14);
            this.txtDigestFile.Name = "txtDigestFile";
            this.txtDigestFile.ReadOnly = true;
            this.txtDigestFile.Size = new System.Drawing.Size(951, 26);
            this.txtDigestFile.TabIndex = 7;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.pageDigest);
            this.tabControl.Location = new System.Drawing.Point(16, 49);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1239, 531);
            this.tabControl.TabIndex = 10;
            // 
            // pageDigest
            // 
            this.pageDigest.BackColor = System.Drawing.SystemColors.Control;
            this.pageDigest.Controls.Add(this.chkOnlyChanges);
            this.pageDigest.Controls.Add(this.btnSelectFolder);
            this.pageDigest.Controls.Add(this.lblFiles);
            this.pageDigest.Controls.Add(this.lblCalculations);
            this.pageDigest.Controls.Add(this.lblFolders);
            this.pageDigest.Controls.Add(this.lvFiles);
            this.pageDigest.Controls.Add(this.lvFolders);
            this.pageDigest.Controls.Add(this.exListView1);
            this.pageDigest.Location = new System.Drawing.Point(4, 27);
            this.pageDigest.Name = "pageDigest";
            this.pageDigest.Padding = new System.Windows.Forms.Padding(8);
            this.pageDigest.Size = new System.Drawing.Size(1231, 500);
            this.pageDigest.TabIndex = 0;
            this.pageDigest.Text = "Checksum digest";
            // 
            // chkOnlyChanges
            // 
            this.chkOnlyChanges.Location = new System.Drawing.Point(925, 264);
            this.chkOnlyChanges.Name = "chkOnlyChanges";
            this.chkOnlyChanges.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkOnlyChanges.Size = new System.Drawing.Size(289, 24);
            this.chkOnlyChanges.TabIndex = 16;
            this.chkOnlyChanges.Text = "Show only changes";
            this.chkOnlyChanges.UseVisualStyleBackColor = true;
            // 
            // btnSelectFolder
            // 
            this.btnSelectFolder.Location = new System.Drawing.Point(468, 12);
            this.btnSelectFolder.Margin = new System.Windows.Forms.Padding(4);
            this.btnSelectFolder.Name = "btnSelectFolder";
            this.btnSelectFolder.Size = new System.Drawing.Size(134, 32);
            this.btnSelectFolder.TabIndex = 15;
            this.btnSelectFolder.Text = "Add folder...";
            this.btnSelectFolder.UseVisualStyleBackColor = true;
            this.btnSelectFolder.Click += new System.EventHandler(this.btnSelectFolder_Click);
            // 
            // lblFiles
            // 
            this.lblFiles.Location = new System.Drawing.Point(15, 266);
            this.lblFiles.Margin = new System.Windows.Forms.Padding(0);
            this.lblFiles.Name = "lblFiles";
            this.lblFiles.Size = new System.Drawing.Size(100, 23);
            this.lblFiles.TabIndex = 14;
            this.lblFiles.Text = "Files";
            // 
            // lblCalculations
            // 
            this.lblCalculations.AutoSize = true;
            this.lblCalculations.Location = new System.Drawing.Point(608, 19);
            this.lblCalculations.Margin = new System.Windows.Forms.Padding(0);
            this.lblCalculations.Name = "lblCalculations";
            this.lblCalculations.Size = new System.Drawing.Size(96, 18);
            this.lblCalculations.TabIndex = 14;
            this.lblCalculations.Text = "Calculations";
            // 
            // lblFolders
            // 
            this.lblFolders.Location = new System.Drawing.Point(11, 19);
            this.lblFolders.Margin = new System.Windows.Forms.Padding(0);
            this.lblFolders.Name = "lblFolders";
            this.lblFolders.Size = new System.Drawing.Size(100, 23);
            this.lblFolders.TabIndex = 14;
            this.lblFolders.Text = "Folders";
            // 
            // lvFiles
            // 
            this.lvFiles.ControlPadding = 4;
            this.lvFiles.FullRowSelect = true;
            this.lvFiles.Location = new System.Drawing.Point(11, 292);
            this.lvFiles.Name = "lvFiles";
            this.lvFiles.OwnerDraw = true;
            this.lvFiles.Size = new System.Drawing.Size(1203, 197);
            this.lvFiles.TabIndex = 12;
            this.lvFiles.UseCompatibleStateImageBehavior = false;
            this.lvFiles.View = System.Windows.Forms.View.Details;
            // 
            // lvFolders
            // 
            this.lvFolders.ControlPadding = 8;
            this.lvFolders.FullRowSelect = true;
            this.lvFolders.Location = new System.Drawing.Point(11, 46);
            this.lvFolders.Name = "lvFolders";
            this.lvFolders.OwnerDraw = true;
            this.lvFolders.Size = new System.Drawing.Size(591, 217);
            this.lvFolders.TabIndex = 13;
            this.lvFolders.UseCompatibleStateImageBehavior = false;
            this.lvFolders.View = System.Windows.Forms.View.Details;
            // 
            // exListView1
            // 
            this.exListView1.ControlPadding = 8;
            this.exListView1.FullRowSelect = true;
            this.exListView1.Location = new System.Drawing.Point(608, 46);
            this.exListView1.Name = "exListView1";
            this.exListView1.OwnerDraw = true;
            this.exListView1.Size = new System.Drawing.Size(606, 217);
            this.exListView1.TabIndex = 13;
            this.exListView1.UseCompatibleStateImageBehavior = false;
            this.exListView1.View = System.Windows.Forms.View.Details;
            // 
            // btnCreateDigest
            // 
            this.btnCreateDigest.Location = new System.Drawing.Point(974, 10);
            this.btnCreateDigest.Margin = new System.Windows.Forms.Padding(4);
            this.btnCreateDigest.Name = "btnCreateDigest";
            this.btnCreateDigest.Size = new System.Drawing.Size(87, 32);
            this.btnCreateDigest.TabIndex = 12;
            this.btnCreateDigest.Text = "Create";
            this.btnCreateDigest.UseVisualStyleBackColor = true;
            this.btnCreateDigest.Click += new System.EventHandler(this.btnCreateDigest_Click);
            // 
            // btnTestDigest
            // 
            this.btnTestDigest.Location = new System.Drawing.Point(1069, 10);
            this.btnTestDigest.Margin = new System.Windows.Forms.Padding(4);
            this.btnTestDigest.Name = "btnTestDigest";
            this.btnTestDigest.Size = new System.Drawing.Size(87, 32);
            this.btnTestDigest.TabIndex = 12;
            this.btnTestDigest.Text = "Test";
            this.btnTestDigest.UseVisualStyleBackColor = true;
            this.btnTestDigest.Click += new System.EventHandler(this.btnTestDigest_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Enabled = false;
            this.btnUpdate.Location = new System.Drawing.Point(1164, 10);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(4);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(87, 32);
            this.btnUpdate.TabIndex = 12;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1267, 623);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnTestDigest);
            this.Controls.Add(this.btnCreateDigest);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.txtDigestFile);
            this.Controls.Add(this.statusStrip1);
            this.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.pageDigest.ResumeLayout(false);
            this.pageDigest.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
