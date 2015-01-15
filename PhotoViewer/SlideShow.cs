using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace PhotoViewer
{
    public partial class SlideShow : Form
    {
        public String selectedFile;
        public List<String> allFiles;
        public int index;
        public Bitmap myBitmap;

        public SlideShow()
        {
            InitializeComponent();
        }

        public SlideShow(String selectedFile, List<String> allFiles,int index)
        {
            InitializeComponent();
            this.selectedFile = selectedFile;
            this.allFiles = allFiles;
            this.index = index;
            this.myBitmap = new Bitmap(selectedFile);
            this.pictureBox.Image = myBitmap;
            loadImage();
        }


        #region 加载灯幻片  (使用线程加载到picturebox)
        private void loadImage()
        {
            this.timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ThreadStart threadStart = new ThreadStart(createImage);
            Thread thread = new Thread(threadStart);
            thread.Start();
        }
        public void createImage()
        {
            if (this.index >= 0 && this.index <= allFiles.Count - 1)
            {
                
                this.myBitmap = new Bitmap(allFiles[this.index]);
                this.selectedFile = allFiles[this.index];
                this.pictureBox.Image = myBitmap;
                this.index++;
            }
            else 
            {
                this.Dispose();
                timer1.Enabled = false;
                this.index = allFiles.Count - 1;
            }

        }
        #endregion

        private void SlideShow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Dispose();
            }
        }
    }
}
