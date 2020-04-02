using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceMonitor
{
    [Description("条件命令分组关系表")]
    public class ConditionCommandGroupRelationInfo
    {
        [JsonProperty("conditionCommandGroupRelationId")]
        public int? ConditionCommandGroupRelationId { get; set; }

        [Description("分组ID")]
        [JsonProperty("conditionCommandGroupId")]
        public int? ConditionCommandGroupId { get; set; }

        [Description("机场ID")]
        [JsonProperty("airportId")]
        public int? AirportId { get; set; }

        [Description("训练计划ID")]
        [JsonProperty("trainingPlanId")]
        public int? TrainingPlanId { get; set; }

        [Description("条件命令ID")]
        [JsonProperty("conditionCommandId")]
        public int? ConditionCommandId { get; set; }

        [Description("条件命令名字")]
        //[JsonIgnore]
        [JsonProperty("conditionCommandName")]
        public string ConditionCommandName { get; set; }

        [Description("删除标志(0:正常;1:删除)")]
        [JsonProperty("delFlag")]
        public int? DelFlag { get; set; } = 0;
    }
}
