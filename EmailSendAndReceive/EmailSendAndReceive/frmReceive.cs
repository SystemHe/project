using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.IO;

namespace EmailSendAndReceive
{
    public partial class frmReceive : Form
    {
        public frmReceive()
        {
            InitializeComponent();
        }
        public static string strserver;//存储邮件服务器
        public static string pwd;//存储用户登录邮箱的密码
        public static int k;//存储邮件数目
        public static TcpClient tcpclient;//实例化TopClient对象，用来建立客户端连接
        public static StreamReader sreader;//通过流读取邮件内容
        public static string strRet;//存储邮件内容
        /// <summary>
        /// 向服务器发送内容
        /// </summary>
        /// <param name="tcpclient"></param>
        /// <param name="strCmd"></param>
        /// <returns></returns>
        private string SendPopCmd(TcpClient tcpclient, string strCmd)
        {
            Byte[] arrCmd;
            string strRet;
            Stream stream;
            stream = tcpclient.GetStream();
            strCmd = strCmd + "\r\n";
            arrCmd = Encoding.Default.GetBytes(strCmd.ToCharArray());
            stream.Write(arrCmd,0,strCmd.Length);
            strRet = sreader.ReadLine();
            return strRet;
        }
        /// <summary>
        /// 调用Logon方法来对获得连接的用户身份进行验证
        /// </summary>
        /// <param name="tcpclient">客户端连接</param>
        /// <param name="user">用户名</param>
        /// <param name="pass">密码</param>
        /// <returns>用户登录信息</returns>
        private string Logon(TcpClient tcpclient, string user, string pass)
        {
            string strRet;//存储用户登录信息
            strRet = SendPopCmd(tcpclient,"user"+user);//向登录服务器发送用户名
            strRet = SendPopCmd(tcpclient, "pass" + pass);//向登录服务器发送密码
            return strRet;
        }
        /// <summary>
        /// 获取登录邮箱的各种内容
        /// </summary>
        /// <param name="tcpclient">邮箱客户端连接</param>
        /// <returns>邮箱的统计信息</returns>
        private string[] StaticMailBox(TcpClient tcpclient)
        {
            string strRet;
            strRet = SendPopCmd(tcpclient, "stat");//向服务器发送信息，返回邮箱的统计信息
            if (JudgeString(strRet) != "+OK")
            {
                return "-ERR -ERR".Split("".ToCharArray());
            }
            else
            {
                string[] arrRet = strRet.Split("".ToCharArray());
                return arrRet;
            }
        }
        /// <summary>
        /// 验证返回的字符串信息，如果是+OK则登录成功，否则登录失败。
        /// </summary>
        /// <param name="strCheck">服务器返回的字符串信息</param>
        /// <returns>登录结果</returns>
        private string JudgeString(string strCheck)
        {
            if (strCheck.Substring(0, 3) != "+OK")
            {
                return "-ERR";
            }
            else
            {
                return "+OK";
            }
        }
        /// <summary>
        /// 根据输入的邮件编号获取邮件信息
        /// </summary>
        /// <param name="tcpclient">客户端连接</param>
        /// <param name="i">邮件编号</param>
        /// <returns>邮件信息</returns>
        private string[] PopMail(TcpClient tcpclient,int i)
        {
            string strRet;
            string[] arrRet = new string[20];
            bool strBody = false;
            string[] strTemp;
            strRet = SendPopCmd(tcpclient, "retr" + i.ToString());
            if (JudgeString(strRet) != "+OK")
            {
                return "-ERR -ERR".Split("".ToCharArray());
            }
            arrRet[0] = "+OK";
            while (sreader.Peek() != 46)
            {
                strRet = sreader.ReadLine();
                strTemp = strRet.Split(":".ToCharArray());
                if (strRet == "")
                    strBody = true;//现在开始接收Body的信息
                if (strTemp[0].ToLower() == "date")
                    arrRet[1] = strTemp[1];//邮件的发送日期
                if (strTemp[0].ToLower() == "from")
                    //发件人
                    arrRet[2] = (strTemp[1].Substring(strTemp[1].LastIndexOf("<") + 1)).Replace(">", "");
                if(strTemp[0].ToLower()=="to")
                    //收件人
                    arrRet[3] = (strTemp[1].Substring(strTemp[1].LastIndexOf("<") + 1)).Replace(">", "");
                if (strTemp[0].ToLower() == "subject")
                    arrRet[4] = strTemp[1].ToString();//主题
                if (strBody)
                    arrRet[5] = arrRet[5] + strRet + "\n";
            }
            return arrRet;
        }
        /// <summary>
        /// 对读取的邮件内容进行Base64编码
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string Base64Dncode(string str)
        {
            return Encoding.UTF8.GetString(Convert.FromBase64String(str));
        }
        /// <summary>
        /// 【登录】按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            string user = textBox2.Text;//设置用户名
            string pass = textBox3.Text;//设置密码
            string[] arrRet;
            pwd = pass;
            strserver = textBox1.Text;
            tcpclient = new TcpClient();
            try
            {
                tcpclient.Connect(strserver, 110);//连接远程主机
                //实例化StreamReader对象，以流的形式读取远程主机中的内容
                sreader = new StreamReader(tcpclient.GetStream(), Encoding.Default);
                sreader.ReadLine();
                strRet = Logon(tcpclient, user, pass);//登录远程主机
                if (JudgeString(strRet) != "+OK")
                {
                    MessageBox.Show("用户名或密码不匹配！");
                    return;
                }
                arrRet = StaticMailBox(tcpclient);//获取远程主机中指定用户的邮件信息
                if (arrRet[0] != "+OK")
                {
                    MessageBox.Show("出错啦！");
                    return;
                }
                richTextBox1.AppendText("当前用户：" + user + "\n");
                richTextBox1.AppendText("邮箱中共有" + arrRet[1] + "封邮件" + "\n");
                richTextBox1.AppendText("共占：" + arrRet[2] + "Byte");
                k = Convert.ToInt32(arrRet[1]);
                textBox1.ReadOnly = textBox2.ReadOnly = textBox3.ReadOnly = true;
                button1.Enabled = false;
                button2.Enabled = true;
                MessageBox.Show("登录成功！");
            }
            catch
            {
                MessageBox.Show("服务器连接失败！");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                tcpclient.Close();//关闭远程主机连接
            }
            catch { }
        }
        /// <summary>
        /// 【接收】按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox4.Text != "")
                {
                    if (Convert.ToInt32(textBox4.Text) > k || Convert.ToInt32(textBox4.Text) <= 0)
                    {
                        MessageBox.Show("输入的索引错误！");
                    }
                    else
                    {
                        richTextBox1.Clear();
                        string[] arrRets;
                        //获取远程主机上指定邮件的相关信息，放到String类型的数组中
                        arrRets = PopMail(tcpclient, Convert.ToInt32(textBox4.Text));
                        richTextBox1.AppendText("当前是第" + textBox4.Text + "封邮件" + "\n");
                        richTextBox1.AppendText("邮件日期" + arrRets[1] + "\n");
                        richTextBox1.AppendText("发信人" + arrRets[2] + "\n");
                        richTextBox1.AppendText("收信人" + arrRets[3] + "\n");
                        richTextBox1.AppendText("邮件主题" + Base64Dncode(arrRets[4]) + "\n");
                        richTextBox1.AppendText("邮件内容" + Base64Dncode(arrRets[5]));
                    }
                }
                else
                {
                    MessageBox.Show("邮件索引错误！");
                }
            }
            catch { }
        }
    }
}
