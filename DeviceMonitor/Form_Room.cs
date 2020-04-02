using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace DeviceMonitor
{
    public partial class Form_Room : Form
    {
        //设备缓存
        public List<Form_Show> devices_list = null;
        //设备扫描
        LANAllComputerIp scan = null;

        private List<string> roomList;

        private string roomName;
        private Form_Show changedForm;

        public  delegate void DeviceRoomChanged(string toRoom, Form_Show device);
        public event DeviceRoomChanged OnDeviceRoomChanged;

        public Form_Room()
        {
            InitializeComponent();
            InitUI();
            InitObj();
        }
        private void InitUI()
        {
            //SetDouble(flowLayoutPanel1);
        }
        private void InitObj()
        {
            scan = new LANAllComputerIp();
            scan.Kii += Scan_Kii;
            devices_list = new List<Form_Show>();
        }

        public List<string> RoomList
        {
            set
            {
                roomList = value;
                foreach (Form_Show frmshow in devices_list)
                {
                    frmshow.RoomList = roomList;
                }
            }
            get
            {
                return roomList;
            }
        }

        public string RoomName
        {
            set
            {
                roomName = value;
                foreach (Form_Show frmshow in devices_list)
                {
                    frmshow.RoomName = roomName;
                }
            }
            get
            {
                return roomName;
            }
        }


        private void Scan_Kii(LANAllComputerIp.ComputerIpInfo cr)
        {
            if(this!=null)
            {
                this.Invoke(new MethodInvoker(delegate
                {
                    if (cr != null)
                    {
                        var v = IsIncludeFormShow(cr.ip);
                        if (v == null)
                            AddFormShow(cr);
                        else
                            v.SetDeviceTitelBkColor(cr.status);
                    }
                }));
            }
        }
        public void StartScan()
        {
            ThreadPool.QueueUserWorkItem(oct =>
            {
                scan.EnumComputers();
            });
        }
        public void SetDouble(Control cc)
        {
            cc.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance |
                         System.Reflection.BindingFlags.NonPublic).SetValue(cc, true, null);
        }
        public void AddFormShow(LANAllComputerIp.ComputerIpInfo cr)
        {
            Form_Show fm = new Form_Show();
            fm.FormName = cr.ip;
            fm.TopLevel = false;
            fm.Parent = flowLayoutPanel1;
            fm.AddDevice(cr.ip, cr.mac);
            fm.RoomList = roomList;
            fm.RoomName = roomName;
            fm.OnRoomChanged += Fm_OnRoomChanged;
            flowLayoutPanel1.Controls.Add(fm);
            devices_list.Add(fm);
            fm.Show();
        }

        private void Fm_OnRoomChanged(string room, string formName)
        {
            Form_Show fm = null;
            
            foreach (Form_Show device in devices_list)
            {
                if (device.FormName == formName)
                {
                    flowLayoutPanel1.Controls.Remove(device);
                    fm = device;
                    changedForm = device;
                    break;
                }
            }
            fm.RoomName = room;
            fm.OnRoomChanged -= Fm_OnRoomChanged;
            devices_list.Remove(fm);
            this.OnDeviceRoomChanged?.Invoke(room, fm);
        }

        public void AddFormShow(string ip, string mac)
        {
            Form_Show fm = new Form_Show();
            fm.FormName = ip;
            fm.TopLevel = false;
            fm.Parent = flowLayoutPanel1;
            fm.AddDevice(ip, mac);
            fm.RoomList = roomList;
            fm.RoomName = roomName;
            flowLayoutPanel1.Controls.Add(fm);
            devices_list.Add(fm);
            fm.Computer_RBS();
            fm.Show();
        }

        public void AddFormShow(Form_Show fm)
        {
            flowLayoutPanel1.Controls.Add(fm);
            devices_list.Add(fm);
            fm.Computer_RBS();
            fm.OnRoomChanged += Fm_OnRoomChanged;
            fm.Show();
        }

        public Form_Show IsIncludeFormShow(string name)
        {
            return devices_list.Find(oct => oct.FormName.Equals(name));
        }
        public void Test()
        {
            for (int i = 0; i < 10; i++)
            {
                Form_Show fm = new Form_Show();
                fm.FormName = "计算机" + i.ToString();
                fm.TopLevel = false;
                fm.Parent = flowLayoutPanel1;
                fm.AddDevice("计算机" + i.ToString(),"0");
                fm.Show();
                flowLayoutPanel1.Controls.Add(fm);
            }
        }
    }
}
