namespace DeviceMonitor
{
    partial class GroupSeting
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.button_Ok = new System.Windows.Forms.Button();
            this.label_Warning = new System.Windows.Forms.Label();
            this.label_Add = new System.Windows.Forms.Label();
            this.label_Reduce = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.CloseLabel = new System.Windows.Forms.PictureBox();
            this.label_DeviceName = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CloseLabel)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.textBox2);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.button_Cancel);
            this.panel1.Controls.Add(this.button_Ok);
            this.panel1.Controls.Add(this.label_Warning);
            this.panel1.Controls.Add(this.label_Add);
            this.panel1.Controls.Add(this.label_Reduce);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(256, 192);
            this.panel1.TabIndex = 0;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(125, 110);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(48, 23);
            this.textBox2.TabIndex = 13;
            this.textBox2.Text = "3";
            // 
            // label2
            // 
            this.label2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Image = global::DeviceMonitor.Properties.Resources.icon_plusbtn_1x;
            this.label2.Location = new System.Drawing.Point(182, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 17);
            this.label2.TabIndex = 12;
            this.label2.Tag = "3";
            // 
            // label3
            // 
            this.label3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label3.ForeColor = System.Drawing.SystemColors.Control;
            this.label3.Image = global::DeviceMonitor.Properties.Resources.icon_minusbtn_1x;
            this.label3.Location = new System.Drawing.Point(95, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(18, 17);
            this.label3.TabIndex = 11;
            this.label3.Tag = "2";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.Control;
            this.label4.Location = new System.Drawing.Point(17, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 17);
            this.label4.TabIndex = 10;
            this.label4.Text = "联合训练组:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(125, 56);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(48, 23);
            this.textBox1.TabIndex = 9;
            this.textBox1.Text = "3";
            this.textBox1.Click += new System.EventHandler(this.textBox1_Click);
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            //this.textBox1.Validating += new System.ComponentModel.CancelEventHandler(this.textBox1_Validating);
            // 
            // button_Cancel
            // 
            this.button_Cancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(151)))), ((int)(((byte)(151)))));
            this.button_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_Cancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button_Cancel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button_Cancel.Location = new System.Drawing.Point(94, 150);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(48, 24);
            this.button_Cancel.TabIndex = 8;
            this.button_Cancel.Tag = "2";
            this.button_Cancel.Text = "取消";
            this.button_Cancel.UseVisualStyleBackColor = false;
            // 
            // button_Ok
            // 
            this.button_Ok.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(151)))), ((int)(((byte)(151)))));
            this.button_Ok.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button_Ok.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button_Ok.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button_Ok.Location = new System.Drawing.Point(20, 150);
            this.button_Ok.Name = "button_Ok";
            this.button_Ok.Size = new System.Drawing.Size(48, 24);
            this.button_Ok.TabIndex = 7;
            this.button_Ok.Tag = "1";
            this.button_Ok.Text = "确定";
            this.button_Ok.UseVisualStyleBackColor = false;
            // 
            // label_Warning
            // 
            this.label_Warning.AutoSize = true;
            this.label_Warning.ForeColor = System.Drawing.Color.Red;
            this.label_Warning.Location = new System.Drawing.Point(18, 86);
            this.label_Warning.Name = "label_Warning";
            this.label_Warning.Size = new System.Drawing.Size(56, 17);
            this.label_Warning.TabIndex = 6;
            this.label_Warning.Text = "分组数：";
            this.label_Warning.Visible = false;
            // 
            // label_Add
            // 
            this.label_Add.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label_Add.ForeColor = System.Drawing.SystemColors.Control;
            this.label_Add.Image = global::DeviceMonitor.Properties.Resources.icon_plusbtn_1x;
            this.label_Add.Location = new System.Drawing.Point(182, 59);
            this.label_Add.Name = "label_Add";
            this.label_Add.Size = new System.Drawing.Size(26, 17);
            this.label_Add.TabIndex = 4;
            this.label_Add.Tag = "3";
            this.label_Add.Click += new System.EventHandler(this.LabelClick);
            // 
            // label_Reduce
            // 
            this.label_Reduce.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label_Reduce.ForeColor = System.Drawing.SystemColors.Control;
            this.label_Reduce.Image = global::DeviceMonitor.Properties.Resources.icon_minusbtn_1x;
            this.label_Reduce.Location = new System.Drawing.Point(95, 60);
            this.label_Reduce.Name = "label_Reduce";
            this.label_Reduce.Size = new System.Drawing.Size(18, 17);
            this.label_Reduce.TabIndex = 3;
            this.label_Reduce.Tag = "2";
            this.label_Reduce.Click += new System.EventHandler(this.LabelClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(17, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "独立训练组:";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(214)))), ((int)(((byte)(214)))));
            this.panel2.Controls.Add(this.CloseLabel);
            this.panel2.Controls.Add(this.label_DeviceName);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(254, 24);
            this.panel2.TabIndex = 1;
            // 
            // CloseLabel
            // 
            this.CloseLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CloseLabel.Dock = System.Windows.Forms.DockStyle.Right;
            this.CloseLabel.Image = global::DeviceMonitor.Properties.Resources.icon_closePopUp_2x1;
            this.CloseLabel.Location = new System.Drawing.Point(212, 0);
            this.CloseLabel.Name = "CloseLabel";
            this.CloseLabel.Size = new System.Drawing.Size(42, 24);
            this.CloseLabel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.CloseLabel.TabIndex = 1;
            this.CloseLabel.TabStop = false;
            this.CloseLabel.Tag = "1";
            this.CloseLabel.Click += new System.EventHandler(this.LabelClick);
            // 
            // label_DeviceName
            // 
            this.label_DeviceName.Dock = System.Windows.Forms.DockStyle.Left;
            this.label_DeviceName.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.label_DeviceName.Location = new System.Drawing.Point(0, 0);
            this.label_DeviceName.Name = "label_DeviceName";
            this.label_DeviceName.Size = new System.Drawing.Size(73, 24);
            this.label_DeviceName.TabIndex = 0;
            this.label_DeviceName.Text = "训练组设置";
            this.label_DeviceName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // GroupSeting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.ClientSize = new System.Drawing.Size(256, 192);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "GroupSeting";
            this.Text = "GroupSeting";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CloseLabel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label_Add;
        private System.Windows.Forms.Label label_Reduce;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox CloseLabel;
        private System.Windows.Forms.Label label_DeviceName;
        private System.Windows.Forms.Label label_Warning;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button_Cancel;
        private System.Windows.Forms.Button button_Ok;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}