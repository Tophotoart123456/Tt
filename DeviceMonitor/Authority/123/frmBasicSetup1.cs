
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DeviceMonitor.ServiceReference1;
using DeviceMonitor;
namespace OperatorSystem
{
    public partial class frmBasicSetup1 : Form
    {
    
        public bool isShow { get; set; }

        Point preLocotion = new Point(0, 0);
        Control _parentBtn;
        public frmBasicSetup1(Control parentBtn)
        {
            _parentBtn = parentBtn;
            InitializeComponent();
            isShow = true;
           
        }
    
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);
        public const int WM_SYSCOMMAND = 0x0112;
        public const int SC_MOVE = 0xF010;
        public const int HTCAPTION = 0x0002;
        private void panel_SetupHeader_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Clicks == 1)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);
              
            }
        }
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == 528|| m.Msg == 129 || m.Msg == 70)
            {
                this.BringToFront();
            }

        }

        private void labClose_Click(object sender, EventArgs e)
        {
            this.Hide();
            isShow = !isShow;
        }
       
       
        private void frmBasicSetup_LocationChanged(object sender, EventArgs e)
        {
            var diffrentX = this.Location.X - preLocotion.X;
            var diffrentY = this.Location.Y - preLocotion.Y;
            preLocotion = this.Location;
        }

      

        private void panel_Setup_Paint(object sender, PaintEventArgs e)
        {
            
        }
        public void loadAuthority()
        {
            try
            {
                tableLayoutPanel1.Controls.Clear();
                foreach (var item in Form_Main.allAuthorityData)
                {
                    authorityControl authorityControl = new authorityControl(_parentBtn);
                    authorityControl.setAuthority(item.Key);
                    tableLayoutPanel1.Controls.Add(authorityControl);

                }
            }
            catch (Exception ex)
            {
                //FlyControl._FlyControl.logger.Error("loadAuthority..." + ex.Message.ToString());
            }
           
        }

        private void frmBasicSetup_Load(object sender, EventArgs e)
        {
            loadAuthority();
        }

        private void labClose_MouseHover(object sender, EventArgs e)
        {
            ((System.Windows.Forms.Label)sender).BackColor = Color.FromArgb(150, 150, 150);
        }

        private void labClose_MouseLeave(object sender, EventArgs e)
        {
            ((System.Windows.Forms.Label)sender).BackColor = Color.FromArgb(68, 68, 68);
            ((System.Windows.Forms.Label)sender).ForeColor = Color.FromArgb(250, 250, 250);
        }

        private void labClose_MouseUp(object sender, MouseEventArgs e)
        {
            ((System.Windows.Forms.Label)sender).BackColor = Color.FromArgb(150, 150, 150);
        }

        private void labClose_MouseDown(object sender, MouseEventArgs e)
        {
            ((System.Windows.Forms.Label)sender).BackColor = Color.FromArgb(250, 250, 250);
            ((System.Windows.Forms.Label)sender).ForeColor = Color.FromArgb(0, 0, 0);
        }
    }
}
