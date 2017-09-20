using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FTP_LS.FTPClass;
using System.IO;
using System.Runtime.InteropServices;
using System.Collections;
using System.Threading;
using System.Net;
namespace FTP_LS
{
    public partial class frmMain : Form
    {
        BaseClass bc = new BaseClass();

        public frmMain()
        {
            InitializeComponent();
        }
        public string FolderName="";
        private string serverIp;
        private string serverUser;
        private string serverPwd;
        private static bool check=false;
        public string BDFolderName="";
        private void frmMain_Load(object sender, EventArgs e)
        {
            tstbPwd.TextBox.PasswordChar='*';
            bc.listFolders(toolStripComboBox1);
            contextMenuStrip1.Items[0].Enabled = false;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)//登录FTP
        {
            try
            {
                if (tstbHost.Text.Trim() == "")
                {
                    if (MessageBox.Show("输入主机名称", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                    {
                        tstbHost.Focus();
                    }
                }
                else if (this.tstbUser.Text.Trim() == "")
                {
                    if (MessageBox.Show("输入用户名", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                    {
                        tstbUser.Focus();
                    }
                }
                else
                {
                    if (this.tstbPwd.Text.Trim() == "")
                    {
                        if (MessageBox.Show("输入密码", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                        {
                            tstbPwd.Focus();
                        }
                    }
                    else
                    {
                        if (bc.CheckFtp(tstbHost.Text.Trim(), tstbUser.Text.Trim(), tstbPwd.Text.Trim()))
                        {
                            serverIp = tstbHost.Text.Trim();
                            serverUser = tstbUser.Text.Trim();
                            serverPwd = tstbPwd.Text.Trim();
                            tabControl2.TabPages[0].Text = "FTP服务器(" + tstbHost.Text.Trim() + ")";
                            listView2.Items.Clear();
                            bc.getFTPServerICO(imageList2, tstbHost.Text.Trim(), tstbUser.Text.Trim(), tstbPwd.Text.Trim(), listView2, "");
                            contextMenuStrip1.Items[0].Enabled = true;
                            this.Text = "HappyTime FTP V1.0-[" + tstbHost.Text + ",状态：已连接]";
                            toolStripStatusLabel3.Text = "[当前登录用户" + tstbUser.Text.Trim() + "]";

                            tscbServer.Items.Add("/" + tstbUser.Text.Trim());
                            tscbServer.SelectedIndex = 0;
                            check = true;
                            contextMenuStrip2.Items[0].Enabled = true;
                            contextMenuStrip2.Items[1].Enabled = true;
                            contextMenuStrip2.Items[2].Enabled = true;
                        }
                        else
                        {
                            MessageBox.Show("FTP登录失败，请检查用户名和密码是否正确", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Text = "FTP V1.0-[" + tstbHost.Text + ",状态：连接失败]";
                            toolStripStatusLabel3.Text = "";
                        }
                    }
                }
            }
            catch
            {
                contextMenuStrip1.Items[0].Enabled = true;
                this.Text = "HappyTime FTP V1.0-[" + tstbHost.Text + ",状态：已连接]";
                contextMenuStrip2.Items[0].Enabled = true;
                contextMenuStrip2.Items[1].Enabled = true;
                contextMenuStrip2.Items[2].Enabled = true;
            }
        }
        
        private void listView1_DoubleClick(object sender, EventArgs e)//双击本地驱动器中的文件或文件夹
        {
            try
            {
                string pp = listView1.SelectedItems[0].Text;
                bc.GetPath(pp.Trim(), imageList1, listView1, 1);
            }
            catch
            {
                MessageBox.Show("无法打开此文件", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)//返回上级目录
        {
            bc.GOBack(listView1, imageList1, toolStripComboBox1.Text);
        }

        //下载文件夹
        public string name;
        public void DownLoadDir(string aimPath)
        {
            DirectoryInfo di;
            try
            {
                if (aimPath[aimPath.Length - 1] != Path.DirectorySeparatorChar)
                    aimPath += "/";
                string path = "";
                if (aimPath == name+"/")
                {
                    path = bc.Mpath() + aimPath.Remove(aimPath.LastIndexOf("/"));
                    di = new DirectoryInfo(path);
                    di.Create();
                }
                string[] fileList = bc.GetFTPList(serverIp, serverUser, serverPwd, aimPath);
                if (fileList == null)
                { }
                else
                {
                    foreach (string file in fileList)
                    {
                        //先当作目录处理如果存在这个目录就递归该目录下面的文件
                        string[] f = file.Split(' ');
                        string m = f[f.Length - 1];
                        path = aimPath + m;
                        path = path.Replace("//", "\\");
                        path = bc.Mpath() + path;
                        path = path.Replace("/", "\\");
                        if (file.IndexOf("DIR") != -1)
                        {

                            di = new DirectoryInfo(path);
                            di.Create();
                            DownLoadDir(aimPath + m);
                        }
                        else
                        {
                            bc.Download(path.Remove(path.LastIndexOf("\\")), m, serverIp, serverUser, serverPwd, aimPath);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)//下载文件
        {
            try
            {
                if (check == false)
                { }
                else
                {
                    if (listView2.SelectedItems.Count == 0)
                    {
                        MessageBox.Show("请选择文件", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        for (int i = 0; i < listView2.SelectedItems.Count; i++)
                        {
                            string filename = listView2.SelectedItems[i].Text;
                            string filetype = listView2.SelectedItems[0].SubItems[1].Text;
                            if (filetype=="文件夹")
                            {
                                for (int j = 0; j < listView1.Items.Count; j++)
                                {
                                    if (listView1.Items[j].ToString() == filename)
                                    {
                                        MessageBox.Show("本地目录中存在此文件夹", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        return;
                                    }
                                }
                                name = filename;
                                DownLoadDir(filename);
                                bc.GetListViewItem(bc.Mpath(), imageList1, listView1);
                            }
                            else
                            {
                                bc.Download(bc.Mpath(), filename, tstbHost.Text.Trim(), tstbUser.Text.Trim(), tstbPwd.Text.Trim(), servePath);
                                bc.GetListViewItem(bc.Mpath(), imageList1, listView1);
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public  void DeleteDir(string aimPath)
        {
            try
            {
                if (aimPath[aimPath.Length - 1] != Path.DirectorySeparatorChar)
                    aimPath += "/";
                string[] fileList = bc.GetFTPList(serverIp, serverUser, serverPwd, aimPath);
                // 遍历所有的文件和目录
                if (fileList == null)
                {
                    aimPath = aimPath.Remove(aimPath.LastIndexOf("/"));
                    bc.delDir(aimPath, serverIp, serverUser, serverPwd);
                }
                else
                {
                    foreach (string file in fileList)
                    {
                        //先当作目录处理如果存在这个目录就递归Delete该目录下面的文件
                        string[] f = file.Split(' ');
                        string m = f[f.Length - 1];
                        if (file.IndexOf("DIR") != -1)
                        {
                            DeleteDir(aimPath + m);
                        }
                        // 否则直接Delete文件
                        else
                        {
                            bc.DeleteFileName(m, serverIp, serverUser, serverPwd, aimPath);
                        }
                    }
                    //删除文件夹
                    aimPath = aimPath.Remove(aimPath.LastIndexOf("/"));
                    bc.delDir(aimPath, serverIp, serverUser, serverPwd);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        private void toolStripButton5_Click(object sender, EventArgs e)//删除文件
        {
            if (check == false)
            { }
            else
            {
                if (listView2.SelectedItems.Count == 0)
                {
                    MessageBox.Show("请选择要删除的项目", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {

                    try
                    {
                        for (int i = 0; i < listView2.SelectedItems.Count; i++)
                        {

                            string filename =servePath+listView2.SelectedItems[i].Text;
                            string filetype = listView2.SelectedItems[i].SubItems[1].Text;

                            if (filetype=="文件夹")
                            {
                                DeleteDir(filename);
                            }
                            else
                            {
                                bc.DeleteFileName(listView2.SelectedItems[i].Text, tstbHost.Text.Trim(), tstbUser.Text.Trim(), tstbPwd.Text.Trim(), servePath);
                            }
                        }
                        listView2.Items.Clear();
                        bc.getFTPServerICO(imageList2, tstbHost.Text.Trim(), tstbUser.Text.Trim(), tstbPwd.Text.Trim(), listView2, servePath);
                    }
                    catch(Exception ex)
                    { 
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        #region 服务器右键菜单

        private void 下载ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripButton4_Click(sender,e);
        }

        private void 删除ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            toolStripButton5_Click(sender, e);
        }

        #endregion

        #region 本地磁盘的右键菜单

        private string path;

        private static ArrayList al=new ArrayList();

        private void 复制ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                al.Clear();
                path = bc.Mpath() + "\\" + listView1.SelectedItems[0].Text;
                for (int i = 0; i < listView1.SelectedItems.Count; i++)
                {
                    al.Add(bc.Mpath() + "\\" + listView1.SelectedItems[i].Text);
                }
                System.Collections.Specialized.StringCollection files = new System.Collections.Specialized.StringCollection();
                files.Add(path);
                Clipboard.SetFileDropList(files);
                MyPath = path;
                T = 1;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        
        private int T = 0;

        private void 粘贴ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (T == 0)
            {
                try
                {
                    for (int i = 0; i < al.Count; i++)
                    {
                        string name1 = al[i].ToString().Substring(al[i].ToString().LastIndexOf("\\") + 1, al[i].ToString().Length - al[i].ToString().LastIndexOf("\\") - 1);
                        string paths = bc.Mpath() + "\\" + name1;
                        if (File.Exists(al[i].ToString()))
                        {
                            if (al[i].ToString() != paths)
                            {
                                File.Move(al[i].ToString(), paths);
                            }
                        }
                        if (Directory.Exists(al[i].ToString()))
                        {
                            bc.Files_Copy(paths, al[i].ToString());
                            DirectoryInfo di = new DirectoryInfo(al[i].ToString());
                            di.Delete(true);
                        }
                    }
                    listView1.Items.Clear();
                    bc.GetListViewItem(bc.Mpath(), imageList1, listView1);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                try
                {
                    for (int i = 0; i < al.Count; i++)
                    {
                        string name1 = al[i].ToString().Substring(al[i].ToString().LastIndexOf("\\") + 1, al[i].ToString().Length - al[i].ToString().LastIndexOf("\\") - 1);
                        string paths = bc.Mpath() + "\\" + name1;
                        if (File.Exists(al[i].ToString()))
                        {
                            if (al[i].ToString() != paths)
                            {
                                File.Copy(al[i].ToString(), paths, false);
                            }
                        }
                        if (Directory.Exists(al[i].ToString()))
                        {
                            bc.Files_Copy(paths, al[i].ToString());
                        }
                    }
                    listView1.Items.Clear();
                    bc.GetListViewItem(bc.Mpath(), imageList1, listView1);
                }
                catch { }
            }
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (listView1.SelectedItems.Count == 0)
                {
                    MessageBox.Show("请选择文件", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    for (int i = 0; i < listView1.SelectedItems.Count; i++)
                    {
                        string path = bc.Mpath() + "\\" + listView1.SelectedItems[i].Text;
                        if (File.GetAttributes(path).CompareTo(FileAttributes.Directory) == 0)
                        {
                            DirectoryInfo dinfo = new DirectoryInfo(path);
                            dinfo.Delete(true);
                        }
                        else
                        {
                            string path1 = bc.Mpath() + "\\" + listView1.SelectedItems[i].Text;
                            FileInfo finfo = new FileInfo(path1);
                            finfo.Delete();
                        }
                    }
                    listView1.Items.Clear();
                    bc.GetListViewItem(bc.Mpath(), imageList1, listView1);
                }
            }
            catch
            { }
        }

        #region  返回上一级目录
        /// <summary>
        /// 返回上一级目录
        /// </summary>
        /// <param dir="string">目录</param>
        /// <returns>返回String对象</returns>
        public string UpAndDown_Dir(string dir)
        {
            string Change_dir = "";
            Change_dir = Directory.GetParent(dir).FullName;
            return Change_dir;
        }
        #endregion

        /// <summary>
        /// 遍历本地文件夹上传整个文件夹到FTP
        /// </summary>z
        /// <param name="path"></param>
        public static string NPath = servePath;
        public string GFolder;
        public void UpDir(string aimPath)
        {
            try
            {
                // 检查目标目录是否以目录分割字符结束如果不是则添加之
                if (aimPath[aimPath.Length - 1] != Path.DirectorySeparatorChar)
                    aimPath += Path.DirectorySeparatorChar;
                if (NPath == "" || NPath == null)
                {
                    NPath = NPath + FolderN;
                    bc.MakeDir(NPath,serverIp,serverUser,serverPwd);
                }
                // 得到源目录的文件列表，里面是包含文件以及目录路径的一个数组
                string[] fileList = Directory.GetFileSystemEntries(aimPath);
                // 遍历所有的文件和目录
                foreach (string file in fileList)
                {
                    string[] a = file.Split('\\');
                    string fname=a[a.Length-1];
                    NPath = file.Remove(0, GFolder.Length).Replace("\\", "//");
                    if (NPath.StartsWith("//"))
                    {
                        NPath = NPath.Remove(0,2);
                    }
                    // 先当作目录处理如果存在这个目录就递归Delete该目录下面的文件
                    if (Directory.Exists(file))
                    {
                        string aa = file;
                        NPath = file.Remove(0,GFolder.Length).Replace("\\","//");
                        if (NPath.StartsWith("//"))
                        {
                            NPath = NPath.Remove(0, 2);
                        }
                        bc.MakeDir(NPath, serverIp, serverUser, serverPwd);
                        UpDir(file);
                    }
                    else
                    {
                        bc.Upload(file, serverIp, serverUser, serverPwd, toolStripProgressBar1, NPath.Remove(NPath.LastIndexOf("//")) + "/");
                    }
                }
            }
            catch{}
        }
      
        /// <summary>
        /// 上传文件菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static string FolderN;
        public static string path1;
        private void 上传ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (listView1.SelectedItems.Count == 0)
                {
                    MessageBox.Show("请选择文件", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    for (int i = 0; i < listView1.SelectedItems.Count; i++)
                    {
                         path1 = bc.Mpath() +listView1.SelectedItems[i].Text;
                         GFolder = Directory.GetParent(path1).FullName;
                         if (Directory.Exists(path1))
                         {
                             if (listView2.Items.Count == 0)
                             {
                                 FolderN = listView1.SelectedItems[i].Text;
                                 UpDir(path1);
                                 NPath = servePath;
                             }
                             else
                             {
                                 for (int j = 0; j < listView2.Items.Count; j++)
                                 {
                                     if (listView2.Items[j].Text == listView1.SelectedItems[i].Text)
                                     {
                                         MessageBox.Show("服务器中已经存在此目录", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                     }
                                     else
                                     {
                                         FolderN = listView1.SelectedItems[i].Text;
                                         UpDir(path1);
                                         NPath = servePath;
                                     }
                                 }
                             }
                         }
                         else if (File.Exists(path1))
                         {
                             if (tscbServer.Text == "/" +serverUser)
                             {
                                 toolStripProgressBar1.Visible = true;
                                 bc.Upload(path1, serverIp, serverUser, serverPwd, toolStripProgressBar1, servePath);
                             }
                             else
                             {
                                 toolStripProgressBar1.Visible = true;
                                 bc.Upload(path1, tstbHost.Text, tstbUser.Text, tstbPwd.Text, toolStripProgressBar1, servePath);
                             }
                         }
                    }
                    toolStripProgressBar1.Visible = false;
                    listView2.Items.Clear();
                    bc.getFTPServerICO(imageList2, tstbHost.Text.Trim(), tstbUser.Text.Trim(), tstbPwd.Text.Trim(), listView2,servePath);
                    tscbServer.Text ="/" +serverUser+servePath;
                }  
            }
            catch{}
        } 

        private void 全选ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                listView1.Items[i].Selected = true;
            }
        }

        private void 打开ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string pp = listView1.SelectedItems[0].Text;
                bc.GetPath(pp.Trim(), imageList1, listView1, 1);
            }
            catch
            {
                MessageBox.Show("无法打开此文件", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        
        private void 重命名ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count != 0)
            {
                listView1.SelectedItems[0].BeginEdit();
            }
        }

        private static string MyPath;

        private void 剪切ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count != 0)
            {
                al.Clear();
                for (int i = 0; i < listView1.SelectedItems.Count; i++)
                {
                    al.Add(bc.Mpath() + "\\" + listView1.SelectedItems[i].Text);
                }
                T = 0;
            }
        }

        #endregion

        #region 常用事件

        private void listView1_AfterLabelEdit(object sender, LabelEditEventArgs e)
        {
            try
            {
                string MyPath = bc.Mpath() + "\\" + listView1.SelectedItems[0].Text;
                string newFilename = e.Label;
                string path2 = bc.Mpath() + "\\" + newFilename;
                if (File.Exists(MyPath))
                {
                    if (MyPath != path2)
                    {
                        File.Move(MyPath, path2);
                    }
                }
                if (Directory.Exists(MyPath))
                {
                    DirectoryInfo di = new DirectoryInfo(MyPath);
                    di.MoveTo(path2);
                }
                listView1.Items.Clear();
                bc.GetListViewItem(bc.Mpath(), imageList1, listView1);
            }
            catch{}
        }

        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            bc.GetPath(toolStripComboBox1.Text, imageList1, listView1,0);
        }

        #endregion

        public static string servePath = "";//---------

        public void  GetPath(string path, int ppath)//-------
        {
            if (ppath == 0)
            {
                if (servePath != path)
                {
                    servePath = path;
                }
            }
            else
            {
                servePath = servePath + path + "/";
            }
        }

        private void listView2_DoubleClick(object sender, EventArgs e)//---
        {
            string filename = listView2.SelectedItems[0].Text;
            string filetype = listView2.SelectedItems[0].SubItems[1].Text;

            if (filetype =="文件夹")//文件夹
            {
                GetPath(filename.Trim(), 1);
                bc.getFTPServerICO(imageList2, tstbHost.Text.Trim(), tstbUser.Text.Trim(), tstbPwd.Text.Trim(), listView2, servePath);
                tscbServer.Items.Add("/" + tstbUser.Text.Trim() + "/" + servePath);
                tscbServer.Text = "/" + tstbUser.Text.Trim() + "/" + servePath;
            }
        }

        private void 新建文件夹ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNewFolder newFolder = new frmNewFolder();
            newFolder.Owner = this;
            newFolder.ShowDialog();
        }

        private void frmMain_Activated(object sender, EventArgs e)
        {
            if (FolderName.Length != 0)
            {
                bc.MakeDir(servePath+FolderName, serverIp, serverUser, serverPwd);
                listView2.Items.Clear();
                bc.getFTPServerICO(imageList2, tstbHost.Text.Trim(), tstbUser.Text.Trim(), tstbPwd.Text.Trim(), listView2, servePath);
                FolderName = "";
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)//服务器返回上一目录
        {
            if (tscbServer.Text == "/" + serverUser||check==false)
            { }
            else
            {
                string path = servePath;
                string Path1 = path.Remove(path.LastIndexOf("/"));
                string NewPath = Path1.Remove(Path1.LastIndexOf("/") + 1);
                servePath = NewPath;
                if (NewPath.Length != 0)
                {
                    tscbServer.Text = "/" + serverUser + "/" + NewPath;
                    listView2.Items.Clear();
                    bc.getFTPServerICO(imageList2, tstbHost.Text.Trim(), tstbUser.Text.Trim(), tstbPwd.Text.Trim(), listView2, NewPath);
                }
                else
                {
                    tscbServer.Text = "/" + serverUser;
                    listView2.Items.Clear();
                    bc.getFTPServerICO(imageList2, tstbHost.Text.Trim(), tstbUser.Text.Trim(), tstbPwd.Text.Trim(), listView2, "");
                }
            }
        }

        private void tscbServer_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (tscbServer.Text == "/" + tstbUser.Text)
            {
                GetPath("", 0);
                bc.getFTPServerICO(imageList2, tstbHost.Text.Trim(), tstbUser.Text.Trim(), tstbPwd.Text.Trim(), listView2, servePath);
            }
            else
            {
                string path = tscbServer.Text.Trim().Remove(0, tstbUser.Text.Trim().Length + 2);
                bc.getFTPServerICO(imageList2, tstbHost.Text.Trim(), tstbUser.Text.Trim(), tstbPwd.Text.Trim(), listView2, path);
            }
        }

        private void toolStripButton8_Click(object sender, EventArgs e)//清空按钮
        {
            try
            {
                if (check == false)
                { }
                else
                {
                    for (int i = 0; i < listView2.Items.Count; i++)
                    {
                        listView2.Items[i].Selected = true;
                    }
                    for (int i = 0; i < listView2.Items.Count; i++)
                    {
                        string filename = servePath + listView2.Items[i].Text;
                        string filetype = listView2.Items[i].SubItems[1].Text;

                        if (filetype == "文件夹")
                        {
                            DeleteDir(filename);
                        }
                        else
                        {
                            bc.DeleteFileName(listView2.SelectedItems[i].Text, tstbHost.Text.Trim(), tstbUser.Text.Trim(), tstbPwd.Text.Trim(), servePath);
                        }
                    }
                    listView2.Items.Clear();
                    bc.getFTPServerICO(imageList2, tstbHost.Text.Trim(), tstbUser.Text.Trim(), tstbPwd.Text.Trim(), listView2, servePath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}