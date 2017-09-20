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
    public partial class frmOutData : Form
    {
        public frmOutData()
        {
            InitializeComponent();
        }
        public string OutTable;
        public string OutData;
        public string strserver;
        public string strUser;
        public string strpwd;
        private void frmOutData_Load(object sender, EventArgs e)
        {
            groupBox1.Text = "数据表名称: " + OutTable;
            try
            {
                using (SqlConnection conn = new SqlConnection("server=" + strserver + ";database=" + OutData + ";Uid=" + strUser + ";pwd=" + strpwd))
                {
                    conn.Open();
                    string strsql = "select * from " + OutTable + "";
                    SqlDataAdapter sda = new SqlDataAdapter(strsql, conn);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    this.dataGridView1.DataSource = dt.DefaultView;
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
                saveASExcel(dataGridView1, true);
            if (radioButton1.Checked == true)
            {
                ExportData(dataGridView1, true);
            }
        }
        private bool ExportData(DataGridView dgv, bool isShowWord)
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
            mydoc = word.Documents.Add(ref myobj, ref myobj, ref myobj, ref myobj);
            word.Visible = isShowWord;
            mydoc.Select();
            mysel = word.Selection;
            mytable = mydoc.Tables.Add(mysel.Range, dgv.RowCount, dgv.ColumnCount, ref myobj, ref myobj);
            mytable.Columns.SetWidth(80, Microsoft.Office.Interop.Word.WdRulerStyle.wdAdjustNone);
            for (int i = 0; i < dgv.ColumnCount; i++)
            {
                mytable.Cell(1, i + 1).Range.InsertAfter(dgv.Columns[i].HeaderText);
            }
            for (int i = 0; i < dgv.RowCount - 1; i++)
            {
                for (int j = 0; j < dgv.ColumnCount; j++)
                {
                    mytable.Cell(i + 2, j + 1).Range.InsertAfter(dgv[j, i].Value.ToString().Trim());
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
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
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
                        excel.Cells[i + 2, j + 1] = dgv[j, i].Value.ToString();
                    }
                }
            }
            return true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //private void ExportData(DataGridView srcDgv, string fileName)
        //{
        //    string type = fileName.Substring(fileName.IndexOf(".") + 1);
        //    if (type.Equals("xls", StringComparison.CurrentCultureIgnoreCase))
        //    {
        //        Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
        //        try
        //        {
        //            excel.DisplayAlerts = false;
        //            excel.Workbooks.Add(true);
        //            excel.Visible = false;
        //            for (int i = 0; i < srcDgv.Columns.Count; i++)
        //            {
        //                excel.Cells[2, i + 1] = srcDgv.Columns[i].HeaderText;
        //            }
        //            for (int i = 0; i < srcDgv.Rows.Count; i++)
        //            {
        //                for (int j = 0; j < srcDgv.Columns.Count; j++)
        //                {
        //                    if (srcDgv[j, i].ValueType.ToString() == "System.Byte[]")
        //                    {
        //                        excel.Cells[i + 3, j = 1] = "System.Byte[]";
        //                    }
        //                    else
        //                    {
        //                        excel.Cells[i + 3, j = 1] = srcDgv[j, i].Value;
        //                    }
        //                }
        //            }
        //            excel.Workbooks[1].SaveCopyAs(fileName);
        //        }

        //        finally
        //        {
        //            excel.Quit();
        //        }
        //        return;
        //    }
        //    if (type.Equals("doc", StringComparison.CurrentCultureIgnoreCase))
        //    {
        //        object path = fileName;
        //        Object None = System.Reflection.Missing.Value;
        //        Microsoft.Office.Interop.Word.Application wordapp = new Microsoft.Office.Interop.Word.Application();
        //        Microsoft.Office.Interop.Word.Document document=wordapp.Documents.Add(ref None,ref None,ref None,ref None);
        //        Microsoft.Office.Interop.Word.Table table = document.Tables.Add(document.Paragraphs.Last.Range,srcDgv.Rows.Count+1,srcDgv.Columns.Count,ref None,ref None);
        //        try
        //        {
        //            for (int i = 0; i < srcDgv.Columns.Count; i++)
        //            {
        //                table.Cell(1, i + 1).Range.Text = srcDgv.Columns[i].HeaderText;
        //            }
        //            for (int i = 0; i < srcDgv.Rows.Count; i++)
        //            {
        //                for (int j = 0; j < srcDgv.Columns.Count; j++)
        //                {
        //                    string a = srcDgv[j, i].ValueType.ToString();
        //                    if (a == "System.Byte[]")
        //                    {
        //                        PictureBox pb = new PictureBox();
        //                        byte[] pic = (byte[])(srcDgv[j, i].Value);
        //                        MemoryStream ms = new MemoryStream(pic);
        //                        pb.Image = Image.FromStream(ms);
        //                        pb.Image.Save(@"C:\22.bmp");
        //                        object aaa = table.Cell(i + 2, j + 1).Range;
        //                        wordapp.Selection.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
        //                        wordapp.Selection.InlineShapes.AddPicture(@"C:\22.bmp", ref None, ref None, ref aaa);
        //                        pb.Dispose();
        //                    }
        //                    else
        //                    {
        //                        table.Cell(i + 2, j + 1).Range.Text = srcDgv[j, i].Value.ToString();
        //                    }
        //                }
        //            }
        //            document.SaveAs(ref path, ref None, ref None, ref None, ref None, ref None, ref None, ref None, ref None, ref None, ref None);
        //            document.Close(ref None, ref None, ref None);
        //            if (File.Exists(@"C:\22.bmp"))
        //            {
        //                File.Delete(@"C:\22.bmp");
        //            }
        //        }
        //        finally
        //        {
        //            wordapp.Quit(ref None, ref None, ref None);
        //        }
        //    }
        //}

    }
}
