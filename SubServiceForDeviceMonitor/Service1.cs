using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using DeviceMonitor;
using System.Threading;
namespace SubServiceForDeviceMonitor
{
    public partial class Service1 : ServiceBase
    {
        //用来记录当前机器上要运行的软件
        List<SoftInfo> softinfo = new List<SoftInfo>();
        SocketCom sc = new SocketCom();
        //
        public Service1()
        {
            InitializeComponent();
           
        }
        private void InitObj()
        {
            softinfo = new List<SoftInfo>();
            OnStart(null);
        }
        protected override void OnStart(string[] args)
        {
            //ConfigInfo info = new ConfigInfo();
            //var path = "F:\\设备管理\\DeviceMonitor\\SubServiceForDeviceMonitor\\bin\\Debug\\soft.ini";//info.GetCurrentPath();
            //var io = info.GetConfigInfo(path);
            //softinfo= info.SerialObj(io);

            PacketInfo pinfo = new PacketInfo();
            LANAllComputerIp lan = new LANAllComputerIp();
            lan.GetLocalMachineIp();
            lan.localMachine.status = LANAllComputerIp.ComputerStatus.ON_LINE;
            pinfo.ip.Add(lan.localMachine);
            SoftInfo sinfo = new SoftInfo();
            sinfo.SoftName = "coach.exe";
            sinfo.status = SoftStatus.Init;
            pinfo.soft.Add(sinfo);
            Packet pt = new Packet();
            var data= pt.Package(pinfo);

            sc.Start();
            sc.RD += Sc_RD;
            sc.SendInfo("",data);
        }

        private void Sc_RD(string data)
        {
            Packet pt = new Packet();
            var v = pt.Unpack(data);
            foreach( var sf in v.soft)
            pt.ProcessPacket(sf);

            foreach (var sl in v.ip)
                pt.ProcessPacket(sl);
        }

        protected override void OnStop()
        {

        }


    }
}
