using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace DeviceMonitor
{
    class DeviceControl
    {
        //远程开机，网卡需要具备远程唤醒功能
        public static void WakeUp(string macStr)
        {
            UdpClient client = new UdpClient();
            client.Connect(IPAddress.Broadcast, 1234);
            byte[] mac = GetComputerMac(macStr);
            byte[] packet = new byte[17 * 6];
            for (int i = 0; i < 6; i++)
            {
                packet[i] = 0xFF;
            }
            for (int i = 1; i < 17; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    packet[i * 6 + j] = mac[j];
                }
            }
            int result = client.Send(packet, packet.Length);
            client.Close();
        }

        //返回MAC byte[]值
        private static byte[] GetComputerMac(string macStr)
        {
            byte[] mac = new byte[6];
            try
            {
                string[] str = macStr.Split(':', '-');
                for (int i = 0; i < str.Length; i++)
                {
                    mac[i] = Convert.ToByte(str[i], 16);
                }
            }
            catch (Exception e)
            {

            }         
            return mac;
        }

        //远程重启或关机方法　　　　
        public static bool Shutdown(string server, string userName, string pwd, bool isShutdown)
        {
            ManagementScope scope = CreateManagementScope(server, userName, pwd);
            ObjectQuery query = new ObjectQuery("select * from Win32_OperatingSystem");
            using (var searcher = new ManagementObjectSearcher(scope, query))
            {
                ManagementObjectCollection operates = searcher.Get();
                foreach (ManagementObject item in operates)
                {
                    string[] str = { "" };
                    if (isShutdown)
                    {
                        item.InvokeMethod("Shutdown", str);
                    }
                    else
                    {
                        item.InvokeMethod("Reboot", str);
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="server"> IP地址</param>
        /// <param name="userName"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public static ManagementScope CreateManagementScope(string server, string userName, string pwd)
        {
            string serverString = @"\\" + server + @"\root\cimv2";
            ManagementScope scope = new ManagementScope(serverString);
            scope.Options = new ConnectionOptions
            {
                Username = userName,
                Password = pwd,
                //Impersonation = ImpersonationLevel.Impersonate,
                //Authentication = AuthenticationLevel.None
            };
            return scope;
        }
    }
}
