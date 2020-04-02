using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using DeviceMonitor;

namespace SubServiceForDeviceMonitor
{
    class ConfigInfo
    {
        string configfilename = "soft.ini";
        public ConfigInfo()
        {
        }
        public string GetCurrentPath()
        {
            return (Directory.GetCurrentDirectory()+"\\"+configfilename);
        }
        public string GetConfigInfo(string path)
        {
            string reslut = "";
            if (null == path || 0 == path.Length)
                return reslut;
            using (Stream s = File.Open(path, FileMode.Open))
            {
                long length = s.Length;
                byte[] buffer=new byte[length];
                var p=s.Read(buffer, 0, (int)length);
                reslut = Encoding.ASCII.GetString(buffer);
            }
            return reslut;
        }
        public List<SoftInfo> SerialObj(string info)
        {
            List<SoftInfo> SoftList = new List<SoftInfo>();
            if (null == info || 0 == info.Length)
                return SoftList;
            JObject v= (JObject)JsonConvert.DeserializeObject(info);
            info = v["SoftList"].ToString();
            SoftList=JsonConvert.DeserializeObject < List<SoftInfo>>(info);
            return SoftList;
        }
    }
}
