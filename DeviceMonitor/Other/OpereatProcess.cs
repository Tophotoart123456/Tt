using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
namespace DeviceMonitor
{
    public class OpereatProcess
    {
        public OpereatProcess()
        {

        }
        public void StartProcess(string path)
        {
            try
            {
                using (Process myProcess = new Process())
                {
                    myProcess.StartInfo.UseShellExecute = false;
                    // You can start any process, HelloWorld is a do-nothing example.
                    myProcess.StartInfo.FileName = path;
                    myProcess.StartInfo.CreateNoWindow = true;
                    myProcess.Start();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void KillProcess(string name)
        {
            try
            {
                foreach (Process item in Process.GetProcesses())
                {
                    if (item.ProcessName == name)
                    {
                        item.Kill();
                    }
                }
            }
            catch(Exception err)
            {

            }
        }

    }
}
