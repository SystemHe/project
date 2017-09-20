using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SqlConnectionDemo4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection conn;
        DataSet ds;
        SqlDataAdapter sda;
        private void Form1_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection("server=.;database=test;uid=he;pwd=hj.593942539");
            SqlCommand cmd = new SqlCommand("select * from 员工信息", conn);
            sda = new SqlDataAdapter();//实例化SQLDataAdapter对象
            sda.SelectCommand = cmd;//设置SQLDataAdapter对象的SelectCommand属性为cmd
            ds = new DataSet();//实例化DataSet对象
            sda.Fill(ds, "员工信息");//使用SQLDataAdapter对象的Fill方法填充DataSet
            dataGridView1.DataSource = ds.Tables[0];//设置dataGridView的数据源
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dt = ds.Tables["员工信息"];//创建一个DataTable对象
            sda.FillSchema(dt, SchemaType.Mapped);//把表结构加载到tb_Command表中
            DataRow dr = dt.Rows.Find(textBox1.Text);//创建一个DataRow
            //设置DataRow中的值
            dr["员工姓名"] = textBox2.Text.Trim();
            dr["性别"] = this.textBox3.Text.Trim();
            dr["年龄"] = this.textBox4.Text.Trim();
            dr["电话"] = this.textBox5.Text.Trim();
            dr["地址"] = this.textBox6.Text.Trim();
            dr["邮箱"] = this.textBox7.Text.Trim();
            dr["员工状态"] = this.textBox8.Text.Trim();
            //实例化一个SQLCommandBuilder
            SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(sda);
            //通过Update方法将DataTable更新到数据表中
            sda.Update(dt);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedCells[0].Value.ToString();
            textBox2.Text = dataGridView1.SelectedCells[1].Value.ToString();
            textBox3.Text = dataGridView1.SelectedCells[2].Value.ToString();
            textBox4.Text = dataGridView1.SelectedCells[3].Value.ToString();
            textBox5.Text = dataGridView1.SelectedCells[4].Value.ToString();
            textBox6.Text = dataGridView1.SelectedCells[5].Value.ToString();
            textBox7.Text = dataGridView1.SelectedCells[6].Value.ToString();
            textBox8.Text = dataGridView1.SelectedCells[7].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CopyDataGrideView frm2 = new CopyDataGrideView(this);
            frm2.Show();
            this.Hide();
        }
    }
}
