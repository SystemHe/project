namespace MyQQClient
{
    partial class F_Logon
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button_QQLogon = new System.Windows.Forms.Button();
            this.button_QQClose = new System.Windows.Forms.Button();
            this.text_Name = new System.Windows.Forms.TextBox();
            this.text_PassWord = new System.Windows.Forms.TextBox();
            this.udpSocket1 = new QQClass.UDPSocket(this.components);
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "用户名：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 131);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "密  码：";
            // 
            // button_QQLogon
            // 
            this.button_QQLogon.Location = new System.Drawing.Point(56, 198);
            this.button_QQLogon.Name = "button_QQLogon";
            this.button_QQLogon.Size = new System.Drawing.Size(75, 23);
            this.button_QQLogon.TabIndex = 2;
            this.button_QQLogon.Text = "登录";
            this.button_QQLogon.UseVisualStyleBackColor = true;
            this.button_QQLogon.Click += new System.EventHandler(this.button_QQLogon_Click);
            // 
            // button_QQClose
            // 
            this.button_QQClose.Location = new System.Drawing.Point(205, 197);
            this.button_QQClose.Name = "button_QQClose";
            this.button_QQClose.Size = new System.Drawing.Size(75, 23);
            this.button_QQClose.TabIndex = 3;
            this.button_QQClose.Text = "取消";
            this.button_QQClose.UseVisualStyleBackColor = true;
            // 
            // text_Name
            // 
            this.text_Name.Location = new System.Drawing.Point(108, 53);
            this.text_Name.Name = "text_Name";
            this.text_Name.Size = new System.Drawing.Size(210, 25);
            this.text_Name.TabIndex = 4;
            // 
            // text_PassWord
            // 
            this.text_PassWord.Location = new System.Drawing.Point(108, 128);
            this.text_PassWord.Name = "text_PassWord";
            this.text_PassWord.Size = new System.Drawing.Size(210, 25);
            this.text_PassWord.TabIndex = 5;
            // 
            // udpSocket1
            // 
            this.udpSocket1.Active = false;
            this.udpSocket1.LocalHost = "192.168.1.96";
            this.udpSocket1.LocalPort = 11003;
            this.udpSocket1.DataArrival += new QQClass.UDPSocket.DataArrivalEventHandler(this.udpSocket1_DataArrival);
            // 
            // F_Logon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(330, 255);
            this.Controls.Add(this.text_PassWord);
            this.Controls.Add(this.text_Name);
            this.Controls.Add(this.button_QQClose);
            this.Controls.Add(this.button_QQLogon);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "F_Logon";
            this.Text = "用户登录";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.F_Logon_FormClosed);
            this.Load += new System.EventHandler(this.F_Logon_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_QQLogon;
        private System.Windows.Forms.Button button_QQClose;
        private System.Windows.Forms.TextBox text_Name;
        private System.Windows.Forms.TextBox text_PassWord;
        private QQClass.UDPSocket udpSocket1;
    }
}