using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QQClass;
using System.Runtime.InteropServices;
using System.Net;

namespace MyQQClient
{
    public partial class F_Logon : Form
    {
        public F_Logon()
        {
            InitializeComponent();
        }
        #region//声名变量
        Publec_Class PubClass = new Publec_Class();
        #endregion

        #region  使Label控件透明
        /// <summary>
        /// 使Label控件透明.
        /// </summary>
        public void Trans(Label lab, PictureBox pic)
        {
            lab.BackColor = Color.Transparent;
            lab.Parent = pic;
        }
        #endregion

        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);
        private void F_Logon_Load(object sender, EventArgs e)
        {
            //如果程序启动目录中没有Server.ini文件
            if (System.IO.File.Exists(PubClass.Get_windows() + "\\Server.ini")==false)
            {
                F_SerSetup FrmSerSetup = new F_SerSetup();
                FrmSerSetup.Text = "用户注册";
                if (FrmSerSetup.ShowDialog(this) == DialogResult.OK)
                {
                    FrmSerSetup.Dispose();
                }
                else
                {
                    FrmSerSetup.Dispose();
                    DialogResult = DialogResult.Cancel;
                }
            }
            //如果程序启动目录中有Server.ini文件
            if (System.IO.File.Exists(PubClass.Get_windows() + "\\Server.ini") == true)
            {
                Publec_Class.ServerIP = "";
                Publec_Class.ServerPort = "";
                StringBuilder temp = new StringBuilder(255);
                //读取服务器IP地址
                GetPrivateProfileString("MyQQ", "IP", "服务器地址读取错误！", temp, 255, System.Environment.CurrentDirectory + "\\Server.ini");
                Publec_Class.ServerIP = temp.ToString();
                //读取服务器端口号
                GetPrivateProfileString("MyQQ", "Port", "服务器端口号读取错误！", temp, 255, System.Environment.CurrentDirectory + "\\Server.ini");
                Publec_Class.ServerPort = temp.ToString();
                //读取用户名称
                GetPrivateProfileString("MyQQ", "Name", "用户名称读取错误！", temp, 255, System.Environment.CurrentDirectory + "\\Server.ini");
                Publec_Class.ClientName = temp.ToString();
            }
            else
            {
                DialogResult = DialogResult.Cancel;
            }
            udpSocket1.Active = true;   //启动自定义控件
        }

        private void button_QQLogon_Click(object sender, EventArgs e)
        {
            if (Publec_Class.ServerIP != "" && Publec_Class.ServerPort != "")
            {
                RegisterMsg registermsg = new RegisterMsg();
                registermsg.UserName = text_Name.Text.Trim();//记录用户名
                registermsg.PassWord = text_PassWord.Text;//记录密码
                //调用ClassSerializers().SerializerBinary()方法将registermsg序列化为二进制流
                byte[] registerData = new ClassSerializers().SerializerBinary(registermsg).ToArray();
                ClassMsg msg = new ClassMsg();
                msg.sendKind = SendKind.SendCommand;//设置为发送命令
                msg.msgCommand = MsgCommand.Logining;//消息命令设置为用户登录
                msg.Data = registerData;//将二进制流存储到类库中的二进制变量Data中
                //用udpSocket控件的Send方法将消息发送给服务器
                udpSocket1.Send(IPAddress.Parse(Publec_Class.ServerIP), Convert.ToInt32(Publec_Class.ServerPort), new ClassSerializers().SerializerBinary(msg).ToArray());
                Publec_Class.UserName = text_Name.Text;
            }
        }
        private delegate void DataArrivaldelegate(byte[] Data, System.Net.IPAddress Ip, int Port);

        private void DataArrival(byte[] Data, System.Net.IPAddress Ip, int Port) //当有数据到达后的处理进程
        {
            try
            {
                ClassMsg msg = new ClassSerializers().DeSerializerBinary((new System.IO.MemoryStream(Data))) as ClassMsg;

                switch (msg.msgCommand)
                {
                    case MsgCommand.Logined://登录成功
                        Publec_Class.UserID = msg.SID;
                        DialogResult = DialogResult.OK;
                        break;

                }
            }
            catch { }
        }

        private void udpSocket1_DataArrival(byte[] Data, IPAddress IP, int Port)
        {
            DataArrivaldelegate outdelegate = new DataArrivaldelegate(DataArrival);
            this.BeginInvoke(outdelegate, new object[] { Data, IP, Port }); 
        }

        private void F_Logon_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (udpSocket1.Active)
                udpSocket1.Active = false;
        }
    }
}
