using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace AutoID
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection("server=.;database=test;uid=he;pwd=hj.593942539"))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();//实例化SQLCommand对象
                //定义SQL语句
                string strSql = "insert into 员工个人信息 values('" + label2.Text + "','" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "')";
                cmd.CommandText = strSql;//指定要执行的SQL语句
                cmd.Connection = conn;//指定数据库连接对象
                cmd.ExecuteNonQuery();//执行数据库操作
                conn.Close();//关闭数据库连接
                MessageBox.Show("添加成功！");
                this.groupBox1.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.label2.Text = strid();
        }
        private string strid()
        {
            using (SqlConnection conn = new SqlConnection("server=.;database=test;uid=he;pwd=hj.593942539")) 
            {
                try
                {
                    SqlCommand cmd = new SqlCommand();//实例化SQLCommand对象
                    cmd.CommandType = CommandType.StoredProcedure;//指定执行存储过程
                    cmd.Connection = conn;//指定数据库连接对象
                    cmd.Connection.Open();//打开书籍库连接
                    cmd.CommandText = "Proc_IdS";//指定要执行的存储过程名
                    SqlParameter par = new SqlParameter("@ID", SqlDbType.VarChar, 50);
                    par.Direction = ParameterDirection.Output;//指定输出参数
                    cmd.Parameters.Add(par);//向命令中添加参数
                    cmd.ExecuteNonQuery();//执行存储过程
                    this.groupBox1.Enabled = true;//设置groupBox可用
                    return par.Value.ToString();//返回生成的编号
                }
                catch (Exception ey)
                {
                    MessageBox.Show(ey.Message);
                    return null;
                }
            }
        }
    }
}
