using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceMonitor
{
    public class TrainPlan
    {
        /// <summary>
        /// 计划Id
        /// </summary>
        public int trainingPlanId { get; set; }
        /// <summary>
        /// 计划类型
        /// </summary>
        public int planType { get; set; }
        /// <summary>
        /// 用户计划类型
        /// </summary>
        public int userPlanType { get; set; }
        /// <summary>
        /// 机场ID
        /// </summary>
        public int airportId { get; set; }
        /// <summary>
        /// 计划名称
        /// </summary>
        public string trainingPlanName { get; set; }
        /// <summary>
        /// 调用视景时的显示时间
        /// </summary>
        public string beginTime { get; set; }

        //结束时间
        public string endTime { get; set; }
        /// <summary>
        /// 参考气压面
        /// </summary>
        public string referencePressure { get; set; }
        /// <summary>
        /// 跑道模式ID
        /// </summary>
        public string runwayModeId { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        public int createUser { get; set; }
        public int? createUserId { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime createDate { get; set; }

        public string airportName { get; set; }
        public string userName { get; set; }
        public List<trainingCoacheeInfo> trainingCoacheeInfoList { get; set; } = new List<trainingCoacheeInfo>();

    }
    public class trainingCoacheeInfo
    {
        public string trainingCoacheeId { get; set; }
        public string trainingPlanId { get; set; }
        public string trainingCoacheeType { get; set; }
        public int userId { get; set; }
        public string trainingMode { get; set; }
        public string middleTime { get; set; }
        public string runwayOpemodeId { get; set; }
        public string depFlightScheduleId { get; set; }
        public string arrFlightScheduleId { get; set; }
    }
}
