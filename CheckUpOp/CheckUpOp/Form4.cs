using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CheckUpOp
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        string path1 = "C:\\Users\\he.jun\\Desktop\\桌面文件\\logo1.jpg";
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("添加的内容不能为空！");
            }
            listView1.LargeImageList = imageList1;
            imageList1.ImageSize = new System.Drawing.Size(30, 30);
            Image Mimg2 = Image.FromFile(path1, true);
            imageList1.Images.Add(Mimg2);
            listView1.SmallImageList = imageList1;
            listView1.Items.Add(textBox1.Text.Trim());
            for(int i=0;i<listView1.Items.Count;i++)
            listView1.Items[i].ImageIndex = 0;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listView1.Items.Count == 0)
            {
                MessageBox.Show("ListView里已经没有内容了！");
            }
            listView1.Items.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("请选择要移除的项！");
            }
            listView1.Items.RemoveAt(listView1.SelectedItems[0].Index);
            listView1.SelectedItems.Clear();
        }

    }
}
