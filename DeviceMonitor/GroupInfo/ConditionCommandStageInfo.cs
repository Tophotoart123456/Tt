using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceMonitor
{
    [Description("条件性命令阶段信息表")]
    public class ConditionCommandStageInfo
    {
        [JsonProperty("conditionCommandStageId")]
        //[Detail(DisPlayName = "conditionCommandStageId", Visible = false, ControlType = (int)ControlType.TextBox, IsTreeNodeName = true)]
        public int? ConditionCommandStageId { get; set; }

        [JsonProperty("conditionCommandStageName")]
        //[Detail(DisPlayName = "阶段名称", Visible = true, MaxLength = 50, ControlType = (int)ControlType.TextBox, IsTreeNodeText = true)]
        public string ConditionCommandStageName { get; set; }

        [JsonProperty("conditionCommandStageMacrocmd")]
        //[Detail(DisPlayName = "阶段命令", Visible = true,MaxLength =255, ControlType = (int)ControlType.TextBox)]
        public string ConditionCommandStageMacrocmd { get; set; }

        [Description("删除标志")]
        [JsonProperty("delFlg")]
        public int? DelFlg { get; set; } = 0;
    }
}
