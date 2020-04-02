using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceMonitor
{
    [Description("条件命令分组信息表")]
    public class ConditionCommandGroupInfo
    {
        #region Files
        [JsonProperty("conditionCommandGroupId")]
        public int? ConditionCommandGroupId { get; set; }

        [Description("分组名称")]
        [JsonProperty("conditionCommandGroupName")]
        public string ConditionCommandGroupName { get; set; }

        [Description("分组类型(0:基本类型;1:用户类型)")]
        [JsonProperty("groupType")]
        public int? GroupType { get; set; }

        [Description("机场ID")]
        [JsonProperty("airportId")]
        public int? AirportId { get; set; }

        [Description("训练计划ID")]
        [JsonProperty("trainingPlanId")]
        public int? TrainingPlanId { get; set; }

        [Description("状态(0:不启用;1:启用)")]
        [JsonProperty("status")]
        public int? Status { get; set; } = 0;

        [Description("删除标志(0:正常;1:删除)")]
        [JsonProperty("delFlag")]
        public int? DelFlag { get; set; } = 0;


        [JsonProperty("readConditionCommandRelationResponseList")]
        public List<ConditionCommandGroupRelationInfo> ConditionCommandGroupRelationInfos { get; set; }


        [JsonProperty("readEnvironmentalPlanRealtionResponse")]
        public ConditionCommandEnvironmentalGroupRelationInfo ConditionCommandEnvironmentalGroupRelationInfo { get; set; }

        //[JsonIgnore]
        //public PlotMap.Common.State StateFlag { get { return _stateFlag; } set { _stateFlag = value; } }
        //private PlotMap.Common.State _stateFlag= PlotMap.Common.State.NoChange;
        #endregion
        
    }
}
