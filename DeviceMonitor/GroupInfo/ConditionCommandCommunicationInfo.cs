using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;

namespace DeviceMonitor
{
    [Description("通话信息表")]
    public class ConditionCommandCommunicationInfo
    {
        [JsonProperty("communicationId")]
        //[Detail(DisPlayName = "communicationId", Visible = false, ControlType = (int)ControlType.TextBox, IsTreeNodeName = true)]
        public int ? CommunicationId { get; set; }

        [JsonProperty("communicationName")]
        //[Detail(DisPlayName = "通话名称", Visible = true, MaxLength =25,ControlType = (int)ControlType.TextBox, IsTreeNodeText = true)]
        public string CommunicationName { get; set; }


        [JsonProperty("content")]
        //[Detail(DisPlayName = "内容", Visible = true, ControlType = (int)ControlType.TextBox)]
        public string Content { get; set; }


        [JsonProperty("remark")]
        //[Detail(DisPlayName = "备注", Visible = true, ControlType = (int)ControlType.TextBox)]
        public string Remark { get; set; }

        [Description("删除标志")]
        [JsonProperty("delFlg")]
        public int? DelFlg { get; set; } = 0;

    }
}