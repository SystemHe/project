namespace SCFile
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
            this.components = new System.ComponentModel.Container();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnSPath = new System.Windows.Forms.Button();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboxUnit = new System.Windows.Forms.ComboBox();
            this.txtLength = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSplit = new System.Windows.Forms.Button();
            this.btnSFile = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFile = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnCombin = new System.Windows.Forms.Button();
            this.btnCPath = new System.Windows.Forms.Button();
            this.txtCPath = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnCFile = new System.Windows.Forms.Button();
            this.txtCFile = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 13);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(439, 219);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.Click += new System.EventHandler(this.tabControl1_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnSPath);
            this.tabPage1.Controls.Add(this.txtPath);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.cboxUnit);
            this.tabPage1.Controls.Add(this.txtLength);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.btnSplit);
            this.tabPage1.Controls.Add(this.btnSFile);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.txtFile);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(431, 190);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "文件分割";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnSPath
            // 
            this.btnSPath.Location = new System.Drawing.Point(373, 157);
            this.btnSPath.Name = "btnSPath";
            this.btnSPath.Size = new System.Drawing.Size(52, 25);
            this.btnSPath.TabIndex = 9;
            this.btnSPath.Text = "<<";
            this.btnSPath.UseVisualStyleBackColor = true;
            this.btnSPath.Click += new System.EventHandler(this.btnSPath_Click);
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(22, 157);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(345, 25);
            this.txtPath.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(172, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "选择分割后文件存放路径";
            // 
            // cboxUnit
            // 
            this.cboxUnit.FormattingEnabled = true;
            this.cboxUnit.Items.AddRange(new object[] {
            "Byte",
            "KB",
            "MB",
            "GB"});
            this.cboxUnit.Location = new System.Drawing.Point(189, 90);
            this.cboxUnit.Name = "cboxUnit";
            this.cboxUnit.Size = new System.Drawing.Size(91, 23);
            this.cboxUnit.TabIndex = 6;
            // 
            // txtLength
            // 
            this.txtLength.Location = new System.Drawing.Point(37, 90);
            this.txtLength.Name = "txtLength";
            this.txtLength.Size = new System.Drawing.Size(146, 25);
            this.txtLength.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(142, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "设置分割文件的大小";
            // 
            // btnSplit
            // 
            this.btnSplit.Location = new System.Drawing.Point(325, 33);
            this.btnSplit.Name = "btnSplit";
            this.btnSplit.Size = new System.Drawing.Size(75, 23);
            this.btnSplit.TabIndex = 3;
            this.btnSplit.Text = "分割";
            this.btnSplit.UseVisualStyleBackColor = true;
            this.btnSplit.Click += new System.EventHandler(this.btnSplit_Click);
            // 
            // btnSFile
            // 
            this.btnSFile.Location = new System.Drawing.Point(275, 31);
            this.btnSFile.Name = "btnSFile";
            this.btnSFile.Size = new System.Drawing.Size(44, 25);
            this.btnSFile.TabIndex = 2;
            this.btnSFile.Text = "<<";
            this.btnSFile.UseVisualStyleBackColor = true;
            this.btnSFile.Click += new System.EventHandler(this.btnSFile_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "请选择要分割的文件";
            // 
            // txtFile
            // 
            this.txtFile.Location = new System.Drawing.Point(37, 31);
            this.txtFile.Name = "txtFile";
            this.txtFile.Size = new System.Drawing.Size(232, 25);
            this.txtFile.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnCombin);
            this.tabPage2.Controls.Add(this.btnCPath);
            this.tabPage2.Controls.Add(this.txtCPath);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.btnCFile);
            this.tabPage2.Controls.Add(this.txtCFile);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(431, 190);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "文件合成";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnCombin
            // 
            this.btnCombin.Location = new System.Drawing.Point(157, 144);
            this.btnCombin.Name = "btnCombin";
            this.btnCombin.Size = new System.Drawing.Size(75, 27);
            this.btnCombin.TabIndex = 6;
            this.btnCombin.Text = "合并";
            this.btnCombin.UseVisualStyleBackColor = true;
            this.btnCombin.Click += new System.EventHandler(this.btnCombin_Click);
            // 
            // btnCPath
            // 
            this.btnCPath.Location = new System.Drawing.Point(356, 97);
            this.btnCPath.Name = "btnCPath";
            this.btnCPath.Size = new System.Drawing.Size(69, 23);
            this.btnCPath.TabIndex = 5;
            this.btnCPath.Text = "<<";
            this.btnCPath.UseVisualStyleBackColor = true;
            this.btnCPath.Click += new System.EventHandler(this.btnCPath_Click);
            // 
            // txtCPath
            // 
            this.txtCPath.Location = new System.Drawing.Point(26, 96);
            this.txtCPath.Name = "txtCPath";
            this.txtCPath.Size = new System.Drawing.Size(323, 25);
            this.txtCPath.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(26, 78);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(187, 15);
            this.label5.TabIndex = 3;
            this.label5.Text = "选择合并后文件的存放路径";
            // 
            // btnCFile
            // 
            this.btnCFile.Location = new System.Drawing.Point(356, 36);
            this.btnCFile.Name = "btnCFile";
            this.btnCFile.Size = new System.Drawing.Size(69, 23);
            this.btnCFile.TabIndex = 2;
            this.btnCFile.Text = "<<";
            this.btnCFile.UseVisualStyleBackColor = true;
            this.btnCFile.Click += new System.EventHandler(this.btnCFile_Click);
            // 
            // txtCFile
            // 
            this.txtCFile.Location = new System.Drawing.Point(26, 35);
            this.txtCFile.Name = "txtCFile";
            this.txtCFile.Size = new System.Drawing.Size(323, 25);
            this.txtCFile.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(127, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "选择要合成的文件";
            // 
            // progressBar
            // 
            this.progressBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar.Location = new System.Drawing.Point(0, 238);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(460, 23);
            this.progressBar.TabIndex = 1;
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            this.openFileDialog.Multiselect = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(460, 261);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btnSPath;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboxUnit;
        private System.Windows.Forms.TextBox txtLength;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSplit;
        private System.Windows.Forms.Button btnSFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFile;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnCombin;
        private System.Windows.Forms.Button btnCPath;
        private System.Windows.Forms.TextBox txtCPath;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnCFile;
        private System.Windows.Forms.TextBox txtCFile;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.Timer timer;
    }
}

