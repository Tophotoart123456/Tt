namespace DeviceMonitor
{
    partial class ComputerSetting
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.maskedTextBox2 = new System.Windows.Forms.Label();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.lbl_Mac = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button_RestartCompt = new System.Windows.Forms.Button();
            this.button_StartComput = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label_Return = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.maskedTextBox2);
            this.panel1.Controls.Add(this.comboBox3);
            this.panel1.Controls.Add(this.lbl_Mac);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.panel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(256, 192);
            this.panel1.TabIndex = 1;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(119, 103);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(132, 23);
            this.textBox1.TabIndex = 10;
            // 
            // maskedTextBox2
            // 
            this.maskedTextBox2.AutoSize = true;
            this.maskedTextBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.maskedTextBox2.Location = new System.Drawing.Point(93, 106);
            this.maskedTextBox2.Name = "maskedTextBox2";
            this.maskedTextBox2.Size = new System.Drawing.Size(135, 17);
            this.maskedTextBox2.TabIndex = 9;
            this.maskedTextBox2.Text = "MAC-MAC-MAC-MAC";
            this.maskedTextBox2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // comboBox3
            // 
            this.comboBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.comboBox3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comboBox3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(91, 37);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(142, 25);
            this.comboBox3.TabIndex = 8;
            this.comboBox3.SelectionChangeCommitted += new System.EventHandler(this.comboBox3_SelectionChangeCommitted);
            // 
            // lbl_Mac
            // 
            this.lbl_Mac.AutoSize = true;
            this.lbl_Mac.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.lbl_Mac.Location = new System.Drawing.Point(93, 71);
            this.lbl_Mac.Name = "lbl_Mac";
            this.lbl_Mac.Size = new System.Drawing.Size(135, 17);
            this.lbl_Mac.TabIndex = 6;
            this.lbl_Mac.Text = "MAC-MAC-MAC-MAC";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.label5.Location = new System.Drawing.Point(21, 106);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 17);
            this.label5.TabIndex = 4;
            this.label5.Text = "IP地址";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.label4.Location = new System.Drawing.Point(21, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "物理地址";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.label3.Location = new System.Drawing.Point(21, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "设备分组";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(214)))), ((int)(((byte)(214)))));
            this.panel3.Controls.Add(this.button_RestartCompt);
            this.panel3.Controls.Add(this.button_StartComput);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.panel3.Location = new System.Drawing.Point(0, 158);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(254, 32);
            this.panel3.TabIndex = 1;
            // 
            // button_RestartCompt
            // 
            this.button_RestartCompt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(151)))), ((int)(((byte)(151)))));
            this.button_RestartCompt.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_RestartCompt.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button_RestartCompt.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button_RestartCompt.Location = new System.Drawing.Point(67, 4);
            this.button_RestartCompt.Name = "button_RestartCompt";
            this.button_RestartCompt.Size = new System.Drawing.Size(48, 24);
            this.button_RestartCompt.TabIndex = 1;
            this.button_RestartCompt.Tag = "2";
            this.button_RestartCompt.Text = "重启";
            this.button_RestartCompt.UseVisualStyleBackColor = false;
            this.button_RestartCompt.Click += new System.EventHandler(this.ButtonClick);
            // 
            // button_StartComput
            // 
            this.button_StartComput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(151)))), ((int)(((byte)(151)))));
            this.button_StartComput.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_StartComput.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button_StartComput.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button_StartComput.Location = new System.Drawing.Point(3, 4);
            this.button_StartComput.Name = "button_StartComput";
            this.button_StartComput.Size = new System.Drawing.Size(48, 24);
            this.button_StartComput.TabIndex = 0;
            this.button_StartComput.Tag = "1";
            this.button_StartComput.Text = "开机";
            this.button_StartComput.UseVisualStyleBackColor = false;
            this.button_StartComput.Click += new System.EventHandler(this.ButtonClick);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(214)))), ((int)(((byte)(214)))));
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label_Return);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(254, 24);
            this.panel2.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(28, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "主机设置";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_Return
            // 
            this.label_Return.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label_Return.Dock = System.Windows.Forms.DockStyle.Left;
            this.label_Return.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.label_Return.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.label_Return.Image = global::DeviceMonitor.Properties.Resources.icon_pre_grey_1x;
            this.label_Return.Location = new System.Drawing.Point(0, 0);
            this.label_Return.Name = "label_Return";
            this.label_Return.Size = new System.Drawing.Size(28, 24);
            this.label_Return.TabIndex = 0;
            this.label_Return.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label_Return.Click += new System.EventHandler(this.label_Return_Click);
            // 
            // ComputerSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "ComputerSetting";
            this.Size = new System.Drawing.Size(256, 192);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label_Return;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button button_StartComput;
        private System.Windows.Forms.Label lbl_Mac;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button_RestartCompt;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.Label maskedTextBox2;
        private System.Windows.Forms.TextBox textBox1;
    }
}
