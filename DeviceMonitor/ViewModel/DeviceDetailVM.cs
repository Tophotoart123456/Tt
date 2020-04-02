using DeviceMonitor.Model;
using Helper;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace DeviceMonitor.ViewModel
{
    class DeviceDetailVM : PropertyChangedNotify
    {
        private bool isSelected = false;
        private List<DeviceDetailInfo> deviceDetails;
        private const int RESULTCODE = 1000;

        public DeviceDetailVM()
        {
        }

        private void BackWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                foreach (DeviceDetailInfo deviceInfo in deviceDetails)
                {
                    foreach (DeviceDetailInfo.DataInfo data in deviceInfo.deviceInfo)
                    {
                        DeviceDetailModel mdl = new DeviceDetailModel();
                        mdl.DeviceName = data.deviceName;
                        mdl.DeviceStatus = "未知";
                        mdl.GroupName = deviceInfo.deviceGroupName;
                        mdl.IpAddress = data.ipAddress;
                        mdl.DeviceMac = data.macAddress;
                        mdl.IsChecked = false;

                        DeviceList.Add(mdl);
                    }
                }
            }
            catch (Exception ex)
            {
              
            }
        }
        public static string GetHttpData(string url, string strparam)
        {
            string strtemp = "";
            if (url == "")
                return "";
            var vr = HttpRequestHelper.HttpPostRequest(url, strparam);
            try
            {
                JObject ob = (JObject)JsonConvert.DeserializeObject(vr);
                int strp = (int)ob["returnCode"];
                if (strp != RESULTCODE)
                    return "";
                strtemp = ob["dataInfo"].ToString();
            }
            catch (Exception err)
            {
                strtemp = err.Message;
            }
            return strtemp;
        }

        private void BackWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            string deviceListParm = ThreadBase.GetHttpUrl("readAllDeviceInfo");
            string deviceList = GetHttpData(deviceListParm, "{ }");
            deviceDetails = JsonConvert.DeserializeObject<List<DeviceDetailInfo>>(deviceList);
        }

        public void InitData()
        {
            //DeviceDetailModel mdl = new DeviceDetailModel { GroupName = "设置组", DeviceName = "Radar01", DeviceStatus = "未开机", IpAddress = "176.16.0.10", IsChecked = false };
            //DeviceDetailModel mdl2 = new DeviceDetailModel { GroupName = "设置组", DeviceName = "Radar02", DeviceStatus = "未开机", IpAddress = "176.16.0.11", IsChecked = false };
            //DeviceDetailModel mdl3 = new DeviceDetailModel { GroupName = "设置组", DeviceName = "Radar03", DeviceStatus = "未开机", IpAddress = "176.16.0.12", IsChecked = false };
            //DeviceDetailModel mdl4 = new DeviceDetailModel { GroupName = "设置组", DeviceName = "Radar04", DeviceStatus = "未开机", IpAddress = "176.16.0.13", IsChecked = false };
            //DeviceDetailModel mdl5 = new DeviceDetailModel { GroupName = "设置组", DeviceName = "Radar05", DeviceStatus = "未开机", IpAddress = "176.16.0.14", IsChecked = false };
            //DeviceDetailModel mdl6 = new DeviceDetailModel { GroupName = "设置组", DeviceName = "Radar06", DeviceStatus = "未开机", IpAddress = "176.16.0.15", IsChecked = false };
            //DeviceDetailModel mdl7 = new DeviceDetailModel { GroupName = "设置组", DeviceName = "Radar07", DeviceStatus = "未开机", IpAddress = "176.16.0.16", IsChecked = false };
            //DeviceDetailModel mdl8 = new DeviceDetailModel { GroupName = "设置组", DeviceName = "Radar08", DeviceStatus = "未开机", IpAddress = "176.16.0.17", IsChecked = false };
            //DeviceDetailModel mdl9 = new DeviceDetailModel { GroupName = "设置组", DeviceName = "Radar09", DeviceStatus = "未开机", IpAddress = "176.16.0.18", IsChecked = false };
            //DeviceDetailModel mdl10 = new DeviceDetailModel { GroupName = "设置组", DeviceName = "Radar010", DeviceStatus = "未开机", IpAddress = "176.16.0.19", IsChecked = false };
            //DeviceDetailModel mdl11 = new DeviceDetailModel { GroupName = "设置组", DeviceName = "Radar011", DeviceStatus = "未开机", IpAddress = "176.16.0.20", IsChecked = false };
            //DeviceDetailModel mdl12 = new DeviceDetailModel { GroupName = "设置组", DeviceName = "Radar012", DeviceStatus = "未开机", IpAddress = "176.16.0.21", IsChecked = false };
            //DeviceDetailModel mdl13 = new DeviceDetailModel { GroupName = "设置组", DeviceName = "Radar013", DeviceStatus = "未开机", IpAddress = "176.16.0.22", IsChecked = false };
            //DeviceList.Add(mdl);
            //DeviceList.Add(mdl2);
            //DeviceList.Add(mdl3);
            //DeviceList.Add(mdl4);
            //DeviceList.Add(mdl5);
            //DeviceList.Add(mdl6);
            //DeviceList.Add(mdl7);
            //DeviceList.Add(mdl8);
            //DeviceList.Add(mdl9);
            //DeviceList.Add(mdl10);
            //DeviceList.Add(mdl11);
            //DeviceList.Add(mdl12);
            //DeviceList.Add(mdl13);
            BackgroundWorker backWorker = new BackgroundWorker();
            backWorker.DoWork += BackWorker_DoWork;
            backWorker.RunWorkerCompleted += BackWorker_RunWorkerCompleted;
            backWorker.RunWorkerAsync();
        }

        public bool IsSelected
        {
            get
            {
                return isSelected;
            }
            set
            {
                isSelected = value;
                NotifyChanged("IsSelected");
            }
        }


        private ObservableCollection<DeviceDetailModel> deviceList = new ObservableCollection<DeviceDetailModel>();

        public ObservableCollection<DeviceDetailModel> DeviceList
        {
            get
            {
                return deviceList;
            }
            set
            {
                if (deviceList != value)
                {
                    deviceList = value;
                    NotifyChanged("DeviceList");
                }
            }
        }

        private ICommand selectAllClick;
        public ICommand SelectAllClick
        {
            get
            {
                return selectAllClick ?? (selectAllClick = new RelayCommand(OnSelecktAll));
            }
        }

        private ICommand itemSelectClick;
        public ICommand ItemSelectClick
        {
            get
            {
                return itemSelectClick ?? (itemSelectClick = new RelayCommand(OnItemSelect));
            }
        }

        private void OnItemSelect(object obj)
        {
            DeviceDetailModel model = (DeviceDetailModel)obj;
            model.IsChecked = !model.IsChecked;
            //throw new NotImplementedException();
        }

        private void OnSelecktAll(object obj)
        {
            CheckBox chk = (CheckBox)obj;
            this.IsSelected = chk.IsChecked.Value;
            foreach (DeviceDetailModel detail in this.DeviceList)
            {
                detail.IsChecked = chk.IsChecked.Value;
            }
        }
    }
}
