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

namespace ChangePicFormat
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string[] path1;
        string path2,oldPath,path;
        int flags, ImgType1;
        Thread td;
        Bitmap bt;
        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)//判断是否选择了文件
            {
                listView1.Items.Clear();//清空ListView列表
                string[] info = new string[7];//存储每一行数据
                FileInfo fi;//创建一个FileInfo对象，用于获取图片信息
                path1 = openFileDialog1.FileNames;//选择获取的图片集合
                for (int i = 0; i < path1.Length; i++)//循环读取图片中的内容
                {
                    //获取图片名称
                    string ImgName = path1[i].Substring(path1[i].LastIndexOf("\\")+1,path1[i].Length-path1[i].LastIndexOf("\\")-1);
                    //获取图片类型
                    string ImgType = ImgName.Substring(ImgName.LastIndexOf(".") + 1, ImgName.Length - ImgName.LastIndexOf(".") - 1);
                    fi = new FileInfo(path1[i].ToString());//实例化FileInfo对象
                    //将每一行第一个位置的图标加入到imageList中
                    imageList1.Images.Add(System.Drawing.Icon.ExtractAssociatedIcon(path1[i]));
                    info[1] = ImgName;//图片名称
                    info[2] = ImgType;//图片类型
                    info[3] = fi.LastWriteTime.ToShortDateString();//最后修改时间
                    info[4] = path1[i].ToString();//路径
                    info[5] = (fi.Length / 1024) + "KB";//大小
                    info[6] = "未转换";//图片状态
                    ListViewItem lvi = new ListViewItem(info, ImgName);//实例化ListViewItem对象
                    listView1.Items.Add(lvi);//将信息添加到ListView中
                }
                //在状态栏显示图片数量
                toolStripStatusLabel1.Text = "当前共有：" + path1.Length.ToString() + "个文件！";
            }
        }

        private void toolStripLabel2_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)//判断是否选择了保存路径
            {
                path2 = folderBrowserDialog1.SelectedPath;//获取保存路径
            }
            toolStripStatusLabel2.Text ="  保存位置："+ path2.ToString();//状态栏显示保存位置
        }

        private void toolStripLabel4_Click(object sender, EventArgs e)
        {
            if (path1 == null)//判断是否选择了图片
            {
                MessageBox.Show("请选择图片！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                try
                {
                    if (path2.Length == 0)//判断是否选择了保存路径
                    {
                        MessageBox.Show("请选择保存位置", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        
                        flags = 1;
                        toolStrip1.Enabled = false;//转换开始是禁用工具栏
                        int flag = toolStripComboBox1.SelectedIndex;//判断将图片转换为什么格式
                        switch (flag)//根据不同格式进行转换
                        {
                            case 0:
                                ImgType1 = 0; 
                                //通过线程调用ConvertImage进行转换
                                td = new Thread(new ThreadStart(ConvertImage));
                                td.Start();
                                break;
                            case 1:
                                ImgType1 = 1;
                                td = new Thread(new ThreadStart(ConvertImage));
                                td.Start();
                                break;
                            case 2:
                                ImgType1 = 2;
                                td = new Thread(new ThreadStart(ConvertImage));
                                td.Start();
                                break;
                            case 3:
                                ImgType1 = 3;
                                td = new Thread(new ThreadStart(ConvertImage));
                                td.Start();
                                break;
                            default: td.Abort(); break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("请选择保存位置！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        private void ConvertImage()
        {
            flags = 1;
            switch (ImgType1)
            { 
                case 0://如果选择第0项则转换为BMP格式
                    for (int i = 0; i < path1.Length; i++)//遍历图片集合
                    {
                        
                        //获取图片名称（带扩展名）
                        string ImgName = path1[i].Substring(path1[i].LastIndexOf("\\") + 1, path1[i].Length - path1[i].LastIndexOf("\\") - 1);
                        //获取图片名称（不带扩展名）
                        ImgName = ImgName.Remove(ImgName.LastIndexOf("."));
                        oldPath = path1[i].ToString();//获取图片所在路径
                        bt = new Bitmap(oldPath);//实例化BitMap对象
                        path = path2 + "\\" + ImgName + ".bmp";//设置保存路径
                        bt.Save(path, System.Drawing.Imaging.ImageFormat.Bmp);//保存
                        listView1.Items[flags - 1].SubItems[6].Text = "已转换";
                        //显示转换进度
                        toolStripStatusLabel1.Text = "正在转换" + flags * 100 / path1.Length + "%";
                        if (flags == path1.Length)//如果转换的数量等于图片的总量
                        {
                            toolStrip1.Enabled = true;//设置工具栏可用
                            toolStripStatusLabel1.Text = "图片全部转换完成！";//提示转换完成
                        }
                        flags++;
                    }
                    break;
                case 1:
                    for (int i = 0; i < path1.Length; i++)
                    {
                        string ImgName = path1[i].Substring(path1[i].LastIndexOf("\\") + 1, path1[i].Length - path1[i].LastIndexOf("\\") - 1);
                        ImgName = ImgName.Remove(ImgName.LastIndexOf("."));
                        oldPath = path1[i].ToString();
                        bt = new Bitmap(oldPath);
                        path = path2 + "\\" + ImgName + ".jpeg";
                        bt.Save(path, System.Drawing.Imaging.ImageFormat.Jpeg);
                        listView1.Items[flags - 1].SubItems[6].Text = "已转换";
                        toolStripStatusLabel1.Text = "正在转换" + flags * 100 / path1.Length + "%";
                        if (flags == path1.Length)
                        {
                            toolStrip1.Enabled = true;
                            toolStripStatusLabel1.Text = "图片全部转换完成！";
                        }
                        flags++;
                    }
                    break;
                case 2:
                    for (int i = 0; i < path1.Length; i++)
                    {
                        string ImgName = path1[i].Substring(path1[i].LastIndexOf("\\") + 1, path1[i].Length - path1[i].LastIndexOf("\\") - 1);
                        ImgName = ImgName.Remove(ImgName.LastIndexOf("."));
                        oldPath = path1[i].ToString();
                        bt = new Bitmap(oldPath);
                        path = path2 + "\\" + ImgName + ".png";
                        bt.Save(path, System.Drawing.Imaging.ImageFormat.Png);
                        listView1.Items[flags - 1].SubItems[6].Text = "已转换";
                        toolStripStatusLabel1.Text = "正在转换" + flags * 100 / path1.Length + "%";
                        if (flags == path1.Length)
                        {
                            toolStrip1.Enabled = true;
                            toolStripStatusLabel1.Text = "图片全部转换完成！";
                        }
                        flags++;
                    }
                    break;
                case 3:
                    for (int i = 0; i < path1.Length; i++)
                    {
                        string ImgName = path1[i].Substring(path1[i].LastIndexOf("\\") + 1, path1[i].Length - path1[i].LastIndexOf("\\") - 1);
                        ImgName = ImgName.Remove(ImgName.LastIndexOf("."));
                        oldPath = path1[i].ToString();
                        bt = new Bitmap(oldPath);
                        path = path2 + "\\" + ImgName + ".gif";
                        bt.Save(path, System.Drawing.Imaging.ImageFormat.Gif);
                        listView1.Items[flags - 1].SubItems[6].Text = "已转换";
                        toolStripStatusLabel1.Text = "正在转换" + flags * 100 / path1.Length + "%";
                        if (flags == path1.Length)
                        {
                            toolStrip1.Enabled = true;
                            toolStripStatusLabel1.Text = "图片全部转换完成！";
                        }
                        flags++;
                    }
                    break;
                default: bt.Dispose(); break;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        private void toolStripLabel5_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "已清空！";
            toolStripStatusLabel2.Text = "";
            listView1.Items.Clear();
        }

        private void toolStripLabel6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
