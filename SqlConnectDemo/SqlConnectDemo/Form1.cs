using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SqlConnectDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection conn;
        private void Form1_Load(object sender, EventArgs e)
        {
            //初始化连接字符串，建立连接
            conn = new SqlConnection("server=.;database=test;uid=he;pwd=hj.593942539");
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Open || textBox1.Text != "")
                {
                    SqlCommand cmd = new SqlCommand();//创建一个sqlcommand对象
                    conn.Open();//打开连接
                    cmd.Connection = conn;//设置connection属性
                    //设置commandText属性，设置查询语句
                    cmd.CommandText = "select count(*) from " + textBox1.Text.Trim();
                    //设置CommandType属性为Text，使其只执行SQL语句文本格式
                    cmd.CommandType = CommandType.Text;
                    //使用ExecuteScalar获取指定数据表中的数据的数量
                    int i = Convert.ToInt32(cmd.ExecuteScalar());
                    label2.Text = "共有:" + i.ToString() + "条数据";
                    textBox2.Text = cmd.CommandText;
                    conn.Close();//关闭连接
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
