using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace SYImage
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string[] ImgArray;
        string ImgDirectoryPath;
        private void btnLoadImg_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)//判断是否选择了文件
            {
                ImgArray = openFileDialog1.FileNames;//记录选择的所有图片
                lbImgList.Items.Clear();//清空ListBox列表
                string imgP = ImgArray[0].ToString();//获取图片的完整路径
                imgP = imgP.Remove(imgP.LastIndexOf("\\"));//获取图片的根目录
                ImgDirectoryPath = imgP;//记录图片的根目录
                for (int i = 0; i < ImgArray.Length; i++)//循环访问选择的所有图片
                {
                    string ImgPath = ImgArray[i].ToString();//记录每张图片的路径
                    //获取图片名称
                    string ImgName = ImgPath.Substring(ImgPath.LastIndexOf("\\") + 1, ImgPath.Length - ImgPath.LastIndexOf("\\") - 1);
                    //将选择的图片添加到listBox中
                    lbImgList.Items.Add(ImgName);
                }
            }
        }
        FontFamily fontF;
        Color fontColor;
        float fontSize;
        FontStyle fontStyle;
        SolidBrush b;
        Bitmap bt,Bigbt;
        Font f;
        int Fwidth, Fheight;
        string NewFolderPath;
        private void button1_Click(object sender, EventArgs e)
        {
            if (lbImgList.Items.Count > 0)//判断是否选择了图片
            {
                fontDialog1.ShowColor = true;
                fontDialog1.ShowHelp = false;
                fontDialog1.ShowApply = false;
                if (fontDialog1.ShowDialog() == DialogResult.OK)//判断是否选择了字体
                {
                    fontF = fontDialog1.Font.FontFamily;//记录选择的字体
                    fontColor = fontDialog1.Color;//记录选择的字体颜色
                    fontSize = fontDialog1.Font.Size;//记录选择的字体大小
                    fontStyle = fontDialog1.Font.Style;//记录选择的字体样式
                    AddFontWaterMark(txtWaterMakeFont.Text.Trim(),lbImgList.Items[0].ToString(),0);
                    pbImgPreview.Image = bt;//在pictureBox中显示字体预览效果
                }
            }
        }
        /// <summary>
        /// 预览水印文字
        /// </summary>
        /// <param name="txt">水印文字</param>
        /// <param name="lname">要添加水印文字的图片名称</param>
        /// <param name="i">是否保存水印图片</param>
        private void AddFontWaterMark(string txt, string lname, int i)
        {
            b = new SolidBrush(fontColor);//实例化SolidBrush
            bt = new Bitmap(368,75);//实例化Bitmap，设置水印图片的大小
            Bigbt = new Bitmap(Image.FromFile(ImgDirectoryPath + "\\" + lname));//通过图片路径实例化Bitmap
            Graphics g = Graphics.FromImage(bt);//实例化Graphics
            Graphics g1 = Graphics.FromImage(Bigbt);//实例化Graphics
            g.Clear(Color.Gainsboro);//设置画布背景颜色
            pbImgPreview.Image = bt;//设置Image属性
            if (fontF == null)//判断是否设置了字体
            {
                f = new Font(txt, fontSize);//实例化字体
                SizeF XMaxSize = g.MeasureString(txt, f);//获取字体大小
                Fwidth = (int)XMaxSize.Width;//字体宽度
                Fheight = (int)XMaxSize.Height;//字体高度
                g.DrawString(txt, f, b, (int)(368 - Fwidth) / 2, (int)(75 - Fheight) / 2);//绘制文字水印
                g1.DrawString(txt, f, b, (int)(Bigbt.Width - Fwidth) / 2, (int)(Bigbt.Height - Fheight) / 2);
            }
            else    //如果设置了字体
            {
                f = new Font(fontF, fontSize, fontStyle);//实例化字体
                SizeF XMaxSize = g.MeasureString(txt, f);//获取字体大小
                Fwidth = (int)XMaxSize.Width;//字体宽度
                Fheight = (int)XMaxSize.Height;//字体高度
                g.DrawString(txt, new Font(fontF, fontSize, fontStyle), b, (int)(368 - Fwidth) / 2, (int)(75 - Fheight) / 2);
                g1.DrawString(txt, new Font(fontF, fontSize, fontStyle), b, (int)(Bigbt.Width - Fwidth) / 2, (int)(Bigbt.Height - Fheight) / 2);
            }
            if (i == 1)//i为1时保存添加了文字水印的图片
            {
                string iPath;//加水印后的图片路径
                NewFolderPath = txtSavePath.Text.Trim();//获取路径
                if (NewFolderPath.Length == 3)//判断是否是系统磁盘
                {
                    //如果是则去掉": "后面的字符
                    iPath = NewFolderPath.Remove(NewFolderPath.LastIndexOf(":") + 1);
                }
                else
                {
                    iPath = NewFolderPath;//获取路径
                }
                //获取图片类型
                string imgstype = lname.Substring(lname.LastIndexOf(".") + 1, lname.Length - 1 - lname.LastIndexOf("."));
                //原图是什么类型，加水印后还是什么类型
                if (imgstype.ToLower() == "jpeg" || imgstype.ToLower() == "jpg")
                {
                    Bigbt.Save(iPath + "\\_" + lname, ImageFormat.Jpeg);
                }
                if (imgstype.ToLower() == "png")
                {
                    Bigbt.Save(iPath + "\\_" + lname, ImageFormat.Png);
                }
                if (imgstype.ToLower() == "bmp")
                {
                    Bigbt.Save(iPath + "\\_" + lname, ImageFormat.Bmp);
                }
                if (imgstype.ToLower() == "gif")
                {
                    Bigbt.Save(iPath + "\\_" + lname, ImageFormat.Gif);
                }
                g1.Dispose();
                Bigbt.Dispose();
            }
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog NewFolderPath = new FolderBrowserDialog();
            string strPath=null;
            if (NewFolderPath.ShowDialog() == DialogResult.OK)//判断是否选择了图片的保存路径
            {
                strPath = NewFolderPath.SelectedPath;//获取文件保存路径
            }
            txtSavePath.Text = strPath;
        }

        private void btnPerform_Click(object sender, EventArgs e)
        {
            if (txtSavePath.Text != "" && txtWaterMakeFont.Text != "")//判断是否添加了保存路径和水印文字
            {
                for (int i = 0; i < lbImgList.Items.Count; i++)//循环访问加水印图片列表
                {
                    //为图片添加水印并保存
                    AddFontWaterMark(txtWaterMakeFont.Text.Trim(), lbImgList.Items[i].ToString(), 1);
                }
            }
            MessageBox.Show("水印添加成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }
}
