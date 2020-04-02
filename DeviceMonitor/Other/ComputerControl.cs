using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace DeviceMonitor
{
   public class ComputerControl
    {
        public ComputerControl()
        {

        }

        public void Shutdown(string ip)
        {
            Process commandProcess = new Process();
            try
            {
                commandProcess.StartInfo.FileName = "cmd.exe";
                commandProcess.StartInfo.UseShellExecute = false;
                commandProcess.StartInfo.CreateNoWindow = true;
                commandProcess.StartInfo.RedirectStandardError = true;
                commandProcess.StartInfo.RedirectStandardInput = true;
                commandProcess.StartInfo.RedirectStandardOutput = true;
                commandProcess.Start();
                commandProcess.StandardInput.WriteLine(string.Format("shutdown -{0} -t 1", ip));
                //commandProcess.StandardInput.WriteLine(string.Format("shutdown /r /m {0} /t 20 /f", ip));
                commandProcess.StandardInput.WriteLine("exit");

                if (!commandProcess.HasExited)//等待cmd命令运行完毕                {     
                    System.Threading.Thread.Sleep(1);
                string tmpout = commandProcess.StandardError.ReadToEnd();
                string tmpout1 = commandProcess.StandardOutput.ReadToEnd();
            }                //错误输出     
            catch (Exception e)
            {
                //MessageBox.Show(e.Message);
            }
            finally
            {
                if (commandProcess != null)
                {
                    commandProcess.Dispose();
                    commandProcess = null;
                }
            }
        }

        //远程开机方法
        public void WakeUp(string macAddress)
        {
            if (string.IsNullOrWhiteSpace(macAddress))
                return;
            byte[] mac = GetComputerMac(macAddress);
            WakeUp(mac);
        }
        //远程开机，网卡需要具备远程唤醒功能
        private void WakeUp(byte[] mac)
        {
            UdpClient client = new UdpClient();
            client.Connect(IPAddress.Broadcast, 9090);
            byte[] packet = new byte[17 * 6];
            for (int i = 0; i < 6; i++)
            {
                packet[i] = 0xFF;
            }
            for (int i = 1; i < 16; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    packet[i * 6 + j] = mac[j];
                }
            }
            int result = client.Send(packet, packet.Length);
            client.Close();
        }

        //返回MAC值
        private byte[] GetComputerMac(string macStr)
        {
            byte[] mac = new byte[6];
            string[] str = macStr.Split(':', '-');
            for (int i = 0; i < str.Length; i++)
            {
                mac[i] = byte.Parse(str[i], NumberStyles.HexNumber); //Convert.ToByte(str[i], 16);
            }
            return mac;
        }

    }
}
