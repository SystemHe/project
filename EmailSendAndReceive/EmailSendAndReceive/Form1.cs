﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EmailSendAndReceive
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmSend frmSend = new frmSend();
            frmSend.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmReceive frmReceive = new frmReceive();
            frmReceive.Show();
        }
    }
}
