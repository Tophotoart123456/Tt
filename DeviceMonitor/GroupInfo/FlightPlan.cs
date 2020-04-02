using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceMonitor
{
    public class flightPlan
    {
        /// <summary>
        /// 飞行计划ID
        /// </summary>
        public int? flightPlanId { get; set; }
        /// <summary>
        /// 训练计划ID
        /// </summary>
        public int? trainingPlanId { get; set; }
        /// <summary>
        /// 飞行计划名称
        /// </summary>
    
        public string flightPlanName { get; set; }
        /// <summary>
        /// 飞行计划类型
        /// </summary>
     
        public int? flightPlanType { get; set; }
        /// <summary>
        /// 航班号
        /// </summary>
      
        public string airlinerId { get; set; }
        /// <summary>
        /// 航空公司ID
        /// </summary>
        public int? airlinesId { get; set; }
        /// <summary>
        /// 航空器ID
        /// </summary>
        public int? planeId { get; set; }
        /// <summary>
        /// 注册号
        /// </summary>
        public string registerNo { get; set; }
        /// <summary>
        /// 注册号归属航空公司
        /// </summary>
        public int? registerNoAirliner { get; set; }
        /// <summary>
        /// 尾流分类ID
        /// </summary>
        public int? wakeFlowId { get; set; }
        /// <summary>
        /// 载重ID
        /// </summary>
        public int? deadweightId { get; set; }
        /// <summary>
        /// 应答机（SSR）
        /// </summary>
        public string ssrNo { get; set; }
        /// <summary>
        /// 航班性质ID
        /// </summary>
        public int? airlinerPropertyId { get; set; }
        /// <summary>
        /// 预计起飞时间
        /// </summary>
        public DateTime? expectDepartureTime { get; set; }
        /// <summary>
        /// 预计到达时间
        /// </summary>
        public DateTime? expectArrivalTime { get; set; }
        /// <summary>
        /// 出现时间
        /// </summary>
        public DateTime? visTime { get; set; }
        /// <summary>
        /// 出现点
        /// </summary>
        public string visPoint { get; set; }
        /// <summary>
        /// 出现点经度类型
        /// </summary>
        public int? longitudeType { get; set; }
        /// <summary>
        /// 出现点经度值
        /// </summary>
        public string longitudeValue { get; set; }
        /// <summary>
        /// 出现点纬度类型
        /// </summary>
        public int? latitudeType { get; set; }
        /// <summary>
        /// 出现点纬度值
        /// </summary>
        public string latitudeValue { get; set; }
        /// <summary>
        /// 出现点X坐标
        /// </summary>
        public double? visX { get; set; }
        /// <summary>
        /// 出现点Y坐标
        /// </summary>
        public double? visY { get; set; }
        /// <summary>
        /// 下一个点
        /// </summary>
        public string nextPoint { get; set; }
        ///// <summary>
        ///// 下一个点经度类型
        ///// </summary>
        //public int longitudeType2 { get; set; }
        ///// <summary>
        ///// 下一个点经度值
        ///// </summary>
        //public double longitudeValue2 { get; set; }
        ///// <summary>
        ///// 下一个点纬度类型
        ///// </summary>
        //public int latitudeType2 { get; set; }
        ///// <summary>
        ///// 下一个点纬度值
        ///// </summary>
        //public double latitudeValue2 { get; set; }
        ///// <summary>
        ///// 下一个X坐标
        ///// </summary>
        //public double nextPointX { get; set; }
        ///// <summary>
        ///// 下一个Y坐标
        ///// </summary>
        //public double nextPointY { get; set; }
        /// <summary>
        /// 初始高度
        /// </summary>
        public double? initialHeight { get; set; }
        /// <summary>
        /// 初始速度
        /// </summary>
        public double? initialSpeed { get; set; }
        /// <summary>
        /// 机头朝向
        /// </summary>
        public double? planeheadOrientation { get; set; }
        /// <summary>
        /// 进程单打印时间
        /// </summary>
        public DateTime? processSheetPrintTime { get; set; }
        /// <summary>
        /// 链接计划ID
        /// </summary>
        public int? linkFlightplanId { get; set; }
        /// <summary>
        /// 备注信息
        /// </summary>
        public string remark { get; set; }
        /// <summary>
        /// 起飞机场ID
        /// </summary>
        public int? departureAirportId { get; set; }
        /// <summary>
        /// 目的地机场ID
        /// </summary>
        public int? arrivalAirportId { get; set; }
        /// <summary>
        /// 备降机场ID
        /// </summary>
        public int? prepareAirportId { get; set; }
        /// <summary>
        /// 使用跑道ID
        /// </summary>
        public int? runwayId { get; set; }
        /// <summary>
        /// 联络道ID
        /// </summary>
        public int? contactWayId { get; set; }
        /// <summary>
        /// 停机位ID
        /// </summary>
        public int? gatePositionId { get; set; }
        /// <summary>
        /// 起飞方式
        /// </summary>
        public int? departureType { get; set; }
        /// <summary>
        /// 离场程序ID
        /// </summary>
        public int? departureProcedureId { get; set; }
        /// <summary>
        /// 离场航线ID
        /// </summary>
        public int? departureRouteId { get; set; }
        /// <summary>
        /// 进场航线ID
        /// </summary>
        public int? arrivalRouteId { get; set; }
        /// <summary>
        /// 进近程序ID
        /// </summary>
        public int? approachProcedureId { get; set; }
        /// <summary>
        /// 航路ID
        /// </summary>
        public int? routeId { get; set; }
        /// <summary>
        /// 复飞程序ID
        /// </summary>
        public int? goAroundId { get; set; }
        /// <summary>
        /// 参考气压面类型
        /// </summary>
        public int? referencePressureType { get; set; }
        /// <summary>
        /// 参考气压面值
        /// </summary>
        public double? referencePressureValue { get; set; }
        /// <summary>
        /// 扇区雷达名称
        /// </summary>
        public int? sectorRadarId { get; set; }
        /// <summary>
        /// 操作权限区ID
        /// </summary>
        public int? operationAuthorityId { get; set; }
        /// <summary>
        /// 燃油时间小时
        /// </summary>
        public int? fuelTimeHour { get; set; }
        /// <summary>
        /// 燃油时间分钟
        /// </summary>
        public int? fuelTimeMinute { get; set; }
        /// <summary>
        /// 燃油时间秒数
        /// </summary>
        public int? fuelTimeSecond { get; set; }
        /// <summary>
        /// 引擎是否启动
        /// </summary>
        public int? engineStartFlag { get; set; }
        /// <summary>
        /// 航路规划命令
        /// </summary>
        public string routePlanCommand { get; set; }
        /// <summary>
        /// 初始命令
        /// </summary>
        public string initialCommand { get; set; }
        /// <summary>
        /// 条件命令
        /// </summary>
        public string conditionCommand { get; set; }
        /// <summary>
        /// 误差速度
        /// </summary>
        public double? differenceSpeed { get; set; }
        /// <summary>
        /// 误差时间
        /// </summary>
        public int? differenceTime { get; set; }
        /// <summary>
        /// 飞行规则
        /// </summary>
        public string flightRules { get; set; }
        /// <summary>
        /// 飞行种类
        /// </summary>
        public string flightType { get; set; }
        /// <summary>
        /// 机载设备和能力
        /// </summary>
        public string airborneEquipment { get; set; }
        /// <summary>
        /// 报文18编组
        /// </summary>
        public string messageGroup { get; set; }
        /// <summary>
        /// 补充情报
        /// </summary>
        public string addInformation { get; set; }
        /// <summary>
        /// 是否具备RVSM能力
        /// </summary>
        public int? rvsmFlag { get; set; }
        /// <summary>
        /// 报文状态标志
        /// </summary>
        public string messageStatus { get; set; }
        
        //update on 20190527
        /// <summary>
        /// 尾流
        /// </summary>
        public string wakeFlowType { get; set; }
        /// <summary>
        /// 飞机类型
        /// </summary>
        public string planeTypeName { get; set; }

        /// <summary>
        /// 跑道类型
        /// </summary>
        public string runwayName { get; set; }
        /// <summary>
        /// 飞行类型（进港、离港、进近）
        /// </summary>
        public string flightPlanTypeCode { get; set; }
        /// <summary>
        /// 机场
        /// </summary>
        public string airportNo { get; set; }
        /// <summary>
        /// 操作名字
        /// </summary>
        public string operationName { get; set; }
        /// <summary>
        /// 目的机场
        /// </summary>
        public string arrivalAirportNo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string airlinerNum { get; set; }
    }
}
