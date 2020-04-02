using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.ServiceModel;
using System.Collections;
using System.IO;
using DeviceMonitor.ServiceReference1;
using DeviceMonitor.Model;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using DeviceMonitor.ViewModel;

namespace DeviceMonitor
{
    public partial class Form_Main : Form
    {
        //训练计划分组界面
       public Form_TrainGroup fm_Traingroup = null;
        //房间缓存与记号对应关系
        Dictionary<string,Form_Room> roomDic = new Dictionary<string, Form_Room>();
        //房间号缓存
        List<ButtonExt> roomNoList = new List<ButtonExt>();
        //训练计划分组设置
        GroupSeting fm_GroupSeting = null;
        //服务引用
        public static ServiceReference1.IService1 service = null;
        public static ServiceReference1.Service1Client service1Client = null;
        public static Dictionary<string, AuthorityGroup> allAuthorityData = new Dictionary<string, AuthorityGroup>();
        public static Dictionary<string, AuthorityGroup> CurrentAuthorityData = new Dictionary<string, AuthorityGroup>();
        //
        //线程服务
        ThreadBase threadBase = null;
        //
        //当前窗口
        public static Form_Main f_main = null;
        //分组数量
        int beforegroupnumber = -1;
        //

        private DeviceDetailList detailForm;
        DeviceDetailVM deviceVM = new DeviceDetailVM();
        ObservableCollection<DeviceDetailModel> deviceDetails;
        public Form_Main()
        {
            InitializeComponent();
            // this.IsMdiContainer = true;
            detailForm = new DeviceDetailList();
            CenterToScreen();
            CheckForIllegalCrossThreadCalls = false;
            ButtonExt btn = new ButtonExt();
            btn.BtnContent = "设置组";
            btn.IsSelect = true;
            btn.Index = 1;
            btn.OnButtonClick += Btn_OnButtonClick;
            flowLayoutPanel_Tab.Controls.Add(btn);
            roomNoList.Add(btn);
            Form_Room room = new Form_Room();
            room.StartScan();
            roomDic.Add("设置组", room);
            room.RoomList = roomDic.Keys.ToList();
            room.OnDeviceRoomChanged += Room_OnDeviceRoomChanged;
            room.RoomName = "设置组";
            LoadRoom("设置组");
             CheckForIllegalCrossThreadCalls = false;
            InitObj();
            //测试
            //allAuthorityData = service1Client.getAllAuthorityData("分组2");
            f_main = this;
            //
            LoadTrainForm();
           // LoadRoom("设置组");
            InitGroupForm();
            
            //for (int i = 0; i < 5; i++)
            //    AddRoom();
            //test
            //TestSockets();
            InitThread();
        }

        private void Room_OnDeviceRoomChanged(string toRoom, Form_Show device)
        {
            Form_Room room = roomDic[toRoom];
            room.AddFormShow(device);
        }

        private void InitObj()
        {
            //InstanceContext instanceContext = new InstanceContext(new Service1Callback());
            service1Client = new ServiceReference1.Service1Client();
            service = service1Client.ChannelFactory.CreateChannel();
        }
        private void InitThread()
        {
            threadBase = new ThreadBase();
            threadBase.SMTMF += ThreadBase_SMTMF;
            threadBase.StartGetClientThread();
        }
        private void ThreadBase_SMTMF(Dictionary<ServiceReference1.TrainPlan, List<ServiceReference1.RoleUserRelation>> ur, Dictionary<string, string[]> online)
        {
            OnLineComputer(online);
            OnLineGroup(ur,online);
        }
        //在线电脑
        private void OnLineComputer(Dictionary<string, string[]> online)
        {
            if (null != online && online.Count > 0)//在线电脑
            {
                foreach (var v in online)
                {
                    foreach (var c in Mainpanel.Controls)
                    {
                        var control = ((Form_Room)c).IsIncludeFormShow(v.Key);
                        if (null == control)
                        {
                            ((Form_Room)c).Invoke((MethodInvoker)delegate
                            {
                                ((Form_Room)c).AddFormShow(v.Key, "XX-XX-XX-XX-XX-XX");
                                
                            });
                            ((Form_Room)c).devices_list[((Form_Room)c).devices_list.Count-1].SetDeviceTitelBkColor(LANAllComputerIp.ComputerStatus.ON_LINE);
                            break;
                        }
                        else
                        {
                            OnLineClient(control.GetDevice(), v.Value);//在线软件
                            control.SetDeviceTitelBkColor(LANAllComputerIp.ComputerStatus.ON_LINE);
                        }
                    }
                }
            }
        }
        //在线软件
        private void OnLineClient(Device device,string[] param)
        {
            string path = Directory.GetCurrentDirectory();
            for (int j = 0; j < 4; j++)
            {
                Image image = null;
                string softname =null;
                if (j == 0 && 0 < param.Where(o => o.Equals("Coach")).Count())
                {
                    softname = "Coach";
                    image = Image.FromFile(String.Format(path + "\\resource\\客户端掉线在线图标\\{0}-{1}.png", (j + 1).ToString(), (j + 1).ToString()));
                }
                else if (j == 1 && 0 < param.Where(o => o.Equals("Pilot")).Count())
                {
                    softname = "Pilot";
                    image = Image.FromFile(String.Format(path + "\\resource\\客户端掉线在线图标\\{0}-{1}.png", (j + 1).ToString(), (j + 1).ToString()));
                }
                else if (j == 2 && 0 < param.Where(o => o.Equals("Radar")).Count())
                {
                    softname = "Radar";
                    image = Image.FromFile(String.Format(path + "\\resource\\客户端掉线在线图标\\{0}-{1}.png", (j + 1).ToString(), (j + 1).ToString()));
                }
                else if (j == 3 && 0 < param.Where(o => o.Equals("Visserver")).Count())
                {
                    softname = "Visserver";
                    image = Image.FromFile(String.Format(path + "\\resource\\客户端掉线在线图标\\{0}-{1}.png", (j + 1).ToString(), (j + 1).ToString()));
                }
                else
                    image = Image.FromFile(String.Format(path + "\\resource\\客户端掉线在线图标\\{0}.png", (j + 1).ToString(), (j + 1).ToString()));
                device.SetSoftImage(softname, image);
            }
        }

        //在线分组
        private void OnLineGroup(Dictionary<ServiceReference1.TrainPlan, List<ServiceReference1.RoleUserRelation>> ur, Dictionary<string, string[]> online)
        {
            string path = Directory.GetCurrentDirectory();
            if (null != ur && 0 < ur.Count)
            {
                foreach(var v in ur)
                {
                    var gg = fm_Traingroup.IsIncludeGroup(v.Key.trainPlanGroupID); 
                    if (null == gg)//添加组
                    {
                        int index = v.Key.trainPlanGroupID.IndexOf("Group");
                        if(index==-1)
                            index= v.Key.trainPlanGroupID.IndexOf("p");
                        string numb = v.Key.trainPlanGroupID.Substring(index+1, v.Key.trainPlanGroupID.Length - index-1);
                        int k = 0;
                        if (numb.Length > 0)
                            k = Convert.ToInt32(numb);
                        fm_Traingroup.AddGroup("Group" + k.ToString(), k);
                        gg= fm_Traingroup.IsIncludeGroup(v.Key.trainPlanGroupID);
                    }
                    for(int j=0;j< v.Value.Count;j++)//添加软件图标
                    {
                        //var on=online.Values.Where(o)
                        Soft st = new Soft();
                        st.Devicename = v.Value[j].user;
                        var image = Image.FromFile(String.Format(path + "\\resource\\客户端掉线在线图标\\{0}-{1}.png", (j + 1).ToString(), (j + 1).ToString()));
                        gg.AddSoft(v.Value[j].role,image, st);
                    }
                    //设置按钮状态
                    gg.DataSync(v.Key);
                }
            }
            //分组数量
            if ( ur.Count != beforegroupnumber)
            {
                fm_GroupSeting.SetGroupNum(ur.Count);
            }
            beforegroupnumber = ur.Count;
        }

        private void LoadTrainForm()
        {
            fm_Traingroup = new Form_TrainGroup();
            fm_Traingroup.STL += Fm_Traingroup_STL;

            Size sz = panel4.Size;
            sz.Width = fm_Traingroup.Width;
            fm_Traingroup.TopLevel = false;
            fm_Traingroup.Parent = panel4;
            fm_Traingroup.Dock = DockStyle.Right;
            fm_Traingroup.ResetFormSize(sz);
        }
        private void InitGroupForm()
        {
            fm_GroupSeting = new GroupSeting();
        }
        private void Fm_Traingroup_STL(bool show)
        {
            label_trainGroup.Visible = show;
        }
        private void InitUi()
        {
           
            panel2.GetType().GetProperty
             ("DoubleBuffered", System.Reflection.BindingFlags.Instance
              | System.Reflection.BindingFlags.NonPublic)
             .SetValue(panel2, true, null);
            panel3.GetType().GetProperty
             ("DoubleBuffered", System.Reflection.BindingFlags.Instance
              | System.Reflection.BindingFlags.NonPublic)
             .SetValue(panel3, true, null);
        }
        //protected override CreateParams CreateParams
        //{
        //    get
        //    {
        //        CreateParams cp = base.CreateParams;
        //        cp.ExStyle |= 0x02000000;
        //        return cp;
        //    }
        //}
     
        private void TitleLabelClick(object sender,EventArgs e)
        {
           if(CloseLabel.Equals(sender))
            {
                Close();
                //SendDataTest(LANAllComputerIp.ComputerStatus.BREAK_LIEN);
            }
           else
            {
                if (MaxOrMinLabel.Equals(sender))
                {
                    if (WindowState.Equals(FormWindowState.Normal))
                        WindowState = FormWindowState.Maximized;
                    else if (WindowState.Equals(FormWindowState.Maximized))
                        WindowState = FormWindowState.Normal;
                }
                else
                {
                    WindowState = FormWindowState.Minimized;
                }
            }
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            Class_Base ba = new Class_Base();
            ba.HeaderPanel_MouseDown(this, e);
        }

        private void menuLabel_MouseMove(object sender, MouseEventArgs e)
        {
            if (!contextMenuStrip1.Visible)
            {
                Point pt = new Point(menuLabel.Location.X, menuLabel.Location.Y + menuLabel.Height);
                contextMenuStrip1.Show(menuLabel, pt);
            }
        }
        private void contextMenuStrip1_MouseLeave(object sender, EventArgs e)
        {
            contextMenuStrip1.Hide();
        }
        //训练计划分组界面
        private void label_trainGroup_Click(object sender, EventArgs e)
        {
            if (fm_Traingroup == null)
            {
                LoadTrainForm();
            }
            fm_Traingroup.Invalidate();
            fm_Traingroup.Show();
            label_trainGroup.Visible = false;
        }
        //房间加载
        private void LoadRoom(string roomName)
        {
            foreach (string name in roomDic.Keys)
            {
                Form_Room room = roomDic[name];
                if (roomName == name)
                {
                    room.TopLevel = false;
                    room.Parent = Mainpanel;
                    room.Dock = DockStyle.Fill;
                    room.Show();
                }
                else
                {
                    room.Hide();
                }

            }
        }
        //添加房间
        //int roomCount = 1;
        //private void AddRoom()
        //{
        //    Label l = new Label();
        //    l.Size = new Size(76, 27);
        //    l.TextAlign = ContentAlignment.MiddleCenter;
        //    l.Text = "房间" + roomCount.ToString();
        //    l.Click += FL_Label_Click;
        //    l.Margin = new Padding(1, 0, 1, 0);
        //    l.BackColor = Color.FromArgb(104, 104, 104);
        //    l.Cursor = Cursors.Hand;
        //    flowLayoutPanel_Tab.Controls.Add(l);
        //    if (1 == roomCount)
        //        FL_Label_Click(l, new EventArgs());
        //    roomCount++;
        //    Form_Room room = new Form_Room();
        //    room.TopLevel = false;
        //    room.Parent = Mainpanel;
        //    room.Dock = DockStyle.Fill;
        //    room.Text = "房间" + roomCount.ToString();
        //    room.Show();
        //}
        private void FL_Label_Click(object sender,EventArgs e)
        {
            foreach (var f in Mainpanel.Controls)
                if (((Form_Room)f).Text.Equals(((Label)sender).Text))
                    ((Form_Room)f).Show();
                else ((Form_Room)f).Hide();

            foreach (var v in flowLayoutPanel_Tab.Controls)
                if (v.Equals(sender))
                {
                    ((Label)sender).BackColor = Color.FromArgb(0, 99, 199);
                }
                else
                {
                    ((Label)v).BackColor = Color.FromArgb(104, 104, 104);
                }
        }
        //测试sockets
        public static SocketCom sc = new SocketCom();
        private void TestSockets()
        {
            sc.RD += Sc_RD;
            LANAllComputerIp lan = new LANAllComputerIp();
            lan.GetLocalMachineIp();
            sc.Start(lan.localMachine.ip);
        }
        private void SendDataTest(LANAllComputerIp.ComputerStatus cs)
        {
            PacketInfo pinfo = new PacketInfo();
            LANAllComputerIp lan = new LANAllComputerIp();
            lan.GetLocalMachineIp();
            lan.localMachine.status = cs;
            pinfo.ip.Add(lan.localMachine);
            SoftInfo sinfo = new SoftInfo();
            sinfo.SoftName = "coach.exe";
            sinfo.status = SoftStatus.Init;
            pinfo.soft.Add(sinfo);
            Packet pt = new Packet();
            var data = pt.Package(pinfo);

            sc.SendInfo(/*lan.localMachine.ip*/"172.16.0.125", data);//206
        }
        private void Sc_RD(string data)
        {
            Packet pt = new Packet();
            var v= pt.Unpack(data);
            
        }
        //训练组设置
        private void ToolStripMenuItem_TraniSet_Click(object sender, EventArgs e)
        {
            fm_GroupSeting.InitUi();
            if (fm_GroupSeting.ShowDialog().Equals(DialogResult.OK))
            {
                int groupCount = fm_Traingroup.GetGroupCount();
                 if (GroupSeting.numb_global> groupCount)
                {
                    for (int i = 4; i <= GroupSeting.numb_global; i++)
                        fm_Traingroup.AddGroup("Group" + i.ToString(), i);
                }
                 else
                {
                    for (int i = GroupSeting.numb_global + 1; i <= groupCount; i++)
                        fm_Traingroup.RemoveGroup("Group" + i.ToString());
                }
            }
        }


        private void 设备状态列表ToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            if (detailForm == null || detailForm.IsDisposed)
            {
                detailForm = new DeviceDetailList();
            }
            detailForm.Location = new Point(this.Location.X, this.ClientSize.Height - 30 - detailForm.Height);
            detailForm.TopMost = true;
            if ((this.ClientSize.Height - 30) > detailForm.Height)
            {
                if (deviceVM.DeviceList.Count == 0)
                {
                    deviceVM.InitData();
                }
                detailForm.Show();
                detailForm.SetBinding(deviceVM);
            }
        }

        private void 设备分组设置ToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            DeviceGroupingSetting frm_GrpSetting = new DeviceGroupingSetting(roomNoList);
            frm_GrpSetting.OnGroupingRoomChanged += Frm_GrpSetting_OnGroupingRoomChanged;
            frm_GrpSetting.ShowDialog();
        }

        private void Frm_GrpSetting_OnGroupingRoomChanged(string room_no, bool isAdd)
        {
            if (isAdd)
            {
                ButtonExt btn = new ButtonExt();
                btn.BtnContent = room_no;
                btn.Index = roomNoList.Count + 1;
                btn.OnButtonClick += Btn_OnButtonClick;
                flowLayoutPanel_Tab.Controls.Add(btn);
                roomNoList.Add(btn);
                Form_Room room_new = new Form_Room();
                room_new.RoomName = room_no;
                room_new.OnDeviceRoomChanged += Room_OnDeviceRoomChanged;
                roomDic.Add(room_no, room_new);
                foreach (Form_Room frmroom in roomDic.Values)
                {
                    frmroom.RoomList = roomDic.Keys.ToList();
                }
            }
            else
            {
                foreach (ButtonExt btn in roomNoList)
                {
                    if (btn.BtnContent == room_no)
                    {
                        roomNoList.Remove(btn);
                        flowLayoutPanel_Tab.Controls.Remove(btn);
                        Form_Room room = roomDic[room_no];
                        roomDic.Remove(room_no);
                        foreach (Form_Room frmroom in roomDic.Values)
                        {
                            frmroom.RoomList = roomDic.Keys.ToList();
                            frmroom.RoomName = room_no;
                            if (frmroom.RoomName == room_no)
                            {
                                foreach (Form_Show frm in room.devices_list)
                                {
                                    frmroom.AddFormShow(frm);
                                }
                            }
                        }
                        foreach (ButtonExt btne in roomNoList)
                        {
                            if (btne.BtnContent == "设置组")
                            {
                                btne.ExecuteButtonClick();
                            }
                        }
                    break;
                    }
                }
            }
        }

        private void Btn_OnButtonClick(object obj)
        {
            ButtonExt btn_ext = (ButtonExt)obj;
            foreach (ButtonExt btn in roomNoList)
            {
                if (btn.BtnContent == btn_ext?.BtnContent)
                {
                    btn.IsSelect = true;
                    Form_Room room = roomDic[btn_ext?.BtnContent];
                    LoadRoom(btn_ext?.BtnContent);
                }
                else
                {
                    btn.IsSelect = false;
                }
            }
        }

        private void Form_Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            threadBase.StopClientThread();
        }

        private void Form_Main_Resize(object sender, EventArgs e)
        {
            if ((this.ClientSize.Height - 30) <= detailForm?.Height)
            {
                detailForm?.Close();
                detailForm = null;
            }
            else
            {
                if (detailForm != null)
                {
                    detailForm.Location = new Point(this.Location.X, this.ClientSize.Height - 30 - detailForm.Height);
                }
            }
        }

        private void 全部开机ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 全部关机ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
