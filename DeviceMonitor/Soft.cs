using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeviceMonitor
{
    public partial class Soft : UserControl
    {
        //拖动控件完成时
        //type =0 拖动完成 type =1 点击显示配置界面
        public delegate void SoftInfo(Soft cr,int type=0);
        public event SoftInfo Kii;
        public string Devicename { get; set; }
        public string SoftName { get; set; }
        public Image PictureImg { get; set; }
        public int GroupNumb { get; set; }
        //鼠标进入显示区域时 在分组里显示对应提示信息
        public delegate void ShowInfo(Soft st);
        public event ShowInfo Hint;
        //

        const int ERROR = 1;
        Point beforePt;
        public Soft()
        {
            InitializeComponent();
        }
        public void SetSoftName(string name)
        {
            label1.Text = name;
            SoftName = name;
        }
        public void SetSoftImage(Image img)
        {
            pictureBox1.Image = img;
            PictureImg = img;
        }
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            beforePt = e.Location;
            //通知上层控件显示对应设置界面
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button.Equals(MouseButtons.Left)&& IsMoveControl(e.Location))
            {
                //panel1.DoDragDrop(panel1, DragDropEffects.All);
                //Kii.Invoke(this);
                ShowForm(this, 0);
                //DrawGroupFlag();
            }
            else
            {
                ShowForm(this, 1);
                //Kii.Invoke(this,1);
                Device.move_contrl = null;
            }
        }
        private bool IsMoveControl(Point current)
        {
            return ( Math.Abs(current.X-beforePt.X)>ERROR ||Math.Abs(current.Y-beforePt.Y)>ERROR );
        }
        
        private void DrawGroupFlag()
        {
            Graphics g = pictureBox1.CreateGraphics();
            SolidBrush redbrush = new SolidBrush(Color.Red);
            SolidBrush whitebrush = new SolidBrush(Color.White);
            Rectangle rc = new Rectangle(pictureBox1.Left, pictureBox1.Top, 20, 20);
            g.FillRectangle(redbrush,rc );
            g.DrawString("1",new Font( "Arial",10), whitebrush, new Point(rc.Left, rc.Top));
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            //给组成员显示提示
            if(null != Hint)
            Hint.Invoke(this);
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            //停止组成员显示提示
            if(null != Hint)
            Hint.Invoke(null);
        }

        //设置组名
        public void SetGroupTagName(string gn)
        {
            label_Tag.Text = gn;
        }
        //设置颜色
        public void SetGroupTagColor(Color cr)
        {
            label_Tag.BackColor = cr;
        }
        //显示隐藏
        public void ShowGroupTag(bool b)
        {
            label_Tag.Visible = b;
        }
        //显示配置属性
        public void ShowForm(Soft st,int type)
        {
            Kii.Invoke(st, type);
        }
    }
}
