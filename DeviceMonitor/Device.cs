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
    public partial class Device : UserControl
    {
        public string DeviceName { get; set; }
        public string DeviceMac { get; set; }
        //type 0主机设置 1权限 2语音频道
        public delegate void MoveContorl(string name,int type, Soft cr,int isclick);
        public event MoveContorl Mc;

        //提供一个公共控件 给目标窗口用
        public static Soft move_contrl = null;
        //
        public Device()
        {
            InitializeComponent();
        }
        public void SetDeviceName(string name)
        {
            label_DeviceName.Text = name;
        }
        public void AddSoft(string name,Image img)
        {
            Soft st = new Soft();
            st.Kii += St_Kii;
            st.Devicename = label_DeviceName.Text;
            st.SetSoftName(name);
            st.SetSoftImage(img);
            flowLayoutPanel1.Controls.Add(st);
        }
        public void AddSoft(Soft cl)
        {
            flowLayoutPanel1.Controls.Add(cl);
        }
        public Soft IsIncludeSoft(string devicename,string softname)
        {
            Soft st = null;
            foreach(var v in flowLayoutPanel1.Controls)
            {
                Soft temp = (Soft)v;
                if (temp.Devicename == devicename && temp.SoftName == softname)
                {
                    st = temp;
                    break;
                }
            }
            return st;
        }
        public void SetSoftImage(string name,Image img)
        {
            foreach(var v in flowLayoutPanel1.Controls)
            {
                Soft t = (Soft)v;
                if (t.SoftName.Equals(name))
                    t.SetSoftImage(img);
            }
        }
        public void SetDeviceColor(Color cr)
        {
            CloseComputerLabel.BackColor = cr;
            panel2.BackColor = cr;
        }
        private void St_Kii(Soft cr,int type)
        {
            if (1 == type)//显示配置属性
            {
                if (cr.SoftName.Equals("Pilot"))
                    Mc.Invoke(DeviceName, 1, cr, type);
                else if (cr.SoftName.Equals("Radar"))
                    Mc.Invoke(DeviceName, 2, cr, type);
            }
            else
            {
                if (cr.SoftName == "Coach")
                    move_contrl = cr;
                else if (null == Group.global_soft.Find(op => op.Devicename.Equals(cr.Devicename) && op.SoftName.Equals(cr.SoftName)))
                    move_contrl = cr;

            }
        }
        private void TitleButtonClick(object sender,EventArgs e)
        {
            if(CloseComputerLabel.Equals(sender))//主机设置
            {
                Mc.Invoke(DeviceName,0, null,0);
            }
            else//开机
            {

            }
        }
        protected override CreateParams CreateParams
        {
            get
            {
                var parms = base.CreateParams;
                /*parms.Style &= ~0x02000000;*/ // Turn off WS_CLIPCHILDREN 
                parms.Style |= 0x02000000;
                return parms;
            }
        }
  
    }
}
