using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FTP_LS
{
    public partial class frmNewFolder : Form
    {
        public frmNewFolder()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtNewFolderName.Text == "")
            { }
            else
            {
                if (txtNewFolderName.Text.Trim().LastIndexOf(".") != -1)
                {
                    MessageBox.Show("文件夹名不规范", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    frmMain main = (frmMain)this.Owner;
                    main.FolderName = txtNewFolderName.Text.Trim();
                    this.Close();
                }
            }
        }

        private void frmNewFolder_Load(object sender, EventArgs e)
        {

        }
    }
}