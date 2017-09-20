namespace CalculatorDemo
{
    partial class Frm_Main
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tramp1 = new System.Windows.Forms.GroupBox();
            this.point = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.result = new System.Windows.Forms.Button();
            this.bt_div = new System.Windows.Forms.Button();
            this.bt_multi = new System.Windows.Forms.Button();
            this.bt_minus = new System.Windows.Forms.Button();
            this.bt_plus = new System.Windows.Forms.Button();
            this.btCE = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tramp1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(12, 38);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(340, 25);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // tramp1
            // 
            this.tramp1.Controls.Add(this.point);
            this.tramp1.Controls.Add(this.button10);
            this.tramp1.Controls.Add(this.button9);
            this.tramp1.Controls.Add(this.button8);
            this.tramp1.Controls.Add(this.button7);
            this.tramp1.Controls.Add(this.button6);
            this.tramp1.Controls.Add(this.button5);
            this.tramp1.Controls.Add(this.button4);
            this.tramp1.Controls.Add(this.button3);
            this.tramp1.Controls.Add(this.button2);
            this.tramp1.Controls.Add(this.button1);
            this.tramp1.Location = new System.Drawing.Point(12, 69);
            this.tramp1.Name = "tramp1";
            this.tramp1.Size = new System.Drawing.Size(224, 233);
            this.tramp1.TabIndex = 1;
            this.tramp1.TabStop = false;
            this.tramp1.Text = "数值";
            this.tramp1.Enter += new System.EventHandler(this.tramp1_Enter);
            // 
            // point
            // 
            this.point.Location = new System.Drawing.Point(150, 185);
            this.point.Name = "point";
            this.point.Size = new System.Drawing.Size(52, 31);
            this.point.TabIndex = 10;
            this.point.Text = ".";
            this.point.UseVisualStyleBackColor = true;
            this.point.Click += new System.EventHandler(this.button11_Click);
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(7, 185);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(120, 32);
            this.button10.TabIndex = 9;
            this.button10.Text = "0";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(150, 128);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(52, 35);
            this.button9.TabIndex = 8;
            this.button9.Text = "9";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(77, 128);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(50, 35);
            this.button8.TabIndex = 7;
            this.button8.Text = "8";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(7, 128);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(49, 35);
            this.button7.TabIndex = 6;
            this.button7.Text = "7";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(150, 79);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(52, 35);
            this.button6.TabIndex = 5;
            this.button6.Text = "6";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(77, 78);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(50, 36);
            this.button5.TabIndex = 4;
            this.button5.Text = "5";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(7, 77);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(49, 37);
            this.button4.TabIndex = 3;
            this.button4.Text = "4";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(150, 26);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(52, 35);
            this.button3.TabIndex = 2;
            this.button3.Text = "3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(77, 25);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(50, 36);
            this.button2.TabIndex = 1;
            this.button2.Text = "2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(7, 25);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(49, 36);
            this.button1.TabIndex = 0;
            this.button1.Text = "1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.result);
            this.groupBox1.Controls.Add(this.bt_div);
            this.groupBox1.Controls.Add(this.bt_multi);
            this.groupBox1.Controls.Add(this.bt_minus);
            this.groupBox1.Controls.Add(this.bt_plus);
            this.groupBox1.Controls.Add(this.btCE);
            this.groupBox1.Location = new System.Drawing.Point(243, 69);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(109, 233);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "操作";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // result
            // 
            this.result.Location = new System.Drawing.Point(17, 185);
            this.result.Name = "result";
            this.result.Size = new System.Drawing.Size(75, 31);
            this.result.TabIndex = 5;
            this.result.Text = "=";
            this.result.UseVisualStyleBackColor = true;
            this.result.Click += new System.EventHandler(this.button17_Click);
            // 
            // bt_div
            // 
            this.bt_div.Location = new System.Drawing.Point(63, 128);
            this.bt_div.Name = "bt_div";
            this.bt_div.Size = new System.Drawing.Size(29, 34);
            this.bt_div.TabIndex = 4;
            this.bt_div.Text = "/";
            this.bt_div.UseVisualStyleBackColor = true;
            this.bt_div.Click += new System.EventHandler(this.button16_Click);
            // 
            // bt_multi
            // 
            this.bt_multi.Location = new System.Drawing.Point(17, 128);
            this.bt_multi.Name = "bt_multi";
            this.bt_multi.Size = new System.Drawing.Size(37, 35);
            this.bt_multi.TabIndex = 3;
            this.bt_multi.Text = "*";
            this.bt_multi.UseVisualStyleBackColor = true;
            this.bt_multi.Click += new System.EventHandler(this.button15_Click);
            // 
            // bt_minus
            // 
            this.bt_minus.Location = new System.Drawing.Point(63, 77);
            this.bt_minus.Name = "bt_minus";
            this.bt_minus.Size = new System.Drawing.Size(29, 33);
            this.bt_minus.TabIndex = 2;
            this.bt_minus.Text = "-";
            this.bt_minus.UseVisualStyleBackColor = true;
            this.bt_minus.Click += new System.EventHandler(this.button14_Click);
            // 
            // bt_plus
            // 
            this.bt_plus.Location = new System.Drawing.Point(17, 78);
            this.bt_plus.Name = "bt_plus";
            this.bt_plus.Size = new System.Drawing.Size(37, 32);
            this.bt_plus.TabIndex = 1;
            this.bt_plus.Text = "+";
            this.bt_plus.UseVisualStyleBackColor = true;
            this.bt_plus.Click += new System.EventHandler(this.button13_Click);
            // 
            // btCE
            // 
            this.btCE.Location = new System.Drawing.Point(17, 26);
            this.btCE.Name = "btCE";
            this.btCE.Size = new System.Drawing.Size(75, 34);
            this.btCE.TabIndex = 0;
            this.btCE.Text = "CE";
            this.btCE.UseVisualStyleBackColor = true;
            this.btCE.Click += new System.EventHandler(this.button12_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "算式：";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // Frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 314);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tramp1);
            this.Controls.Add(this.textBox1);
            this.Name = "Frm_Main";
            this.Text = "简易计算器";
            this.Load += new System.EventHandler(this.Frm_Main_Load);
            this.tramp1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox tramp1;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button point;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button result;
        private System.Windows.Forms.Button bt_div;
        private System.Windows.Forms.Button bt_multi;
        private System.Windows.Forms.Button bt_minus;
        private System.Windows.Forms.Button bt_plus;
        private System.Windows.Forms.Button btCE;
    }
}

