using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace ShowDialogPBar
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CopyFile(textBox1.Text,textBox2.Text,10000,progressBar1);
        }

        private void CopyFile(string FormerFile, string toFile, int sectSize, ProgressBar progressBar1)
        {
            progressBar1.Value = 0;//设置进度条的当前进度为0
            progressBar1.Minimum = 0;//设置进度条的最小值为0 
            //创建目标文件，如果文件已存在则会覆盖
            FileStream fileToCreat = new FileStream(toFile, FileMode.Create);
            fileToCreat.Close();//关闭所有资源
            fileToCreat.Dispose();//清空所有资源
            //以自读方式打开源文件
            FileStream FormerOpen = new FileStream(FormerFile,FileMode.Open,FileAccess.Read);
            //以写方式打开目的文件
            FileStream toFileOpen = new FileStream(toFile,FileMode.Append,FileAccess.Write);
            //根据一次传输的大小来计算最大传输次数
            int max = Convert.ToInt32(Math.Ceiling((double)FormerOpen.Length/(double)sectSize));
            progressBar1.Maximum = max;//设置进度条的最大值为传输次数
            int fileSize;//要复制的文件的大小
            //如果分段复制，既每次复制的内容小于文件的总长度
            if (sectSize < FormerOpen.Length)
            {
                byte[] buffer = new byte[sectSize];//根据每次传输的大小定义一个字节数组
                int copied = 0;//记录传输的大小
                int tem_n = 1;//设置进度条每次增长的个数
                while (copied <= ((int)FormerOpen.Length - sectSize))//复制的主体部分
                {
                    fileSize = FormerOpen.Read(buffer, 0, sectSize);//从0开始读，每次读的最大长度为sectSize
                    FormerOpen.Flush();//清空缓存
                    toFileOpen.Write(buffer, 0, sectSize);//向目标文件写入字节
                    toFileOpen.Flush();//清空缓存
                    toFileOpen.Position = FormerOpen.Position;//是源文件和目标文件流的位置相同
                    copied += fileSize;//记录已复制的大小
                    progressBar1.Value = progressBar1.Value + tem_n;//进度条显示进度增加
                }
                int left = (int)FormerOpen.Length - copied;//获取剩余大小
                fileSize = FormerOpen.Read(buffer, 0, left);//读取剩余字节
                FormerOpen.Flush();//清空缓存
                toFileOpen.Write(buffer, 0, left);//写入剩余的部分
                toFileOpen.Flush();//清空缓存
            }
            else//如果整体复制，既每次复制的内容大小大于文件的总长度
            {
                byte[] buffer = new byte[FormerOpen.Length];//获取文件的大小
                FormerOpen.Read(buffer, 0, (int)FormerOpen.Length);//读取源文件的字节
                FormerOpen.Flush();//清空缓存
                toFileOpen.Write(buffer, 0, (int)FormerOpen.Length);//写入字节
                toFileOpen.Flush();//清空缓存
            }
            FormerOpen.Close();
            toFileOpen.Close();
            if (MessageBox.Show("复制完成") == DialogResult.OK)
            {
                progressBar1.Value = 0;
                textBox1.Clear();
                textBox2.Clear();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string defaultpath = "";
            OpenFileDialog dilog = new OpenFileDialog();
            if (dilog.ShowDialog() == DialogResult.OK || dilog.ShowDialog() == DialogResult.Yes)
            {
                defaultpath = dilog.FileName;//获取源文件路径
            }
            textBox1.Text = defaultpath;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string defaultpath = "";
            //SaveFileDialog dilog = new SaveFileDialog();
            //dilog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            //dilog.FilterIndex = 2;
            //dilog.RestoreDirectory = true;
            FolderBrowserDialog dilog = new FolderBrowserDialog();
            if (dilog.ShowDialog() == DialogResult.OK || dilog.ShowDialog() == DialogResult.Yes)
            {

                //defaultpath = dilog.FileName;//获取目的文件路径
                defaultpath = dilog.SelectedPath+"\\" + Path.GetFileName(textBox1.Text.Trim());
            }
            textBox2.Text = defaultpath;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2(this);
            frm2.Show();
            this.Hide();
        }


    }
}
