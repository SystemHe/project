using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GetYearDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int year;
            if (int.TryParse(textBox1.Text, out year))
            {
                if (year % 400 == 0 || (year % 4 == 0 && year % 100 != 0))
                {
                    textBox2.Text = year + "年是闰年";
                }
                else
                {
                    textBox2.Text = year + "年不是闰年";
                }

            }
            else {
                MessageBox.Show("请输入年份！！", "出现错误");
            }
        }
    }
}
