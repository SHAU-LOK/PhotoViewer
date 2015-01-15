using System.Windows.Forms;
using System.Drawing;
namespace PhotoViewer
{
    partial class NavigateListView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NavigateListView));
            this.lvBrowse = new System.Windows.Forms.ListView();
            this.stopTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // lvBrowse
            // 
            this.lvBrowse.BackColor = System.Drawing.Color.White;
            this.lvBrowse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvBrowse.Location = new System.Drawing.Point(0, 0);
            this.lvBrowse.Name = "lvBrowse";
            this.lvBrowse.Size = new System.Drawing.Size(1366, 191);
            this.lvBrowse.TabIndex = 0;
            this.lvBrowse.UseCompatibleStateImageBehavior = false;
            this.lvBrowse.SelectedIndexChanged += new System.EventHandler(this.lvBrowse_SelectedIndexChanged);
            // 
            // stopTimer
            // 
            this.stopTimer.Enabled = true;
            this.stopTimer.Interval = 200;
            this.stopTimer.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // NavigateListView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1366, 191);
            this.ControlBox = false;
            this.Controls.Add(this.lvBrowse);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "NavigateListView";
            this.Opacity = 0.9D;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.TopMost = true;
            this.ResumeLayout(false);

        }

        #endregion

        private ListView lvBrowse;
        private Timer stopTimer;
    }
}