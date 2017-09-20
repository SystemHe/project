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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            monthCalendar1.ShowWeekNumbers = true;
            textBox1.Text = monthCalendar1.TodayDate.ToString();
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            textBox2.Text = monthCalendar1.SelectionStart.ToString();
            textBox3.Text = monthCalendar1.SelectionEnd.ToString();
        }

    }
}
