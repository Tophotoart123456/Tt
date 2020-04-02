using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceMonitor
{
    public partial class airportInfoBase
    {
        //机场id
        public int? airportId { get; set; }
        //机场编号
        public string airportNo { get; set; }
        //机场名称
        public string airportName { get; set; }
    }

}
