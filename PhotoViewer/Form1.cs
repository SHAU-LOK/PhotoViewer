using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace PhotoViewer
{
    public partial class Form1 : Form
    {
        private OpenFileDialog openFile;
        private List<String> listFileFilter;   //过滤得到的图片文件
        private String[] allFiles;     //获得所有文件
        private Bitmap myBitmap;
        private String selectedFile;

        #region 主窗口初始化
        public Form1()
        {
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;
            listFileFilter = new List<string>();
            InitializeComponent();
            SystemMessage();  //初始化加载TreeView
        }
        #endregion 

        #region 初始化加载TreeView的内容
        public void SystemMessage()
        {

            DriveInfo[] dr = DriveInfo.GetDrives();

            string driveName = "";
            foreach (DriveInfo d in dr)
            {
                switch (d.DriveType)
                {
                    case DriveType.Fixed:
                        driveName = "本地磁盘(" + d.Name.Substring(0, 2) + ")";
                        break;
                    case DriveType.Removable:
                        driveName = "可移动磁盘(" + d.Name.Substring(0, 2) + ")";
                        break;
                    case DriveType.CDRom:
                        driveName = "DVD驱动器(" + d.Name.Substring(0, 2) + ")";
                        break;
                    default:
                        driveName = "未知(" + d.Name + ")";
                        break;
                }

                this.TreeViewExplore.Nodes.Add(d.Name, driveName);
            }
      
        }
        #endregion

        #region 关listView 的单击事件
        private void lvDisplay_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvDisplay.SelectedItems.Count > 0)
            {
                String FirstName = lvDisplay.SelectedItems[0].Text;
                try
                {
                    Bitmap mybitmap = new Bitmap(FirstName);
                    preview.Image = mybitmap;
                    preview.SizeMode = PictureBoxSizeMode.Zoom;
                }
                catch
                {

                }

            }
        }
        #endregion

        #region listView 的双击事件
        private void lvDisplay_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lvDisplay.Items.Count > 0)
            {
                if (lvDisplay.SelectedItems.Count == 1)
                {
                    String selItem = lvDisplay.SelectedItems[0].Text;
                    PictureComing picComing = new PictureComing( listFileFilter , selItem);
                    picComing.Show(this);
                }
            }
        }
        #endregion

        #region menu
        private void msOpen_Click(object sender, EventArgs e)
        {
            openFile = new OpenFileDialog();
            openFile.Filter = "Image File(*.jpg;*.png;*.bmp;*gif)|*.jpg;*.png;*.bmp;*.gif;";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                this.myBitmap = new Bitmap(openFile.FileName);
                this.selectedFile = openFile.FileName;
                PictureComing picComing = new PictureComing(selectedFile);
                picComing.Show(this);

            }
            else
            {

            }
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void 全屏显示ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lvDisplay.Items.Count > 0)
            {
                if (lvDisplay.SelectedItems.Count == 1)
                {
                    //测试ListView Item的双击内容
                    //     MessageBox.Show(lvDisplay.SelectedItems[0].Text);

                    String selItem = lvDisplay.SelectedItems[0].Text;

                    PictureComing picComing = new PictureComing(listFileFilter, selItem);
                    picComing.Show(this);



                }
            }
        }

        private void 实际大小ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.preview.SizeMode = PictureBoxSizeMode.AutoSize;
        }

        private void 适合屏幕ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.preview.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void 适应ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.preview.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Copyright @ 2014/12/10 SHAU-LOK. All rights reserved.");
        }

        #endregion

        #region treeView的单双击监听
        private void TreeViewExplore_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            
            if (e.Node.Nodes.Count > 0)
            {

                if (e.Node.IsExpanded)
                { e.Node.Collapse(); }

                else
                {
                    e.Node.Expand();
                }
            }

            else
            {

                if (Directory.Exists(e.Node.Name))
                {
                    try
                    {
                        String[] allDirectory = Directory.GetDirectories(e.Node.Name);

                        foreach (String s in allDirectory)
                        {
                            e.Node.Nodes.Add(s, s.Remove(0, s.LastIndexOf("\\") + 1));
                        }

                    }
                    catch
                    {

                    }

                }
                e.Node.Expand();
            }
             
        }

        private void TreeViewExplore_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
               
                this.allFiles = Directory.GetFiles(e.Node.Name);
                PhotoFilter();       //图片过滤
                this.listFileFilter.Sort();
                loadingListView();   //线程加载缩略图
                if (lvDisplay.Items.Count > 0)
                {
                    try
                    {
                        String FirstName = lvDisplay.Items[0].Text;
                        Bitmap mybitmap = new Bitmap(FirstName);
                        preview.Image = mybitmap;
                        preview.SizeMode = PictureBoxSizeMode.Zoom;
                    }
                    catch
                    {

                    }
                }
                else
                {
                    preview.Image = null;
                }
            }
            catch
            {

            }
        }
        #endregion

        #region 线程加载
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
            if (this.lvDisplay == null)
            {
                this.lvDisplay = new ListView();
            }
            else
            {

                lvDisplay.View = View.LargeIcon;
                lvDisplay.Items.Clear();
                lvDisplay.FullRowSelect = true;
                ImageList imageListLarge = new ImageList();
                imageListLarge.ColorDepth = ColorDepth.Depth32Bit;    //解决失真情况

                if (lvDisplay.LargeImageList != null)
                {
                    lvDisplay.LargeImageList.Dispose();
                }

                imageListLarge.ImageSize = new System.Drawing.Size(200, 150);
                lvDisplay.Cursor = Cursors.WaitCursor;
                int listViewIndex=0;
                foreach (String fileName in listFileFilter)
                {
                    try
                    {
                        imageListLarge.Images.Add(System.Drawing.Image.FromFile(fileName));
                        this.lvDisplay.LargeImageList = imageListLarge;
                        this.lvDisplay.Items.Add(fileName, listViewIndex);
                        label3.Text = (listViewIndex+1).ToString();
                        listViewIndex++;
                      
                    }
                    catch
                    {

                    }

                }
                lvDisplay.Cursor = Cursors.AppStarting;
            }
        }
        #endregion

        #region 图片png,jpg,bmp格式的过滤
        public void PhotoFilter()
        {
            listFileFilter = new List<string>();
          
            if (allFiles != null)
            {
                foreach (String sf in allFiles)
                {
                    //获取类型
                    String Filetype = Path.GetExtension(sf);
                    switch (Filetype)
                    {
                        case ".jpg":
                            {
                                listFileFilter.Add(sf);
                                break;
                            }
                        case ".png":
                            {
                                listFileFilter.Add(sf);
                                break;
                            }

                        case ".bmp":
                            {
                                listFileFilter.Add(sf);
                                break;
                            };
                        case ".gif":
                            {
                                listFileFilter.Add(sf);
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
