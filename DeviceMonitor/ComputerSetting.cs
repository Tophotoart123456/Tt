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
    public partial class ComputerSetting : UserControl
    {
        //定义一个委托 返回上一层
        public delegate void ReturnBeforeStep();
        public event ReturnBeforeStep RBS;
        private List<string> roomList;
        private string IP;
        private string MAC;
        public delegate void RoomChange(string toroom, string fromroom);
        public event RoomChange OnRoomChanged;
        private string roomName;
        //
        //电脑开关机对象
        ComputerControl cc = null;
        //
        public ComputerSetting()
        {
            InitializeComponent();
            InitObj();
        }
        public void SetIp(string ip)
        {
            maskedTextBox2.Text = ip;
            this.IP = ip;
        }

        public string RoomName
        {

            set
            {
                roomName = value;
                comboBox3.SelectedIndex = (int)roomList?.IndexOf(roomName);
            }
            get
            {
                return roomName;
            }
        }

        public List<string> RoomList
        {
            get
            {
                return roomList;
            }
            set
            {
                roomList = value;
                comboBox3.DataSource = roomList;
            }
        }

        public void SetMac(string mac)
        {
            lbl_Mac.Text = mac;
            this.MAC = mac;
        }

        private void InitObj()
        {
            cc = new ComputerControl();
        }

        private void label_Return_Click(object sender, EventArgs e)
        {
            RBS.Invoke();
        }
        //开关机点击事件
        private void ButtonClick(object sender,EventArgs e)
        {
            Button btn = sender as Button;
            if(btn!=null)
            {
                int tag = Convert.ToInt32(btn.Tag);
                switch (tag)
                {
                    case 1://开机或关机
                        if (button_StartComput.Text.Equals("开机"))
                        {
                            button_StartComput.Text = "关机";
                            button_StartComput.BackColor = Color.Red;
                            cc.WakeUp("48-4D-7E-BA-A6-D1"); //("00-30-18-03-B6-87");//;("48-4D-7E-BA-A6-D1")
                        }
                        else
                        {
                            button_StartComput.Text = "开机";
                            button_StartComput.BackColor = Color.FromArgb(90, 90, 90);
                            SendPackToSubService(textBox1.Text, LANAllComputerIp.ComputerStatus.BREAK_LIEN);
                        }
                        break;
                    case 2://重启
                        {
                            SendPackToSubService(textBox1.Text, LANAllComputerIp.ComputerStatus.RESTART);
                        }
                        break;
                    default:break;
                }
            }
        }
        
        //组包发给子服务
        public static void SendPackToSubService(string ip, LANAllComputerIp.ComputerStatus cs)
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
            Form_Main.sc.SendInfo(ip, data);
        }

        private void comboBox3_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string room = comboBox3.SelectedValue.ToString();
            //roomName = room;
            OnRoomChanged?.Invoke(room, roomName);
        }
    }
}
