using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace UsePagination
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static int Num = 0, AllCount = 0;
        int Size = 4;
        SqlConnection conn;
        private void Form1_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection("server=.;database=test;uid=he;pwd=hj.593942539");
            SqlDataAdapter sda=new SqlDataAdapter("select * from 员工信息",conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            int i = dt.Rows.Count;
            AllCount = i;
            int m = i % Size;
            if (m == 0)
            {
                m = i / Size;
            }
            else 
            {
                m = i / Size + 1;
            }
            this.label3.Text = m.ToString();
            Show(0, 4);
            this.label4.Text = "1";
        }

        private void Show(int i, int j)
        {
            conn = new SqlConnection("server=.;database=test;uid=he;pwd=hj.593942539");
            SqlDataAdapter sdaone = new SqlDataAdapter("select * from 员工信息", conn);
            DataSet dsone = new DataSet();
            sdaone.Fill(dsone,i,j,"员工信息");
            this.dataGridView1.DataSource = dsone.Tables["员工信息"].DefaultView;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.dataGridView1.DataSource = null;
            int m = Convert.ToInt32(this.label4.Text) - 1;
            if (m < 1)
            {
                this.label4.Text = "1";
            }
            else
            {
                this.label4.Text = m.ToString();
            }
            int a = Convert.ToInt32(this.label4.Text) * 4 - 4;
            Show(a, 4);
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.dataGridView1.DataSource = null;
            int m = Convert.ToInt32(this.label4.Text) + 1;
            if (m > Convert.ToInt32(this.label3.Text))
            {
                this.label4.Text = this.label3.Text;
            }
            else
            {
                this.label4.Text = m.ToString();
            }
            int a = Convert.ToInt32(this.label4.Text) * 4 - 4;
            Show(a, 4);
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
