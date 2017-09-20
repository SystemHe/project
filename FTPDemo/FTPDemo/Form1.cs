using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Net.FtpClient;

namespace FTPDemo
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }
        string serverIp, serverUser, serverPwd;
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (tstbHost.Text.Trim() == "")
                {
                    if (MessageBox.Show("请输入主机地址！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                    {
                        tstbHost.Focus();
                    }
                }
                else if (!tstbHost.Text.Trim().Contains(":"))
                {
                    if (MessageBox.Show("请输入端口号！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                    {
                        tstbHost.Focus();
                    }
                }
                else if (tstbUser.Text.Trim() == "")
                {
                    if (MessageBox.Show("请输入用户名！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                    {
                        tstbUser.Focus();
                    }
                }
                else if (tstbPwd.Text.Trim() == "")
                {
                    if (MessageBox.Show("请输入密码！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                    {
                        tstbPwd.Focus();
                    }
                }
                else
                {
                    if (CheckFtp(tstbHost.Text.Trim(), tstbUser.Text.Trim(), tstbPwd.Text.Trim()))
                    {
                        serverIp = tstbHost.Text.Trim();
                        serverUser = tstbUser.Text.Trim();
                        serverPwd = tstbPwd.Text.Trim();
                        groupBox2.Text = "FTP 服务器(" + tstbHost.Text.Trim() + ")";
                        listView2.Items.Clear();
                        contextMenuStrip1.Items[0].Enabled = true;
                        this.Text = "FTP V1.0-[" + tstbHost.Text.Trim() + "],状态：已连接！";
                        toolStripStatusLabel2.Text = "[当前登录用户：" + tstbUser.Text.Trim() + "]";
                        tscbServer.Items.Add("/" + tstbUser.Text.Trim());
                        tscbServer.SelectedIndex = 0;
                        //check=true;
                        contextMenuStrip2.Items[0].Enabled = true;
                        contextMenuStrip2.Items[1].Enabled = true;
                        contextMenuStrip2.Items[2].Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("FTP登录失败，请检查是否是用户名和密码输入错误！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Text = "FTP V1.0-[" + tstbHost.Text.Trim() + "],状态：连接失败！";
                        toolStripStatusLabel1.Text = "";
                    }
                }
            }
            catch
            {
                contextMenuStrip1.Items[0].Enabled = true;
                this.Text = "FTP V1.0-[" + tstbHost.Text.Trim() + "],状态：已连接！";
                contextMenuStrip2.Items[0].Enabled = true;
                contextMenuStrip2.Items[1].Enabled = true;
                contextMenuStrip2.Items[2].Enabled = true;
            }
        }
        FtpWebRequest reqFTP;
        public bool CheckFtp(string DomainName, string FtpUserName, string FtpUserPwd)
        {
            bool resultValue = true;
            try
            {
                FtpWebRequest ftprequest = (FtpWebRequest)WebRequest.Create("ftp://" + DomainName);
                ftprequest.Credentials = new NetworkCredential(FtpUserName, FtpUserPwd);
                ftprequest.Method = WebRequestMethods.Ftp.ListDirectory;
                FtpWebResponse ftpresponse = (FtpWebResponse)ftprequest.GetResponse();
                ftpresponse.Close();
            }
            catch
            {
                resultValue = false;
            }
            return resultValue;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            tstbPwd.TextBox.PasswordChar = '*';
            listFolders(ToolStripComboBox1);
            contextMenuStrip1.Items[0].Enabled = false;
        }
        public void listFolders(ToolStripComboBox tscb)
        {
            string[] logicdrive = System.IO.Directory.GetLogicalDrives();
            for (int i = 0; i < logicdrive.Length; i++)
            {
                tscb.Items.Add(logicdrive[i]);
                
            }
            tscb.SelectedIndex = 0;
        }

        private void ToolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetPath(ToolStripComboBox1.Text, imageList1, listView1, 0);
        }
        public static string AllPath = "";
        public void GetPath(string path, ImageList imglist, ListView lv, int ppath)
        {
            string pp = "";
            string uu = "";
            if (ppath == 0)
            {
                if (AllPath != path)
                {
                    lv.Items.Clear();
                    AllPath = path;
                    GetListViewItem(AllPath, imglist, lv);
                }
            }
            else
            {
                uu = AllPath + path;
                if (Directory.Exists(uu))
                {
                    AllPath = AllPath + path + "\\";
                    pp = AllPath.Substring(0, AllPath.Length - 1);
                    lv.Items.Clear();
                    GetListViewItem(pp, imglist, lv);
                }
                else
                {
                    uu = AllPath + path;
                    System.Diagnostics.Process.Start(uu);
                }
            }
        }

        private void GetListViewItem(string path, ImageList imglist, ListView lv)
        {
            DirectoryInfo di = new DirectoryInfo(path);
            foreach (FileInfo f in di.GetFiles())
            {
                //add system icon of current file into imagelist    
                if (!imageList1.Images.Keys.Contains(f.Extension))
                {
                    imageList1.Images.Add(f.Extension, Icon.ExtractAssociatedIcon(f.FullName));
                }
                ListViewItem lvi = new ListViewItem();
                long fSize = Convert.ToInt64(f.Length);
                string fPath = Path.GetFullPath(f.DirectoryName);
                string fTime = f.LastWriteTime.ToString();
                lvi.Text = f.Name;
                //get imageindex from imagelist according to the file extension    
                lvi.ImageIndex = imageList1.Images.Keys.IndexOf(f.Extension);
                lvi.SubItems.Add(Math.Ceiling(decimal.Divide(fSize, 1024)) + " KB");
                lvi.SubItems.Add(fPath);
                lvi.SubItems.Add(fTime);
                listView1.Items.Add(lvi);

            }
        }
        string newFileName;
        public bool UpLoad(string fileName,string ftpServerIP,string ftpUserID,string ftpPassword,ToolStripProgressBar pb,string path)
        {
            if (path == null)
            {
                path = "";
            }
            bool success = true;
            FileInfo fileInfo = new FileInfo(fileName);
            int allbye = (int)fileInfo.Length;
            int startbye = 0;
            pb.Maximum = allbye;
            pb.Minimum = 0;
            if (fileInfo.Name.IndexOf("#") == -1)
            {
                newFileName = fileInfo.Name.Replace(" ","");
            }
            else
            {
                newFileName = fileInfo.Name.Replace("#", "#");
                newFileName = newFileName.Replace(" ", "");
            }
            string uri;
            if (path.Length == 0)
            {
                uri = "ftp://" + ftpServerIP + "/" + newFileName;
            }
            else
                uri = "ftp://" + ftpServerIP + "/" + path + newFileName;
            FtpWebRequest reqFTP;
            reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(uri));
            reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
            reqFTP.KeepAlive = false;
            reqFTP.Method = WebRequestMethods.Ftp.UploadFile;
            reqFTP.UseBinary = true;
            reqFTP.ContentLength = fileInfo.Length;
            int buffLength = 2048;
            byte[] buff = new byte[buffLength];
            FileStream fs = fileInfo.OpenRead();
            try
            {
                Stream strm = reqFTP.GetRequestStream();
                int ContentLen = fs.Read(buff, 0, buffLength);
                while (ContentLen != 0)
                {
                    strm.Write(buff, 0, ContentLen);
                    ContentLen = fs.Read(buff, 0, buffLength);
                    startbye += ContentLen;
                    pb.Value = startbye;
                }
                strm.Close();
                fs.Close();
            }
            catch
            {
                success = false;
            }
            return success;
        }
        public static string NPath;
        public string GFolder;
        public void UpDir(string aimPath)
        {
            try
            {
                if (aimPath[aimPath.Length - 1] != Path.DirectorySeparatorChar)
                {
                    aimPath += Path.DirectorySeparatorChar;
                }
                if (NPath == null || NPath == "")
                {
                    NPath = NPath + FolderN;
                    MakeDir(NPath, serverIp, serverUser, serverPwd);
                }
                string[] fileList = Directory.GetFileSystemEntries(aimPath);
                foreach (string file in fileList)
                {
                    string[] a = file.Split('\\');
                    string fName = a[a.Length - 1];
                    NPath = file.Remove(0, GFolder.Length).Replace("\\", "//");
                    if (NPath.StartsWith("//"))
                    {
                        NPath = NPath.Remove(0, 2);
                    }
                    if (Directory.Exists(file))
                    {
                        string aa = file;
                        NPath = file.Remove(0, GFolder.Length).Replace("\\", "//");
                        if (NPath.StartsWith("//"))
                        {
                            NPath = NPath.Remove(0, 2);
                        }
                        MakeDir(NPath, serverIp, serverUser, serverPwd);
                        UpDir(file);
                    }
                    else
                    {
                        UpLoad(file, serverIp, serverUser, serverPwd, toolStripProgressBar1, NPath.Remove(NPath.LastIndexOf("//")) + "/");
                    }
                }
            }
            catch { }
        }

        private void MakeDir(string dirName, string serverIp, string serverUser, string serverPwd)
        {
            try
            {
                string uri = "ftp://" + serverIp + "/" + dirName;
                Connect(uri, serverUser, serverPwd);
                reqFTP.Method = WebRequestMethods.Ftp.MakeDirectory;
                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                response.Close();
            }
            catch { }
        }
        public bool Connect(string strServer, string strUser, string strPassword)
        {
            using (FtpClient ftp = new FtpClient())
            {
                ftp.Host = strServer;
                ftp.Credentials = new NetworkCredential(strUser, strPassword);
                ftp.Connect();
                return ftp.IsConnected;
            }
        }

        public static string FolderN;
        public static string path1;
        private void 上传_Click(object sender, EventArgs e)
        {
            try
            {
                if (listView1.SelectedItems.Count == 0)
                {
                    MessageBox.Show("请选择要上传的文件！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    for (int i = 0; i < listView1.SelectedItems.Count; i++)
                    {
                        path1 = MPath() + listView1.SelectedItems[i].Text;
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
                            if (tscbServer.Text == "/" + serverUser)
                            {
                                toolStripProgressBar1.Visible = true;
                                UpLoad(path1, serverIp, serverUser, serverPwd, toolStripProgressBar1, servePath);
                            }
                            else
                            {
                                toolStripProgressBar1.Visible = true;
                                UpLoad(path1, tstbHost.Text, tstbUser.Text, tstbPwd.Text, toolStripProgressBar1, servePath);
                            }
                        }
                    }
                    toolStripProgressBar1.Visible = false;
                    listView2.Items.Clear();
                    getFTPServerICO(imageList2, tstbHost.Text.Trim(), tstbUser.Text.Trim(), tstbPwd.Text.Trim(), listView2, servePath);
                    tscbServer.Text = "/" + serverUser + servePath;
                }
            }
            catch { }
        }

    }
}

