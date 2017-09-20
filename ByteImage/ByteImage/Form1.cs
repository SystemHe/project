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

namespace ByteImage
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        #region 定义公共的类对象及变量
        SqlConnection conn;
        SqlDataAdapter sda;
        DataSet ds;
        string str = "server=.;database=test;uid=he;pwd=hj.593942539";
        #endregion
        private void button1_Click(object sender, EventArgs e)
        {
            //定义可选择的头像图片类型
            openFileDialog1.Filter = "*.jpg,*.jpeg,*.ico,*.bmp,*.png,*.tif,*.wmf|*.jpg;*.jpeg;*.bmp;*.ico;*.png;*.tif;*.wmf";
            openFileDialog1.Title = "选择头像";
            //判断是否选择了头像
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //显示选择的用户头像
                pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.FileName != "" && textBox1.Text != "")
            {
                if (AddInfo(textBox1.Text, openFileDialog1.FileName))//添加用户信息
                {
                    MessageBox.Show("用户信息添加成功！");
                }

            }
            ShowInfo();
        }
        #region 在DataGridView中显示用户名称
        /// <summary>
        /// 在DataGridView中显示用户名称
        /// </summary>
        private void ShowInfo()
        {
            conn = new SqlConnection(str);//实例化数据库连接类对象
            //实例化数据库桥接器对象
            sda = new SqlDataAdapter("select name as 用户名称 from tb_image", conn);
            //实例化数据集对象
            ds = new DataSet();
            sda.Fill(ds);//填充数据集
            dataGridView1.DataSource = ds.Tables[0];//为dataGridView设置数据源
        }
        #endregion
        
        #region 添加用户信息
        /// <summary>
        /// 添加用户信息
        /// </summary>
        /// <param name="strName">用户名称</param>
        /// <param name="strImage">选择的用户头像</param>
        /// <returns>执行成功，返回</returns>
        private bool AddInfo(string strName, string strImage)
        {
            conn = new SqlConnection(str);
            //实例化FileStream对象
            FileStream fStream = new FileStream(strImage,FileMode.Open,FileAccess.Read);
            //实例化BinaryReader对象
            BinaryReader bReader = new BinaryReader(fStream);
            //读取二进制图片
            byte[] byteImage = bReader.ReadBytes((int)fStream.Length);
            SqlCommand sqlcmd = new SqlCommand("insert into tb_image(name,photo) values(@name,@photo)",conn);
            //为SQL语句添加@name参数和@photo参数
            sqlcmd.Parameters.Add("@name", SqlDbType.VarChar, 50).Value=strName;
            sqlcmd.Parameters.Add("@photo", SqlDbType.Image).Value=byteImage;
            conn.Open();//打开数据库连接
            sqlcmd.ExecuteNonQuery();//执行用户信息添加操作
            conn.Close();//关闭数据库连接
            return true;
        }
        #endregion

        private void Form1_Load(object sender, EventArgs e)
        {
            ShowInfo();
        }
        #region 单击DataGridView中的用户名称时在左边显示用户名称和头像
        /// <summary>
        /// 单击DataGridView中的用户名称时在左边显示用户名称和头像
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //记录选中的用户名
            string strName = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            if (strName != "")//用户名不为空时
            {
                conn = new SqlConnection(str);//实例化数据库连接对象
                //实例化数据库桥接器对象
                sda = new SqlDataAdapter("select * from tb_image where name='" + strName + "'", conn);
                //实例化数据集对象
                ds = new DataSet();
                sda.Fill(ds);//填充数据集
                textBox1.Text = ds.Tables[0].Rows[0][0].ToString();//显示用户名称
                //使用数据库中存储的二进制头像实例化内存数据流
                MemoryStream MStream = new MemoryStream((byte[])ds.Tables[0].Rows[0][1]);
                pictureBox1.Image = Image.FromStream(MStream);//显示用户头像
            }
        }
        #endregion 

    }
}
