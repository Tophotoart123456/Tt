using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OperatorSystem;
namespace DeviceMonitor
{
    public partial class AuthoritySetting : UserControl
    {
        //定义一个委托通知上层窗口执行某个动作
        public delegate void NoticeToParentForm();
        public event NoticeToParentForm NTPF;

        Soft soft = null;

        public AuthoritySetting()
        {
            InitializeComponent();
            InitUi();
            SetGroupSelectIndex(0);
        }
        public void InitUi()
        {
            if(GroupSeting.numb_global>0)
            {
                if (comboBox1.Items.Count > 0)
                    comboBox1.Items.Clear();
                for (int i = 1; i <= GroupSeting.numb_global; i++)
                    comboBox1.Items.Add("Group" + i.ToString());
            }
        }
        public void SetGroupSelectIndex(int index)
        {
            if (comboBox1.Items.Count > 0)
                comboBox1.SelectedIndex = index;
        }
        public void SetSoft(Soft st)
        {
            soft = st;
        }
        public void ChangeGroup()
        {
            if (null != soft)
            {
                soft.ShowForm(soft, 0);
                soft.SetGroupTagName((comboBox1.SelectedIndex + 1).ToString());
            }
        }
        private void LabelClick(object sender,EventArgs e)
        {
            if(sender is Label)
            {
                var lb = sender as Label;
                int tag = Convert.ToInt32(lb.Tag);
                switch (tag)
                {
                    case 1:
                        NTPF.Invoke();
                        break;
                    case 2:
                        if(null == label2.Image.Tag)
                        {
                            label2.Image = DeviceMonitor.Properties.Resources.icon_lock_on_1x;
                            label2.Image.Tag = 1;
                        }
                        else
                        {
                            label2.Image = DeviceMonitor.Properties.Resources.icon_lock_off_1x;
                        }
                        break;
                    default:break;
                }
            }
        }

        private void AuthoritySetting_Load(object sender, EventArgs e)
        {
            //InitFormAuthor();
            //loadAuthority();
        }
        public void loadAuthority()
        {
            try
            {
                flowLayoutPanel1.Controls.Clear();
                foreach (var item in Form_Main.allAuthorityData)
                {
                    authorityControl authorityControl = new authorityControl(Form_Main.f_main);
                    authorityControl.setAuthority(item.Key);
                    flowLayoutPanel1.Controls.Add(authorityControl);
                }
            }
            catch (Exception ex)
            {
                //FlyControl._FlyControl.logger.Error("loadAuthority..." + ex.Message.ToString());
            }
        }
        //更改分组时
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (null != soft)
            {
                RemoveListItem();
                ChangeGroup();
                var v= Form_Main.f_main.fm_Traingroup.IsIncludeGroup(comboBox1.Text);
                if (v != null)
                {
                    if (v.AddGroupItem())
                        RemoveSoft();
                        AddListItem();
                }
            }
        }
        //先移除再添加
        private void RemoveSoft()
        {
            //Group.current_soft.ShowForm(Group.current_soft,0);
            var v = Form_Main.f_main.fm_Traingroup.IsIncludeGroup(beforevalue);
            if (v != null)
                v.RemoveGroupItem(soft);
        }
        //移除公共数组元素
        private void RemoveListItem()
        {
            int index = Group.global_soft.FindIndex(o => o.Devicename == soft.Devicename && o.SoftName == soft.SoftName);
            if (index != -1)
                Group.global_soft.RemoveAt(index);
        }
        //添加公共数组元素
        private void AddListItem()
        {
            Group.global_soft.Add(soft);
        }
        //读取操作权限
        public void ReadAuthority(string groupname)
        {
            Form_Main.allAuthorityData = Form_Main.service1Client.getAllAuthorityData(groupname);
            loadAuthority();
        }
        //为改变内容之前
        string beforevalue = "";
        private void comboBox1_Click(object sender, EventArgs e)
        {
            beforevalue = comboBox1.Text;
        }
    }
}
