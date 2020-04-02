using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceMonitor
{
    [Description("事件信息表")]
    public class ConditionCommandEventInfo
    {
        [JsonProperty("conditionCommandEventId")]
        //[Detail(DisPlayName = "conditionCommandEventId", Visible = false, ControlType = (int)ControlType.TextBox, IsTreeNodeName = true)]
        public int? ConditionCommandEventId { get; set; }

        [JsonProperty("conditionCommandEventName")]
        //[Detail(DisPlayName = "事件名称", Visible = true, MaxLength = 25, ControlType = (int)ControlType.TextBox, IsTreeNodeText = true)]
        public string ConditionCommandEventName { get; set; }

        [JsonProperty("remark")]
        //[Detail(DisPlayName = "备注", Visible = true, ControlType = (int)ControlType.TextBox)]
        public string Remark { get; set; }

        [Description("删除标志")]
        [JsonProperty("delFlg")]
        public int? DelFlg { get; set; } = 0;
    }
}
