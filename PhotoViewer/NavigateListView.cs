using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.InteropServices;

namespace PhotoViewer
{

    public partial class NavigateListView : Form
    {

        public String selectedFileName{get;set;}
        public List<String> allfiles { get; set; }
        public Boolean isModify { get; set; }
        public int index { get; set; }


        #region 窗口初始化
        public NavigateListView()
        {
            InitializeComponent();

        }

        public NavigateListView(String selectedItem, List<String> files)
        {
            this.isModify = false;  //初始化没有点击事件
            this.selectedFileName = selectedItem;
            this.allfiles = files;
            this.Location = new Point(this.Location.X, (this.Height - 2) * (-1));
            InitializeComponent();
            lvBrowse.Visible = true;       
            loadingListView();        
        }
        #endregion

        #region 定位选择文件的位置 (Find Index)
        public int getIndex(String selectFile,List<String> allFile)
        {
            int i = 0;
            foreach (String sf in allFile)
            {
                if (sf == selectFile)
                {  
                    break;
                }
                i++;
            }
            return i;  
        }
        #endregion

        #region 计时器工作
        private void timer1_Tick(object sender, EventArgs e)
        {

            if (this.Bounds.Contains(Cursor.Position))
            {
                //把NavgateListView还原出来
                this.Location = new Point(this.Location.X, 0);
            }
            else
            {
                //隐藏NavigateListView
                this.Location = new Point(this.Location.X, (this.Height - 2) * (-1));
            }
        }
        #endregion

        #region 加载listView (使用线程池加载)
        public void loadingListView()
        {
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;
            ThreadPool.QueueUserWorkItem(new WaitCallback(ThreadProc));

        }

        public void ThreadProc(Object stateInfo)
        {

            createListView();

        }

        public void createListView()
        {
            if (this.lvBrowse == null)
            {
                lvBrowse = new ListView();
            }
            else
            {
                lvBrowse.View = View.LargeIcon;
                lvBrowse.Items.Clear();
                lvBrowse.FullRowSelect = true;
                ImageList imageListLarge = new ImageList();
                imageListLarge.ColorDepth = ColorDepth.Depth32Bit;    //解决失真情况
                if (lvBrowse.LargeImageList != null)
                {
                    lvBrowse.LargeImageList.Dispose();
                }
                imageListLarge.ImageSize = new System.Drawing.Size(200, 150);
                lvBrowse.Cursor = Cursors.WaitCursor;

                int listIndex = 0;
                try
                {
                    foreach (String sf in allfiles)
                    {
                        imageListLarge.Images.Add(System.Drawing.Image.FromFile(sf));
                        this.lvBrowse.LargeImageList = imageListLarge;
                        this.lvBrowse.Items.Add(sf, listIndex);
                        listIndex++;
                    }
                }
                catch
                {

                }
                lvBrowse.Cursor = Cursors.AppStarting;  
            }
        }
        #endregion

        #region listView单击事件
        private void lvBrowse_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvBrowse.Items.Count > 0)
            {
                try
                {
                    String FileName = lvBrowse.SelectedItems[0].Text;
                    this.selectedFileName = FileName;
                    isModify = true;
                }
                catch
                {

                }       
            }
        }
        #endregion


    }
}
