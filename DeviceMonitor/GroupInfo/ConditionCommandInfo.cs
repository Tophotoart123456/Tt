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
    public class ConditionCommandInfo
    {
        #region Fileds
        [JsonProperty("conditionCommandId")]
       public int? ConditionCommandId { get; set; }

        [Description("条件命令名称")]
        [JsonProperty("conditionCommandName")]
        public string ConditionCommandName { get; set; }

        [Description("条件命令类型(0:基本类型;1:用户类型)")]
        [JsonProperty("conditionType")]
        public int? ConditionType { get; set; }

        [Description("机场ID")]
        [JsonProperty("airportId")]
        public int? AirportId { get; set; }

        [Description("训练计划ID")]
        [JsonProperty("trainingPlanId")]
        public int? TrainingPlanId { get; set; }

        [Description("目标类型(0:所有飞机;1:指定飞机)")]
        [JsonProperty("objectiveType")]
        public int? ObjectiveType { get; set; }

        [Description("航班号集合")]
        [JsonProperty("airlinerNos")]
        public string AirlinerNos { get; set; }

        [Description("事件ID")]
        [JsonProperty("conditionCommandEventId")]
        public int? ConditionCommandEventId { get; set; }

        [Description("事件名称")]
        [JsonProperty("conditionCommandEventName")]
        public string ConditionCommandEventName { get; set; }

        [Description("触发区域类型(0:空中;1:地面)")]
        [JsonProperty("conditionCommandAreaType")]
        public int? ConditionCommandAreaType { get; set; }

        [Description("区域类型(1:点;2:线;五边)")]
        [JsonProperty("areaType")]
        public int? AreaType { get; set; }

        [Description("区域点")]
        [JsonProperty("areaPointId")]
        public int? AreaPointId { get; set; }


        [Description("区域线")]
        [JsonProperty("areaLineId")]
        public int? AreaLineId { get; set; }

        [Description("跑道ID")]
        [JsonProperty("runwayId")]
        public int? RunwayId { get; set; }

        [Description("方向")]
        [JsonProperty("direction")]
        public double? Direction { get; set; }

        [Description("距离")]
        [JsonProperty("distance")]
        public double? Distance { get; set; }

        [Description("半径")]
        [JsonProperty("areaRadius")]
        public double? AreaRadius { get; set; }


        [Description("触发阶段")]
        [JsonProperty("conditionCommandStageId")]
        public int? ConditionCommandStageId { get; set; }

        [Description("开始时间分钟")]
        [JsonProperty("beginTimeMinute")]
        public int? BeginTimeMinute { get; set; }

        [Description("开始时间秒数")]
        [JsonProperty("beginTimeSecond")]
        public int? BeginTimeSecond { get; set; }

        [Description("结束时间分钟")]
        [JsonProperty("endTimeMinute")]
        public int? EndTimeMinute { get; set; }

        [Description("开始时间秒数")]
        [JsonProperty("endTimeSecond")]
        public int? EndTimeSecond { get; set; }

        [Description("触发宏命令")]
        [JsonProperty("macrocmd")]
        public string macrocmd { get; set; }

        [Description("删除标志(0:正常;1:删除)")]
        [JsonProperty("delFlag")]
        public int? DelFlag { get; set; } = 0;

        //update on 20190930
        public string pointX { get; set; }
        public string pointY { get; set; }
        public string conditionCommandStageMacrocmd { get; set; }
        [Description("路名字")]
        [JsonProperty("roadName")]
        public string roadName { get; set; }
        //
        #endregion

        public List<ConditionCommandRemindInfo> conditionCommandRemindInfoList = new List<ConditionCommandRemindInfo>();
    }
}
