using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace DeviceMonitor
{
    public class Class_Base
    {
        public Class_Base()
        {
        }
        //自定义移动窗口
        #region
        //放大窗口
        public void maxWindow(Form fm)
        {
            //fm.MaximizedBounds = Screen.PrimaryScreen.WorkingArea;
            fm.WindowState = FormWindowState.Maximized;
        }
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);
        public const int WM_SYSCOMMAND = 0x0112;
        public const int SC_MOVE = 0xF010;
        public const int HTCAPTION = 0x0002;

        public void HeaderPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Clicks == 1)
            {
                
                ReleaseCapture();
                SendMessage(((Form)sender).Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);
            }
            else
            {
                maxWindow(((Form)sender));
            }
        }
        public void DrapPanel_MouseDown(object sender, MouseEventArgs e)
        {
            Cursor.Current = Cursors.SizeWE;
            //Cursor.Current = Cursors.Default;
            ReleaseCapture();
            SendMessage(((Form)sender).Handle, /*WM_SYSCOMMAND */274,/*移动信息SC_Size=*/61440 +/*WMSZ_LEFT=1 <0x1> 这里可以换成其它参数下面给出*/2/*8*/, 0);
        }
        public void DrapPanel_MouseMove(object sender, MouseEventArgs e)
        {
            //Cursor.Current = Cursors.SizeNWSE;
            Cursor.Current = Cursors.Default;
        }
        #endregion

    }
}
