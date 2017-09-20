using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace UseInsertSelect
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str_conn = string.Format(@"server=.;database=test;uid=he;pwd=hj.593942539");
            string str_sqlstr = string.Format(@"insert into 部门信息_copy(部门编号,部门名称,员工编号,公司编号)  select 部门编号,部门名称,员工编号,公司编号 from 部门信息");
            SqlConnection conn = new SqlConnection(str_conn);
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(str_sqlstr, conn);
                if (cmd.ExecuteNonQuery() != 0)
                {
                    MessageBox.Show("成功写入数据", "提示");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误");
            }
            finally
            {
                conn.Close();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("server=.;database=test;uid=he;pwd=hj.593942539");
            SqlCommand cmd = new SqlCommand("select * from 部门信息",conn);
            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = cmd;
            DataSet ds = new DataSet();
            sda.Fill(ds,"部门信息");
            dataGridView1.DataSource = ds.Tables[0];
        }
    }
}
