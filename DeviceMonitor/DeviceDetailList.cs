using DeviceMonitor.Model;
using DeviceMonitor.ViewModel;
using Helper;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeviceMonitor
{
    public partial class DeviceDetailList : Form
    {
        DeviceDetailGrid deviceInfo;
        DeviceDetailVM deviceVM;
        public DeviceDetailList()
        {
            InitializeComponent();

            deviceInfo = (DeviceDetailGrid)elementHost1.Child;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        public void SetBinding(object obj)
        {
            deviceVM = obj as DeviceDetailVM;
            deviceInfo.SetBinding(obj);
        }

        //public ObservableCollection<DeviceDetailModel> InitData()
        //{
        //    deviceVM.InitData();
        //    return deviceVM.DeviceList;
        //}

        //public void SetDeviceData(ObservableCollection<DeviceDetailModel> detailList)
        //{
        //    deviceVM.DeviceList = detailList;
        //}

        private void btnPowerOn_Click(object sender, EventArgs e)
        {
            foreach (DeviceDetailModel model in deviceVM.DeviceList)
            {
                if (model.IsChecked)
                {
                    string mac = model.DeviceMac;
                    DeviceControl.WakeUp(mac);
                }
            }
        }

        private void btnPowerOn_MouseEnter(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (btn?.Name == "btnPowerOn")
            {
                this.btnPowerOn.BackColor = Color.FromArgb(53, 53, 53);
            }
            else if (btn?.Name == "btnPowerOff")
            {
                this.btnPowerOff.BackColor = Color.FromArgb(53, 53, 53);
            }
            else
            {
                this.btnCancel.BackColor = Color.FromArgb(53, 53, 53);
            }
        }

        private void btnPowerOn_MouseLeave(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (btn?.Name == "btnPowerOn")
            {
                this.btnPowerOn.BackColor = Color.FromArgb(102, 102, 102);
            }
            else if (btn?.Name == "btnPowerOff")
            {
                this.btnPowerOff.BackColor = Color.FromArgb(102, 102, 102);
            }
            else
            {
                this.btnCancel.BackColor = Color.FromArgb(102, 102, 102);
            }
        }

        private void btnPowerOff_Click(object sender, EventArgs e)
        {
            foreach (DeviceDetailModel model in deviceVM.DeviceList)
            {
                if (model.IsChecked)
                {
                    string IP = model.IpAddress;
                    ComputerSetting.SendPackToSubService(IP, LANAllComputerIp.ComputerStatus.BREAK_LIEN);
                }
            }
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile(Application.StartupPath + "\\resource\\icon_closePopUp@2x.png");
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile(Application.StartupPath + "\\resource\\1x\\icon_closePopUp@2x.png");
        }
    }
}
