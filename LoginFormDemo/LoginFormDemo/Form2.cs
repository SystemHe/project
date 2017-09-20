using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LoginFormDemo
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;//设置为无标题栏窗体
            this.BackgroundImage = Image.FromFile("logo1.ipg");
            this.timer1.Start();
            this.timer1.Interval = 1000;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int i = 10;
            progressBar1.Maximum = 10;
            progressBar1.Minimum = 0;
            progressBar1.Value = progressBar1.Value + 5;
            i = 10 - progressBar1.Value;
            if(i==0)
            this.Close();
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.timer1.Stop();
        }

        private void Form2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
