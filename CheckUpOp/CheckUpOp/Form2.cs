using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CheckUpOp
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form3 frm3 = new Form3();
            frm3.Show();
            this.Hide();
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form1 frm1 = new Form1();
            frm1.Show();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            string[] strCaiDan={"豆角炒肉","西红柿炒蛋","小鸡炖蘑菇","酸菜炖肉","地三鲜"};
            for(int i=0;i<strCaiDan.Length;i++)
            {
                listBox1.Items.Add(strCaiDan[i]);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                listBox1.SelectedIndex = i;
                if (!listBox2.Items.Contains(listBox1.Text))
                {
                    listBox2.Items.Add(listBox1.SelectedItem.ToString());
                }
                else 
                {
                    MessageBox.Show("您已经选择该菜品！", "提示");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex!=-1)
            {
                if (!listBox2.Items.Contains(listBox1.Text))
                {
                    listBox2.Items.Add(listBox1.SelectedItem.ToString());
                }
                else
                {
                    MessageBox.Show("您已经选择该菜品！", "提示");
                }
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox2.SelectedIndex != -1)
            {
                listBox2.Items.Remove(listBox2.SelectedItem);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
        }
    }
}
