using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Newtonsoft;
using Newtonsoft.Json;
using DeviceMonitor.ServiceReference1;
using System.Configuration;

namespace DeviceMonitor
{
    public class ThreadBase
    {
        //给外部窗口使用
        public delegate void GetInfoSuccess();
        public event GetInfoSuccess GIS;
        //一次性读取机场、训练计划、条件性命令
        public static List<airportInfoBase> airportInfoBases = new List<airportInfoBase>();
        public static List<TrainPlan> trainPlans = new List<TrainPlan>();
        public static List<ConditionCommandInfo> conditionCommands = new List<ConditionCommandInfo>();
        //启动、停止获取客户端线程
        public bool RunGetClientThread = true;
        //
        //从服务获取到的在线客户端以及训练分组成员
        public  List<ServiceReference1.TrainPlan> global_TrainPlan = null;
        public  List<RoleUserRelation> global_UserRelation = null;
        public  Dictionary<string, string[]> global_online_client = null;

        //每次动态获取并处理完通知主窗口更新内容
        public delegate void SendMessageToMainForm(Dictionary<ServiceReference1.TrainPlan, List<RoleUserRelation>> ur, Dictionary<string, string[]> online);
        public event SendMessageToMainForm SMTMF;
        //
        public ThreadBase() { }

        public static string GetHttpUrl(string param)
        {
            string reslut = ConfigurationManager.AppSettings["ServerInterfaceAddress"];
            reslut += ConfigurationManager.AppSettings[param];
            return reslut;
        }

        public void ReadAirportAndTrainInfo()
        {
            ThreadPool.QueueUserWorkItem(o =>
            {
                while (true)
                {
                    try
                    {
                        string trainplan = GetHttpUrl("readTrainingPlan");
                        string airport = GetHttpUrl("readAirportInfo");
                        string conditioncmd = GetHttpUrl("readConditionCommandInfo");
                        //机场信息
                        airport = cla_http.GetHttpData(airport, "{ }");
                        if ("" == airport)
                        {
                            Thread.Sleep(1000);
                            continue;
                        }
                        airportInfoBases = JsonConvert.DeserializeObject<List<airportInfoBase>>(airport);
                        //训练计划
                        trainplan = cla_http.GetHttpData(trainplan, "{ }");
                        if ("" == trainplan)
                        {
                            Thread.Sleep(1000);
                            continue;
                        }
                        trainPlans = JsonConvert.DeserializeObject<List<TrainPlan>>(trainplan);
                        //条件性命令
                        conditioncmd = cla_http.GetHttpData(conditioncmd, "{ }");
                        conditionCommands = JsonConvert.DeserializeObject<List<ConditionCommandInfo>>(trainplan);

                        GIS.Invoke();
                        break;
                    }
                    catch (Exception err)
                    {
                        Thread.Sleep(1000);
                        
                    }
                }
            });
        }

        public void StopClientThread()
        {
            RunGetClientThread = false;
        }
        public void StartGetClientThread()
        {
            Thread thread = new Thread(new ThreadStart(GetClientThread));
            thread.IsBackground = true;
            thread.Name = "获取在线客户端";
            thread.Start();
        }
        private void GetClientThread()
        {

                while (RunGetClientThread)
                {
                    try
                    {
                        global_TrainPlan = Form_Main.service.getAllTrainingGroup().ToList();//训练计划组
                        global_UserRelation = Form_Main.service.getAllGroupUser().ToList();//组成员
                        global_online_client = Form_Main.service.getUserRoleList();//在线客户端
                    
                        global_online_client =GetOnlineClient(global_online_client);
                        var v = GetGroupUser(global_TrainPlan, global_UserRelation);
                        SMTMF.Invoke(v, global_online_client);
                        Thread.Sleep(100);
    
                    }
                    catch (System.ServiceModel.CommunicationObjectFaultedException ex)
                    {
                        try
                        {
                            Thread.Sleep(60);
                            Form_Main.service = Form_Main.service1Client.ChannelFactory.CreateChannel();
                            //FlyControl._FlyControl.sc.heartBeat(FlyControl._FlyControl.user, FlyControl._FlyControl.role);
                        }
                        catch
                        {
                            Console.WriteLine("重连失败...");
                        }
                    }
                    catch (System.ServiceModel.EndpointNotFoundException ex)
                    {
                        try
                        {
                            Thread.Sleep(60);
                            Form_Main.service = Form_Main.service1Client.ChannelFactory.CreateChannel();
                            //FlyControl._FlyControl.sc.heartBeat(FlyControl._FlyControl.user, FlyControl._FlyControl.role);
                        }
                        catch
                        {
                            Console.WriteLine("重连失败...");
                        }
                    }
                    catch (Exception err)
                    {
                        //Log.Error(err.Message);
                    }

                Thread.Sleep(100);
            }
        }
        private Dictionary<string,string[]> GetOnlineClient(Dictionary<string,string[]> param)
        {
            Dictionary<string, string[]> reslut = new Dictionary<string, string[]>();
           foreach(var v in param.Values)
            {
                var temp = param.Values.Where(o => o.Equals(v));
                if(temp!=null&&temp.Count()>0)
                {
                    List<string> role = new List<string>();
                    foreach (var k in param)
                        if (k.Value.Where(o => o.Equals(v)) != null)
                            role.Add(k.Key);
                    if(!reslut.Keys.Contains(v.First()))
                    reslut.Add(v.First(), role.ToArray());
                }
            }
            return reslut;
        }
        private Dictionary<ServiceReference1.TrainPlan,List< RoleUserRelation>> GetGroupUser(List<ServiceReference1.TrainPlan> t,List<RoleUserRelation> r)
        {
            Dictionary<ServiceReference1.TrainPlan,List< RoleUserRelation>> reslut = new Dictionary<ServiceReference1.TrainPlan,List< RoleUserRelation>>();

            foreach(var v in t)
            {
                if(!reslut.Keys.Contains(v))
                {
                    var p = r.Where(o => o.trainGroupId.Equals(v.trainPlanGroupID));
                    reslut.Add(v, p.ToList());
                }
            }

            return reslut;
        }

    }
}
