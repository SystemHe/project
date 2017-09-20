using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void ToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ToolStripMenuItem2_Click_1(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void ToolStripMenuItem3_Click_1(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2();
            frm2.Show();
            frm2.MdiParent = this;
            Form3 frm3 = new Form3();
            frm3.Show();
            frm3.MdiParent = this;
            Form4 frm4 = new Form4();
            frm4.Show();
            frm4.MdiParent = this;
        }
    }
}
