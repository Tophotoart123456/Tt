using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceMonitor
{
    [Description("条件命令表")]
    public class ConditionCommandRemindInfo
    {
        [JsonProperty("remindId")]
        public int? remindId { get; set; }

        [JsonProperty("conditionCommandId")]
        public int? ConditionCommandId { get; set; }

        [Description("执行命令阶段(0:及时;1:前;2:后)")]
        [JsonProperty("stage")]
        public int? Stage { get; set; }

        [Description("提示时长(秒)")]
        [JsonProperty("remindTime")]
        public int? RemindTime { get; set; }
        [Description("通话ID")]
        [JsonProperty("communicationId")]
        public int ?CommunicationId { get; set; }

        [Description("内容")]
        [JsonProperty("content")]
        public string Content { get; set; }

        [Description("备注")]
        [JsonProperty("remark")]
        public string Remark { get; set; }

        [Description("删除标志(0:正常;1:删除)")]
        [JsonProperty("delFlag")]
        public int ?DelFlag { get; set; } = 0;

    }
}
