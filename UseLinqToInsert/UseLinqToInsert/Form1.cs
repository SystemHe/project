using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UseLinqToInsert
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string conn = "server=.;database=test;uid=he;pwd=hj.593942539";
        linqtisqlClassesDataContext linq;
        int pageSize = 7;
        int page = 0;

        protected int getCount()
        {
            int sum = linq.员工信息.Count();
            int s1 = sum / pageSize;
            int s2 = sum % pageSize>0 ? 1 : 0;
            int count = s1 + s2;
            return count;
        }
        #region 添加数据库信息
        /// <summary>
        /// 添加数据库信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            linq = new linqtisqlClassesDataContext(conn);//实例化Linq连接对象
            员工信息 employee = new 员工信息();//实例化"员工信息"类对象
            //为"员工信息"类中的员工实体进行赋值
            employee.员工编号 = textBox1.Text;
            employee.员工姓名 = textBox2.Text;
            employee.性别 = comboBox1.Text;
            employee.年龄 = textBox3.Text;
            employee.电话 = textBox4.Text;
            employee.地址 = textBox5.Text;
            employee.邮箱 = textBox6.Text;
            linq.员工信息.InsertOnSubmit(employee);//添加员工信息
            linq.SubmitChanges();//提交操作
            MessageBox.Show("信息添加成功");
            BindInfo();
        }
        #endregion

        #region BindInfo()获取数据库中的所有员工信息
        /// <summary>
        /// 获取数据库信息
        /// </summary>
        private void BindInfo()
        {
            int pageIndex = Convert.ToInt32(page);
            linq = new linqtisqlClassesDataContext(conn);//实例化Linq连接对象
            var result =( from info in linq.员工信息
                         select new
                         {
                             员工编号 = info.员工编号,
                             员工姓名 = info.员工姓名,
                             性别 = info.性别,
                             年龄 = info.年龄,
                             电话 = info.电话,
                             地址 = info.地址,
                             邮箱 = info.邮箱
                         }).Skip(pageSize*pageIndex).Take(pageSize);
            dataGridView1.DataSource = result;
            button5.Enabled = button6.Enabled = true;
            if (page == 0)
            {
                button5.Enabled = false;
            }
            if (page == getCount() - 1)
            {
                button6.Enabled = false;
            }
        }
        #endregion

        private void Form1_Load(object sender, EventArgs e)
        {
            page = 0;
            BindInfo();
        }

         #region 修改信息
        /// <summary>
        /// 修改信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("请选择要修改的数据！");
                return;
            }
            linq = new linqtisqlClassesDataContext(conn);//实例化Linq连接对象
            //根据员工编号获取要修改的员工信息
            var result = from employee in linq.员工信息
                          where employee.员工编号 == textBox1.Text
                          select employee;
            //对指定的员工信息进行修改
             foreach (员工信息 tbemployee in result)
             {
                 tbemployee.员工编号 = textBox1.Text;
                 tbemployee.员工姓名 = textBox2.Text;
                 tbemployee.性别 = comboBox1.Text;
                 tbemployee.年龄 = textBox3.Text;
                 tbemployee.电话 = textBox4.Text;
                 tbemployee.地址 = textBox5.Text;
                 tbemployee.邮箱 = textBox6.Text;
                 linq.SubmitChanges();
             }
             MessageBox.Show("信息修改成功！");
             BindInfo();
        }
         #endregion

        #region 显示dataGridView中选择的数据的详细内容
        /// <summary>
        /// 显示数据库表内容
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            linq = new linqtisqlClassesDataContext(conn);
            //获取选择的员工编号
            textBox1.Text = Convert.ToString(dataGridView1[0, e.RowIndex].Value).Trim();
            //根据选择的员工编号获取其详细内容，并重新生成一个表
            var result = from info in linq.员工信息
                         where info.员工编号 == textBox1.Text
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
            //在相应的文本框和下拉框中显示员工信息
            foreach (var item in result)
            {
                textBox1.Text = item.员工编号;
                textBox2.Text = item.员工姓名;
                comboBox1.Text = item.性别;
                textBox3.Text = item.年龄;
                textBox4.Text = item.电话;
                textBox5.Text = item.地址;
                textBox6.Text = item.邮箱;
            }
        }
        #endregion

        #region 删除选择的信息
        /// <summary>
        /// 删除信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("请选择要删除的信息！");
                return;
            }
            linq = new linqtisqlClassesDataContext(conn);//实例化linq连接对象
            //根据员工编号查询出要删除的员工信息
            var result = from employee in linq.员工信息
                         where employee.员工编号 == textBox1.Text
                         select employee;
            //删除选择的员工信息
            linq.员工信息.DeleteAllOnSubmit(result);
            //提交操作
            linq.SubmitChanges();
            MessageBox.Show("信息删除成功！");
            BindInfo();
        }
        #endregion

        #region 清空选择的信息
        /// <summary>
        /// 清空选择的信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
            textBox1.Clear();
            textBox2.Clear();
            comboBox1.Text = "";
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
        }
        #endregion
        private void button5_Click(object sender, EventArgs e)
        {
            page = page - 1;
            BindInfo();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            page = page + 1;
            BindInfo();
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("请选择要删除的信息！");
                return;
            }
            linq = new linqtisqlClassesDataContext(conn);//实例化linq连接对象
            //根据员工编号查询出要删除的员工信息
            var result = from employee in linq.员工信息
                         where employee.员工编号 == textBox1.Text
                         select employee;
            //删除选择的员工信息
            linq.员工信息.DeleteAllOnSubmit(result);
            //提交操作
            linq.SubmitChanges();
            MessageBox.Show("信息删除成功！");
            BindInfo();
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right && e.ColumnIndex > -1 && e.RowIndex > -1)  //点击的是鼠标右键，并且不是表头
            {
                //右键选中单元格
                this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = true;
                this.contextMenuStrip1.Show(MousePosition.X, MousePosition.Y); //MousePosition.X, MousePosition.Y 是为了让菜单在所选行的位置显示

            }

        }

    }
}
