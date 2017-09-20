using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace hebingDataGridView
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        #region 声明的变量
        static string strconn = "server=.;database=test;uid=he;pwd=hj.593942539";
        SqlConnection conn = new SqlConnection(strconn);
        SqlDataAdapter sda;
        DataSet ds = new DataSet();
        #endregion 
        #region 显示数据
        private void Form1_Load(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Closed)//判断数据库是否关闭
                conn.Open();//打开数据库连接
            string strSelect = "select * from 员工信息";
            sda = new SqlDataAdapter(strSelect, conn);//实例化填充数据集和更新数据库的对象
            sda.Fill(ds);//填充DataSet数据集
            dataGridView1.DataSource = ds.Tables[0];//为dataGridView设置数据源
            conn.Close();//关闭数据库连接
        }
        #endregion 
        #region 合并列内容相同的单元格
        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            //对第一列相同单元格进行合并
            if(e.ColumnIndex==2&&e.RowIndex !=-1||e.ColumnIndex==3&&e.RowIndex!=-1||e.ColumnIndex==4&&e.RowIndex!=-1)
            {
                Brush datagridBrush=new SolidBrush(dataGridView1.GridColor);
                SolidBrush groupLineBrush=new SolidBrush(e.CellStyle.BackColor);
                using (Pen datagridLinePen=new Pen(datagridBrush))
                {
                    //清除单元格
                    e.Graphics.FillRectangle(groupLineBrush,e.CellBounds);
                    if(e.RowIndex<dataGridView1.Rows.Count-1&&dataGridView1.Rows[e.RowIndex+1].Cells[e.ColumnIndex].Value!=null&&dataGridView1.Rows[e.RowIndex+1].Cells[e.ColumnIndex].Value.ToString()!=e.Value.ToString())
                    {
                        //绘制底边线
                        e.Graphics.DrawLine(datagridLinePen,e.CellBounds.Left,e.CellBounds.Bottom-1,e.CellBounds.Right,e.CellBounds.Bottom-1);
                        //绘制右边线
                        e.Graphics.DrawLine(datagridLinePen,e.CellBounds.Right-1,e.CellBounds.Top,e.CellBounds.Right-1,e.CellBounds.Bottom);
                    }
                    else 
                    {
                        //画右边线
                        e.Graphics.DrawLine(datagridLinePen,e.CellBounds.Right-1,e.CellBounds.Top,e.CellBounds.Right-1,e.CellBounds.Bottom);
                    }
                    if(e.RowIndex==dataGridView1.Rows.Count-1)//对最后一行只画底边线
                    {
                        //绘制底边线
                        e.Graphics.DrawLine(datagridLinePen,e.CellBounds.Left,e.CellBounds.Bottom-1,e.CellBounds.Right,e.CellBounds.Bottom-1);
                    }
                    if(e.Value!=null)//填写单元格内容，相同内容的单元格只填写第一个
                    {
                        if(!(e.RowIndex>0&&dataGridView1.Rows[e.RowIndex-1].Cells[e.ColumnIndex].Value.ToString()==e.Value.ToString()))
                        {
                            //绘制单元格内容
                            e.Graphics.DrawString(e.Value.ToString(),e.CellStyle.Font,Brushes.Black,e.CellBounds.X+2,e.CellBounds.Y+5,StringFormat.GenericDefault);
                        }
                    }
                    e.Handled=true;
                }
            }
        }
        #endregion
    }
}
