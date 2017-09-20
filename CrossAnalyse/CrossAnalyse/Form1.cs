using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CrossAnalyse
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            binginfo();
        }
        #region 根据指定的条件使用交叉表查询数据
        /// <summary>
        /// 根据指定的条件使用交叉表查询数据
        /// </summary>
        private void binginfo()
        {
            SqlConnection conn = new SqlConnection("server=.;database=test;uid=he;pwd=hj.593942539");
            SqlCommand cmd = new SqlCommand("proc_across_table", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@TableName", SqlDbType.VarChar, 50).Value = "商品销售表";
            if (comboBox1.Text == comboBox2.Text)
            {
                MessageBox.Show("表头字段和分组字段不能相同", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            cmd.Parameters.Add("@NewColumn", SqlDbType.VarChar, 50).Value = comboBox1.Text;
            cmd.Parameters.Add("@GroupColumn", SqlDbType.VarChar, 50).Value = comboBox2.Text;
            cmd.Parameters.Add("@StatColumn", SqlDbType.VarChar, 50).Value = "订货数量";
            cmd.Parameters.Add("@Operator", SqlDbType.VarChar, 10).Value = "SUM";
            SqlDataAdapter sda = new SqlDataAdapter();//实例化SQLDataAdapter对象
            sda.SelectCommand = cmd;
            DataSet ds = new DataSet();//实例化数据集对象
            sda.Fill(ds);//填充数据集
            dataGridView1.DataSource = ds.Tables[0];//为dataGridView设置数据源
            dataGridView1.Columns[1].Width = 120;//设置列宽
        }
        #endregion
    }
}
