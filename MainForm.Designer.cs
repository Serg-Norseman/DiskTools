namespace FileChecker
{
    partial class MainForm
    {
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar ProgressBar;
        private System.Windows.Forms.ToolStripStatusLabel ProgressPercentage;
        private System.Windows.Forms.ToolStripStatusLabel StatusText;
        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.OpenFileDialog OpenFileDialog;
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox textBox1;

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
            this.btnProcess = new System.Windows.Forms.Button();
            this.OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.exListView1 = new EXControls.EXListView();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ProgressBar,
            this.ProgressPercentage,
            this.StatusText});
            this.statusStrip1.Location = new System.Drawing.Point(0, 510);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip1.Size = new System.Drawing.Size(982, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // ProgressBar
            // 
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(133, 20);
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
            this.StatusText.Size = new System.Drawing.Size(962, 17);
            this.StatusText.Spring = true;
            this.StatusText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnProcess
            // 
            this.btnProcess.Location = new System.Drawing.Point(933, 9);
            this.btnProcess.Margin = new System.Windows.Forms.Padding(4);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(36, 28);
            this.btnProcess.TabIndex = 3;
            this.btnProcess.Text = "...";
            this.btnProcess.UseVisualStyleBackColor = true;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // OpenFileDialog
            // 
            this.OpenFileDialog.Filter = "All files|*.*";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(16, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(910, 22);
            this.textBox1.TabIndex = 7;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(16, 276);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox2.Size = new System.Drawing.Size(954, 212);
            this.textBox2.TabIndex = 8;
            // 
            // exListView1
            // 
            this.exListView1.ControlPadding = 4;
            this.exListView1.FullRowSelect = true;
            this.exListView1.Location = new System.Drawing.Point(16, 44);
            this.exListView1.Name = "exListView1";
            this.exListView1.OwnerDraw = true;
            this.exListView1.Size = new System.Drawing.Size(953, 226);
            this.exListView1.TabIndex = 9;
            this.exListView1.UseCompatibleStateImageBehavior = false;
            this.exListView1.View = System.Windows.Forms.View.Details;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 532);
            this.Controls.Add(this.exListView1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnProcess);
            this.Controls.Add(this.statusStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "Form1";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.TextBox textBox2;
        private EXControls.EXListView exListView1;
    }
}
