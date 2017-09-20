using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace SCFile
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSplit_Click(object sender, EventArgs e)
        {
            if (txtLength.Text == "")
            {
                MessageBox.Show("请输入要分割的文件大小！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtLength.Focus();
            }
            else if (cboxUnit.Text == "")
            {
                MessageBox.Show("请选择要分割的文件单位！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboxUnit.Focus();
            }
            else 
            {
                //分割文件
                SplitFile(cboxUnit.Text,Convert.ToInt32(txtLength.Text.Trim()),txtPath.Text,txtFile.Text,progressBar);
            }
        }
        /// <summary>
        /// 分割文件
        /// </summary>
        /// <param name="strFlag">分割单位</param>
        /// <param name="intFlag">分割大小</param>
        /// <param name="strPath">分割后的文件存放路径</param>
        /// <param name="strFile">要分割的文件</param>
        /// <param name="PBar">进度显示</param>
        private void SplitFile(string strFlag, int intFlag, string strPath, string strFile, ProgressBar PBar)
        {
            int iFileSize = 0;
            //根据选择来确定分割的小文件的大小
            switch (strFlag)
            { 
                case "Byte":
                    iFileSize = intFlag;
                    break;
                case "KB":
                    iFileSize = intFlag * 1024;
                    break;
                case "MB":
                    iFileSize = intFlag * 1024 * 1024;
                    break;
                case "GB":
                    iFileSize = intFlag * 1024 * 1024 * 1024;
                    break;
            }
            //如果计算机不存在存放分割文件的目录，则创建一个
            if (!Directory.Exists(strPath))
            {
                Directory.CreateDirectory(strPath);
            }
            //以文件的全路径对应的字符串和文件的打开方式来初始化FileStream文件流实例
            FileStream SplitFileStream = new FileStream(strFile, FileMode.Open);
            //以FileStream文件流实例来初始化BinaryReader文件阅读器
            BinaryReader SplitFileReader = new BinaryReader(SplitFileStream);
            byte[] tempBytes;//每次分割读取的最大数据
            //计算分割出来的文件的数量
            int iFileCount = (int)(SplitFileStream.Length / iFileSize);
            PBar.Maximum = iFileCount;//设置进度条的最大值
            if (SplitFileStream.Length % iFileSize != 0) iFileCount++;//小文件总数
            string[] tempExtra = strFile.Split('.');
            string fileName = strFile.Substring(strFile.LastIndexOf("\\") + 1, (strFile.LastIndexOf(".") - strFile.LastIndexOf("\\") - 1));
            for (int i = 1; i <= iFileCount; i++)//循环将大文件分割成多个小文件
            {

                string sTempFileName = strPath + @"\" +fileName+DateTime.Now.ToString("yyMMdd")+ i.ToString().PadLeft(4, '0') + "." + tempExtra[tempExtra.Length - 1];
                //以文件名称和文件的打开模式来初始化FileStream文件流实例
                FileStream tempStream = new FileStream(sTempFileName,FileMode.OpenOrCreate);
                //以FileStream实例来创建、初始化BinaryWrite书写器实例
                BinaryWriter tempWriter = new BinaryWriter(tempStream);
                tempBytes = SplitFileReader.ReadBytes(iFileSize);//从大文件中读取指定大小的数据
                tempWriter.Write(tempBytes);//把此数据写入小文件
                tempWriter.Close();//关闭书写器
                tempStream.Close();//关闭文件流
                PBar.Value = i - 1;//显示进度
            }
            SplitFileReader.Close();//关闭大文件阅读器
            SplitFileStream.Close();//关闭大文件文件流
            MessageBox.Show("文件分割成功！");
            
        }

        private void btnCombin_Click(object sender, EventArgs e)
        {
            if (txtCFile.Text.IndexOf(",") == -1)
                MessageBox.Show("请选择要合并的文件，最少为两个！！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                string[] strFiles = txtCFile.Text.Split(',');
                CombinFile(strFiles,txtCPath.Text,progressBar);//合并文件
            }
        }
        /// <summary>
        /// 合并文件
        /// </summary>
        /// <param name="strFile">要合并的文件的集合</param>
        /// <param name="strPath">合并后的文件名称</param>
        /// <param name="PBar">进度显示</param>
        private void CombinFile(string[] strFile, string strPath, ProgressBar PBar)
        {
            PBar.Maximum = strFile.Length;//设置进度条的最大值
            FileStream addStream = null;//创建文件流对象
            //以合并后的文件名称和文件的打开方式来初始化FileStream文件流实例
            addStream = new FileStream(strPath, FileMode.Append);
            //用FileStream实例创建、初始化BinaryWriter书写器实例，用来合并分割后的文件
            BinaryWriter addWriter = new BinaryWriter(addStream);
            FileStream tempStream = null;
            BinaryReader tempReader = null;
            for (int i = 0; i < strFile.Length-1; i++)//循环合并小文件，并生成合成文件
            {
                //以小文件的文件名称和文件的打开方式来初始化FileStream文件流实例,起到读取分割作用
                tempStream = new FileStream(strFile[i].ToString(),FileMode.Open);
                tempReader = new BinaryReader(tempStream);
                //读取分割文件中的数据，并生成合并后的文件
                addWriter.Write(tempReader.ReadBytes((int)tempStream.Length));
                tempReader.Close();//关闭阅读器
                tempStream.Close();//关闭文件流
                PBar.Value = i + 2;//进度显示
            }
            addWriter.Close();//关闭BinaryWriter书写器
            addStream.Close();//关闭文件流
            MessageBox.Show("文件合并成功！！");
        }

        private void btnSFile_Click(object sender, EventArgs e)
        {
            //获取文件路径
            OpenFileDialog openfile = new OpenFileDialog();
            if (openfile.ShowDialog() == DialogResult.OK)
                txtFile.Text = openfile.FileName;
        }

        private void btnSPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == DialogResult.OK || dialog.ShowDialog() == DialogResult.Yes)
            {
                txtPath.Text = dialog.SelectedPath;
            }
        }

        private void btnCFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openfile = new OpenFileDialog();
            openfile.Multiselect = true;
            string strFileName = "";
            if (openfile.ShowDialog() == DialogResult.OK)
            {
                foreach (string s in openfile.FileNames)
                {
                    strFileName += s.ToString()+",";
                }
                txtCFile.Text = strFileName;
            }
               
        }

        private void btnCPath_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            if (sfd.ShowDialog() == DialogResult.OK || sfd.ShowDialog() == DialogResult.Yes)
            {
                txtCPath.Text = sfd.FileName;
            }
        }

        private void tabControl1_Click(object sender, EventArgs e)
        {
            progressBar.Value = 0;
        }

    }
}
