using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AscllDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != string.Empty)
            {
                if (Encoding.GetEncoding("unicode").GetBytes(new char[] { textBox1.Text[0] })[1] == 0)
                {
                    textBox2.Text = Encoding.GetEncoding("unicode").GetBytes(textBox1.Text)[0].ToString();
                }
                else
                {
                    textBox2.Text = string.Empty;
                    MessageBox.Show("请输入字母！！", "提示");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox3.Text != string.Empty)
            {
                int Num;
                if (int.TryParse(textBox3.Text, out Num))
                {
                    textBox4.Text = ((char)Num).ToString();
                }
                else
                {
                    MessageBox.Show("请输入正确的ASCll码", "提示");
                }
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            textBox6.Text = new PinYin().GetABC(textBox5.Text);
        }
    }
}
