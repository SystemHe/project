﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PWMS.PerForm
{
    public partial class F_HaveBack : Form
    {
        public F_HaveBack()
        {
            InitializeComponent();
        }
        DataClass.MyMeans MyDataClass = new PWMS.DataClass.MyMeans();
        ModuleClass.MyModule MyMC = new PWMS.ModuleClass.MyModule();
        private void button1_Click(object sender, EventArgs e)
        {
            string Str_dar = "";
            if (radioButton1.Checked == true)
                Str_dar = System.Environment.CurrentDirectory + "\\bar\\";
            if (radioButton2.Checked == true)
                Str_dar = textBox2.Text + "\\";
            if (textBox2.Text == "" & radioButton2.Checked == true)
            {
                MessageBox.Show("请选择备份数据库文件的路径。");
                return;
            }
            try
            {
                Str_dar = "backup database db_PWMS to disk='" + Str_dar + (System.DateTime.Now.ToShortDateString()).ToString() + MyMC.Time_Format(System.DateTime.Now.ToString()) + ".bak" + "'";
                MyDataClass.getsqlcom(Str_dar);
                MessageBox.Show("数据备份成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog(this) == DialogResult.OK)
            {
                textBox2.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                MessageBox.Show("请选择备份数据库文件的路径。");
                return;
            }
            try
            {
                if (DataClass.MyMeans.My_con.State == ConnectionState.Open)
                {
                    DataClass.MyMeans.My_con.Close();
                }
                string DateStr = "Data Source=.;Database=master;User id=he;PWD=hj.593942539";
                SqlConnection conn = new SqlConnection(DateStr);
                conn.Open();

                //-------------------杀掉所有连接 db_PWMS 数据库的进程--------------
                string strSQL = "select spid from master..sysprocesses where dbid=db_id( 'db_PWMS') ";
                SqlDataAdapter Da = new SqlDataAdapter(strSQL, conn);

                DataTable spidTable = new DataTable();
                Da.Fill(spidTable);

                SqlCommand Cmd = new SqlCommand();
                Cmd.CommandType = CommandType.Text;
                Cmd.Connection = conn;

                for (int iRow = 0; iRow <= spidTable.Rows.Count - 1; iRow++)
                {
                    Cmd.CommandText = "kill " + spidTable.Rows[iRow][0].ToString();   //强行关闭用户进程 
                    Cmd.ExecuteNonQuery();
                }
                conn.Close();
                conn.Dispose();
                //--------------------------------------------------------------------

                SqlConnection Tem_con = new SqlConnection(DateStr);
                Tem_con.Open();
                SqlCommand SQLcom = new SqlCommand("backup log db_PWMS to disk='" + textBox3.Text.Trim() + "' restore database db_PWMS from disk='" + textBox3.Text.Trim() + "'", Tem_con);
                SQLcom.ExecuteNonQuery();
                SQLcom.Dispose();
                Tem_con.Close();
                Tem_con.Dispose();
                MessageBox.Show("数据还原成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                MyDataClass.con_open();
                MyDataClass.con_close();
                MessageBox.Show("为了避免数据丢失，在数据库原还后将关闭整个系统。");
                Application.Exit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "*.bak|*.bak";
            if (openFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                textBox3.Text = openFileDialog1.FileName;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
