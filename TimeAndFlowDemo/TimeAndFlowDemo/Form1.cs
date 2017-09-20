using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TimeAndFlowDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private MyNetWorkMatchClass[] m_MNWMadapters;
        private MyNetWorkMonitor monitor;
        private void Form1_Load(object sender, EventArgs e)
        {
            monitor = new MyNetWorkMonitor();
            m_MNWMadapters = monitor.Adapters;   //获得控制器MyNetWorkMonitor上所有计算机的适配器列表

            if (m_MNWMadapters.Length == 0)
            {
                listBox1.Enabled = false;
                MessageBox.Show("在计算机上没有找到网络适配器");
                return;
            }

            listBox1.Items.AddRange(m_MNWMadapters); 

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            monitor.StopMonitoring();
            monitor.StartMonitoring(m_MNWMadapters[listBox1.SelectedIndex]);     //控制该适配器开始工作
            this.timer1.Start();                                      //计时开始
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            MyNetWorkMatchClass adapter = m_MNWMadapters[listBox1.SelectedIndex];    //该适配器
            textBox1.Text = String.Format("{0:n} kbps", adapter.DownloadSpeedKbps);   //得到该适配器的下载速度
            textBox2.Text = String.Format("{0:n} kbps", adapter.UploadSpeedKbps);     //得到该适配器的上传速度
        }

    }
}
