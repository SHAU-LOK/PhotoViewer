using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace PhotoViewer
{
    public partial class Toolbox : Form
    {
        public List<String> allFiles { get; set; }
        public String selectFile { get; set; }
        public int index { get; set; }
        public Boolean isModify { get; set; }
        public Bitmap myBitmap { get; set; }
        public OpenFileDialog openFile;
        public SaveFileDialog saveFile;
        public FileInfo fileinfo { get; set; }
        public Boolean isNew { get; set; }

        #region 初始化窗口
        public Toolbox()
        {
            InitializeComponent();
        }

        public Toolbox(String FileName, List<String> allFiles)
        {
            this.selectFile = FileName;
            this.allFiles = allFiles;
            this.Location = new Point(0, Screen.PrimaryScreen.Bounds.Height - 40);
            InitializeComponent();
            this.myBitmap = new Bitmap(selectFile);
        }
        #endregion

        #region 计时器工作
        private void stopTimer_Tick(object sender, EventArgs e)
        {
            if (this.Bounds.Contains(Cursor.Position))
            {
                //把ToolBox还原出来
                this.Location = new Point(0, Screen.PrimaryScreen.Bounds.Height - 40);
            }
            else
            {
                //隐藏ToolBox
                this.Location = new Point(0, Screen.PrimaryScreen.Bounds.Height - 1);
            }
        }
        #endregion

        #region 按钮点击事件

        private void msOpen_Click(object sender, EventArgs e)
        {
            openFile = new OpenFileDialog();
            openFile.Filter = "Image File(*.jpg;*.png;*.bmp;*gif)|*.jpg;*.png;*.bmp;*.gif;";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                this.myBitmap = new Bitmap(openFile.FileName);
                this.selectFile = openFile.FileName;
                PhotoFilter(GetAllFiles(this.selectFile));
                this.allFiles.Sort();
                isModify = true;
                isNew = true;
            }
            else
            {

            }
        }

        private void msSaveAs_Click(object sender, EventArgs e)
        {
            saveFile = new SaveFileDialog();
            saveFile.Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif|PnG Image|*.png";
            if (this.myBitmap == null)
            {
                MessageBox.Show("没有预览图片");
            }
            else if (saveFile.ShowDialog() == DialogResult.OK)
            {
                if (this.myBitmap != null)
                {
                    myBitmap.Save(saveFile.FileName);
                    MessageBox.Show("保存成功");
                }
                else
                {
                    MessageBox.Show("没有预览图片");
                }
            }
            else
            {
                //DO NOTHING （当用户点击了取消）
            }
        }

        private void msPrev_Click(object sender, EventArgs e)
        {
          
            this.index = allFiles.IndexOf(this.selectFile);
            if (this.index == 0)
            {
                MessageBox.Show("第一张");

            }
            else if (this.index > 0)
            {
                isModify = true;
                this.index--;
                this.selectFile = allFiles[this.index];
                this.myBitmap = new Bitmap(selectFile);
            }
        }

        private void msNext_Click(object sender, EventArgs e)
        {
            this.index = allFiles.IndexOf(this.selectFile);
            if (this.index == allFiles.Count-1)
            {
                MessageBox.Show("最后一张");
            }
            else if (this.index >= 0 && this.index <= allFiles.Count - 1)
            {
                isModify = true;
                this.index++;
                this.selectFile = allFiles[this.index];
                this.myBitmap = new Bitmap(selectFile);
            }
        }

        private void msSlideShow_Click(object sender, EventArgs e)
        {
            this.index = allFiles.IndexOf(this.selectFile);
            SlideShow slideShow = new SlideShow(this.selectFile, this.allFiles, this.index + 1);
            slideShow.Show(this);
        }

        private void msLegend_Click(object sender, EventArgs e)  //顺时针
        {
            if (this.myBitmap != null)
            {
                myBitmap.RotateFlip(RotateFlipType.Rotate270FlipXY);
                isModify = true;
            }
        }

        private void msCountClockWise_Click(object sender, EventArgs e)
        {
            if (this.myBitmap != null)
            {
                myBitmap.RotateFlip(RotateFlipType.Rotate90FlipXY);
                isModify = true;
            }
        }
        #endregion

        #region 过滤非图片
        public List<String> GetAllFiles(String FileName)
        {
            List<String> list = new List<string>();
            String FolderName = FileName.Substring(0, FileName.LastIndexOf("\\"));
            String[] allF = Directory.GetFiles(FolderName);
            foreach (String sf in allF)
            {
                list.Add(sf);
            }
            return list;
        }
        public void PhotoFilter(List<String> File)
        {
            if (File != null)
            {
                foreach (String sf in File)
                {
                    //获取类型
                    String Filetype = Path.GetExtension(sf);
                    switch (Filetype)
                    {
                        case ".jpg":
                            {
                                this.allFiles.Add(sf);
                                break;
                            }
                        case ".png":
                            {
                                this.allFiles.Add(sf);
                                break;
                            }

                        case ".bmp":
                            {
                                this.allFiles.Add(sf);
                                break;
                            };

                        case ".gif":
                            {
                                this.allFiles.Add(sf);
                                break;
                            }
                        default:

                            break;
                    }

                }
            }
        }
        #endregion



    }


}
