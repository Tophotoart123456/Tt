using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Threading;
using System.Net;

namespace DeviceMonitor
{
    public class SocketCom
    {
        //局域网计算机端口
        const int IP_PORT = 9050;
        //广播地址
        const string UDP_IP = "255.255.255.255";
        bool connecting = false;
        //
        //给外部提供一个委托 用来处理接受到的数据
        public delegate void ReceiveData(string data);
        public event ReceiveData RD;
        //
        public SocketCom()
        {

        }
        public void Start(string ip="")
        {
            connecting = true;
            ReceiveInfo(ip);
        }
        public void Stop()
        {
            connecting = false;
        }
        public void ReceiveInfo(string ip = "")
        {

            ThreadPool.QueueUserWorkItem((x) =>
            {
                try
                {
                    Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                    IPEndPoint iep = null;
                    if (ip.Equals(""))
                        iep = new IPEndPoint(IPAddress.Any, IP_PORT);
                    else
                        iep = new IPEndPoint(IPAddress.Parse(ip), IP_PORT);
                    sock.Bind(iep);
                    EndPoint ep = (EndPoint)iep;
                    byte[] data;
                    int recv;
                    string stringData;
                    while (connecting)
                    {
                        data = new byte[1024];
                        recv = sock.ReceiveFrom(data, ref ep);
                        stringData = Encoding.ASCII.GetString(data, 0, recv);
                        RD.Invoke(stringData);
                    }
                    sock.Close();

                }
                catch (Exception err)
                {

                }
       
            });
        }
        public void SendInfo(string ip, string content)
        {
            if (ip == null || ip.Length == 0)
                ip = UDP_IP;
            Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            IPEndPoint iep2 = new IPEndPoint(IPAddress.Parse(ip), 9050);
            byte[] data = Encoding.ASCII.GetBytes(content);
            sock.SetSocketOption(SocketOptionLevel.Socket,
            SocketOptionName.Broadcast, 1);
            sock.SendTo(data, iep2);
            sock.Close();
        }

    }
}
