namespace MyQQClient
{
    partial class F_Chat
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(F_Chat));
            this.Rich_Out = new System.Windows.Forms.RichTextBox();
            this.Rich_Input = new System.Windows.Forms.RichTextBox();
            this.button_Close = new System.Windows.Forms.Button();
            this.button_Send = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.视频 = new System.Windows.Forms.ToolStripButton();
            this.Label = new System.Windows.Forms.ToolStripLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.udpSocket1 = new QQClass.UDPSocket(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button_Incepl = new System.Windows.Forms.Button();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Rich_Out
            // 
            this.Rich_Out.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Rich_Out.Location = new System.Drawing.Point(12, 28);
            this.Rich_Out.Name = "Rich_Out";
            this.Rich_Out.Size = new System.Drawing.Size(432, 266);
            this.Rich_Out.TabIndex = 0;
            this.Rich_Out.Text = "";
            // 
            // Rich_Input
            // 
            this.Rich_Input.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Rich_Input.Location = new System.Drawing.Point(12, 300);
            this.Rich_Input.Name = "Rich_Input";
            this.Rich_Input.Size = new System.Drawing.Size(432, 90);
            this.Rich_Input.TabIndex = 1;
            this.Rich_Input.Text = "";
            // 
            // button_Close
            // 
            this.button_Close.Location = new System.Drawing.Point(218, 394);
            this.button_Close.Name = "button_Close";
            this.button_Close.Size = new System.Drawing.Size(75, 23);
            this.button_Close.TabIndex = 2;
            this.button_Close.Text = "关闭";
            this.button_Close.UseVisualStyleBackColor = true;
            this.button_Close.Click += new System.EventHandler(this.button_Close_Click);
            // 
            // button_Send
            // 
            this.button_Send.Location = new System.Drawing.Point(348, 396);
            this.button_Send.Name = "button_Send";
            this.button_Send.Size = new System.Drawing.Size(75, 23);
            this.button_Send.TabIndex = 3;
            this.button_Send.Text = "发送";
            this.button_Send.UseVisualStyleBackColor = true;
            this.button_Send.Click += new System.EventHandler(this.button_Send_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.视频,
            this.Label});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(655, 25);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // 视频
            // 
            this.视频.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.视频.Image = ((System.Drawing.Image)(resources.GetObject("视频.Image")));
            this.视频.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.视频.Name = "视频";
            this.视频.Size = new System.Drawing.Size(23, 22);
            this.视频.Text = "视频";
            this.视频.Click += new System.EventHandler(this.视频_Click);
            // 
            // Label
            // 
            this.Label.Name = "Label";
            this.Label.Size = new System.Drawing.Size(39, 22);
            this.Label.Text = "视频";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // udpSocket1
            // 
            this.udpSocket1.Active = false;
            this.udpSocket1.LocalHost = "127.0.0.1";
            this.udpSocket1.LocalPort = 11005;
            this.udpSocket1.DataArrival += new QQClass.UDPSocket.DataArrivalEventHandler(this.udpSocket1_DataArrival);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(450, 42);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(193, 157);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(450, 224);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(193, 166);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 6;
            this.pictureBox2.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button_Incepl);
            this.panel1.Location = new System.Drawing.Point(0, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(444, 266);
            this.panel1.TabIndex = 7;
            this.panel1.Visible = false;
            // 
            // button_Incepl
            // 
            this.button_Incepl.Location = new System.Drawing.Point(366, 240);
            this.button_Incepl.Name = "button_Incepl";
            this.button_Incepl.Size = new System.Drawing.Size(75, 23);
            this.button_Incepl.TabIndex = 0;
            this.button_Incepl.Text = "关闭视频";
            this.button_Incepl.UseVisualStyleBackColor = true;
            this.button_Incepl.Click += new System.EventHandler(this.button_Incepl_Click);
            // 
            // F_Chat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(655, 429);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.button_Send);
            this.Controls.Add(this.button_Close);
            this.Controls.Add(this.Rich_Input);
            this.Controls.Add(this.Rich_Out);
            this.Controls.Add(this.panel1);
            this.Name = "F_Chat";
            this.Text = "F_Chat";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.F_Chat_FormClosed);
            this.Load += new System.EventHandler(this.F_Chat_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox Rich_Input;
        private System.Windows.Forms.Button button_Close;
        private System.Windows.Forms.Button button_Send;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton 视频;
        private System.Windows.Forms.ToolStripLabel Label;
        private System.Windows.Forms.Timer timer1;
        private QQClass.UDPSocket udpSocket1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button_Incepl;
        public System.Windows.Forms.RichTextBox Rich_Out;
    }
}