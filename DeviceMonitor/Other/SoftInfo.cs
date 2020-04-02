using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceMonitor
{
    public enum SoftStatus
    {
        Init=0,
        Open,
        Close
    }
    public class SoftInfo
    {
        public string SoftName { get; set; }
        public string SoftPath { get; set; }

        public SoftStatus status { get; set; }
    }
}
