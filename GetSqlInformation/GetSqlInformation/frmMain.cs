using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SQLDMO;
using System.Data.SqlClient;

namespace GetSqlInformation
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        string strDataName;
        string strUser;
        string strPwd;
        string strServerName;
        private void frmMain_Load(object sender, EventArgs e)
        {
            getSqlServer();
            cbbSqlServerName.SelectedIndex = 0;

        }

        private void getSqlServer()
        {//获取数据库服务器列表
            SQLDMO.Application SQLServer = new SQLDMO.Application();
            SQLDMO.NameList strServerList = SQLServer.ListAvailableSQLServers();
            if (strServerList.Count > 0)
            {
                for (int i = 0; i < strServerList.Count; i++)
                {
                    cbbSqlServerName.Items.Add(strServerList.Item(i+1));//将找到的服务器添加到comboBox中显示
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                strUser = textBox1.Text.Trim();
                strPwd = textBox2.Text.Trim();
                strServerName = cbbSqlServerName.Text.Trim();
                cbbSQLData.Items.Clear();
                SqlConnection conn = new SqlConnection("Server=" + strServerName + ";DataBase=master;uid=" + strUser + ";pwd=" + strPwd);
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    //MessageBox.Show("连接成功！");
                    SqlCommand cmd = new SqlCommand("sp_helpdb", conn);
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        if (sdr[0].ToString() == "master" || sdr[0].ToString() == "model" || sdr[0].ToString() == "msdb" ||  sdr[0].ToString() == "tempdb")
                        { }
                        else
                        {
                            cbbSQLData.Items.Add(sdr[0].ToString());
                        }
                    }
                    cbbSQLData.SelectedIndex = 0;
                    cbbDataTable.SelectedIndex = 0;
                    sdr.Close();
                    conn.Close();
                }
                else if (conn.State == ConnectionState.Closed)
                {
                    conn.Close();
                }
            }
            catch
            {
                button1_Click(sender,e);
            }
        }

        private void cbbSQLData_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection DBCon = new SqlConnection("Server=" + cbbSqlServerName.Text.Trim() + ";Database=" + cbbSQLData.Text.Trim() + ";uid=" + textBox1.Text.Trim() + ";pwd=" + textBox2.Text.Trim());
            strDataName = cbbSQLData.Text.Trim();
            listBox1.DataSource = null;
            listBox1.Items.Clear();
            SqlDataAdapter sda = new SqlDataAdapter("select name from sysobjects where xtype='u' and  name <>'dtproperties'", DBCon);
            DataTable dt = new DataTable("sysobjects");
            sda.Fill(dt);
            listBox1.DataSource = dt.DefaultView;
            listBox1.DisplayMember = "name";
            listBox1.ValueMember = "name";

        }

        private void cbbDataTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbDataTable.Text.Trim() == "视图")
            {
                using (SqlConnection sqlconn = new SqlConnection("server=" + strServerName + ";database=" + strDataName + ";uid=" + strUser + ";pwd=" + strPwd))
                {//获取数据库视图
                    SqlDataAdapter sda = new SqlDataAdapter("select name from sysobjects where xtype='v'", sqlconn);
                    DataTable dt = new DataTable("sysobjects");
                    sda.Fill(dt);
                    listBox1.DataSource = dt.DefaultView;
                    listBox1.DisplayMember = "name";
                    listBox1.ValueMember = "name";
                }

            }
            if (cbbDataTable.Text.Trim() == "数据表")
            {
                listBox1.DataSource = null;
                listBox1.Items.Clear();
                SqlConnection DBCon = new SqlConnection("Server=" + strServerName + ";Database=" + strDataName + ";uid=" + strUser + ";pwd=" + strPwd);
                SqlDataAdapter sda = new SqlDataAdapter("select name from sysobjects where xtype='u' and  name <>'dtproperties'", DBCon);
                DataTable dt = new DataTable("sysobjects");
                sda.Fill(dt);
                listBox1.DataSource = dt.DefaultView;
                listBox1.DisplayMember = "name";
                listBox1.ValueMember = "name";
            }
            if (cbbDataTable.Text.Trim() == "存储过程")
            {
                listBox1.DataSource = null;
                listBox1.Items.Clear();
                SqlConnection DBCon = new SqlConnection("Server=" + strServerName + ";Database=" + strDataName + ";uid=" + strUser + ";pwd=" + strPwd);
                SqlDataAdapter sda = new SqlDataAdapter("select name from sysobjects where xtype='p'", DBCon);
                DataTable dt = new DataTable("sysobjects");
                sda.Fill(dt);
                listBox1.DataSource = dt.DefaultView;
                listBox1.DisplayMember = "name";
                listBox1.ValueMember = "name";
            }
        }

        private void addSQL_Click(object sender, EventArgs e)
        {
            using (frmAppend frmAppend = new frmAppend())
            {
                frmAppend.strUser = textBox1.Text.Trim();
                frmAppend.strpwd = textBox2.Text.Trim();
                frmAppend.ShowDialog();
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 'a' && e.KeyChar <= 'z') || (e.KeyChar >= 'A' && e.KeyChar <= 'Z')
                || (e.KeyChar >= '0' && e.KeyChar <= '9') || (e.KeyChar == 8)||(e.KeyChar=='.'))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void outputTable_Click(object sender, EventArgs e)
        {
            using (frmDataExport frmDataExport = new frmDataExport())
            {
                frmDataExport.OutTable = listBox1.SelectedValue.ToString().Trim();
                frmDataExport.OutData = cbbSQLData.Text.Trim();
                frmDataExport.strserver = cbbSqlServerName.Text.Trim();
                frmDataExport.strUser = textBox1.Text.Trim();
                frmDataExport.strpwd = textBox2.Text.Trim();
                frmDataExport.ShowDialog();//显示表结构导出窗口

            }
        }
        
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string text = listBox1.Text.ToString();
                string strsql = "select name 字段名,xusertype 类型编号,length 长度 into hy_linshibiao from syscolumns where id=object_id('" + text + "')";
                strsql += "select name 类型,xusertype 类型编号 into angel_linshibiao from systypes where xusertype in (select xusertype from syscolumns where id=object_id('" + text + "') )";
                using (SqlConnection conn = new SqlConnection("Server=" + strServerName + ";Database=" + strDataName + ";uid=" + strUser + ";pwd=" + strPwd))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(strsql, conn);
                    cmd.ExecuteNonQuery();
                    SqlDataAdapter sda = new SqlDataAdapter("select 字段名,类型,长度 from hy_linshibiao t,angel_linshibiao b where t.类型编号=b.类型编号", conn);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    dataGridView1.DataSource = dt.DefaultView;
                    SqlCommand cmdnew = new SqlCommand("drop table hy_linshibiao ,angel_linshibiao ", conn);
                    cmdnew.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void outputData_Click(object sender, EventArgs e)
        {
            using (frmOutData frmOutData = new frmOutData())
            {
                frmOutData.OutTable = listBox1.SelectedValue.ToString().Trim();
                frmOutData.OutData = cbbSQLData.Text.Trim();
                frmOutData.strserver = cbbSqlServerName.Text.Trim();
                frmOutData.strUser = textBox1.Text.Trim();
                frmOutData.strpwd = textBox2.Text.Trim();
                frmOutData.ShowDialog();//显示数据导出窗口

            }
        }

        private void ExitSys_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public bool DataBackupConfigDB(string backupFolder)
        {
            //获取配置文件中sql数据库名  
            string dbName = cbbSQLData.Text.Trim();
            string name = dbName + DateTime.Now.ToString("yyyyMMddHHmmss");
            string procname;
            string sql;
            //创建连接对象  
            using (SqlConnection conn = new SqlConnection("server=" +strServerName+ ";database=" +strDataName+ ";Uid=" +strUser+ ";pwd=" +strPwd+""))
            {
                conn.Open();        //打开数据库连接  
                //删除逻辑备份设备，但不会删掉备份的数据库文件  
                procname = "sp_dropdevice";
                SqlCommand sqlcmd1 = new SqlCommand(procname, conn);
                sqlcmd1.CommandType = CommandType.StoredProcedure;
                SqlParameter sqlpar = new SqlParameter();
                sqlpar = sqlcmd1.Parameters.Add("@logicalname", SqlDbType.VarChar, 20);
                sqlpar.Direction = ParameterDirection.Input;
                sqlpar.Value = dbName;
                try        //如果逻辑设备不存在，略去错误  
                {
                    sqlcmd1.ExecuteNonQuery();
                }
                catch
                {
                    MessageBox.Show("错误的备份文件目录");
                }
                //创建逻辑备份设备  
                procname = "sp_addumpdevice";
                SqlCommand sqlcmd2 = new SqlCommand(procname, conn);
                sqlcmd2.CommandType = CommandType.StoredProcedure;
                sqlpar = sqlcmd2.Parameters.Add("@devtype", SqlDbType.VarChar, 20);
                sqlpar.Direction = ParameterDirection.Input;
                sqlpar.Value = "disk";
                sqlpar = sqlcmd2.Parameters.Add("@logicalname", SqlDbType.VarChar, 20);//逻辑设备名  
                sqlpar.Direction = ParameterDirection.Input;
                sqlpar.Value = dbName;
                sqlpar = sqlcmd2.Parameters.Add("@physicalname", SqlDbType.NVarChar, 260);//物理设备名  
                sqlpar.Direction = ParameterDirection.Input;
                sqlpar.Value = backupFolder + name + ".bak";
                try
                {
                    int i = sqlcmd2.ExecuteNonQuery();
                }
                catch (Exception err)
                {
                    string str = err.Message;
                }
                //备份数据库到指定的数据库文件(完全备份)  
                sql = "BACKUP DATABASE " + dbName + " TO " + dbName + " WITH INIT";
                SqlCommand sqlcmd3 = new SqlCommand(sql, conn);
                sqlcmd3.CommandType = CommandType.Text;
                try
                {
                    sqlcmd3.ExecuteNonQuery();
                    MessageBox.Show("备份成功！");
                }
                catch (Exception err)
                {
                    string str = err.Message;
                    conn.Close();
                    return false;
                }
                conn.Close();//关闭数据库连接  
                return true;
            }
        }

        private void copySQL_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            if (folder.ShowDialog() == DialogResult.OK)
            {
                DataBackupConfigDB(folder.SelectedPath);
            }
            
        }  
        public bool DataRestoreConfigDB(string dbFile)  
        {  
            //sql数据库名  
            string dbName = cbbSQLData.Text.Trim();  
            //创建连接对象  
            SqlConnection conn = new SqlConnection("server=" + strServerName + ";database=" + strDataName + ";Uid=" + strUser + ";pwd=" + strPwd + "");  
            //还原指定的数据库文件  
            string sql =string.Format("use master ;declare @s varchar(8000);select @s=isnull(@s,'')+' kill '+rtrim(spID) from master..sysprocesses where dbid=db_id('{0}');select @s;exec(@s) ;RESTORE DATABASE {1} FROM DISK = N'{2}' with replace",dbName,dbName,dbFile);  
            SqlCommand sqlcmd = new SqlCommand(sql, conn);  
            sqlcmd.CommandType = CommandType.Text;  
            conn.Open();  
            try  
            {  
                sqlcmd.ExecuteNonQuery();
                MessageBox.Show("恢复成功！");
            }  
            catch (Exception err)  
            {  
                string str = err.Message;  
                conn.Close();  
                return false;  
            }  
            conn.Close();//关闭数据库连接  
            return true;  
        }

        private void resetSQL_Click(object sender, EventArgs e)
        {

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                DataRestoreConfigDB(openFileDialog1.FileName);
            }

        }
        SqlConnection Conn;
        public void DetachDataBase()
        {
            try
            {
                Conn = new SqlConnection("server=" + strServerName + ";database=" + strDataName + ";Uid=" + strUser + ";pwd=" + strPwd + "");
                Conn.Open();
                SqlCommand Comm = new SqlCommand();
                Comm.Connection = Conn;
                Comm.CommandText = @"sp_detach_db";
                Comm.Parameters.Add(new SqlParameter(@"dbname", SqlDbType.NVarChar));
                Comm.Parameters[@"dbname"].Value = cbbSQLData.Text.Trim();
                Comm.CommandType = CommandType.StoredProcedure;
                Comm.ExecuteNonQuery();
                MessageBox.Show("数据库分离成功！");
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                Conn.Close();
            }
        }

        private void fenliSQL_Click(object sender, EventArgs e)
        {
            DetachDataBase();
        }


    }
}
