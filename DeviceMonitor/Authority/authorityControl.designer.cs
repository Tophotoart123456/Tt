namespace OperatorSystem
{
    public partial class authorityControl
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.button3 = new System.Windows.Forms.Button();
            this.btnAuthority = new System.Windows.Forms.Button();
            this.btnPlanType = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(69)))), ((int)(((byte)(69)))));
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 57.30337F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 42.69663F));
            this.tableLayoutPanel1.Controls.Add(this.button3, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnAuthority, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnPlanType, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Font = new System.Drawing.Font("Microsoft YaHei UI", 8F);
            this.tableLayoutPanel1.ForeColor = System.Drawing.SystemColors.Window;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(90, 51);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.button3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button3.Location = new System.Drawing.Point(51, 26);
            this.button3.Margin = new System.Windows.Forms.Padding(0);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(38, 24);
            this.button3.TabIndex = 2;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnAuthority
            // 
            this.btnAuthority.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.btnAuthority.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAuthority.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAuthority.Location = new System.Drawing.Point(1, 1);
            this.btnAuthority.Margin = new System.Windows.Forms.Padding(0);
            this.btnAuthority.Name = "btnAuthority";
            this.tableLayoutPanel1.SetRowSpan(this.btnAuthority, 2);
            this.btnAuthority.Size = new System.Drawing.Size(49, 49);
            this.btnAuthority.TabIndex = 0;
            this.btnAuthority.Text = "button1";
            this.btnAuthority.UseVisualStyleBackColor = false;
            this.btnAuthority.Click += new System.EventHandler(this.btnAuthority_Click);
            // 
            // btnPlanType
            // 
            this.btnPlanType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.btnPlanType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPlanType.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPlanType.Location = new System.Drawing.Point(51, 1);
            this.btnPlanType.Margin = new System.Windows.Forms.Padding(0);
            this.btnPlanType.Name = "btnPlanType";
            this.btnPlanType.Size = new System.Drawing.Size(38, 24);
            this.btnPlanType.TabIndex = 1;
            this.btnPlanType.Text = "Type";
            this.btnPlanType.UseVisualStyleBackColor = false;
            this.btnPlanType.Click += new System.EventHandler(this.btnPlanType_Click);
            // 
            // authorityControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "authorityControl";
            this.Size = new System.Drawing.Size(90, 51);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnAuthority;
        private System.Windows.Forms.Button btnPlanType;
    }
}
