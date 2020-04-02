using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace DeviceMonitor
{
    class FollowPanelBase:FlowLayoutPanel
    {
        public FollowPanelBase()
        {
            //this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
            //this.UpdateStyles();
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                //cp.ExStyle |= 0x02000000;
                return cp;
            }
        }
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            // 重载基类的背景擦除函数，
            // 解决窗口刷新，放大，图像闪烁
            return;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            // 使用双缓冲
            this.DoubleBuffered = true;
            // 背景重绘移动到此
            if (this.BackgroundImage != null)
            {
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                e.Graphics.DrawImage(
                    this.BackgroundImage,
                    new System.Drawing.Rectangle(0, 0, this.Width, this.Height),
                    0,
                    0, this.BackgroundImage.Width, this.BackgroundImage.Height, System.Drawing.GraphicsUnit.Pixel);
            }
            base.OnPaint(e);
        }


    }
}
