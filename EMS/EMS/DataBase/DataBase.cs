using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Data.Common;

namespace EMS.DataBase
{
    class DataBase
    {
        SqlConnection con;
        private void Open()
        {
            if (con == null)
            {
                con = new SqlConnection("server=.;database=db_EMS;uid=he;pwd=hj.593942539");
            }
            if (con.State == System.Data.ConnectionState.Closed)
                con.Open();
        }
        public void Close()
        {
            if (con != null)
                con.Close();
        }
        #region 释放数据库连接资源

        /// <summary>
        ///   释放资源
        /// </summary>
        public void Dispose()
        {
            if (con != null) //判断连接对象是否不为空
            {
                con.Dispose(); //释放数据库连接资源
                con = null; //设置数据库连接为空
            }
        }
        #endregion

        #region   传入参数并且转换为SqlParameter类型
        /// <summary>
        ///   转换参数
        /// </summary>
        /// <param name="ParamName"> 存储过程名称或命令文本 </param>
        /// <param name="DbType"> 参数类型 </param>
        /// </param>
        /// <param name="Size"> 参数大小 </param>
        /// <param name="Value"> 参数值 </param>
        /// <returns> 新的 parameter 对象 </returns>
        public SqlParameter MakeInParam(string paramName, SqlDbType DbType, int size, object value)
        {
            return MakeParam(paramName, DbType, size, ParameterDirection.Input, value);
        }
        /// <summary>
        ///   初始化参数值
        /// </summary>
        /// <param name="ParamName"> 存储过程名称或命令文本 </param>
        /// <param name="DbType"> 参数类型 </param>
        /// <param name="Size"> 参数大小 </param>
        /// <param name="Direction"> 参数方向 </param>
        /// <param name="Value"> 参数值 </param>
        /// <returns> 新的 parameter 对象 </returns>
        private SqlParameter MakeParam(string paramName, SqlDbType DbType, int size, ParameterDirection Direction, object value)
        {
            SqlParameter param;
            if (size > 0)
            {
                param = new SqlParameter(paramName, DbType, size);
            }
            else
            {
                param = new SqlParameter(paramName, DbType);
            }
            param.Direction=Direction;
            if (!(Direction == ParameterDirection.Output && value == null))
            {
                param.Value = value;
            }
            return param;
        }
        #endregion

        #region   执行参数命令文本(无数据库中数据返回)

        /// <summary>
        ///   执行命令
        /// </summary>
        /// <param name="procName"> 命令文本 </param>
        /// <param name="prams"> 参数对象 </param>
        /// <returns> </returns>
        public int RunProc(string procName,SqlParameter[] prams)
        {
            SqlCommand cmd =CreateCommand(procName,prams);
            cmd.ExecuteNonQuery();
            this.Close();
            return (int)cmd.Parameters["ReturnValue"].Value;
        }
        /// <summary>
        ///   直接执行SQL语句
        /// </summary>
        /// <param name="procName"> 命令文本 </param>
        /// <returns> </returns>
        public int RunProc(string procName)
        {
            this.Open();
            SqlCommand cmd = new SqlCommand(procName, con);
            cmd.ExecuteNonQuery();
            this.Close();
            return 1;
        }

        /// <summary>
        ///   执行命令文本，并且返回DataSet数据集
        /// </summary>
        /// <param name="procName"> 命令文本 </param>
        /// <param name="tbName"> 数据表名称 </param>
        /// <returns> DataSet </returns>
        public DataSet RunProcReturn(string procName, SqlParameter[] prams, string tbName)
        {
            SqlDataAdapter dap = CreateDataAdapter(procName, prams);
            DataSet ds = new DataSet();
            dap.Fill(ds, tbName);
            this.Close();
            return ds;
        }
        public DataSet RunProcReturn(string procName, string tbName)
        {
            SqlDataAdapter dap = CreateDataAdapter(procName, null); //创建桥接器对象
            DataSet ds = new DataSet(); //创建数据集对象
            dap.Fill(ds, tbName); //填充数据集
            Close(); //关闭数据库连接
            return ds; //返回数据集
        }

        #endregion

        #region 将命令文本添加到SqlDataAdapter

        /// <summary>
        ///   创建一个SqlDataAdapter对象以此来执行命令文本
        /// </summary>
        /// <param name="procName"> 命令文本 </param>
        /// <param name="prams"> 参数对象 </param>
        /// <returns> </returns>
        private SqlDataAdapter CreateDataAdapter(string procName, SqlParameter[] prams)
        {
            Open(); //打开数据库连接
            SqlDataAdapter dap = new SqlDataAdapter(procName, con); //创建桥接器对象
            dap.SelectCommand.CommandType = CommandType.Text; //指定要执行的类型为命令文本
            if (prams != null) //判断SQL参数是否不为空
            {
                foreach (SqlParameter parameter in prams) //遍历传递的每个SQL参数
                    dap.SelectCommand.Parameters.Add(parameter); //将SQL参数添加到执行命令对象中
            }
            //加入返回参数
            dap.SelectCommand.Parameters.Add(new SqlParameter("ReturnValue", SqlDbType.Int, 4,
                                                              ParameterDirection.ReturnValue, false, 0, 0, string.Empty,
                                                              DataRowVersion.Default, null));
            return dap; //返回桥接器对象
        }

        #endregion

        #region   将命令文本添加到SqlCommand

        /// <summary>
        ///   创建一个SqlCommand对象以此来执行命令文本
        /// </summary>
        /// <param name="procName"> 命令文本 </param>
        /// <param name="prams" 命令文本所需参数 </param>
        /// <returns> 返回SqlCommand对象 </returns>
        private SqlCommand CreateCommand(string procName, SqlParameter[] prams)
        {
            Open(); //打开数据库连接
            SqlCommand cmd = new SqlCommand(procName, con); //创建SqlCommand命令对象
            cmd.CommandType = CommandType.Text; //指定要执行的类型为命令文本
            // 依次把参数传入命令文本
            if (prams != null) //判断SQL参数是否不为空
            {
                foreach (SqlParameter parameter in prams) //遍历传递的每个SQL参数
                    cmd.Parameters.Add(parameter); //将SQL参数添加到执行命令对象中
            }
            //加入返回参数
            cmd.Parameters.Add(new SqlParameter("ReturnValue", SqlDbType.Int, 4,
                                                ParameterDirection.ReturnValue, false, 0, 0, string.Empty,
                                                DataRowVersion.Default, null));
            return cmd; //返回SqlCommand命令对象
        }

        #endregion
    }
}
