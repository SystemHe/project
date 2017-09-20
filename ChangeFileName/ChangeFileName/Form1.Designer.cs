namespace ChangeFileName
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lBoxMenu = new System.Windows.Forms.ListBox();
            this.btnDSelect = new System.Windows.Forms.Button();
            this.btnCSelect = new System.Windows.Forms.Button();
            this.btnSelect = new System.Windows.Forms.Button();
            this.tvMenu = new System.Windows.Forms.TreeView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbtnEnd = new System.Windows.Forms.RadioButton();
            this.rbtnStart = new System.Windows.Forms.RadioButton();
            this.rbtnID = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cBoxExtention = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rbtnExtention = new System.Windows.Forms.RadioButton();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtNewValue = new System.Windows.Forms.TextBox();
            this.txtOldValue = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.rbtnTitle = new System.Windows.Forms.RadioButton();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btnSure = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.filesIcon = new System.Windows.Forms.ImageList(this.components);
            this.directoryIcon = new System.Windows.Forms.ImageList(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lBoxMenu);
            this.groupBox1.Controls.Add(this.btnDSelect);
            this.groupBox1.Controls.Add(this.btnCSelect);
            this.groupBox1.Controls.Add(this.btnSelect);
            this.groupBox1.Controls.Add(this.tvMenu);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(535, 267);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "选择目录";
            // 
            // lBoxMenu
            // 
            this.lBoxMenu.FormattingEnabled = true;
            this.lBoxMenu.ItemHeight = 15;
            this.lBoxMenu.Location = new System.Drawing.Point(328, 25);
            this.lBoxMenu.Name = "lBoxMenu";
            this.lBoxMenu.ScrollAlwaysVisible = true;
            this.lBoxMenu.Size = new System.Drawing.Size(201, 229);
            this.lBoxMenu.TabIndex = 4;
            // 
            // btnDSelect
            // 
            this.btnDSelect.Location = new System.Drawing.Point(238, 198);
            this.btnDSelect.Name = "btnDSelect";
            this.btnDSelect.Size = new System.Drawing.Size(75, 23);
            this.btnDSelect.TabIndex = 3;
            this.btnDSelect.Text = "<<";
            this.btnDSelect.UseVisualStyleBackColor = true;
            this.btnDSelect.Click += new System.EventHandler(this.btnDSelect_Click);
            // 
            // btnCSelect
            // 
            this.btnCSelect.Location = new System.Drawing.Point(238, 127);
            this.btnCSelect.Name = "btnCSelect";
            this.btnCSelect.Size = new System.Drawing.Size(75, 23);
            this.btnCSelect.TabIndex = 2;
            this.btnCSelect.Text = "<";
            this.btnCSelect.UseVisualStyleBackColor = true;
            this.btnCSelect.Click += new System.EventHandler(this.btnCSelect_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(238, 55);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(75, 23);
            this.btnSelect.TabIndex = 1;
            this.btnSelect.Text = ">";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // tvMenu
            // 
            this.tvMenu.Location = new System.Drawing.Point(7, 25);
            this.tvMenu.Name = "tvMenu";
            this.tvMenu.Size = new System.Drawing.Size(225, 236);
            this.tvMenu.TabIndex = 0;
            //this.tvMenu.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.tvMenu_BeforeExpand);
            //this.tvMenu.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.tvMenu_AfterExpand);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbtnEnd);
            this.groupBox2.Controls.Add(this.rbtnStart);
            this.groupBox2.Controls.Add(this.rbtnID);
            this.groupBox2.Location = new System.Drawing.Point(13, 281);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(255, 100);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // rbtnEnd
            // 
            this.rbtnEnd.AutoSize = true;
            this.rbtnEnd.Location = new System.Drawing.Point(22, 68);
            this.rbtnEnd.Name = "rbtnEnd";
            this.rbtnEnd.Size = new System.Drawing.Size(148, 19);
            this.rbtnEnd.TabIndex = 2;
            this.rbtnEnd.TabStop = true;
            this.rbtnEnd.Text = "在文件名后加编号";
            this.rbtnEnd.UseVisualStyleBackColor = true;
            // 
            // rbtnStart
            // 
            this.rbtnStart.AutoSize = true;
            this.rbtnStart.Location = new System.Drawing.Point(22, 31);
            this.rbtnStart.Name = "rbtnStart";
            this.rbtnStart.Size = new System.Drawing.Size(148, 19);
            this.rbtnStart.TabIndex = 1;
            this.rbtnStart.TabStop = true;
            this.rbtnStart.Text = "在文件名前加编号";
            this.rbtnStart.UseVisualStyleBackColor = true;
            // 
            // rbtnID
            // 
            this.rbtnID.AutoSize = true;
            this.rbtnID.Location = new System.Drawing.Point(6, 5);
            this.rbtnID.Name = "rbtnID";
            this.rbtnID.Size = new System.Drawing.Size(118, 19);
            this.rbtnID.TabIndex = 0;
            this.rbtnID.TabStop = true;
            this.rbtnID.Text = "按编号重命名";
            this.rbtnID.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cBoxExtention);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.rbtnExtention);
            this.groupBox3.Location = new System.Drawing.Point(288, 281);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(260, 100);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            // 
            // cBoxExtention
            // 
            this.cBoxExtention.FormattingEnabled = true;
            this.cBoxExtention.Location = new System.Drawing.Point(64, 53);
            this.cBoxExtention.Name = "cBoxExtention";
            this.cBoxExtention.Size = new System.Drawing.Size(173, 23);
            this.cBoxExtention.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(172, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "选择要修改成的拓展名：";
            // 
            // rbtnExtention
            // 
            this.rbtnExtention.AutoSize = true;
            this.rbtnExtention.Location = new System.Drawing.Point(6, 5);
            this.rbtnExtention.Name = "rbtnExtention";
            this.rbtnExtention.Size = new System.Drawing.Size(118, 19);
            this.rbtnExtention.TabIndex = 0;
            this.rbtnExtention.TabStop = true;
            this.rbtnExtention.Text = "拓展名重命名";
            this.rbtnExtention.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtNewValue);
            this.groupBox4.Controls.Add(this.txtOldValue);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.rbtnTitle);
            this.groupBox4.Location = new System.Drawing.Point(13, 387);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(535, 100);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            // 
            // txtNewValue
            // 
            this.txtNewValue.Location = new System.Drawing.Point(117, 58);
            this.txtNewValue.Name = "txtNewValue";
            this.txtNewValue.ReadOnly = true;
            this.txtNewValue.Size = new System.Drawing.Size(395, 25);
            this.txtNewValue.TabIndex = 4;
            // 
            // txtOldValue
            // 
            this.txtOldValue.Location = new System.Drawing.Point(117, 29);
            this.txtOldValue.Name = "txtOldValue";
            this.txtOldValue.ReadOnly = true;
            this.txtOldValue.Size = new System.Drawing.Size(395, 25);
            this.txtOldValue.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "替换后的文字:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "要替换的文字:";
            // 
            // rbtnTitle
            // 
            this.rbtnTitle.AutoSize = true;
            this.rbtnTitle.Location = new System.Drawing.Point(7, 0);
            this.rbtnTitle.Name = "rbtnTitle";
            this.rbtnTitle.Size = new System.Drawing.Size(208, 19);
            this.rbtnTitle.TabIndex = 0;
            this.rbtnTitle.TabStop = true;
            this.rbtnTitle.Text = "批量替换文件标题中的文字";
            this.rbtnTitle.UseVisualStyleBackColor = true;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(13, 494);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(333, 23);
            this.progressBar1.TabIndex = 4;
            // 
            // btnSure
            // 
            this.btnSure.Location = new System.Drawing.Point(364, 494);
            this.btnSure.Name = "btnSure";
            this.btnSure.Size = new System.Drawing.Size(75, 23);
            this.btnSure.TabIndex = 5;
            this.btnSure.Text = "确定";
            this.btnSure.UseVisualStyleBackColor = true;
            this.btnSure.Click += new System.EventHandler(this.btnSure_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(450, 494);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // filesIcon
            // 
            this.filesIcon.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("filesIcon.ImageStream")));
            this.filesIcon.TransparentColor = System.Drawing.Color.Transparent;
            this.filesIcon.Images.SetKeyName(0, "CLSDFOLD.ICO");
            // 
            // directoryIcon
            // 
            this.directoryIcon.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("directoryIcon.ImageStream")));
            this.directoryIcon.TransparentColor = System.Drawing.Color.Transparent;
            this.directoryIcon.Images.SetKeyName(0, "MyComputer.ICO");
            this.directoryIcon.Images.SetKeyName(1, "ClosedFolder.ICO");
            this.directoryIcon.Images.SetKeyName(2, "OpenFolder.ICO");
            this.directoryIcon.Images.SetKeyName(3, "FixedDrive.ico");
            this.directoryIcon.Images.SetKeyName(4, "MyDocuments.ICO");
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 539);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSure);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox lBoxMenu;
        private System.Windows.Forms.Button btnDSelect;
        private System.Windows.Forms.Button btnCSelect;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.TreeView tvMenu;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbtnEnd;
        private System.Windows.Forms.RadioButton rbtnStart;
        private System.Windows.Forms.RadioButton rbtnID;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cBoxExtention;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rbtnExtention;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtNewValue;
        private System.Windows.Forms.TextBox txtOldValue;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rbtnTitle;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button btnSure;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ImageList filesIcon;
        private System.Windows.Forms.ImageList directoryIcon;
    }
}

