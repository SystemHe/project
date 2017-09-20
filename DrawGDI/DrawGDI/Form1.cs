using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace DrawGDI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 绘制矩形
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            Graphics ghs = this.CreateGraphics();//创建Graphic对象
            ghs.Clear(this.BackColor);
            Brush bus = new SolidBrush(Color.Crimson);//使用SolidBrush类创建一个Brush对象
            Rectangle rts = new Rectangle(50, 150, 200, 200);//绘制一个矩形
            ghs.FillRectangle(bus, rts);//用Brush填充Rectangle
        }
        /// <summary>
        /// 绘制一个长条图示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            Graphics ghs = this.CreateGraphics();//创建Graphic对象
            ghs.Clear(this.BackColor);
            for (int i = 0; i < 10; i++)
            {
                HatchStyle hs = (HatchStyle)(1 + i);//设置HatchStyle的值
                HatchBrush hb = new HatchBrush(hs, Color.Cyan);//实例化HatchBrush类
                Rectangle rts = new Rectangle(50, 50*i, 30*i,50);//根据i值绘制矩形
                ghs.FillRectangle(hb, rts);//填充矩形
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Graphics ghs = this.CreateGraphics();//创建Graphic对象
            ghs.Clear(this.BackColor);
            Point p1 = new Point(100, 100);
            Point p2 = new Point(200, 200);
            LinearGradientBrush lgb = new LinearGradientBrush(p1, p2, Color.Crimson, Color.DarkBlue);
            lgb.WrapMode = WrapMode.TileFlipX;
            ghs.FillRectangle(lgb, 50, 100, 200, 300);
        }
        /// <summary>
        /// 画直线，两种方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            Pen pen1 = new Pen(Color.DarkGoldenrod, 10);//实例化Pen类
            Point p1 = new Point(50, 200);//实例化Point类
            Point p2 = new Point(330, 200);//再实例化一个point类
            Graphics g = this.CreateGraphics();//创建Graphic对象
            g.Clear(this.BackColor);
            g.DrawLine(pen1, p1, p2);//方法一
            Pen pen2 = new Pen(Color.CornflowerBlue, 20);
            g.DrawLine(pen2, 190, 500, 190, 100);//方法二
        }
        /// <summary>
        /// 画矩形
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();//创建Graphic对象
            g.Clear(this.BackColor);
            Pen pen1 = new Pen(Color.Chocolate, 15);
            g.DrawRectangle(pen1, 50, 150, 200, 200);
        }
        /// <summary>
        /// 画椭圆
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button6_Click(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();//创建Graphic对象
            g.Clear(this.BackColor);
            Pen pen1 = new Pen(Color.Chocolate, 5);
            g.DrawEllipse(pen1, 50, 150, 200, 100);//椭圆
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();//创建Graphic对象
            g.Clear(this.BackColor);
            Pen pen1 = new Pen(Color.Chocolate, 5);
            Rectangle rg = new Rectangle(50, 150, 300, 200);//定义一个Rectangle结构，绘制一个椭圆
            //调用DrawArc方法绘制圆弧，在椭圆上截取一段圆弧
            g.DrawArc(pen1, rg, 100, 200);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();//创建Graphic对象
            g.Clear(this.BackColor);
            Pen pen1 = new Pen(Color.Chocolate, 5);
            g.DrawPie(pen1, 50, 150, 200, 300, 210, 120);//调用DrawPie方法绘制扇形
        }
        /// <summary>
        /// 绘制多边形
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button9_Click(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();//创建Graphic对象
            g.Clear(this.BackColor);
            Pen pen1 = new Pen(Color.Chocolate, 1);
            Point p1 = new Point(50, 150);
            Point p2 = new Point(100, 200);
            Point p3 = new Point(150, 300);
            Point p4 = new Point(300, 400);
            Point p5 = new Point(330, 350);
            Point p6 = new Point(310, 250);
            Point[] point = { p1, p2, p3, p4, p5, p6 };
            //调用DrawPolygon方法绘制多边形
            g.DrawPolygon(pen1, point);
        }
        /// <summary>
        /// 绘制文字
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button10_Click(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();//创建Graphic对象
            g.Clear(this.BackColor);
            SolidBrush sb = new SolidBrush(Color.CadetBlue);
            string str = "领益科技";
            Font myFont = new Font("幼圆", 20, FontStyle.Bold);
            //调用DrawString方法绘制文字
            g.DrawString(str, myFont, sb, 50, 150);
        }
        /// <summary>
        /// 绘制图形
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button11_Click(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();//创建Graphic对象
            g.Clear(this.BackColor);
            Image myImg=Image.FromFile(@"C:\Users\he.jun\Desktop\桌面文件\logo1.jpg");
            //调用DrawImage方法显示图片
            g.DrawImage(myImg, 50, 150);
        }

    }
}
