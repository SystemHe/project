using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace HistoryMenu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            文件ToolStripMenuItem.DropDownItems.Clear();//清空菜单
            ToolStripMenuItem MItem = new ToolStripMenuItem("打开");//实例化"打开"菜单
            文件ToolStripMenuItem.DropDownItems.Insert(0, MItem);//添加“打开”菜单
            MItem.Click+=new EventHandler(打开ToolStripMenuItem_Click);//为打开菜单添加单击事件
            ToolStripMenuItem MItem2 = new ToolStripMenuItem("退出");//实例化"退出"菜单
            文件ToolStripMenuItem.DropDownItems.Insert(1, MItem2);//添加退出菜单
            StreamReader sr = new StreamReader("Menu.ini");//实例化读取流对象
            int i = this.文件ToolStripMenuItem.DropDownItems.Count - 1;//定义历史记录位置
            while (sr.Peek() >= 0)//从INI文件读取历史记录
            {
                //实例化历史菜单
                ToolStripMenuItem MItem3 = new ToolStripMenuItem(sr.ReadLine());
                //添加历史菜单
                this.文件ToolStripMenuItem.DropDownItems.Insert(i, MItem3);
                i++;//重新指定历史记录位置
                //为历史菜单添加单击事件
                MItem3.Click+=new EventHandler(MItem3_Click);
            }
            sr.Close();//关闭读取流
        }

        private void 打开ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "*.*(所有文件)|*.*";//设置打开文件格式
            if (openFileDialog1.ShowDialog() == DialogResult.OK)//判断是否打开文件
            {
                StreamWriter sw = new StreamWriter("Menu.ini", true);//实例化写入流对象
                sw.WriteLine(openFileDialog1.FileName);//向INI文件写入对象
                sw.Flush();//清除缓冲区
                sw.Close();//关闭写入流
                System.Diagnostics.Process.Start(openFileDialog1.FileName);//打开写入文件
            }
            Form1_Load(sender, e);//重新加载菜单
        }

        public void MItem3_Click(object sender,EventArgs e)
        {
            try
            {
                ToolStripMenuItem menu = (ToolStripMenuItem)sender;//获取菜单单击项
                System.Diagnostics.Process.Start(menu.Text);//根据历史菜单打开指定文件
            }
            catch { }
        }

    }
}
