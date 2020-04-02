using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeviceMonitor
{
    public partial class Form_Show : Form
    {
        //窗口名称
        public string FormName { get; set; }
        //设备窗口对象
        Device device = null;
        //电脑设置窗口对象
        ComputerSetting computer = null;
        //通讯设置窗口对象
        CommunicationSetting communication = null;
        //机长设置窗口
        CaptainSftSetting captain = null;

        public delegate void RoomChange(string room, string formName);
        public event RoomChange OnRoomChanged;

        private string roomName;

        List<string> roomList;
        //权限窗口对象
        AuthoritySetting authoritySetting = null;
        //软件名称
        List<string> softName = null;
        public Form_Show()
        {
            InitializeComponent();
            InitObj();
            InitSoftName();
        }
        private void InitObj()
        {
            device = new Device();
            computer = new ComputerSetting();
            communication = new CommunicationSetting();
            captain = new CaptainSftSetting();
            authoritySetting = new AuthoritySetting();
            softName = new List<string>();
        }

        public List<string> RoomList
        {
            set
            {
                roomList = value;
                computer.RoomList = roomList;
            }
            get
            {
                return roomList;
            }
         
        }
        private void InitSoftName()
        {
            softName.Add("Coach");
            softName.Add("Pilot");
            softName.Add("Radar");
            softName.Add("Visserver");
            softName.Add("Surveillance");
            softName.Add("Assist");
        }

        public string RoomName
        {
            set
            {
                roomName = value;
                computer.RoomName = roomName;
            }
            get
            {
                return roomName;
            }
        }

        public void AddDevice(string name, string mac)
        {
            if (!panel1.Controls.Contains(device))
            {
                string path = Directory.GetCurrentDirectory();
                device.Mc += Device_Mc;
                device.SetDeviceName(name);
                device.DeviceName = name;
                device.DeviceMac = mac;
                device.Dock = DockStyle.Fill;
                for (int j = 0; j < 4; j++)
                {   //F:\\设备管理\\DeviceMonitor\\DeviceMonitor\\
                    Image image = Image.FromFile(String.Format(path + "\\resource\\客户端掉线在线图标\\{0}.png", (j + 1).ToString(),(j+1).ToString()));
                    device.AddSoft(softName[j], image);
                }
                panel1.Controls.Add(device);

            }
            else
                device.Show();
        }
        public void SetDeviceTitelBkColor(LANAllComputerIp.ComputerStatus st)
        {
            if (st == LANAllComputerIp.ComputerStatus.ON_LINE)
                device.SetDeviceColor(Color.FromArgb(24,121,231));
            else
                device.SetDeviceColor(Color.FromArgb(214, 214, 214));
        }
        private void Device_Mc(string name, int type, Soft cr,int isclick)
        {
            switch (type)
            {
                case 0://主机设置
                    HideDevicePanel();
                    AddComputerSetting();
                    break;
                case 1://权限设置
                    if(1 == isclick)
                    {
                        HideDevicePanel();
                        AddAuthoritySetting(cr);
                    }
                    break;
                case 2://语音设置
                    if (1 == isclick)//点击而不是拖动
                    {
                        HideDevicePanel();
                        AddCommunicationSetting();
                    }
                    break;
                default: break;
            }
        }
        public void AddComputerSetting()
        {
            if (!panel1.Controls.Contains(computer))
            {
                computer.RBS += Computer_RBS;
                computer.SetIp(device.DeviceName);
                computer.OnRoomChanged += Computer_OnRoomChanged;
                if (!string.IsNullOrEmpty(device.DeviceMac))
                {
                    computer.SetMac(device.DeviceMac);
                }
                computer.Dock = DockStyle.Fill;
                panel1.Controls.Add(computer);
                //updtate on 20200402
                computer.Show();
            }
            else
                computer.Show();
        }

        private void Computer_OnRoomChanged(string room, string fromroom)
        {
            this.OnRoomChanged?.Invoke(room, this.FormName);
        }

        public void Computer_RBS()
        {
            computer.Hide();
            device.Show();
        }
        public void AddAuthoritySetting(Soft st)
        {
            if (!panel1.Controls.Contains(authoritySetting))
            {
                authoritySetting.NTPF += AuthoritySetting_NTPF;
                authoritySetting.Dock = DockStyle.Fill;
                authoritySetting.InitUi();
                authoritySetting.SetGroupSelectIndex(st.GroupNumb - 1);
                authoritySetting.SetSoft(st);
                authoritySetting.ReadAuthority("Group"+st.GroupNumb.ToString());
                panel1.Controls.Add(authoritySetting);
            }
            else
            {
                authoritySetting.InitUi();
                authoritySetting.SetGroupSelectIndex(st.GroupNumb - 1);
                authoritySetting.SetSoft(st);
                authoritySetting.ReadAuthority("Group"+st.GroupNumb.ToString());
                authoritySetting.Show();
                
            }
        }

        private void AuthoritySetting_NTPF()
        {
            //throw new NotImplementedException();
            authoritySetting.Hide();
            device.Show();
        }

        public void AddCommunicationSetting()
        {
            if (!panel1.Controls.Contains(communication))
            {
                communication.EN += Communication_EN;
                communication.Dock = DockStyle.Fill;
                panel1.Controls.Add(communication);
            }
            else
                communication.Show();
            //if (!panel1.Controls.Contains(captain))
            //{
            //    captain.OnGoBack += Communication_EN;
            //    captain.Dock = DockStyle.Fill;
            //    panel1.Controls.Add(captain);
            //}
            //else
            //    captain.Show();
        }
        private void Communication_EN()
        {
            communication.Hide();
            device.Show();
        }
        public void HideDevicePanel()
        {
            device.Hide();
        }
        public Device GetDevice()
        {
            return device;
        }
    }
}
