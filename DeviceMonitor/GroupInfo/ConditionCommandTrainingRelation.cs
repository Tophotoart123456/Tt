using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceMonitor
{
    [Description("条件命令训练计划关系")]
    public class ConditionCommandTrainingRelation
    {
        [JsonProperty("conditionCommandTrainingRelationId")]
        public int? ConditionCommandTrainingRelationId { get; set; }

        [Description("条件命令类型(0:基本类型;1:用户类型)")]
        [JsonProperty("conditionType")]
        public int? ConditionType { get; set; }

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

        /// <summary>
        /// 不需要序列化ConditionCommandName字段
        /// Json序列化用法
        /// </summary>
        /// <returns></returns>
        public bool ShouldSerializeConditionCommandName()
        {
            return false;
        }


        [Description("删除标志(0:正常;1:删除)")]
        [JsonProperty("delFlag")]
        public int? DelFlag { get; set; } = 0;
    }
}
