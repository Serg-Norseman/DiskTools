namespace DiskTracker
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tslblDisk = new System.Windows.Forms.ToolStripLabel();
            this.tscmbDisk = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tslblPathStub = new System.Windows.Forms.ToolStripLabel();
            this.tslblPath = new System.Windows.Forms.ToolStripLabel();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslblDisk,
            this.tscmbDisk,
            this.toolStripSeparator1,
            this.tslblPathStub,
            this.tslblPath});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(709, 28);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tslblDisk
            // 
            this.tslblDisk.Name = "tslblDisk";
            this.tslblDisk.Size = new System.Drawing.Size(40, 25);
            this.tslblDisk.Text = "Disk:";
            // 
            // tscmbDisk
            // 
            this.tscmbDisk.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tscmbDisk.Name = "tscmbDisk";
            this.tscmbDisk.Size = new System.Drawing.Size(240, 28);
            this.tscmbDisk.SelectedIndexChanged += new System.EventHandler(this.tscmbDisk_SelectedIndexChanged);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 28);
            // 
            // tslblPathStub
            // 
            this.tslblPathStub.Name = "tslblPathStub";
            this.tslblPathStub.Size = new System.Drawing.Size(41, 25);
            this.tslblPathStub.Text = "Path:";
            // 
            // tslblPath
            // 
            this.tslblPath.Name = "tslblPath";
            this.tslblPath.Size = new System.Drawing.Size(15, 25);
            this.tslblPath.Text = "-";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(709, 456);
            this.Controls.Add(this.toolStrip1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel tslblDisk;
        private System.Windows.Forms.ToolStripComboBox tscmbDisk;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel tslblPathStub;
        private System.Windows.Forms.ToolStripLabel tslblPath;
    }
}

