using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DataTimeAndMouthCalendar
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Time;
            textBox1.Text = dateTimePicker1.Text;
            //*****************************************************
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat="yyyy年-MMMM-d号 dddd";
            label1.Text = dateTimePicker2.Text;
            //*****************************************************
            textBox2.Text = dateTimePicker3.Text;
            textBox3.Text = dateTimePicker3.Value.Year.ToString();
            textBox4.Text = dateTimePicker3.Value.Month.ToString();
            textBox5.Text = dateTimePicker3.Value.Day.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 frm2=new Form2();
            frm2.Show();
            this.Hide();
        }
    }
}
