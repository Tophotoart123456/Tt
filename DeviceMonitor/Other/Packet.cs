using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
namespace DeviceMonitor
{
    public class PacketInfo
    {
        public PacketInfo()
        {
            ip = new List<LANAllComputerIp.ComputerIpInfo>();
            soft = new List<SoftInfo>();
        }
        public List<LANAllComputerIp.ComputerIpInfo> ip { get; set; }
        public List<SoftInfo> soft { get; set; }
    }
    public class Packet
    {
        public Packet()
        {

        }
        public string Package(PacketInfo info)
        {
            return JsonConvert.SerializeObject(info);
        }
        public PacketInfo Unpack(string info)
        {
            return JsonConvert.DeserializeObject<PacketInfo>(info);
        }

        public void ProcessPacket(SoftInfo sf)
        {
            OpereatProcess op = new OpereatProcess();
            if (sf.status.Equals(SoftStatus.Open))
                op.StartProcess(sf.SoftPath);
            else if (sf.status.Equals(SoftStatus.Close))
                op.KillProcess(sf.SoftName);
        }
        public void ProcessPacket(LANAllComputerIp.ComputerIpInfo ipinfo)
        {
            ComputerControl cc = new ComputerControl();
            if (ipinfo.status.Equals(LANAllComputerIp.ComputerStatus.BREAK_LIEN))
                cc.Shutdown("s");//关闭电脑
            else if(ipinfo.status.Equals(LANAllComputerIp.ComputerStatus.ON_LINE))
            {
                //打开电脑
                
            }
            else if(ipinfo.status.Equals(LANAllComputerIp.ComputerStatus.RESTART))//重启电脑
            {
                cc.Shutdown("r");
            }
        }

    }
}
