using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace PhotoViewer
{
    public partial class PictureComing : Form
    {
        public List<String> Files { get; set; }
        public String selectFiles { get; set; }
        public Bitmap bitmap;
        public NavigateListView navigate;
        public Toolbox toolbox;
        public Boolean isModify { get; set; }
        public int index;

        #region 初始化窗口
        public PictureComing()
        {
            InitializeComponent();
        }


        public PictureComing(List<String> Files, String selectFiles)
        {
            this.isModify = false;
            this.Files = Files;
            this.selectFiles = selectFiles;
            InitializeComponent();
            ShowImage(selectFiles);
            openNavigat();
            openToolbox();
        }

        public PictureComing(String selectFiles)
        {
            this.selectFiles = selectFiles;
            InitializeComponent();
            ShowImage(selectFiles);
        }
        #endregion

        #region 打开工具栏
        public void openToolbox()
        {
            toolbox = new Toolbox(selectFiles, Files);
            toolbox.Show(this);
        }

        #endregion

        #region 打开导航工具栏
        public void openNavigat()
        {
            navigate = new NavigateListView(selectFiles, Files);
            navigate.Show(this);
        }

        #endregion

        #region 加载图片

        public void ShowImage(String FilesName)
        {

            try
            {
                bitmap = new Bitmap(FilesName);
                this.pictureBoxShow.Image = bitmap;
                PropertyItem[] pt = bitmap.PropertyItems;  //显示图片的属性（名字）
                lbInformation.Text = "";
                lbInformation.Text += FilesName + " ";

            }
            catch
            {

            }

        }

        #endregion

        #region 键盘点击事件
        private void PictureComing_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Dispose();
            }
            if (e.KeyCode == Keys.Left)
            {
                
                this.index = this.Files.IndexOf(this.selectFiles);
                if (this.index < 0 )
                {
                    //DO NOTHING;
                }
                else
                {
                    if (this.index != 0)
                    {
                        this.index--;
                        this.selectFiles = this.Files[this.index];
                        ShowImage(selectFiles);
                    }
                }

            }
            if (e.KeyCode == Keys.Right)
            {
                this.index = this.Files.IndexOf(this.selectFiles);
                if (this.index > this.Files.Count - 1)
                {
                    //DO NOTHING;
                }
                else
                {
                    if (this.index != this.Files.Count - 1)
                    {
                        this.index++;
                        this.selectFiles = this.Files[this.index];
                        ShowImage(selectFiles);
                    }
                }
            }
        }
        #endregion

        #region 监听navigateListView的动态变化
        private void CatchModify_Tick(object sender, EventArgs e)
        {
            try
            {
                if (navigate.isModify == true)
                {
                    this.selectFiles = navigate.selectedFileName;
                    this.Files = navigate.allfiles;
                    ShowImage(selectFiles);
                    navigate.isModify = false;
                }

            }
            catch
            {

            }
        }
        #endregion

        #region 监听Toolbox的动态变化
        private void CatchModify2_Tick(object sender, EventArgs e)
        {
            try
            {
                if (toolbox.isModify == true)
                {
                    this.selectFiles = toolbox.selectFile;
                    this.Files = toolbox.allFiles;
                    if (toolbox.isNew == true)
                    {
                        this.navigate.Dispose();
                        this.navigate = new NavigateListView(this.selectFiles, this.Files);
                        this.navigate.Show(this);
                    }
                    pictureBoxShow.Image = toolbox.myBitmap;
                    toolbox.isNew = false;
                    toolbox.isModify = false;

                }
            }
            catch
            {

            }

        }
        #endregion    

    }
}
