using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace CheckUpOp
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        string path1 = "C:\\Users\\he.jun\\Desktop\\桌面文件\\logo1.jpg";
        string path2 = "C:\\Users\\he.jun\\Desktop\\桌面文件\\logo2.jpg";
        private void Form3_Load(object sender, EventArgs e)
        {
            
            Image Mimg2 = Image.FromFile(path1, true);
            imageList1.Images.Add(Mimg2);
            Image Mimg1 = Image.FromFile(path2, true);
            imageList1.Images.Add(Mimg2);
            imageList1.ImageSize = new Size(140, 140);
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = "图片路径：" + Path.GetFileName(path1);
            pictureBox1.Image = imageList1.Images[0];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label1.Text = "图片路径：" + Path.GetFileName(path2);
            pictureBox1.Image = imageList1.Images[1];
        }

        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form2 frm2 = new Form2();
            frm2.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Image Mimg2 = Image.FromFile(path1, true);
            imageList1.Images.Add(Mimg2);
            Image Mimg1 = Image.FromFile(path2, true);
            imageList1.Images.Add(Mimg2);
            imageList1.ImageSize = new Size(200, 165);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            imageList1.Images.RemoveAt(0);
            imageList1.Images.RemoveAt(1);
            pictureBox1.Image = null;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form4 frm4 = new Form4();
            frm4.Show();
            this.Hide();
        }
    }
}
