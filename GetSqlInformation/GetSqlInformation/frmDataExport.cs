using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace GetSqlInformation
{
    public partial class frmDataExport : Form
    {
        public frmDataExport()
        {
            InitializeComponent();
        }
        public string OutTable;
        public string OutData;
        public string strserver;
        public string strUser;
        public string strpwd;
        private void frmDataExport_Load(object sender, EventArgs e)
        {
            groupBox2.Text = "数据表名称: " + OutTable;
            try
            {
                using (SqlConnection conn = new SqlConnection("server=" + strserver + ";database=" + OutData + ";Uid=" + strUser + ";pwd=" + strpwd))
                {
                    conn.Open();
                    string strsql = "select name 字段名,xusertype 类型编号,length 长度 into hy_linshibiao from syscolumns where id=object_id('" + OutTable + "')";
                    strsql += "select name 类型,xusertype 类型编号 into angel_linshibiao from systypes where xusertype in (select xusertype from syscolumns where id=object_id('" + OutTable + "') )";
                    SqlCommand cmd = new SqlCommand(strsql, conn);
                    cmd.ExecuteNonQuery();
                    SqlDataAdapter sda = new SqlDataAdapter("select 字段名,类型,长度 from hy_linshibiao t,angel_linshibiao b where t.类型编号=b.类型编号", conn);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    this.dataGridView1.DataSource = dt.DefaultView;
                    SqlCommand cmdnew = new SqlCommand("drop table hy_linshibiao ,angel_linshibiao ", conn);
                    cmdnew.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"警告",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
                saveASExcel(dataGridView1,true);
            if (radioButton1.Checked == true)
            {
                ExportData(dataGridView1,true);
            }
        }

        private bool ExportData(DataGridView dgv,bool isShowWord)
        {
            Microsoft.Office.Interop.Word.Document mydoc = new Microsoft.Office.Interop.Word.Document();
            Microsoft.Office.Interop.Word.Table mytable;
            Microsoft.Office.Interop.Word.Selection mysel;
            Object myobj;
            if (dgv.Rows.Count == 0)
            {
                return false;
            }
            Microsoft.Office.Interop.Word.Application word = new Microsoft.Office.Interop.Word.Application();
            myobj = System.Reflection.Missing.Value;
            mydoc = word.Documents.Add(ref myobj,ref myobj,ref myobj,ref myobj);
            word.Visible = isShowWord;
            mydoc.Select();
            mysel = word.Selection;
            mytable = mydoc.Tables.Add(mysel.Range,dgv.RowCount,dgv.ColumnCount,ref myobj,ref myobj);
            mytable.Columns.SetWidth(80,Microsoft.Office.Interop.Word.WdRulerStyle.wdAdjustNone);
            for (int i = 0; i < dgv.ColumnCount; i++)
            {
                mytable.Cell(1, i + 1).Range.InsertAfter(dgv.Columns[i].HeaderText);
            }
            for (int i = 0; i < dgv.RowCount - 1; i++)
            {
                for (int j = 0; j < dgv.ColumnCount; j++)
                {
                    mytable.Cell(i + 2, j + 1).Range.InsertAfter(dgv[j,i].Value.ToString());
                }
            }
            return true;
        }
        private bool saveASExcel(DataGridView dgv, bool isShowExcel)
        {
            if (dgv.Rows.Count == 0)
            {
                return false;
            }
            Microsoft.Office.Interop.Excel.Application excel=new Microsoft.Office.Interop.Excel.Application();
            excel.Application.Workbooks.Add(true);
            excel.Visible = isShowExcel;
            for (int i = 0; i < dgv.ColumnCount; i++)
            {
                excel.Cells[1, i + 1] = dgv.Columns[i].HeaderText;
            }
            for (int i = 0; i < dgv.RowCount - 1; i++)
            {
                for (int j = 0; j < dgv.ColumnCount; j++)
                {
                    if (dgv[j, i].ValueType == typeof(string))
                    {
                        excel.Cells[i + 2, j + 1] = "'" + dgv[j, i].Value.ToString();
                    }
                    else
                    {
                        excel.Cells[i + 2, j + 1] =dgv[j, i].Value.ToString();
                    }
                }
            }
            return true;
        }

            private void button2_Click(object sender, EventArgs e)
            {
                this.Close();
            }

    }
}
