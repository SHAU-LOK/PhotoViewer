namespace PhotoViewer
{
    partial class Toolbox
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
            if (disposing && (components != null))
            {
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Toolbox));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.msOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.msSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.msPrev = new System.Windows.Forms.ToolStripMenuItem();
            this.msNext = new System.Windows.Forms.ToolStripMenuItem();
            this.msSlideShow = new System.Windows.Forms.ToolStripMenuItem();
            this.msClockwise = new System.Windows.Forms.ToolStripMenuItem();
            this.msCountClockWise = new System.Windows.Forms.ToolStripMenuItem();
            this.StopTimer = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.White;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.msOpen,
            this.msSaveAs,
            this.msPrev,
            this.msNext,
            this.msSlideShow,
            this.msClockwise,
            this.msCountClockWise});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(420, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // msOpen
            // 
            this.msOpen.Name = "msOpen";
            this.msOpen.Size = new System.Drawing.Size(68, 24);
            this.msOpen.Text = "打开文件";
            this.msOpen.Click += new System.EventHandler(this.msOpen_Click);
            // 
            // msSaveAs
            // 
            this.msSaveAs.Name = "msSaveAs";
            this.msSaveAs.Size = new System.Drawing.Size(65, 24);
            this.msSaveAs.Text = "另存为...";
            this.msSaveAs.Click += new System.EventHandler(this.msSaveAs_Click);
            // 
            // msPrev
            // 
            this.msPrev.Name = "msPrev";
            this.msPrev.Size = new System.Drawing.Size(56, 24);
            this.msPrev.Text = "上一张";
            this.msPrev.Click += new System.EventHandler(this.msPrev_Click);
            // 
            // msNext
            // 
            this.msNext.Name = "msNext";
            this.msNext.Size = new System.Drawing.Size(56, 24);
            this.msNext.Text = "下一张";
            this.msNext.Click += new System.EventHandler(this.msNext_Click);
            // 
            // msSlideShow
            // 
            this.msSlideShow.Name = "msSlideShow";
            this.msSlideShow.Size = new System.Drawing.Size(56, 24);
            this.msSlideShow.Text = "幻灯片";
            this.msSlideShow.Click += new System.EventHandler(this.msSlideShow_Click);
            // 
            // msClockwise
            // 
            this.msClockwise.Name = "msClockwise";
            this.msClockwise.Size = new System.Drawing.Size(56, 24);
            this.msClockwise.Text = "顺时针";
            this.msClockwise.Click += new System.EventHandler(this.msLegend_Click);
            // 
            // msCountClockWise
            // 
            this.msCountClockWise.Name = "msCountClockWise";
            this.msCountClockWise.Size = new System.Drawing.Size(56, 24);
            this.msCountClockWise.Text = "逆时针";
            this.msCountClockWise.Click += new System.EventHandler(this.msCountClockWise_Click);
            // 
            // StopTimer
            // 
            this.StopTimer.Enabled = true;
            this.StopTimer.Tick += new System.EventHandler(this.stopTimer_Tick);
            // 
            // Toolbox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 28);
            this.ControlBox = false;
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Toolbox";
            this.Opacity = 0.9D;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.TopMost = true;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem msOpen;
        private System.Windows.Forms.ToolStripMenuItem msSaveAs;
        private System.Windows.Forms.ToolStripMenuItem msPrev;
        private System.Windows.Forms.ToolStripMenuItem msNext;
        private System.Windows.Forms.ToolStripMenuItem msSlideShow;
        private System.Windows.Forms.ToolStripMenuItem msClockwise;
       // private System.Windows.Forms.Timer stopTimer;
        private System.Windows.Forms.ToolStripMenuItem msCountClockWise;
        private System.Windows.Forms.Timer StopTimer;
    }
}