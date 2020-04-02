using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceMonitor.Model
{
   public class DeviceDetailInfo
    {
        public int deviceGroupId { get; set; }
        public string deviceGroupName { get; set; }
        public string remark { get; set; }

        public List<DataInfo> deviceInfo = new List<DataInfo>();

        public class DataInfo
        {
        public int deviceId { get; set; }
        public string deviceName { get; set; }
        public string ipAddress { get; set; }
        public string macAddress { get; set; }
        public string createDate { get; set; }
        public string delFlag { get; set; }
        }
    }
}
