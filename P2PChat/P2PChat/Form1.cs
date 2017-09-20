using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Net.Sockets;
using System.Net;
using System.IO;

namespace P2PChat
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private Thread td;
        private TcpListener tcpListener;
        private static string message = "";
        private void Form1_Load(object sender, EventArgs e)
        {
            td = new Thread(new ThreadStart(this.startListen));
            td.Start();
            timer1.Start();
        }

        private void startListen()
        {
            message = "";
            tcpListener = new TcpListener(888);
            tcpListener.Start();
            while (true)
            {
                TcpClient tclient = tcpListener.AcceptTcpClient();
                NetworkStream nstream = tclient.GetStream();
                byte[] mybyte = new byte[1024];
                int i = nstream.Read(mybyte,0,mybyte.Length);
                message = Encoding.Default.GetString(mybyte,0,i);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                IPAddress[] ip = Dns.GetHostAddresses(Dns.GetHostName());
                string strmsg = " " + txtName.Text + "(" + ip[0].ToString() + ")" + DateTime.Now.ToLongTimeString() + "\n" + "  " + this.rtbSend.Text + "\n";
                TcpClient tcpClient = new TcpClient(txtIP.Text, 888);
                NetworkStream netStream = tcpClient.GetStream();
                StreamWriter wstream = new StreamWriter(netStream, Encoding.Default);
                wstream.Write(strmsg);
                wstream.Flush();
                wstream.Close();
                tcpClient.Close();
                rtbContent.AppendText(strmsg);
                rtbContent.ScrollToCaret();
                rtbSend.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (message != "")
            {
                rtbContent.AppendText(message);
                rtbContent.ScrollToCaret();
                message = "";
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.tcpListener != null)
            {
                tcpListener.Stop();
            }
            if (td != null)
            {
                if (td.ThreadState == ThreadState.Running)
                {
                    td.Abort();
                }
            }
        }
    }
}
