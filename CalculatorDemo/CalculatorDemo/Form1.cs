using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CalculatorDemo
{
    public partial class Frm_Main : Form
    {
        private List<double> value_list= new List<double>();//存输入的数字
        private List<int> operator_list = new List<int>();//存运算符，+为0，-为1，*为2，/为3
        private bool add_flag = false;//+按下  
        private bool minus_flag = false;//-按下  
        private bool multi_flag = false;//×按下  
        private bool div_flag = false;//÷按下  
        private bool result_flag = false;//=按下  
        private bool can_operate_flag = false;//按下=是否响应  


        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Num_down(String num) 
        {
            if (add_flag || minus_flag || multi_flag || div_flag || result_flag)
            {
                if (result_flag)
                {
                    label1.Text = "";
                }
                textBox1.Clear();
                add_flag = false;
                minus_flag = false;
                multi_flag = false;
                div_flag = false;
                result_flag = false;
            }
            if ((num.Equals(".") && textBox1.Text.IndexOf(".") < 0) || !(num.Equals(".")))
            {
                textBox1.Text += num;
                label1.Text += num;
                can_operate_flag = true;
            }
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void tramp1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Num_down("1");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Num_down("2");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Num_down("3");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Num_down("4");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Num_down("5");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Num_down("6");
        }
        private void button7_Click(object sender, EventArgs e)
        {
            Num_down("7");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Num_down("8");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Num_down("9");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Num_down("0");
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Num_down(".");
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        //CE键，将所有东西初始化
        private void button12_Click(object sender, EventArgs e)
        {
            operator_list.Clear();
            value_list.Clear();
            add_flag = false;
            minus_flag = false;
            multi_flag = false;
            div_flag = false;
            result_flag = false;
            can_operate_flag = false;
            textBox1.Clear();
            label1.Text = "";
        }
        //+键
        private void button13_Click(object sender, EventArgs e)
        {
            if(!add_flag)
            {
                result_flag=false;
                value_list.Add(double.Parse(textBox1.Text));
                operator_list.Add(0);
                label1.Text+="+";
                add_flag=true;
                can_operate_flag=false;
            }
        }
        //-键
        private void button14_Click(object sender, EventArgs e)
        {
            if (!minus_flag)
            {
                result_flag = false;
                value_list.Add(double.Parse(textBox1.Text));
                operator_list.Add(1);
                label1.Text += "-";
                add_flag = true;
                can_operate_flag = false;
            }
        }
        //*键
        private void button15_Click(object sender, EventArgs e)
        {
            if (!multi_flag)  
            {  
                result_flag = false;  
                value_list.Add(double.Parse(textBox1.Text));  
                operator_list.Add(2);  
                label1.Text = "(" + label1.Text + ")" + "×";//给前面的已经输入的东西加个括号。（运算符栈问题是一个很复杂的数据结构问题，这里不做，：P）  
                multi_flag = true;  
                can_operate_flag = false;  
            }  

        }
        // /键
        private void button16_Click(object sender, EventArgs e)
        {
            if (!div_flag)  
            {  
                result_flag = false;  
                value_list.Add(double.Parse(textBox1.Text));  
               operator_list.Add(3);  
                label1.Text = "(" + label1.Text + ")" + "÷";  
                div_flag = true;  
                can_operate_flag = false;  
            } 

        }
        //=键
        private void button17_Click(object sender, EventArgs e)
        {
            if (value_list.Count > 0 && operator_list.Count > 0 && can_operate_flag)
            {
                value_list.Add(double.Parse(textBox1.Text));
                double total = value_list[0];
                for (int i = 0; i < operator_list.Count; i++)
                {
                    int _operate = operator_list[i];
                    switch (_operate)
                    {
                        case 0: total += value_list[i + 1]; break;
                        case 1: total -= value_list[i + 1]; break;
                        case 2: total *= value_list[i + 1]; break;
                        case 3: total /= value_list[i + 1]; break;
                    }
                }
                textBox1.Text = total + "";
                label1.Text = total + "";
                operator_list.Clear();
                value_list.Clear();
                result_flag = true;
            }
        }

    }
}
