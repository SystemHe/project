using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SqlConnectDemo2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection conn;
        private void button1_Click(object sender, EventArgs e)
        {
            //实例化SQLConnection变量conn
            conn = new SqlConnection("server=.;database=test;uid=he;pwd=hj.593942539");
            conn.Open();//打开连接
            SqlCommand cmd = new SqlCommand();//创建一个SQLCommand对象
            cmd.Connection = conn;//设置connection属性，指定其使用conn连接数据库
            //设置CommandText属性，设置其执行的SQL语句
            cmd.CommandText = "select * from 员工信息";
            //设置CommandType属性为Text，使其只执行SQL语句的文本格式
            cmd.CommandType = CommandType.Text;
            //使用ExecuteReader实例化一个SQLDataReader对象
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())//读取SQLDataReader
            {
                listView1.Items.Add(sdr[1].ToString());//将内容添加到ListView

            }
            conn.Dispose();//释放连接
            button1.Enabled = false;//禁用按钮
        }
    }
}
