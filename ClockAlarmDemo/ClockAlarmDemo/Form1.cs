using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Runtime.InteropServices;

namespace ClockAlarmDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string strHour = DateTime.Now.TimeOfDay.Hours.ToString();//获取当前小时
            string strMouit = DateTime.Now.TimeOfDay.Minutes.ToString();//获取当前分钟
            string strSecon = DateTime.Now.TimeOfDay.Seconds.ToString();//获取当前秒
            if (Convert.ToInt32(strHour) < 10)
            {
                strHour = "0" + strHour;//将小时格式化为两位表示
            }
            if (Convert.ToInt32(strMouit) < 10)
            {
                strMouit = "0" + strMouit;//将分钟格式为两位表示
            }
            if (Convert.ToInt32(strSecon) < 10)
            {
                strSecon = "0" + strSecon;//将秒格式化为两位表示
            }
            textBox2.Text = strHour + ":" + strMouit + ":" + strSecon;//显示当前时间
            int hour = Convert.ToInt32(strHour);//将小时转换为int类型
            int mouit = Convert.ToInt32(strMouit);//将分钟转换为int类型
            int Secon = Convert.ToInt32(strSecon);//将秒转换为int类型
            numericUpDown1.Value = hour;//显示小时
            numericUpDown2.Value = mouit;//显示分钟
            numericUpDown3.Value = Secon;//显示秒
           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string strHour = DateTime.Now.TimeOfDay.Hours.ToString();
            string strMouit = DateTime.Now.TimeOfDay.Minutes.ToString();
            string strSecon = DateTime.Now.TimeOfDay.Seconds.ToString();
            if (Convert.ToInt32(strHour) < 10)
            {
                strHour = "0" + strHour;
            }
            if (Convert.ToInt32(strMouit) < 10)
            {
                strMouit = "0" + strMouit;
            }
            if (Convert.ToInt32(strSecon) < 10)
            {
                strSecon = "0" + strSecon;
            }
            //显示当前时间
            textBox1.Text = strHour + ":" + strMouit + ":" + strSecon;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.Text = numericUpDown1.Value + ":" + numericUpDown2.Value + ":" + numericUpDown3.Value;
            //获取当前时间
            DateTime get_time = Convert.ToDateTime(DateTime.Now.ToString());
            //获取定时时间
            DateTime sta_ontime = Convert.ToDateTime(Convert.ToDateTime(textBox2.Text.Trim().ToString()));
            //计算倒计时
            long dat = DateAndTime.DateDiff("s",get_time,sta_ontime,FirstDayOfWeek.Sunday,FirstWeekOfYear.FirstFourDays);
            if (dat > 0)//判断倒计时是否为0
            {
                if (timer2.Enabled != true)
                {
                    timer2.Enabled = true;//启动计时器
                    label1.Text = "闹钟已启动";
                    label2.Text = "剩余" + dat.ToString() + "秒";//显示倒计时
                }
                else
                {
                    MessageBox.Show("时钟已启动，请先取消后在启动", "错误提示");
                }
            }
            else
            {
                long hour = 24 * 3600 + dat;//计算倒计时
                timer2.Enabled = true;//启动计时器
                label1.Text = "闹钟已启动！";
                label2.Text = "剩余" + hour.ToString() + "秒";//显示倒计时
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            //获取单钱时间
            DateTime get_time = Convert.ToDateTime(DateTime.Now.ToString());
            //获取定时时间
            DateTime sta_ontime = Convert.ToDateTime(Convert.ToDateTime(textBox2.Text.Trim().ToString()));
            //计算倒计时
            long dat = DateAndTime.DateDiff("s", get_time, sta_ontime, FirstDayOfWeek.Sunday, FirstWeekOfYear.FirstFourDays);
            if (dat == 0)
            {
                Beep(200, 500);//声音提示
                label1.Text = "时间已到！！";
                label2.Text = "";
                timer2.Enabled = false;
            }
            else if (dat > 0)
            {
                label2.Text = "剩余" + dat.ToString() + "秒";//显示倒计时
            }
            else 
            {
                long hour = 24 * 3600 + dat;
                label2.Text = "剩余" + hour.ToString() + "秒";
            }
        }
        [DllImport("kernel32", EntryPoint = "Beep")]//使用API函数Beep来生成简单声音
        public extern static int Beep(int dwfreq, int dwduration);

        private void button2_Click(object sender, EventArgs e)
        {
            timer2.Enabled = false;//关闭计时器
            label1.Text = "闹钟已关闭！";
            label2.Text = "";
        }
        
    }
}
