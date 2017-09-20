using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SqlInsertChange
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection conn;//声明一个SQLConnection变量
        SqlDataAdapter adapter;//声明一个SQLDataAdapter变量
        int intindex = 0;//记录行索引
        private void Form1_Load(object sender, EventArgs e)
        {
            //实例化数据库连接对象conn
            conn = new SqlConnection("server=.;database=test;uid=he;pwd=hj.593942539");
            //实例化SQLCommand对象
            SqlCommand cmd = new SqlCommand("select * from 部门信息", conn);
            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = cmd;
            DataSet ds = new DataSet();
            sda.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.Green;//改选中单元格的背景颜色
            dataGridView1.Columns[0].ReadOnly = true;//第一列只读，不能修改
        }

        private DataTable dataTable(string strsql)
        {
            this.adapter = new SqlDataAdapter(strsql,conn);
            DataTable dtselect = new DataTable();
            int rnt = this.adapter.Fill(dtselect);
            return dtselect;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dbUpdate())
            {
                MessageBox.Show("修改成功！");
            }
            Form1_Load(sender, e);
        }

        private Boolean dbUpdate()
        {
            string strSql = "select * from 部门信息";
            DataTable dtUpdate = new DataTable();
            dtUpdate = this.dataTable(strSql);
            dtUpdate.Rows.Clear();
            DataTable dtShow = new DataTable();
            dtShow = (DataTable)this.dataGridView1.DataSource;
            dtUpdate.ImportRow(dtShow.Rows[intindex]);
            try
            {
                SqlCommandBuilder commandbuilder;
                commandbuilder = new SqlCommandBuilder(this.adapter);
                this.adapter.Update(dtUpdate);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                return false;
            }
            dtUpdate.AcceptChanges();
            return true;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            intindex = e.RowIndex;
        }

    }
}
