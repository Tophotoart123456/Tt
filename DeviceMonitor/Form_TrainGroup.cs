using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeviceMonitor
{
    public partial class Form_TrainGroup : Form
    {
        //用委托实现训练计划分组按钮显示和隐藏
        public delegate void ShowTraniLabel(bool show);
        public event ShowTraniLabel STL;

        //
        public Form_TrainGroup()
        {
            InitializeComponent();
            SetDoubleBuffer();
            GetGroupInfo();
        }
        //设置双缓冲
        public void SetDoubleBuffer()
        {
            this.DoubleBuffered = true;//设置本窗体
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true); // 禁止擦除背景.
            SetStyle(ControlStyles.DoubleBuffer, true); // 双缓冲
        }
        //获取机场和训练计划
        private void GetGroupInfo()
        {
            ThreadBase tb = new ThreadBase();
            tb.GIS += Tb_GIS;
            tb.ReadAirportAndTrainInfo();
        }
        private void Tb_GIS()
        {
            Test2();
        }

        //隐藏当前窗口
        private void panel_Titel_Click(object sender, EventArgs e)
        {
            STL.Invoke(true);
            this.Hide();
        }
        //设置窗口大小
        public void ResetFormSize(Size sz)
        {
            this.Size = sz;
        }
        private void Test2()
        {
            for (int i = 1; i <=3; i++)
            {
                AddGroup("Group" + i.ToString(),i);
            }
        }
        object obj = new object();
        public void AddGroup(string groupname,int numb)
        {
            lock (obj)
            {
                var v = IsIncludeGroup(groupname);
                if (null == v)
                {
                    Group group = new Group();
                    group.McGroup += Group_McGroup;
                    group.SetGroupName(groupname);
                    group.GroupName = groupname;
                    group.GroupNumb = numb;
                    flowLayoutPanel1.Controls.Add(group);
                }
            }
        }
        public void RemoveGroup(string groupname)
        {
            foreach (var v in flowLayoutPanel1.Controls)
            {
                if (((Group)v).GroupName.Equals(groupname))
                {
                    flowLayoutPanel1.Controls.Remove((Group)v);
                    break;
                }
            }
        }
        private void Group_McGroup(string name, Control cr)
        {
            ///throw new NotImplementedException();
        }
        public Group IsIncludeGroup(string groupname)
        {
            Group gp = null;
            foreach(var v in flowLayoutPanel1.Controls)
            {
                if (((Group)v).GroupName.Equals(groupname))
                {
                    gp = (Group)v;
                    break;
                }
            }
            return gp;
        }
        public int GetGroupCount()
        {
            return flowLayoutPanel1.Controls.Count;
        }


    }
}
