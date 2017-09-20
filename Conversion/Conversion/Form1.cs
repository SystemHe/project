using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;

namespace Conversion
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Action();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "输入出错，请重新输入", "出现错误");
            }
        }
        private void Action()
        {
                long value;
                int temp = Convert.ToInt32(textBox1.Text.Trim());
                if (long.TryParse(textBox1.Text, out value))
                {
                    if (comboBox1.SelectedIndex == 0)
                    {
                        switch (comboBox2.SelectedIndex)
                        {
                            case 0: textBox2.Text = textBox1.Text; break;
                            case 1: textBox2.Text = Convert.ToString(temp, 2).ToString(); break;
                            case 2: textBox2.Text = Convert.ToString(temp, 8).ToString(); break;
                            case 3: textBox2.Text = Convert.ToString(temp, 16).ToString(); break;
                        }
                    }
                    else if (comboBox1.SelectedIndex == 1)
                    {
                        switch (comboBox2.SelectedIndex)
                        {
                            case 0: textBox2.Text = Convert.ToInt32(temp.ToString(), 2).ToString(); break;
                            case 1: textBox2.Text = textBox1.Text; break;
                            case 2: textBox2.Text = Convert.ToString(Convert.ToInt32(temp.ToString(), 2), 8).ToString(); break;
                            case 3: textBox2.Text = Convert.ToString(Convert.ToInt32(temp.ToString(), 2), 16).ToString(); break;
                        }
                    }
                    else if (comboBox1.SelectedIndex == 2)
                    {
                        switch (comboBox2.SelectedIndex)
                        {
                            case 0: textBox2.Text = Convert.ToString(Convert.ToInt32(temp.ToString(), 8), 2); break;
                            case 1: textBox2.Text = Convert.ToInt32(temp.ToString(), 8).ToString(); break;
                            case 2: textBox2.Text = textBox1.Text; break;
                            case 3: textBox2.Text = Convert.ToString(Convert.ToInt32(temp.ToString(), 8), 16); break;

                        }
                    }
                    else
                    {
                        switch (comboBox2.SelectedIndex)
                        {
                            case 0: textBox2.Text = Convert.ToString(Convert.ToInt32(temp.ToString(), 16), 2); break;
                            case 1: textBox2.Text = Convert.ToInt32(temp.ToString(), 16).ToString(); break;
                            case 2: textBox2.Text = Convert.ToString(Convert.ToInt32(temp.ToString(), 16), 8); break;
                            case 3: textBox2.Text = textBox1.Text; break;

                        }
                    }
                }
                else
                    MessageBox.Show("请输入正确数值", "出现错误");
        }
    }
}
