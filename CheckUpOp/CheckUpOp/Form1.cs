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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void ckInfo_CheckedChanged(object sender, EventArgs e)
        {
            if (ckInfo.Checked == true)
            {
                cklInfo.Visible = true;
                CheckAll(cklInfo);
            }
            else 
            {
                cklInfo.Visible = false;
                CheckAllEsce(cklInfo);
            }
        }

        private void CheckAllEsce(object checkList)
        {
            if (checkList.GetType().ToString() == "System.Windows.Forms.CheckedListBox")
            {
                CheckedListBox ckl = (CheckedListBox)checkList;
                for (int i = 0; i < ckl.Items.Count; i++)
                {
                    ckl.SetItemCheckState(i, CheckState.Unchecked);
                }
            }
        }

        private void CheckAll(object checkList)
        {
            if (checkList.GetType().ToString() == "System.Windows.Forms.CheckedListBox")
            {
                CheckedListBox ckl = (CheckedListBox)checkList;
                for (int i = 0; i < ckl.Items.Count; i++)
                {
                    ckl.SetItemCheckState(i, CheckState.Checked);
                }
            }
        }

        private void ckShop_CheckedChanged(object sender, EventArgs e)
        {
            if (ckShop.Checked == true)
            {
                cklShop.Visible = true;
                CheckAll(cklShop);
            }
            else
            {
                cklShop.Visible = false;
                CheckAllEsce(cklShop);
            }

        }

        private void ckSell_CheckedChanged(object sender, EventArgs e)
        {
            if (ckSell.Checked == true)
            {
                cklSell.Visible = true;
                CheckAll(cklSell);
            }
            else
            {
                cklSell.Visible = false;
                CheckAllEsce(cklSell);
            }
        }

        private void ckManage_CheckedChanged(object sender, EventArgs e)
        {
            if (ckManage.Checked == true)
            {
                cklManage.Visible = true;
                CheckAll(cklManage);
            }
            else
            {
                cklManage.Visible = false;
                CheckAllEsce(cklManage);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("用户名不能为空！", "提示");
                    return;
                }
                if (textBox2.Text == "")
                {
                    MessageBox.Show("密码不能为空！", "提示");
                    return;
                }
                if (radioButton1.Checked == false && radioButton2.Checked == false)
                {
                    MessageBox.Show("请选择用户性别！", "提示");
                    return;
                }
                if (ckInfo.Checked == false && ckShop.Checked == false && ckSell.Checked == false && ckManage.Checked == false)
                {
                    MessageBox.Show("请至少选择一项用户权限！", "提示");
                    return;
                }
                string strName = textBox1.Text.Trim();
                string strPassword = textBox2.Text;
                string strPhone = textBox3.Text;
                string strEmail = textBox4.Text;
                string strAddress = textBox5.Text;
                string strSex;
                if (radioButton1.Checked == true)
                    strSex = "男";
                else
                    strSex = "女";
                string strKCGL = "库存管理: " + "\n";
                string strXSGL = "销售管理: " + "\n";
                string strJHGL = "进货管理: " + "\n";
                string strJBQX = "基本权限: " + "\n";
                if (cklInfo.Visible == true)
                {
                    for (int i = 0; i < cklInfo.CheckedItems.Count; i++)
                    {
                        strJBQX += "    " + cklInfo.CheckedItems[i].ToString() + "\n";
                    }
                }
                if (cklShop.Visible == true)
                {
                    for (int i = 0; i < cklShop.CheckedItems.Count; i++)
                    {
                        strJHGL += "    "+cklShop.CheckedItems[i].ToString() + "\n";
                    }
                }
                if (cklSell.Visible == true)
                {
                    for (int i = 0; i < cklSell.CheckedItems.Count; i++)
                    {
                        strXSGL += "    " + cklSell.CheckedItems[i].ToString() + "\n";
                    }
                }
                if (cklManage.Visible == true)
                {
                    for (int i = 0; i < cklManage.CheckedItems.Count; i++)
                    {
                        strKCGL += "    " + cklManage.CheckedItems[i].ToString() + "\n";
                    }
                }
                MessageBox.Show("注册信息如下：" + "\n" + "姓名：" + strName + "\n" + "密码：" + strPassword + "\n" + "电话：" + strPhone + "\n" + "邮箱：" + strEmail + "\n" + "地址：" + strAddress + "\n" + "性别：" + strSex + "\n" + "用户权限如下：" + "\n" + strJBQX + strJHGL + strXSGL + strKCGL, "信息确认");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            frm.Show();
            this.Hide();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

    }
}
