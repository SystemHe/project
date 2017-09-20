using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace LinqShowFInfo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                listView1.Items.Clear();//清空listview控件
                textBox1.Text = folderBrowserDialog1.SelectedPath;//获取选择的文件夹的路径
                List<FileInfo> myfile = new List<FileInfo>();//实例化List泛型类对象
                foreach (string strFile in Directory.GetFiles(textBox1.Text))//遍历选择文件夹中的所有文件
                {
                    myfile.Add(new FileInfo(strFile));//将遍历到的所有文件添加到list中
                }
                //使用Linq从list对象中查找文件
                var values = from strFile in myfile
                             group strFile by strFile.Extension into FExten
                             orderby FExten.Key
                             select FExten;
                foreach (var vFile in values)
                {
                    foreach (var v in vFile)
                        listView1.Items.Add(v.FullName);//将文件名添加到listview中
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listView1.View = View.Details;//设置listview的显示方式
        }

        private void listView1_Click(object sender, EventArgs e)
        {
                FileInfo myFile = new FileInfo(listView1.SelectedItems[0].Text);//实例化fileinfo对象
                //定义一个数组来存储文件的相关属性
                string[] strAttribute = new string[] { myFile.Name, Convert.ToDouble(myFile.Length / 1024).ToString(), myFile.Extension, myFile.CreationTime.ToString(), myFile.IsReadOnly.ToString(), myFile.LastWriteTime.ToString() };
                var value = from str in strAttribute    //使用Linq为文件属性赋值
                            select new
                            {
                                Name = strAttribute[0].ToString(),
                                Size = strAttribute[1].ToString(),
                                Exten = strAttribute[2].ToString(),
                                Readonly = strAttribute[4].ToString(),
                                CTime = strAttribute[3].ToString(),
                                WTime = strAttribute[5].ToString()
                            };
                foreach (var v in value)
                {   //输出文件属性
                    textBox2.Text = v.Name.ToString();
                    textBox3.Text = v.Exten.ToString();
                    textBox4.Text = v.Size.ToString();
                    textBox5.Text = v.CTime.ToString();
                    textBox6.Text = v.Readonly.ToString();
                    textBox7.Text = v.WTime.ToString();
                }
        }
    }
}
