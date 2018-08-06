namespace DiskTracker
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripComboBox tscmbDisk;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar tsProgress;
        private System.Windows.Forms.ToolStripButton tsbAbout;
        private System.Windows.Forms.ToolStripButton tsbOptions;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tsbRefresh;
        private System.Windows.Forms.ContextMenuStrip mnuTreeMap;
        private System.Windows.Forms.ToolStripMenuItem miDownLevel;
        private System.Windows.Forms.ToolStripMenuItem miUpLevel;
        private System.Windows.Forms.ToolStripMenuItem miDownToFile;
        private System.Windows.Forms.ToolStripMenuItem miUpToRoot;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem miOpenFile;
        private System.Windows.Forms.ToolStripMenuItem miExplore;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem miProperties;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tscmbDisk = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbOptions = new System.Windows.Forms.ToolStripButton();
            this.tsbAbout = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsProgress = new System.Windows.Forms.ToolStripProgressBar();
            this.tslblPath = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslblBasePath = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslblCurFile = new System.Windows.Forms.ToolStripStatusLabel();
            this.mnuTreeMap = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miDownLevel = new System.Windows.Forms.ToolStripMenuItem();
            this.miUpLevel = new System.Windows.Forms.ToolStripMenuItem();
            this.miDownToFile = new System.Windows.Forms.ToolStripMenuItem();
            this.miUpToRoot = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.miOpenFile = new System.Windows.Forms.ToolStripMenuItem();
            this.miExplore = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.miProperties = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.mnuTreeMap.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbRefresh,
            this.toolStripSeparator1,
            this.tscmbDisk,
            this.toolStripSeparator3,
            this.tsbOptions,
            this.tsbAbout,
            this.toolStripSeparator2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(782, 28);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbRefresh
            // 
            this.tsbRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRefresh.Name = "tsbRefresh";
            this.tsbRefresh.Size = new System.Drawing.Size(23, 25);
            this.tsbRefresh.ToolTipText = "Refresh";
            this.tsbRefresh.Click += new System.EventHandler(this.tsbRefresh_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 28);
            // 
            // tscmbDisk
            // 
            this.tscmbDisk.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tscmbDisk.Name = "tscmbDisk";
            this.tscmbDisk.Size = new System.Drawing.Size(240, 28);
            this.tscmbDisk.SelectedIndexChanged += new System.EventHandler(this.tscmbDisk_SelectedIndexChanged);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 28);
            // 
            // tsbOptions
            // 
            this.tsbOptions.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbOptions.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbOptions.Name = "tsbOptions";
            this.tsbOptions.Size = new System.Drawing.Size(23, 25);
            this.tsbOptions.ToolTipText = "Options";
            this.tsbOptions.Click += new System.EventHandler(this.tsbOptions_Click);
            // 
            // tsbAbout
            // 
            this.tsbAbout.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbAbout.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAbout.Name = "tsbAbout";
            this.tsbAbout.Size = new System.Drawing.Size(23, 25);
            this.tsbAbout.ToolTipText = "About";
            this.tsbAbout.Click += new System.EventHandler(this.tsbAbout_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 28);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsProgress,
            this.tslblPath,
            this.tslblBasePath,
            this.tslblCurFile});
            this.statusStrip1.Location = new System.Drawing.Point(0, 662);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(782, 29);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsProgress
            // 
            this.tsProgress.Name = "tsProgress";
            this.tsProgress.Size = new System.Drawing.Size(200, 23);
            // 
            // tslblPath
            // 
            this.tslblPath.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.tslblPath.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner;
            this.tslblPath.Name = "tslblPath";
            this.tslblPath.Size = new System.Drawing.Size(19, 24);
            this.tslblPath.Text = "-";
            // 
            // tslblBasePath
            // 
            this.tslblBasePath.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.tslblBasePath.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner;
            this.tslblBasePath.Name = "tslblBasePath";
            this.tslblBasePath.Size = new System.Drawing.Size(19, 24);
            this.tslblBasePath.Text = "-";
            // 
            // tslblCurFile
            // 
            this.tslblCurFile.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.tslblCurFile.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner;
            this.tslblCurFile.Name = "tslblCurFile";
            this.tslblCurFile.Size = new System.Drawing.Size(19, 24);
            this.tslblCurFile.Text = "-";
            // 
            // mnuTreeMap
            // 
            this.mnuTreeMap.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mnuTreeMap.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miDownLevel,
            this.miUpLevel,
            this.miDownToFile,
            this.miUpToRoot,
            this.toolStripMenuItem1,
            this.miOpenFile,
            this.miExplore,
            this.toolStripMenuItem2,
            this.miProperties});
            this.mnuTreeMap.Name = "contextMenuStrip1";
            this.mnuTreeMap.Size = new System.Drawing.Size(182, 184);
            this.mnuTreeMap.Opening += new System.ComponentModel.CancelEventHandler(this.mnuTreeMap_Opening);
            // 
            // miDownLevel
            // 
            this.miDownLevel.Name = "miDownLevel";
            this.miDownLevel.Size = new System.Drawing.Size(181, 24);
            this.miDownLevel.Text = "Down one level";
            this.miDownLevel.Click += new System.EventHandler(this.miDownLevel_Click);
            // 
            // miUpLevel
            // 
            this.miUpLevel.Name = "miUpLevel";
            this.miUpLevel.Size = new System.Drawing.Size(181, 24);
            this.miUpLevel.Text = "Up one level";
            this.miUpLevel.Click += new System.EventHandler(this.miUpLevel_Click);
            // 
            // miDownToFile
            // 
            this.miDownToFile.Name = "miDownToFile";
            this.miDownToFile.Size = new System.Drawing.Size(181, 24);
            this.miDownToFile.Text = "Down to file";
            this.miDownToFile.Click += new System.EventHandler(this.miDownToFile_Click);
            // 
            // miUpToRoot
            // 
            this.miUpToRoot.Name = "miUpToRoot";
            this.miUpToRoot.Size = new System.Drawing.Size(181, 24);
            this.miUpToRoot.Text = "Up to root";
            this.miUpToRoot.Click += new System.EventHandler(this.miUpToRoot_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(178, 6);
            // 
            // miOpenFile
            // 
            this.miOpenFile.Name = "miOpenFile";
            this.miOpenFile.Size = new System.Drawing.Size(181, 24);
            this.miOpenFile.Text = "Open file";
            this.miOpenFile.Click += new System.EventHandler(this.miOpenFile_Click);
            // 
            // miExplore
            // 
            this.miExplore.Name = "miExplore";
            this.miExplore.Size = new System.Drawing.Size(181, 24);
            this.miExplore.Text = "Explore";
            this.miExplore.Click += new System.EventHandler(this.miExplore_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(178, 6);
            // 
            // miProperties
            // 
            this.miProperties.Name = "miProperties";
            this.miProperties.Size = new System.Drawing.Size(181, 24);
            this.miProperties.Text = "Properties";
            this.miProperties.Click += new System.EventHandler(this.miProperties_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 691);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DiskTracker";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.mnuTreeMap.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.ToolStripStatusLabel tslblPath;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripStatusLabel tslblBasePath;
        private System.Windows.Forms.ToolStripStatusLabel tslblCurFile;
    }
}
