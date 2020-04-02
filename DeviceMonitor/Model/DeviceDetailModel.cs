using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceMonitor.Model
{
    public class DeviceDetailModel:PropertyChangedNotify
    {
        private string groupName;
        private string deviceName;
        private string ipAddress;
        private string deviceStatus;
        private bool isChecked;
        private string deviceMac; 

        public string GroupName
        {
            get
            {
                return groupName;
            }
            set
            {
                groupName = value;
                NotifyChanged("GroupName");
            }
        }

        public string DeviceName
        {
            get
            {
                return deviceName;
            }
            set
            {
                deviceName = value;
                NotifyChanged("DeviceName");
            }
        }

        public string IpAddress
        {
            get
            {
                return ipAddress;
            }
            set
            {
                ipAddress = value;
                NotifyChanged("IpAddress");
            }
        }

        public string DeviceStatus
        {
            get
            {
                return deviceStatus;
            }
            set
            {
                deviceStatus = value;
                NotifyChanged("DeviceStatus");
            }
        }

        public bool IsChecked
        {
            get
            {
                return isChecked;
            }
            set
            {
                isChecked = value;
                NotifyChanged("IsChecked");
            }
        }

        public string DeviceMac
        {
            get
            {
                return deviceMac;
            }
            set
            {
                deviceMac = value;
                NotifyChanged("DeviceMac");
            }
        }
    }
}
