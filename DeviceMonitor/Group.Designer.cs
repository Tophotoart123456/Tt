namespace DeviceMonitor
{
    partial class Group
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
            this.panel4 = new System.Windows.Forms.Panel();
            this.label_Ip = new System.Windows.Forms.Label();
            this.label_ComputerName = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label_StartTime = new System.Windows.Forms.Label();
            this.label_Exam = new System.Windows.Forms.Label();
            this.label_TrainTime = new System.Windows.Forms.Label();
            this.label_Record = new System.Windows.Forms.Label();
            this.label_End = new System.Windows.Forms.Label();
            this.label_StartOrPause = new System.Windows.Forms.Label();
            this.label_Load = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.TitelLabel = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.flowLayoutPanel1);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(453, 184);
            this.panel1.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Transparent;
            this.panel4.Controls.Add(this.label_Ip);
            this.panel4.Controls.Add(this.label_ComputerName);
            this.panel4.Controls.Add(this.pictureBox1);
            this.panel4.Font = new System.Drawing.Font("Microsoft YaHei UI", 6.5F);
            this.panel4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panel4.Location = new System.Drawing.Point(246, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(91, 37);
            this.panel4.TabIndex = 6;
            this.panel4.Visible = false;
            // 
            // label_Ip
            // 
            this.label_Ip.AutoSize = true;
            this.label_Ip.BackColor = System.Drawing.Color.White;
            this.label_Ip.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label_Ip.Location = new System.Drawing.Point(4, 17);
            this.label_Ip.Name = "label_Ip";
            this.label_Ip.Size = new System.Drawing.Size(58, 14);
            this.label_Ip.TabIndex = 7;
            this.label_Ip.Text = "192.168.0.90";
            // 
            // label_ComputerName
            // 
            this.label_ComputerName.AutoSize = true;
            this.label_ComputerName.BackColor = System.Drawing.Color.White;
            this.label_ComputerName.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label_ComputerName.Location = new System.Drawing.Point(4, 2);
            this.label_ComputerName.Name = "label_ComputerName";
            this.label_ComputerName.Size = new System.Drawing.Size(37, 14);
            this.label_ComputerName.TabIndex = 6;
            this.label_ComputerName.Text = "Radar1";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::DeviceMonitor.Properties.Resources.矩形_1x;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(91, 37);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 36);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(451, 110);
            this.flowLayoutPanel1.TabIndex = 3;
            this.flowLayoutPanel1.MouseHover += new System.EventHandler(this.flowLayoutPanel1_MouseHover);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.panel3.Controls.Add(this.label_StartTime);
            this.panel3.Controls.Add(this.label_Exam);
            this.panel3.Controls.Add(this.label_TrainTime);
            this.panel3.Controls.Add(this.label_Record);
            this.panel3.Controls.Add(this.label_End);
            this.panel3.Controls.Add(this.label_StartOrPause);
            this.panel3.Controls.Add(this.label_Load);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.panel3.Location = new System.Drawing.Point(0, 146);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(451, 36);
            this.panel3.TabIndex = 2;
            // 
            // label_StartTime
            // 
            this.label_StartTime.Dock = System.Windows.Forms.DockStyle.Right;
            this.label_StartTime.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.label_StartTime.ForeColor = System.Drawing.Color.White;
            this.label_StartTime.Location = new System.Drawing.Point(316, 0);
            this.label_StartTime.Name = "label_StartTime";
            this.label_StartTime.Size = new System.Drawing.Size(64, 36);
            this.label_StartTime.TabIndex = 6;
            this.label_StartTime.Text = "00:00";
            this.label_StartTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label_Exam
            // 
            this.label_Exam.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(132)))), ((int)(((byte)(132)))));
            this.label_Exam.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label_Exam.Location = new System.Drawing.Point(172, 5);
            this.label_Exam.Name = "label_Exam";
            this.label_Exam.Size = new System.Drawing.Size(32, 23);
            this.label_Exam.TabIndex = 5;
            this.label_Exam.Tag = "5";
            this.label_Exam.Text = "考试";
            this.label_Exam.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_Exam.Click += new System.EventHandler(this.LabelClick);
            // 
            // label_TrainTime
            // 
            this.label_TrainTime.Dock = System.Windows.Forms.DockStyle.Right;
            this.label_TrainTime.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.label_TrainTime.ForeColor = System.Drawing.Color.White;
            this.label_TrainTime.Location = new System.Drawing.Point(380, 0);
            this.label_TrainTime.Name = "label_TrainTime";
            this.label_TrainTime.Size = new System.Drawing.Size(71, 36);
            this.label_TrainTime.TabIndex = 4;
            this.label_TrainTime.Text = "/00:00";
            this.label_TrainTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_Record
            // 
            this.label_Record.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label_Record.Image = global::DeviceMonitor.Properties.Resources.icon_record_off_1x;
            this.label_Record.Location = new System.Drawing.Point(131, 5);
            this.label_Record.Name = "label_Record";
            this.label_Record.Size = new System.Drawing.Size(32, 23);
            this.label_Record.TabIndex = 3;
            this.label_Record.Tag = "4";
            this.label_Record.Click += new System.EventHandler(this.LabelClick);
            // 
            // label_End
            // 
            this.label_End.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label_End.Image = global::DeviceMonitor.Properties.Resources.icon_stop_off_1x;
            this.label_End.Location = new System.Drawing.Point(90, 5);
            this.label_End.Name = "label_End";
            this.label_End.Size = new System.Drawing.Size(35, 23);
            this.label_End.TabIndex = 2;
            this.label_End.Tag = "3";
            this.label_End.Click += new System.EventHandler(this.LabelClick);
            // 
            // label_StartOrPause
            // 
            this.label_StartOrPause.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label_StartOrPause.Image = global::DeviceMonitor.Properties.Resources.icon_play_off_1x;
            this.label_StartOrPause.Location = new System.Drawing.Point(49, 5);
            this.label_StartOrPause.Name = "label_StartOrPause";
            this.label_StartOrPause.Size = new System.Drawing.Size(35, 23);
            this.label_StartOrPause.TabIndex = 1;
            this.label_StartOrPause.Tag = "2";
            this.label_StartOrPause.Click += new System.EventHandler(this.LabelClick);
            // 
            // label_Load
            // 
            this.label_Load.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label_Load.Image = global::DeviceMonitor.Properties.Resources.icon_load_off_1x;
            this.label_Load.Location = new System.Drawing.Point(10, 5);
            this.label_Load.Name = "label_Load";
            this.label_Load.Size = new System.Drawing.Size(33, 23);
            this.label_Load.TabIndex = 0;
            this.label_Load.Tag = "1";
            this.label_Load.Click += new System.EventHandler(this.LabelClick);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.panel2.Controls.Add(this.comboBox3);
            this.panel2.Controls.Add(this.comboBox2);
            this.panel2.Controls.Add(this.comboBox1);
            this.panel2.Controls.Add(this.TitelLabel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(451, 36);
            this.panel2.TabIndex = 1;
            // 
            // comboBox3
            // 
            this.comboBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.comboBox3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(306, 5);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(142, 25);
            this.comboBox3.TabIndex = 3;
            this.comboBox3.SelectedIndexChanged += new System.EventHandler(this.comboBox3_SelectedIndexChanged);
            // 
            // comboBox2
            // 
            this.comboBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.comboBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "训练计划",
            "回放计划"});
            this.comboBox2.Location = new System.Drawing.Point(183, 5);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 25);
            this.comboBox2.TabIndex = 2;
            // 
            // comboBox1
            // 
            this.comboBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.comboBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(60, 5);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 25);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // TitelLabel
            // 
            this.TitelLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.TitelLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.TitelLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.TitelLabel.Location = new System.Drawing.Point(0, 0);
            this.TitelLabel.Name = "TitelLabel";
            this.TitelLabel.Size = new System.Drawing.Size(60, 36);
            this.TitelLabel.TabIndex = 0;
            this.TitelLabel.Text = "Group1";
            this.TitelLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Group
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "Group";
            this.Size = new System.Drawing.Size(453, 184);
            this.Load += new System.EventHandler(this.Group_Load);
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label TitelLabel;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label_Record;
        private System.Windows.Forms.Label label_End;
        private System.Windows.Forms.Label label_StartOrPause;
        private System.Windows.Forms.Label label_Load;
        private System.Windows.Forms.Label label_TrainTime;
        private System.Windows.Forms.Label label_Exam;
        private System.Windows.Forms.Label label_StartTime;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label_Ip;
        private System.Windows.Forms.Label label_ComputerName;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
