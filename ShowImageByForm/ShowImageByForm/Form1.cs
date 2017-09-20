using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;

namespace ShowImageByForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            SetDragImageToFrm(this, e);//在窗体中显示拖放到窗体中的图片
            treeView1.Nodes.Clear();//清空treeview控件
            SetDragImageToFrm(treeView1, e);//在窗体上显示拖放到窗体的文件夹
        }
        /// <summary>
        /// 在背景窗体中显示拖放过去的图片
        /// </summary>
        /// <param name="frm">窗体</param>
        /// <param name="e">DragDrop、DragEnter、DragOver事件提供数据</param>
        public void SetDragImageToFrm(Form frm, DragEventArgs e)
        {
                e.Effect = DragDropEffects.Copy;//设置拖放操作中的目标放置类型为复制
                string[] str_Drap = (string[])e.Data.GetData(DataFormats.FileDrop, true);//检索数据格式相关联的数据
                string tempstr;
                Bitmap bkImage;
                tempstr = str_Drap[0];//获取拖放文件的目录
                try
                {
                    bkImage = new Bitmap(tempstr);//存储拖放的图片
                    //根据图片设置窗体的大小
                    frm.Size = new System.Drawing.Size(bkImage.Width + 6, bkImage.Height + 33);
                    frm.BackgroundImage = bkImage;//在窗体中显示背景图片
                }
                catch { }
            
        }
        Thread thdAddFile;
        string tempstr;
        /// <summary>
        /// 向TreeView控件中添加被拖放的文件夹目录
        /// </summary>
        /// <param name="treeview">TreeView控件</param>
        /// <param name="e">DragDrop、DragEnter、DragOver事件提供数据</param>
        public void SetDragImageToFrm(TreeView treeview, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;//设置拖放操作中的目标放置类型为复制
            string[] str_Drap = (string[])e.Data.GetData(DataFormats.FileDrop, true);//检索数据格式相关联的数据
            tempstr=str_Drap[0];//获取拖放文件夹的目录
            thdAddFile = new Thread(new ThreadStart(SetAddFile));//创建一个线程
            thdAddFile.Start();//执行当前线程
        }
        public delegate void AddFile();//定义托管线程
        /// <summary>
        /// 设置托管线程
        /// </summary>
        public void SetAddFile()
        {
            this.Invoke(new AddFile(RunAddFile));//对指定的线程进行托管
        }
        /// <summary>
        /// 设置线程
        /// </summary>
        public void RunAddFile()
        {
            TreeNode TNode = new TreeNode();//实例化一个线程
            Files_Copy(treeView1, tempstr, TNode, 0);
            Thread.Sleep(0);//休眠主线程
            thdAddFile.Abort();//执行线程
        }
        /// <summary>
        /// 显示文件夹下所有子文件夹和文件的名称
        /// </summary>
        /// <param name="tv">TreeView控件</param>
        /// <param name="Sdir">文件夹的目录</param>
        /// <param name="TNode">节点</param>
        /// <param name="n">标识，判断当前是文件夹还是文件</param>
        public void Files_Copy(TreeView tv, string Sdir, TreeNode TNode, int n)
        {
            DirectoryInfo dir = new DirectoryInfo(Sdir);
            try
            {
                if (!dir.Exists)//判断所指的文件或文件夹是否存在
                {
                    return;
                }
                DirectoryInfo dirD = dir as DirectoryInfo;//如果给定参数不是文件夹则退出
                if (dirD == null)//判断文件夹是否为空
                {
                    return;
                }
                else
                {
                    if (n == 0)
                    {
                        TNode = tv.Nodes.Add(dirD.Name);//添加文件夹的名称
                        TNode.Tag = 1;
                    }
                    else
                    {
                        TNode = TNode.Nodes.Add(dirD.Name);//添加文件夹中各子文件夹的名称
                        TNode.Tag = 1;
                    }
                }
                FileSystemInfo[] files = dirD.GetFileSystemInfos();//获取文件夹中所有的文件和子文件夹
                //对单个FileSystemInfo进行判断，如果是文件夹则进行地柜
                foreach (FileSystemInfo FSys in files)
                {
                    FileInfo file = FSys as FileInfo;
                    if (file != null)//如果是文件的话对文件进行复制操作
                    {
                        //获取文件所在的原始路径
                        FileInfo SFInfo = new FileInfo(file.DirectoryName + "\\" + file.Name);
                        TNode.Nodes.Add(file.Name);//添加文件
                        TNode.Tag = 1;
                    }
                    else
                    {
                        string pp = FSys.Name;//获取当前搜索到的文件夹名称
                        Files_Copy(tv, Sdir + "\\" + FSys.ToString(), TNode, 1);//如果是文件夹则进行递归调用
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

    }
}
