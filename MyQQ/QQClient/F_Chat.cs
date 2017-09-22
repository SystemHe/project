using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using QQClass;
using System.IO;

namespace MyQQClient
{
    public partial class F_Chat : Form
    {
        public F_Chat()
        {
            InitializeComponent();
        }
        public UDPSocket udpsocket;
        public ClassForms FormList;
        public bool Voiding;
        public bool SendViod;
        Video video;
        private void button_Send_Click(object sender, EventArgs e)
        {
            IPAddress ip = IPAddress.Parse(Publec_Class.ServerIP);//服务器端的IP地址
            string port = Publec_Class.ServerPort;//服务器端口号
            string revid = ((this.Tag as TreeNode).Tag as ClassUserInfo).UserID;//接收ID号
            string sid = Publec_Class.UserID;//发送ID
            string msgid = Guid.NewGuid().ToString();//设置全局唯一标识
            byte[] data = Encoding.Unicode.GetBytes(Rich_Input.Rtf);//将当前要发送的信息转化为二进制流
            ClassMsg msg = new ClassMsg();
            msg.sendKind = SendKind.SendMsg;//发送的消息
            msg.msgCommand = MsgCommand.SendToOne;//发送的是单用户信息
            msg.SID = sid;//发送ID
            msg.RID = revid;//接收ID
            msg.Data = data;//发送的消息
            msg.msgID = msgid;
            if (data.Length <= 1024)
            {
                msg.sendState = SendState.Single;
                //将信息直接发送给远程客户端
                udpsocket.Send(ip, Convert.ToInt32(port), new ClassSerializers().SerializerBinary(msg).ToArray());
            }
            else
            {
                ClassMsg start = new ClassMsg();
                start.sendKind = SendKind.SendMsg;
                start.sendState = SendState.Start;
                start.msgCommand = MsgCommand.SendToOne;
                start.SID = sid;
                start.RID = revid;
                start.Data = Encoding.Unicode.GetBytes("");
                start.msgID = msgid;
                udpsocket.Send(ip, Convert.ToInt32(port), new ClassSerializers().SerializerBinary(start).ToArray());
                MemoryStream stream = new MemoryStream(data);
                int sendlen = 1024;//设置文件每块发送的大小
                long sunlen = stream.Length;//整个文件的大小
                int offset = 0;//设置文件发送的起始位置
                while (sunlen > 0)
                {
                    if (sunlen <= sendlen)
                        sendlen = Convert.ToInt32(sunlen);
                    byte[] msgdata = new byte[sendlen];//创建一个1024大小的二进制流
                    stream.Read(msgdata, offset, sendlen);//读取要发送的字节块
                    msg.sendState = SendState.Sending;//发送状态为文件发送中
                    msg.Data = msgdata;
                    udpsocket.Send(ip, Convert.ToInt32(port), new ClassSerializers().SerializerBinary(msg).ToArray());
                    sunlen = sunlen - sendlen;//记录下一块的起始位置
                 }   
                ClassMsg end = new ClassMsg();
                end.sendKind = SendKind.SendMsg;
                end.sendState = SendState.End;
                end.msgCommand = MsgCommand.SendToOne;
                end.SID = sid;
                end.RID = revid;
                end.Data = Encoding.Unicode.GetBytes("");
                end.msgID = msgid;
                udpsocket.Send(ip, Convert.ToInt32(port), new ClassSerializers().SerializerBinary(end).ToArray());
            }   
            Rich_Out.SelectionStart = 0;
            Rich_Out.AppendText(Publec_Class.UserID);
            Rich_Out.AppendText("  " + DateTime.Now.ToString());
            Rich_Out.AppendText("\r\n");
            Rich_Out.SelectedRtf = Rich_Input.Rtf;
            Rich_Input.Clear();
            
        }

        private void 视频_Click(object sender, EventArgs e)
        {
            video = new Video(pictureBox1.Handle, pictureBox1.Width, pictureBox1.Height);
            video.StartWebCam();
            ClassMsg msg = new ClassMsg();
            msg.sendKind = SendKind.SendCommand;
            msg.msgCommand = MsgCommand.VideoOpen;
            msg.Data = Encoding.Unicode.GetBytes("");
            IPAddress ip = IPAddress.Parse(((this.Tag as TreeNode).Tag as ClassUserInfo).UserIP);
            string port = "11005";
            udpsocket.Send(ip, Convert.ToInt32(port), new ClassSerializers().SerializerBinary(msg).ToArray());
            Voiding = true;
            SendViod = false;
            timer1.Enabled = true;
            panel1.Visible = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Voiding || !SendViod || pictureBox1.Image != null)
            {
                SendViod = true;
                IPAddress ip = IPAddress.Parse(((this.Tag as TreeNode).Tag as ClassUserInfo).UserIP);
                string port = "11005";
                string revid = ((this.Tag as TreeNode).Tag as ClassUserInfo).UserID;
                string sid = Publec_Class.UserID;//发送ID
                ClassMsg msg = new ClassMsg();
                msg.sendKind = SendKind.SendCommand;//发送的消息
                msg.msgCommand = MsgCommand.Videoing;//发送的是单用户信息
                msg.sendState = SendState.Sending;
                msg.SID = sid;//发送ID
                msg.RID = revid;//接收ID
                msg.Data = Encoding.Unicode.GetBytes("");
                ClassMsg start = new ClassMsg();
                start.sendKind = SendKind.SendCommand;
                start.sendState = SendState.Start;
                start.msgCommand = MsgCommand.Videoing;
                start.SID = sid;
                start.RID = revid;
                start.Data = Encoding.Unicode.GetBytes("");
                udpsocket.Send(ip, Convert.ToInt32(port), new ClassSerializers().SerializerBinary(start).ToArray());
                video.GrabImage(pictureBox1.Handle, "C:\\tempVoid.Bmp");
                FileStream stream = File.OpenRead("C:\\tempVoid.Bmp");
                int sendlen = 1024;
                long sunlen = stream.Length;
                int offset = 0;
                while (sunlen > 0)
                {
                    if (sunlen <= sendlen)
                        sendlen = Convert.ToInt32(sunlen);
                    byte[] msgdata = new byte[sendlen];//创建一个1024大小的二进制流
                    stream.Read(msgdata, offset, sendlen);//读取要发送的字节块
                    msg.sendState = SendState.Sending;//发送状态为文件发送中
                    msg.Data = msgdata;
                    udpsocket.Send(ip, Convert.ToInt32(port), new ClassSerializers().SerializerBinary(msg).ToArray());
                    sunlen = sunlen - sendlen;//记录下一块的起始位置
                 }   
                 ClassMsg end = new ClassMsg();
                 end.sendKind = SendKind.SendCommand;
                 end.sendState = SendState.End;
                 end.msgCommand = MsgCommand.Videoing;
                 end.SID = sid;
                 end.RID = revid;
                 end.Data = Encoding.Unicode.GetBytes("");
                 stream.Close();
                 udpsocket.Send(ip, Convert.ToInt32(port), new ClassSerializers().SerializerBinary(end).ToArray());
                 SendViod = false;
                
            }
        }

        private void udpSocket1_DataArrival(byte[] Data, IPAddress IP, int Port)
        {
            DataArrivaldelegate outdelegate = new DataArrivaldelegate(DataArrival);
            this.BeginInvoke(outdelegate, new object[] { Data, IP, Port });
        }
        private void DataArrival(byte[] Data, System.Net.IPAddress Ip, int Port) //当有数据到达后的处理进程
        {
            try
            {
                ClassMsg msg = new ClassSerializers().DeSerializerBinary((new System.IO.MemoryStream(Data))) as ClassMsg;

                switch (msg.msgCommand)
                {
                    case MsgCommand.VideoOpen:
                        Voiding = true;
                        SendViod = false;
                        break;
                    case MsgCommand.Videoing:
                        GetVoid(Data, Ip, Port);
                        break;
                    case MsgCommand.VideoClose:
                        Voiding = false;
                        break;

                }
            }
            catch { }
        }
        private delegate void DataArrivaldelegate(byte[] Data, System.Net.IPAddress Ip, int Port);
        private void GetVoid(byte[] Data,System.Net.IPAddress IP, int Port)
        {
            ClassMsg msg = (ClassMsg)new ClassSerializers().DeSerializerBinary(new MemoryStream(Data));
            string sid = msg.SID;//发送方用户ID
            string msgid = msg.msgID;//消息标识，GUID
            switch (msg.msgCommand)
            {
                case MsgCommand.Videoing://发送的消息
                    {
                        switch (msg.sendState)  //消息发送的状态
                        {
                            case SendState.Start:
                                {
                                    FileStream fs = null;
                                    try
                                    {
                                        string FileName = "c:\\Void.bmp";//设置文件接收路径
                                        fs = File.Create(FileName);//创建文件
                                        fs.Write(msg.Data, 0, msg.Data.Length);//向文件中写入接收物信息
                                    }
                                    finally
                                    {
                                        fs.Close();//关闭文件
                                    }
                                    break;
                                }
                            case SendState.Sending:
                                {
                                    FileStream fs = null;
                                    try
                                    {
                                        string FileName = "c:\\Void.bmp";//设置文件接收路径
                                        fs = File.OpenWrite(FileName);//打开当前要写入的文件
                                        fs.Seek(0, SeekOrigin.End);//将该流的当前位值设为0
                                        fs.Write(msg.Data, 0, msg.Data.Length);//向文件中写入当前接收的信息
                                    }
                                    finally
                                    {
                                        fs.Close();
                                    }
                                    break;
                                }
                            case SendState.End:
                                {
                                    pictureBox2.Load("c:\\Void.bmp");
                                    break;
                                }

                        }
                    }
                    break;
            }
        }

        private void F_Chat_Load(object sender, EventArgs e)
        {
            udpSocket1.Active = true;
        }

        private void button_Incepl_Click(object sender, EventArgs e)
        {
            Voiding = false;
            SendViod = true;
            timer1.Enabled = false;
            panel1.Visible = false;
            video.CloseWebcam();
            //MessageBox.Show(System.Environment.CurrentDirectory + @"\Image\QQ08.jpg");
            string dir = System.Environment.CurrentDirectory;
            dir = dir.Substring(0, dir.Length - 9);
            pictureBox2.Load(dir + @"Image\QQ08.jpg");
            pictureBox1.Load(dir + @"Image\QQ12.jpg");
        }

        private void F_Chat_FormClosed(object sender, FormClosedEventArgs e)
        {
            FormList.Remove(this);
            udpSocket1.Active = false;
        }

        private void button_Close_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
