using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Mail;

namespace EmailSendAndReceive
{
    public partial class frmSend : Form
    {
        public frmSend()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        public static string Base64Encode(string str)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(str));
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                MailAddress from = new MailAddress(textBox1.Text);//设置发件人
                MailAddress to = new MailAddress(textBox2.Text);//设置收件人
                MailMessage message = new MailMessage(from, to);//实例化MailMessage对象
                message.Subject = Base64Encode(textBox7.Text);//设置发送邮件的主题
                message.Body = Base64Encode(textBox8.Text);//设置发送邮件的内容
                //实例化SMTPClient发送类对象
                SmtpClient client = new SmtpClient(textBox5.Text, Convert.ToInt32(textBox6.Text));
                //设置用于验证发件人身份的凭据
                client.Credentials = new System.Net.NetworkCredential(textBox3.Text, textBox4.Text);
                client.Send(message);//发送
                MessageBox.Show("发送成功！");
            }
            catch
            {
                MessageBox.Show("发送失败！");
            }
        }
    }
}
