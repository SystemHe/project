using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace RWTxtByIO
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 使用I/O流操作文本文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == string.Empty)
            {
                MessageBox.Show("要写入的文件名不能为空！");
            }
            else
            {
                //设置保存文件的格式
                saveFileDialog1.Filter = "文本文件(*.txt)|*.txt";
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    //使用“另存为”对话框中输入的文件名来实例化StreamWriter对象
                    StreamWriter sw = new StreamWriter(saveFileDialog1.FileName,true);
                    //向创建的文件中写入内容
                    sw.WriteLine(textBox1.Text);
                    //关闭当前写入文件流
                    sw.Close();
                    //清空文本框
                    textBox1.Text = string.Empty;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //设置打开文件的格式
            openFileDialog1.Filter = "文本文件(*.txt)|*.txt";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //先清空显示文本框
                textBox1.Text = string.Empty;
                //使用“打开”对话框中选择的文件实例化StreamReader对象
                StreamReader sr = new StreamReader(openFileDialog1.FileName);
                //调用ReadToEnd方法读取选中文件的全部内容
                textBox1.Text = sr.ReadToEnd();
                //关闭文件读取流
                sr.Close();
            }
        }
        /// <summary>
        /// 使用I/O流操作二进制文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == string.Empty)
            {
                MessageBox.Show("要写入的内容不能为空！");
            }
            else
            {
                //设置保存文件的格式
                saveFileDialog1.Filter = "二进制文件(*.dat)|*.dat";
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    //使用“另存为”对话框中输入的文件名来实例化FileStream对象
                    FileStream myStream = new FileStream(saveFileDialog1.FileName,FileMode.OpenOrCreate,FileAccess.ReadWrite);
                    //使用FileStream对象实例化BinaryWriter二进制写入流对象
                    BinaryWriter myWriter = new BinaryWriter(myStream);
                    myWriter.Write(textBox1.Text);//以二进制方式向文件中写入内容
                    myWriter.Close();//关闭二进制写入流
                    myStream.Close();//关闭当前文件流
                    textBox1.Text = string.Empty;//清空文本框
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //设置打开的文件格式
            openFileDialog1.Filter = "二进制文件(*.dat)|*.dat";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = string.Empty;//首先清空显示内容的文本框
                //使用选择的文件名来实例化FileStream对象
                FileStream myStream = new FileStream(saveFileDialog1.FileName, FileMode.Open, FileAccess.Read);
                //使用FileStream对象来实例化BinaryReader二进制读取流对象
                BinaryReader myReader = new BinaryReader(myStream);
                if (myReader.PeekChar() != 1)
                {
                    //以二进制方式显示文件中的内容
                    textBox1.Text = Convert.ToString(myReader.ReadInt32());
                }
                myReader.Close();//关闭当前二进制读取流
                myStream.Close();//关闭文件流
            }
        }
    }
}
