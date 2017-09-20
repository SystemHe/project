using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EncryptDemo
{
    public partial class frm_Main : Form
    {
        public frm_Main()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int Num, key;
            if (int.TryParse(textBox1.Text, out Num) && int.TryParse(textBox2.Text, out key))
            {
                textBox3.Text = (Num ^ key).ToString();
            }
            else
            {
                MessageBox.Show("请输入数值","出现错误！！");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int key, jmh;
            if (int.TryParse(textBox3.Text, out key)&&int.TryParse(textBox2.Text,out jmh))
            {
                textBox4.Text = (key ^ jmh).ToString();
            }
            else
            {
                MessageBox.Show("请输入数值", "出现错误！！");
            }
        }
    }
}
