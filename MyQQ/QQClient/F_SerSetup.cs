using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Runtime.InteropServices;
using QQClass;

namespace MyQQClient
{
    public partial class F_SerSetup : Form
    {
        public F_SerSetup()
        {
            InitializeComponent();
        }
        Publec_Class PubClass = new Publec_Class();
        string serID = "";

        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        private void button_OK_Click(object sender, EventArgs e)
        {
            if (text_PassWord.Text.Trim() == text_PassWord2.Text.Trim())
            {
                //创建并应用MyQQClass类库中的RegisterMsg()
                RegisterMsg registermsg = new RegisterMsg();
                registermsg.UserName = text_Name.Text;//记录用户名
                registermsg.PassWord = text_PassWord.Text;//记录密码
                //调用ClassSerializers().SerializerBinary()方法，将registermsg序列化为二进制流
                byte[] registerData = new ClassSerializers().SerializerBinary(registermsg).ToArray();
                ClassMsg msg = new ClassMsg();
                msg.sendKind = SendKind.SendCommand;
                msg.msgCommand = MsgCommand.Registering;
                msg.Data = registerData;
                serID = text_IP.Text.Trim();
                udpSocket1.Send(IPAddress.Parse(serID), Convert.ToInt32(text_IP5.Text.Trim()), new ClassSerializers().SerializerBinary(msg).ToArray());

            }
            else
            {
                text_PassWord.Text = "";
                text_PassWord2.Text = "";
                MessageBox.Show("密码匹配不正确，请重新输入！");
            }
        }
        private void DataArrival(byte[] Data, System.Net.IPAddress IP, int Port) 
        {
            try
            {
                ClassMsg msg = new ClassSerializers().DeSerializerBinary((new System.IO.MemoryStream(Data))) as ClassMsg;
                switch (msg.msgCommand)
                {
                    case MsgCommand.Registered:
                        DialogResult = DialogResult.OK;
                        WritePrivateProfileString("MyQQ", "ID", serID, PubClass.Get_windows() + "\\Server.ini");
                        WritePrivateProfileString("MyQQ", "Port", text_IP5.Text.Trim(), PubClass.Get_windows() + "\\Server.ini");
                        WritePrivateProfileString("MyQQ", "Name", text_Name.Text.Trim(), PubClass.Get_windows() + "\\Server.ini");
                        break;
                }
            }
            catch { }
        }
        private delegate void DataArrivaldelegate(byte[] Data, System.Net.IPAddress Ip, int Port);

        private void udpSocket1_DataArrival(byte[] Data, IPAddress IP, int Port)
        {
            DataArrivaldelegate outdelegate = new DataArrivaldelegate(DataArrival);//托管
            this.BeginInvoke(outdelegate, new object[] { Data, IP, Port }); //异步执行托管
        }

        private void button_Close_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void F_SerSetup_Load(object sender, EventArgs e)
        {
            udpSocket1.Active = true;
        }

        private void F_SerSetup_FormClosed(object sender, FormClosedEventArgs e)
        {
            udpSocket1.Active = false;
        }
    }
}
