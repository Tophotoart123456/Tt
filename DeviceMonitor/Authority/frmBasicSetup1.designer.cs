namespace OperatorSystem
{
   public partial class frmBasicSetup1
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
            this.panel_Setup = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel_SetupHeader = new System.Windows.Forms.Panel();
            this.labClose = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.panel_Setup.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel_SetupHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_Setup
            // 
            this.panel_Setup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.panel_Setup.Controls.Add(this.groupBox2);
            this.panel_Setup.Controls.Add(this.panel_SetupHeader);
            this.panel_Setup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Setup.Location = new System.Drawing.Point(0, 0);
            this.panel_Setup.Name = "panel_Setup";
            this.panel_Setup.Padding = new System.Windows.Forms.Padding(1);
            this.panel_Setup.Size = new System.Drawing.Size(474, 397);
            this.panel_Setup.TabIndex = 7;
            this.panel_Setup.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_Setup_Paint);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tableLayoutPanel1);
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(8, 28);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(455, 357);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Authority";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoScroll = true;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 17);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(449, 337);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel_SetupHeader
            // 
            this.panel_SetupHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.panel_SetupHeader.Controls.Add(this.labClose);
            this.panel_SetupHeader.Controls.Add(this.label9);
            this.panel_SetupHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_SetupHeader.Location = new System.Drawing.Point(1, 1);
            this.panel_SetupHeader.Name = "panel_SetupHeader";
            this.panel_SetupHeader.Size = new System.Drawing.Size(472, 22);
            this.panel_SetupHeader.TabIndex = 1;
            this.panel_SetupHeader.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel_SetupHeader_MouseDown);
            // 
            // labClose
            // 
            this.labClose.AutoSize = true;
            this.labClose.ForeColor = System.Drawing.Color.White;
            this.labClose.Location = new System.Drawing.Point(450, 4);
            this.labClose.Name = "labClose";
            this.labClose.Size = new System.Drawing.Size(17, 12);
            this.labClose.TabIndex = 1;
            this.labClose.Text = "×";
            this.labClose.Click += new System.EventHandler(this.labClose_Click);
            this.labClose.MouseDown += new System.Windows.Forms.MouseEventHandler(this.labClose_MouseDown);
            this.labClose.MouseLeave += new System.EventHandler(this.labClose_MouseLeave);
            this.labClose.MouseHover += new System.EventHandler(this.labClose_MouseHover);
            this.labClose.MouseUp += new System.Windows.Forms.MouseEventHandler(this.labClose_MouseUp);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(0, 3);
            this.label9.Margin = new System.Windows.Forms.Padding(0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(70, 14);
            this.label9.TabIndex = 0;
            this.label9.Text = "Authority";
            // 
            // frmBasicSetup1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(474, 397);
            this.Controls.Add(this.panel_Setup);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmBasicSetup1";
            this.Text = "frmSetup";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmBasicSetup_Load);
            this.LocationChanged += new System.EventHandler(this.frmBasicSetup_LocationChanged);
            this.panel_Setup.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.panel_SetupHeader.ResumeLayout(false);
            this.panel_SetupHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_Setup;
        public System.Windows.Forms.Panel panel_SetupHeader;
        private System.Windows.Forms.Label labClose;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}