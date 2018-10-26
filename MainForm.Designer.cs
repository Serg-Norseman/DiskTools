namespace FileChecker
{
    partial class MainForm
    {
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar ProgressBar;
        private System.Windows.Forms.ToolStripStatusLabel ProgressPercentage;
        private System.Windows.Forms.ToolStripStatusLabel StatusText;
        private System.Windows.Forms.Button btnProcess;
        private System.ComponentModel.IContainer components = null;

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
            this.btnSelectFile = new System.Windows.Forms.Button();
            this.txtOutputFile = new System.Windows.Forms.TextBox();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.pageCreateDigest = new System.Windows.Forms.TabPage();
            this.lblFiles = new System.Windows.Forms.Label();
            this.lblCalculations = new System.Windows.Forms.Label();
            this.lblFolders = new System.Windows.Forms.Label();
            this.lvFiles = new EXControls.EXListView();
            this.lvFolders = new EXControls.EXListView();
            this.exListView1 = new EXControls.EXListView();
            this.pageTestDigest = new System.Windows.Forms.TabPage();
            this.btnSelectFolder = new System.Windows.Forms.Button();
            this.btnProcess = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.pageCreateDigest.SuspendLayout();
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
            // btnSelectFile
            // 
            this.btnSelectFile.Location = new System.Drawing.Point(933, 10);
            this.btnSelectFile.Margin = new System.Windows.Forms.Padding(4);
            this.btnSelectFile.Name = "btnSelectFile";
            this.btnSelectFile.Size = new System.Drawing.Size(36, 32);
            this.btnSelectFile.TabIndex = 3;
            this.btnSelectFile.Text = "...";
            this.btnSelectFile.UseVisualStyleBackColor = true;
            this.btnSelectFile.Click += new System.EventHandler(this.btnSelectFile_Click);
            // 
            // txtOutputFile
            // 
            this.txtOutputFile.Location = new System.Drawing.Point(16, 14);
            this.txtOutputFile.Name = "txtOutputFile";
            this.txtOutputFile.Size = new System.Drawing.Size(910, 26);
            this.txtOutputFile.TabIndex = 7;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.pageCreateDigest);
            this.tabControl.Controls.Add(this.pageTestDigest);
            this.tabControl.Location = new System.Drawing.Point(16, 49);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1239, 531);
            this.tabControl.TabIndex = 10;
            // 
            // pageCreateDigest
            // 
            this.pageCreateDigest.BackColor = System.Drawing.SystemColors.Control;
            this.pageCreateDigest.Controls.Add(this.lblFiles);
            this.pageCreateDigest.Controls.Add(this.lblCalculations);
            this.pageCreateDigest.Controls.Add(this.lblFolders);
            this.pageCreateDigest.Controls.Add(this.lvFiles);
            this.pageCreateDigest.Controls.Add(this.lvFolders);
            this.pageCreateDigest.Controls.Add(this.exListView1);
            this.pageCreateDigest.Location = new System.Drawing.Point(4, 27);
            this.pageCreateDigest.Name = "pageCreateDigest";
            this.pageCreateDigest.Padding = new System.Windows.Forms.Padding(8);
            this.pageCreateDigest.Size = new System.Drawing.Size(1231, 500);
            this.pageCreateDigest.TabIndex = 0;
            this.pageCreateDigest.Text = "Create checksum digest";
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
            this.lblCalculations.Location = new System.Drawing.Point(608, 8);
            this.lblCalculations.Margin = new System.Windows.Forms.Padding(0);
            this.lblCalculations.Name = "lblCalculations";
            this.lblCalculations.Size = new System.Drawing.Size(100, 23);
            this.lblCalculations.TabIndex = 14;
            this.lblCalculations.Text = "Calculations";
            // 
            // lblFolders
            // 
            this.lblFolders.Location = new System.Drawing.Point(8, 8);
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
            this.lvFolders.Location = new System.Drawing.Point(11, 34);
            this.lvFolders.Name = "lvFolders";
            this.lvFolders.OwnerDraw = true;
            this.lvFolders.Size = new System.Drawing.Size(591, 229);
            this.lvFolders.TabIndex = 13;
            this.lvFolders.UseCompatibleStateImageBehavior = false;
            this.lvFolders.View = System.Windows.Forms.View.Details;
            // 
            // exListView1
            // 
            this.exListView1.ControlPadding = 8;
            this.exListView1.FullRowSelect = true;
            this.exListView1.Location = new System.Drawing.Point(608, 34);
            this.exListView1.Name = "exListView1";
            this.exListView1.OwnerDraw = true;
            this.exListView1.Size = new System.Drawing.Size(606, 229);
            this.exListView1.TabIndex = 13;
            this.exListView1.UseCompatibleStateImageBehavior = false;
            this.exListView1.View = System.Windows.Forms.View.Details;
            // 
            // pageTestDigest
            // 
            this.pageTestDigest.BackColor = System.Drawing.SystemColors.Control;
            this.pageTestDigest.Location = new System.Drawing.Point(4, 27);
            this.pageTestDigest.Name = "pageTestDigest";
            this.pageTestDigest.Padding = new System.Windows.Forms.Padding(3);
            this.pageTestDigest.Size = new System.Drawing.Size(1231, 500);
            this.pageTestDigest.TabIndex = 1;
            this.pageTestDigest.Text = "Test checksum digest";
            // 
            // btnSelectFolder
            // 
            this.btnSelectFolder.Location = new System.Drawing.Point(977, 10);
            this.btnSelectFolder.Margin = new System.Windows.Forms.Padding(4);
            this.btnSelectFolder.Name = "btnSelectFolder";
            this.btnSelectFolder.Size = new System.Drawing.Size(76, 32);
            this.btnSelectFolder.TabIndex = 11;
            this.btnSelectFolder.Text = "Folder...";
            this.btnSelectFolder.UseVisualStyleBackColor = true;
            this.btnSelectFolder.Click += new System.EventHandler(this.btnSelectFolder_Click);
            // 
            // btnProcess
            // 
            this.btnProcess.Location = new System.Drawing.Point(1061, 10);
            this.btnProcess.Margin = new System.Windows.Forms.Padding(4);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(190, 32);
            this.btnProcess.TabIndex = 12;
            this.btnProcess.Text = "Calculate";
            this.btnProcess.UseVisualStyleBackColor = true;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1267, 623);
            this.Controls.Add(this.btnSelectFolder);
            this.Controls.Add(this.btnProcess);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.txtOutputFile);
            this.Controls.Add(this.btnSelectFile);
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
            this.pageCreateDigest.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private EXControls.EXListView exListView1;
        private EXControls.EXListView lvFiles;
        private System.Windows.Forms.Button btnSelectFile;
        private System.Windows.Forms.TextBox txtOutputFile;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage pageCreateDigest;
        private System.Windows.Forms.TabPage pageTestDigest;
        private System.Windows.Forms.Label lblFiles;
        private System.Windows.Forms.Label lblCalculations;
        private System.Windows.Forms.Label lblFolders;
        private EXControls.EXListView lvFolders;
        private System.Windows.Forms.Button btnSelectFolder;
    }
}
