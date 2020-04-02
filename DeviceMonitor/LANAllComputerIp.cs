using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.NetworkInformation;
using System.Threading;
using System.Management;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace DeviceMonitor
{
    //获取局域网电脑ip及名字
    public class LANAllComputerIp
    {
        [DllImport("Iphlpapi.dll")]
        private static extern int SendARP(Int32 dest, Int32 host, ref Int64 mac, ref Int32 length);
        [DllImport("Ws2_32.dll")]
        private static extern Int32 inet_addr(string ip);
        public enum ComputerStatus
        {
            BREAK_LIEN=0,
            ON_LINE,
            RESTART
        }
        public class ComputerIpInfo
        {
            public string machinename;
            public string ip;
            public string mac;
            public ComputerStatus status;
        }
        //用来保存局域网内电脑信息的缓存
        public Dictionary<string, ComputerIpInfo> computerInfo = null;
        public delegate void ComputerInfo(ComputerIpInfo cr);
        public event ComputerInfo Kii;

        //本机ip信息
        public ComputerIpInfo localMachine = null;
        //
        public LANAllComputerIp()
        {
            computerInfo = new Dictionary<string, ComputerIpInfo>();
            localMachine = new ComputerIpInfo();
        }
        public void ClearComputerInfo()
        {
            computerInfo.Clear();
        }
        //默认获取本机ip用来分解成网段
        public string GetLocalMachineIp()
        {
            string reslut=null;
            try
            {
                string machinename = Dns.GetHostName();
                var v = Dns.GetHostEntry(machinename);
                int i = 1;
                string ip = v.AddressList[v.AddressList.Length - i].ToString();
                reslut = ip.Remove(ip.LastIndexOf('.') + 1);
                while (reslut == "")
                {
                    i++;
                    ip = v.AddressList[v.AddressList.Length - i].ToString();
                    reslut = ip.Remove(ip.LastIndexOf('.') + 1);
                    if (v.AddressList.Length - i == 0)
                    {
                        break;
                    }
                }

                localMachine.ip = ip;
                localMachine.machinename = machinename;
                localMachine.mac = GetMacAddress();
            }
            catch(Exception err)
            {

            }
            return reslut;
        }
        public Dictionary<string,ComputerIpInfo> EnumComputers()
        {
            try
            {
                string bIp = GetLocalMachineIp();
                if (null == bIp || 0 == bIp.Length)
                    return computerInfo;
                for (int i = 0; i <= 10; i++)
                {
                    Ping myPing;
                    myPing = new Ping();
                    myPing.PingCompleted += new PingCompletedEventHandler(_myPing_PingCompleted);
                    string pingIP = bIp + i.ToString();
                    byte[] buffer = Encoding.ASCII.GetBytes("");
                    if (!computerInfo.Keys.Contains(pingIP))
                    {
                        ComputerIpInfo cip = new ComputerIpInfo();
                        string mac = GetRemoteMac(localMachine.ip, pingIP);
                        cip.ip = pingIP;
                        cip.status = ComputerStatus.BREAK_LIEN;
                        if (mac != "0")
                        {
                            cip.mac = mac;
                        }
                        computerInfo.Add(pingIP,cip );
                        Kii.Invoke(cip);
                    }
                    myPing.SendAsync(pingIP, 1000, buffer);
                }
                
            }
            catch(Exception err)
            {

            }
            
            return computerInfo;
        }
        private void _myPing_PingCompleted(object sender, PingCompletedEventArgs e)
        {
            if (e.Reply.Status == IPStatus.Success)
            {
                string reply = e.Reply.Address.ToString();
                if (computerInfo.Keys.Contains(reply))
                {
                    try
                    {
                        computerInfo[reply].machinename = Dns.GetHostEntry(IPAddress.Parse(reply)).HostName;
                        computerInfo[reply].status = ComputerStatus.ON_LINE;
                        Kii.Invoke(computerInfo[reply]);
                    }
                    catch(Exception err)
                    {

                    }
                }
            }
        }

        //获取远程主机MAC
        public string GetRemoteMac(string localIP, string remoteIP)
        {
            Int32 ldest = inet_addr(remoteIP); //目的ip
            Int32 lhost = inet_addr(localIP); //本地ip

            try
            {
                Int64 macinfo = new Int64();
                Int32 len = 6;
                int res = SendARP(ldest, 0, ref macinfo, ref len);
                string mac_Add = Convert.ToString(macinfo, 16);
                mac_Add = string.Join("-", Regex.Matches(mac_Add, @"..").Cast<Match>().ToList()).ToUpper();
                return mac_Add;
            }
            catch (Exception err)
            {
                Console.WriteLine("Error:{0}", err.Message);
            }
            return 0.ToString();
        }

        public string GetMacAddress()
        {
            try
            {
                string strMac = string.Empty;
                ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
                ManagementObjectCollection moc = mc.GetInstances();
                foreach (ManagementObject mo in moc)
                {
                    if ((bool)mo["IPEnabled"] == true)
                    {
                        strMac = mo["MacAddress"].ToString();
                        break;
                    }
                }
                moc = null;
                mc = null;
                return strMac;
            }
            catch
            {
                return "unknown";
            }
        }

    }
}
