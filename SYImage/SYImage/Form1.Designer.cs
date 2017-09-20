namespace SYImage
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.lbImgList = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtWaterMakeFont = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSavePath = new System.Windows.Forms.TextBox();
            this.pbImgPreview = new System.Windows.Forms.PictureBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.btnLoadImg = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.btnPerform = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbImgPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // lbImgList
            // 
            this.lbImgList.FormattingEnabled = true;
            this.lbImgList.ItemHeight = 15;
            this.lbImgList.Location = new System.Drawing.Point(13, 13);
            this.lbImgList.Name = "lbImgList";
            this.lbImgList.Size = new System.Drawing.Size(192, 319);
            this.lbImgList.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(211, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "输入水印文字：";
            // 
            // txtWaterMakeFont
            // 
            this.txtWaterMakeFont.Location = new System.Drawing.Point(214, 95);
            this.txtWaterMakeFont.Name = "txtWaterMakeFont";
            this.txtWaterMakeFont.Size = new System.Drawing.Size(403, 25);
            this.txtWaterMakeFont.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(220, 266);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "文件保存路径：";
            // 
            // txtSavePath
            // 
            this.txtSavePath.Location = new System.Drawing.Point(338, 263);
            this.txtSavePath.Name = "txtSavePath";
            this.txtSavePath.Size = new System.Drawing.Size(279, 25);
            this.txtSavePath.TabIndex = 4;
            // 
            // pbImgPreview
            // 
            this.pbImgPreview.Location = new System.Drawing.Point(211, 157);
            this.pbImgPreview.Name = "pbImgPreview";
            this.pbImgPreview.Size = new System.Drawing.Size(504, 87);
            this.pbImgPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbImgPreview.TabIndex = 5;
            this.pbImgPreview.TabStop = false;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "图片文件|*.jpeg;*.jpg;*.bmp;*.png;*.gif";
            this.openFileDialog1.Multiselect = true;
            // 
            // btnLoadImg
            // 
            this.btnLoadImg.Location = new System.Drawing.Point(212, 33);
            this.btnLoadImg.Name = "btnLoadImg";
            this.btnLoadImg.Size = new System.Drawing.Size(75, 23);
            this.btnLoadImg.TabIndex = 6;
            this.btnLoadImg.Text = "加载图片";
            this.btnLoadImg.UseVisualStyleBackColor = true;
            this.btnLoadImg.Click += new System.EventHandler(this.btnLoadImg_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(624, 95);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 25);
            this.button1.TabIndex = 7;
            this.button1.Text = "设置字体";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(214, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 15);
            this.label3.TabIndex = 8;
            this.label3.Text = "预览水印效果";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(624, 263);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 25);
            this.button2.TabIndex = 9;
            this.button2.Text = "浏览...";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnPerform
            // 
            this.btnPerform.Location = new System.Drawing.Point(464, 304);
            this.btnPerform.Name = "btnPerform";
            this.btnPerform.Size = new System.Drawing.Size(75, 28);
            this.btnPerform.TabIndex = 10;
            this.btnPerform.Text = "确定";
            this.btnPerform.UseVisualStyleBackColor = true;
            this.btnPerform.Click += new System.EventHandler(this.btnPerform_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(591, 304);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 28);
            this.btnExit.TabIndex = 11;
            this.btnExit.Text = "退出";
            this.btnExit.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(727, 340);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnPerform);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnLoadImg);
            this.Controls.Add(this.pbImgPreview);
            this.Controls.Add(this.txtSavePath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtWaterMakeFont);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbImgList);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pbImgPreview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbImgList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtWaterMakeFont;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSavePath;
        private System.Windows.Forms.PictureBox pbImgPreview;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button btnLoadImg;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnPerform;
        private System.Windows.Forms.Button btnExit;
    }
}

