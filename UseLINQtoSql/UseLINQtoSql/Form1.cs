using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace UseLINQtoSql
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string strcon = "server=.;database=test;uid=he;pwd=hj.593942539";
        DataClasses1DataContext linq;
        private void Form1_Load(object sender, EventArgs e)
        {
            BindInfo();
        }

        private void BindInfo()
        {
            linq = new DataClasses1DataContext(strcon);//实例化Linq连接对象
            if (textBox1.Text == "")
            {
                var result = from info in linq.员工信息
                             select new
                             {
                                 员工编号 = info.员工编号,
                                 员工姓名 = info.员工姓名,
                                 性别 = info.性别,
                                 年龄 = info.年龄,
                                 电话 = info.电话,
                                 地址 = info.地址,
                                 邮箱 = info.邮箱
                             };
                dataGridView1.DataSource = result;//对dataGridView控件进行数据绑定
            }
            else
            {
                switch (comboBox1.Text)
                { 
                    case "员工编号":
                        //根据员工编号查询员工信息
                        var resultid = from info in linq.员工信息
                                       where info.员工编号.Contains(textBox1.Text)
                                       select new
                                       {
                                           员工编号 = info.员工编号,
                                           员工姓名 = info.员工姓名,
                                           性别 = info.性别,
                                           年龄 = info.年龄,
                                           电话 = info.电话,
                                           地址 = info.地址,
                                           邮箱 = info.邮箱
                                       };
                        dataGridView1.DataSource = resultid;
                        break;
                    case "员工姓名":
                        var resultName=from info in linq.员工信息
                                       where info.员工姓名.Contains(textBox1.Text)
                                       select new
                                       {
                                           员工编号 = info.员工编号,
                                           员工姓名 = info.员工姓名,
                                           性别 = info.性别,
                                           年龄 = info.年龄,
                                           电话 = info.电话,
                                           地址 = info.地址,
                                           邮箱 = info.邮箱
                                       };
                        dataGridView1.DataSource = resultName;
                        break;
                    case "性别":
                        var resultSex=from info in linq.员工信息
                                       where info.性别==textBox1.Text
                                       select new
                                       {
                                           员工编号 = info.员工编号,
                                           员工姓名 = info.员工姓名,
                                           性别 = info.性别,
                                           年龄 = info.年龄,
                                           电话 = info.电话,
                                           地址 = info.地址,
                                           邮箱 = info.邮箱
                                       };
                        dataGridView1.DataSource = resultSex;
                        break;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BindInfo();
        }
    }
}
