using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceMonitor
{
    [Description("条件命令环境分组表")]
    public class ConditionCommandEnvironmentalGroupRelationInfo
    {
        [JsonProperty("conditionCommandEnvironmentalGroupId")]
        public int? ConditionCommandEnvironmentalGroupId { get; set; }

        [Description("分组ID")]
        [JsonProperty("conditionCommandGroupId")]
        public int? ConditionCommandGroupId { get; set; }

        [Description("机场ID")]
        [JsonProperty("airportId")]
        public int? AirportId { get; set; }

        [Description("训练计划ID")]
        [JsonProperty("trainingPlanId")]
        public int? TrainingPlanId { get; set; }

        [Description("环境计划ID")]
        [JsonProperty("environmentalPlanId")]
        public int? EnvironmentalPlanId { get; set; }

        [Description("环境名字")]
        [JsonProperty("environmentalPlanName")]
        public string EnvironmentalPlanName { get; set; }

        [Description("删除标志(0:正常;1:删除)")]
        [JsonProperty("delFlag")]
        public int? DelFlag { get; set; } = 0;
    }
}
