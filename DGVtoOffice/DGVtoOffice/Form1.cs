using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.Office.Interop.Word;
using Microsoft.Office.Interop.Excel;


namespace DGVtoOffice
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //实例化连接对象
        SqlConnection conn = new SqlConnection("server=.;database=test;uid=he;pwd=hj.593942539");
        SqlDataAdapter sda;//声明SQLDataAdapter对象
        DataSet ds;//声明DataSet对象
        private void Form1_Load(object sender, EventArgs e)
        {
            sda = new SqlDataAdapter("select * from 员工信息", conn);//实例化SQLDataAdapter对象
            ds = new DataSet();//实例化DataSet对象
            sda.Fill(ds);//填充数据集
            dataGridView1.DataSource = ds.Tables[0];//设置dataGridView的数据源
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ExportDataGridview(dataGridView1, true);//导出Word
        }

        private bool ExportDataGridview(DataGridView dgv, bool isShowWord)
        {
            //实例化Word文档对象
            Microsoft.Office.Interop.Word.Document mydoc = new Microsoft.Office.Interop.Word.Document();
            Microsoft.Office.Interop.Word.Table mytable;//声明Word表格
            Microsoft.Office.Interop.Word.Selection mysel;//声明Word选区
            Object myobj;
            if (dgv.Rows.Count == 0)
            {
                return false;
            }
            //建立Word对象
            Microsoft.Office.Interop.Word.Application word = new Microsoft.Office.Interop.Word.Application();
            myobj = System.Reflection.Missing.Value;
            mydoc = word.Documents.Add(ref myobj,ref myobj,ref myobj,ref myobj);
            word.Visible = isShowWord;
            mydoc.Select();
            mysel = word.Selection;
            //将数据生成Word表格文件
            mytable = mydoc.Tables.Add(mysel.Range,dgv.RowCount,dgv.ColumnCount,ref myobj,ref myobj);
            //设置列宽
            mytable.Columns.SetWidth(80,Microsoft.Office.Interop.Word.WdRulerStyle.wdAdjustNone);
            for (int i = 0; i < dgv.ColumnCount; i++)//输出列标题数据
            {
                mytable.Cell(1, i + 1).Range.InsertAfter(dgv.Columns[i].HeaderText);
            }
            for (int i = 0; i < dgv.RowCount - 1; i++)//输出控件中的记录
            {
                for (int j = 0; j < dgv.ColumnCount; j++)
                {
                    mytable.Cell(i + 2, j + 1).Range.InsertAfter(dgv[j,i].Value.ToString());
                }
            }
            return true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ExportDataGridview2(dataGridView1, true);//导出Excel
        }

        private bool ExportDataGridview2(DataGridView dgv, bool isShowExcel)
        {
            if (dgv.Rows.Count == 0)
            {
                return false;
            }
            //建立Excel对象
            Microsoft.Office.Interop.Excel.Application excel=new Microsoft.Office.Interop.Excel.Application();
            excel.Application.Workbooks.Add(true);
            excel.Visible = isShowExcel;
            //生成字段名称
            for (int i = 0; i < dgv.ColumnCount; i++)
            {
                excel.Cells[1, i + 1] = dgv.Columns[i].HeaderText;
            }
            //填充数据
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
    }
}
