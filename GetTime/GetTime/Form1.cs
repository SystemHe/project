using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GetTime
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Interval = 1000;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            textBox1.Text = DateTime.Now.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "开始")
            {
                timer1.Start();
                button1.Text = "停止";
            }
            else
            {
                timer1.Stop();
                button1.Text = "开始";
            }
            progressBar1.Value = 0;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 500;
            progressBar1.Step = 1;
            for (int i = 0; i < 500; i++)
            {
                progressBar1.PerformStep();
                textBox2.Text = "当前进度：" + progressBar1.Value.ToString();
            }
        }
    }
}
