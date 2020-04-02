namespace DeviceMonitor
{
    partial class Device
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label_Permission = new System.Windows.Forms.Label();
            this.label_AXN = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.CloseComputerLabel = new System.Windows.Forms.PictureBox();
            this.label_DeviceName = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CloseComputerLabel)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(256, 192);
            this.panel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Controls.Add(this.flowLayoutPanel1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 24);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(254, 166);
            this.panel3.TabIndex = 2;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(214)))), ((int)(((byte)(214)))));
            this.panel4.Controls.Add(this.label_Permission);
            this.panel4.Controls.Add(this.label_AXN);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 132);
            this.panel4.Margin = new System.Windows.Forms.Padding(0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(252, 32);
            this.panel4.TabIndex = 0;
            // 
            // label_Permission
            // 
            this.label_Permission.Dock = System.Windows.Forms.DockStyle.Left;
            this.label_Permission.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.label_Permission.Location = new System.Drawing.Point(76, 0);
            this.label_Permission.Name = "label_Permission";
            this.label_Permission.Size = new System.Drawing.Size(76, 32);
            this.label_Permission.TabIndex = 1;
            this.label_Permission.Text = "西塔(自定义)";
            this.label_Permission.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_AXN
            // 
            this.label_AXN.Dock = System.Windows.Forms.DockStyle.Left;
            this.label_AXN.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.label_AXN.Location = new System.Drawing.Point(0, 0);
            this.label_AXN.Name = "label_AXN";
            this.label_AXN.Size = new System.Drawing.Size(76, 32);
            this.label_AXN.TabIndex = 0;
            this.label_AXN.Text = "130.35";
            this.label_AXN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(252, 164);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(214)))), ((int)(((byte)(214)))));
            this.panel2.Controls.Add(this.CloseComputerLabel);
            this.panel2.Controls.Add(this.label_DeviceName);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(254, 24);
            this.panel2.TabIndex = 0;
            // 
            // CloseComputerLabel
            // 
            this.CloseComputerLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CloseComputerLabel.Dock = System.Windows.Forms.DockStyle.Right;
            this.CloseComputerLabel.Image = global::DeviceMonitor.Properties.Resources.icon_setup_grey_1x;
            this.CloseComputerLabel.Location = new System.Drawing.Point(212, 0);
            this.CloseComputerLabel.Name = "CloseComputerLabel";
            this.CloseComputerLabel.Size = new System.Drawing.Size(42, 24);
            this.CloseComputerLabel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.CloseComputerLabel.TabIndex = 1;
            this.CloseComputerLabel.TabStop = false;
            this.CloseComputerLabel.Click += new System.EventHandler(this.TitleButtonClick);
            // 
            // label_DeviceName
            // 
            this.label_DeviceName.Dock = System.Windows.Forms.DockStyle.Left;
            this.label_DeviceName.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.label_DeviceName.Location = new System.Drawing.Point(0, 0);
            this.label_DeviceName.Name = "label_DeviceName";
            this.label_DeviceName.Size = new System.Drawing.Size(179, 24);
            this.label_DeviceName.TabIndex = 0;
            this.label_DeviceName.Text = "label1";
            this.label_DeviceName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Device
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "Device";
            this.Size = new System.Drawing.Size(256, 192);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CloseComputerLabel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label_DeviceName;
        private System.Windows.Forms.PictureBox CloseComputerLabel;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label_Permission;
        private System.Windows.Forms.Label label_AXN;
    }
}
