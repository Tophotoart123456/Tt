using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using DeviceMonitor.FlightService;

namespace DeviceMonitor
{
    class CallWCFService
    {
        public Service1Client serviceClient;

        public CallWCFService()
        {
            InstanceContext instanceContext = new InstanceContext(new CallBackHandler());
            serviceClient = new Service1Client(instanceContext);

        }

        public void GetAllDevice()
        {
            Dictionary<string,string[]> dic_AllDevice = serviceClient.getUserRoleList();
        }

        public class CallBackHandler : DeviceMonitor.FlightService.IService1Callback
        {
            public void setCondition(string msg, long time)
            {

            }

            public  void cxc()
            {

            }
        }
    }
}
