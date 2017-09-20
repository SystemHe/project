using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ShowDialogPBar
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            colorDialog1.AllowFullOpen = true;
            colorDialog1.AnyColor = true;
            colorDialog1.SolidColorOnly = false;//设置用户可以在颜色对话框中选择复杂颜色
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                if (richTextBox1.SelectedText == "")
                {
                    richTextBox1.SelectAll();
                }
                richTextBox1.SelectionColor = colorDialog1.Color;
            }
        }
        public Form proForm = new Form();
        public Form2(Form f1)
        {
            InitializeComponent();
            proForm = f1;
        }
        void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Form1 frm1 = new Form1();
            //frm1.Visible = true;
            proForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            fontDialog1.AllowVectorFonts = true;
            fontDialog1.AllowVerticalFonts = true;
            fontDialog1.FixedPitchOnly = false;
            fontDialog1.MaxSize = 72;
            fontDialog1.MinSize = 5;
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                if (richTextBox1.SelectedText == "")
                {
                    richTextBox1.SelectAll();
                }
                richTextBox1.SelectionFont = fontDialog1.Font;
            }
        }
    }
}
