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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        public Form3(string text):this()//重载Form3对象将Form1的下拉框的值作为窗口标题
        {
            this.Text = text;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            richTextBox1.Text = "领益科技: http://help.lstech.com/ 东莞领益";
            richTextBox1.Multiline = true;
            richTextBox1.ScrollBars = RichTextBoxScrollBars.Vertical;
            richTextBox1.Font = new Font("楷体", 12, FontStyle.Bold);
            richTextBox1.ForeColor = System.Drawing.Color.BlueViolet;
            richTextBox1.SelectionIndent = 8;
            richTextBox1.SelectionRightIndent = 8;
        }

        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void richTextBox1_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.LinkText);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("请输入要添加的数据！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox1.Focus();
            }
            else
            {
                listBox1.Items.Add(textBox1.Text);
                textBox1.Text = "";
                label1.Text = "共有" + listBox1.Items.Count + "项";
                textBox1.Focus();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItems.Count == 0)
            {
                MessageBox.Show("请选择要删除的数据！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listBox1.Focus();
            }
            else
            {
                listBox1.Items.Remove(listBox1.SelectedItem);
                
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label1.Text = "共有" + listBox1.Items.Count + "项,选择了" + listBox1.SelectedItems.Count.ToString() + "项";
        }
    }
}
