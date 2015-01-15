namespace PhotoViewer
{
    partial class PictureComing
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PictureComing));
            this.pictureBoxShow = new System.Windows.Forms.PictureBox();
            this.lbInformation = new System.Windows.Forms.Label();
            this.CatchModify = new System.Windows.Forms.Timer(this.components);
            this.CatchModify2 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxShow)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxShow
            // 
            this.pictureBoxShow.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pictureBoxShow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxShow.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxShow.Name = "pictureBoxShow";
            this.pictureBoxShow.Size = new System.Drawing.Size(284, 262);
            this.pictureBoxShow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxShow.TabIndex = 0;
            this.pictureBoxShow.TabStop = false;
            // 
            // lbInformation
            // 
            this.lbInformation.AutoSize = true;
            this.lbInformation.BackColor = System.Drawing.Color.Black;
            this.lbInformation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbInformation.Font = new System.Drawing.Font("SimSun", 13F);
            this.lbInformation.Location = new System.Drawing.Point(8, 8);
            this.lbInformation.Name = "lbInformation";
            this.lbInformation.Size = new System.Drawing.Size(107, 18);
            this.lbInformation.TabIndex = 1;
            this.lbInformation.Text = "Imformation";
            // 
            // CatchModify
            // 
            this.CatchModify.Enabled = true;
            this.CatchModify.Interval = 50;
            this.CatchModify.Tick += new System.EventHandler(this.CatchModify_Tick);
            // 
            // CatchModify2
            // 
            this.CatchModify2.Enabled = true;
            this.CatchModify2.Tick += new System.EventHandler(this.CatchModify2_Tick);
            // 
            // PictureComing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.lbInformation);
            this.Controls.Add(this.pictureBoxShow);
            this.ForeColor = System.Drawing.Color.LimeGreen;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "PictureComing";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PictureComing_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxShow)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxShow;
        private System.Windows.Forms.Label lbInformation;
        private System.Windows.Forms.Timer CatchModify;
        private System.Windows.Forms.Timer CatchModify2;

    }
}