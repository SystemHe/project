using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Threading;
using System.DirectoryServices;

namespace ScanPort
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        #region 实例化类对象和公共变量
        //实例化DirectoryEntry对象，以便获取局域网组名和计算机名
        DirectoryEntry DEMain = new DirectoryEntry("WinNT:");
        TcpClient TClient = null;//实例化连接侦听对象
        private Thread myThread;//实例化线程对象
        string strName = "";//记录选择的计算机名称
        int intflag = 0;//扫描到的端口号
        int intport = 0;//记录已用端口号
        int intstart = 0;//扫描的开始端口号
        int intend = 0;//扫描的结束端口号
        #endregion
        private void Form1_Load(object sender, EventArgs e)
        {
            //遍历局域网中的工作组，并显示在下拉列表控件中
            foreach (DirectoryEntry DEGroup in DEMain.Children)
            {
                comboBox1.Items.Add(DEGroup.Name);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            foreach (DirectoryEntry DEGroup in DEMain.Children)
            { 
                //判断工作组名称
                if(DEGroup.Name.ToLower()==comboBox1.Text.ToLower())
                {
                    //遍历指定工作组中的所有计算机名，并显示在listBox中
                    foreach (DirectoryEntry DEComputer in DEGroup.Children)
                    {
                        if (DEComputer.Name.ToLower() != "schema")
                        {
                            listBox1.Items.Add(DEComputer.Name);
                        }
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();//清空ListView中的项
            try
            {
                if (button1.Text == "扫描")
                {
                    intport = 0;
                    //指定进度条的最小值和最大值
                    progressBar1.Minimum = Convert.ToInt32(textBox1.Text);
                    progressBar1.Maximum = Convert.ToInt32(textBox2.Text);
                    //指定进度条的初始值
                    progressBar1.Value = progressBar1.Minimum;
                    timer1.Start();//开始运行计时器
                    button1.Text = "停止";
                    intstart = Convert.ToInt32(textBox1.Text);//为开始扫描的端口号赋值
                    intend = Convert.ToInt32(textBox2.Text);//为结束扫描的端口号赋值
                    myThread = new Thread(new ThreadStart(this.StartScan));
                    myThread.Start();//开始运行扫描端口号的线程
                }
                else
                {
                    button1.Text = "扫描";
                    timer1.Stop();//停止运行计时器
                    progressBar1.Value = Convert.ToInt32(textBox2.Text);
                    if (myThread != null)//判断线程对象是否为空
                    {
                        //判断扫描端口号的线程是否正在运行
                        if (myThread.ThreadState == ThreadState.Running)
                        {
                            myThread.Abort();//终止线程
                        }
                    }
                }
            }
            catch { }
        }
        private void StartScan()
        {
            while (true)
            {
                for (int i = intstart; i <= intend; i++)
                {
                    intflag = i;//记录正在使用的端口号
                    try
                    {
                        //使用记录的计算机名和端口号实例化侦听对象
                        TClient = new TcpClient(strName, i);
                        intport = i;//记录已分配的端口号
                        
                    }
                    catch { }
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (intport != 0)//判断是否有可用端口号
            {
                if (listView1.Items.Count > 0)
                {
                    for (int i = 0; i < listView1.Items.Count; i++)
                    {
                        if (listView1.Items[i].Text == intport.ToString())//判断扫描到的端口号是否与列表中的值重复
                        {
                            break;//一旦有重复就直接跳出循环，不需要在判断后面的
                            //listView1.Items.Add(intport.ToString());
                        }
                        else if (i == listView1.Items.Count - 1)
                        { //如果不重复则判断是否已经遍历完，如果没有完成则继续，否则说明listview中没有与扫到的端口重复的值
                            listView1.Items.Add(intport.ToString());
                        }
                    }
                }
                else
                {
                    listView1.Items.Add(intport.ToString());
                }
            }
            if (progressBar1.Value < progressBar1.Maximum)
            {
                progressBar1.Value = intflag;
            }
            if (intflag == Convert.ToInt32(textBox2.Text)) 
            {
                timer1.Stop();
                button1.Text = "扫描";
                MessageBox.Show("端口扫描结束！");
                if (myThread != null)//判断线程对象是否为空
                {
                    //判断扫描端口号的线程是否正在运行
                    if (myThread.ThreadState == ThreadState.Running)
                    {
                        myThread.Abort();//终止线程
                    }
                }
            }
        }

    }
}
