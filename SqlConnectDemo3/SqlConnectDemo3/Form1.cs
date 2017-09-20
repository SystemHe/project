using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SqlConnectDemo3
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
            conn = new SqlConnection("server=.;database=test;uid=he;pwd=hj.593942539");
            SqlCommand cmd = new SqlCommand("select * from 员工信息", conn);
            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = cmd;
            DataSet ds = new DataSet();
            sda.Fill(ds, "员工信息");
            dataGridView1.DataSource = ds.Tables[0];
        }
    }
}
