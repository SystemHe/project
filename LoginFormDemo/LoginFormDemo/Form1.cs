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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("用户名不能为空，请重新输入", "错误信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox1.Focus();
            }
            else if (textBox2.Text == "")
            { 
                MessageBox.Show("请输入密码！","提示",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                textBox2.Focus();
            }
            else
            {
                if (textBox1.Text.ToLower() == "test" && textBox2.Text == "1111")
                {
                    MessageBox.Show("登录成功", "成功", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Form3 frm3=new Form3(comboBox1.Text);
                    frm3.Show();
                    this.Hide();
                }
                else
                    MessageBox.Show("登录失败", "失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox2.Text = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2();
            frm2.ShowDialog();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox1.SelectAll();

        }

        
    }
}
