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
    public partial class CopyDataGrideView : Form
    {
        public CopyDataGrideView()
        {
            InitializeComponent();
        }
        public Form proForm = new Form();
        public CopyDataGrideView(Form frm)
        {
            InitializeComponent();
            proForm = frm;
        }

        SqlConnection conn;
        DataSet ds;
        private void CopyDataGrideView_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection("server=.;database=test;uid=he;pwd=hj.593942539");
            SqlCommand cmd = new SqlCommand("select * from 员工信息",conn);
            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = cmd;
            ds = new DataSet();
            sda.Fill(ds, "员工信息");
            dataGridView1.DataSource = ds.Tables[0];
        }


        private void CopyDataGrideView_FormClosed(object sender, FormClosedEventArgs e)
        {
            proForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataSet ds1 = ds.Copy();
            dataGridView2.DataSource = ds1.Tables[0];
        }
    }
}
