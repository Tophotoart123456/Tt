using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace DeviceMonitor
{
    public partial class Group : UserControl
    {
        public string GroupName{get;set;}
        public int GroupNumb { get; set; }
        //定义一个委托 提供给外部窗口调用
        public delegate void MoveContorl(string name, Control cr);
        public event MoveContorl McGroup;
        //
        //训练计划定时器
        System.Timers.Timer timer = null;
        DateTime dateTime;
        //
        //当前选中的图标
        public static Soft current_soft = null;
        //
        public static List< Soft> global_soft= new List<Soft>();
        //
        public Group()
        {
            InitializeComponent();
            InitUi();
            InitTimer();
        }
        private void InitUi()
        {
            if (comboBox2.Items.Count > 0)
                comboBox2.SelectedIndex = 0;
        }
        private void InitTimer()
        {
            timer = new System.Timers.Timer();
            timer.AutoReset = true;
            timer.Interval = 1000;
            timer.Elapsed += Timer_Tick;
        }
        public void StartTimer()
        {
            timer.Start();
        }
        public void StopTimer()
        {
            timer.Stop();
        }
        public void SetDateTime(DateTime dt)
        {
            if (dt != null)
                dateTime = dt;
            else
                dateTime = new DateTime();
            SetLabelStartTimeValue();
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            dateTime=dateTime.AddSeconds(1.0f);
            SetLabelStartTimeValue();
        }
        private void SetLabelStartTimeValue()
        {
            string tm = dateTime.ToString("HH:mm:ss");
            label_StartTime.Text = tm;
        }
        private void Tread_GIS()
        {
            Thread.Sleep(100);
            if(ThreadBase.airportInfoBases.Count>0)
            {
                ThreadBase.airportInfoBases.ForEach(o => comboBox1.Items.Add(o.airportName));
                if(comboBox1.Items.Count>0)
                comboBox1.SelectedIndex = 0;
            }
        }

        public void SetGroupName(string name)
        {
            TitelLabel.Text = name;
            GroupName = name;
        }
        public void SetBkColor(Color cr)
        {
            panel2.BackColor = cr;
        }
        public void AddSoft(string name,Image img,Soft stl)
        {
            if (!IsInclueSoft(name, stl))
            {
                Soft st = new Soft();
                st.Kii += St_Kii;
                st.Hint += St_Hint;
                st.Devicename = stl.Devicename;
                st.SetSoftName(name);
                st.SetSoftImage(img);
                st.GroupNumb = GroupNumb;
                flowLayoutPanel1.Controls.Add(st);
            }
        }
        //鼠标进入显示 鼠标离开时隐藏
        private void St_Hint(Soft st)
        {
            if(null != st)//显示
            {
                panel4.Visible = true;
                panel4.Location = st.Location;//new Point(st.Location.X, st.Location.Y - panel4.Height);
                SetMsg(st.SoftName, st.Devicename);
            }
            else//隐藏
            {
                panel4.Visible = false;
            }
        }
        //设置提示信息
        private void SetMsg(string softname,string devicename)
        {
            label_ComputerName.Text = softname;
            label_Ip.Text = devicename;
        }
        public void AddSoft(Soft st)
        {
            flowLayoutPanel1.Controls.Add(st);
        }
        private bool IsInclueSoft(string softname,Soft st)
        {
            bool success = false;
            foreach(var v in flowLayoutPanel1.Controls)
            {
                if(((Soft)v).SoftName.Equals(softname)&&((Soft)v).Devicename.Equals(st.Devicename))
                {
                    success = true;
                    break;
                }
            }
            return success;
        }
        public void RemoveFlowLayoutPanelItem(Control cr)
        {
            if (null == cr)
                return;
            
        }
        //拖动完成时
        private void St_Kii(Control cr,int type)
        {
            var soft = (Soft)cr;
            if (0 == type)//拖动完成时
            {
                McGroup.Invoke(GroupName, soft);
                //设置标记
                var v = global_soft.FindAll(o => o.Devicename == soft.Devicename && o.SoftName == soft.SoftName);
                if (v.Count == 1)
                {
                    v.FirstOrDefault().ShowGroupTag(false);
                }
                //移除当前客户端图标
                flowLayoutPanel1.Controls.Remove(soft);
                Form_Main.service.removeUserToTrainningGroupAsync(soft.SoftName, soft.Devicename, GroupName);
                //int k= global_soft.RemoveAll(o => o.Devicename.Equals(soft.Devicename) && o.SoftName.Equals(soft.SoftName));
                int index = global_soft.FindIndex(o => o.Devicename == soft.Devicename && o.SoftName == soft.SoftName);
                if (index != -1)
                    global_soft.RemoveAt(index);
            }
            else//单击时显示设置界面
            {
                current_soft = soft;

                if (label_Load.Image.Tag != null)
                {
                    Soft v = global_soft.Find(o => o.Devicename.Equals(soft.Devicename) && o.SoftName.Equals(soft.SoftName));
                    if (null != v)
                    {
                        v.GroupNumb = GroupNumb;
                        v.ShowForm(v, 1);
                    }
                }
            }

        }

        private void flowLayoutPanel1_MouseHover(object sender, EventArgs e)
        {
            AddGroupItem();
        }
        //移除组成员
        public void RemoveGroupItem(Soft soft)
        {
            foreach(var c in flowLayoutPanel1.Controls)
            {
                Soft st = (Soft)c;
                if(st.Devicename==soft.Devicename&&st.SoftName==soft.SoftName)
                {
                    Form_Main.service.removeUserToTrainningGroupAsync(soft.SoftName, soft.Devicename, GroupName);
                    //int k= global_soft.RemoveAll(o => o.Devicename.Equals(soft.Devicename) && o.SoftName.Equals(soft.SoftName));
                    int index = global_soft.FindIndex(o => o.Devicename == soft.Devicename && o.SoftName == soft.SoftName);
                    if (index != -1)
                        global_soft.RemoveAt(index);
                    flowLayoutPanel1.Controls.Remove(st);
                    break;
                }
            }
        }
        //添加组成员
        public bool AddGroupItem()
        {
            bool success = false;
            if (null != Device.move_contrl && !IsInclueSoft(Device.move_contrl.SoftName, Device.move_contrl))
            {
                string name = Device.move_contrl.SoftName;
                Image img = (Image)Device.move_contrl.PictureImg.Clone();
                //增加当前客户端图标
                AddSoft(name, img, Device.move_contrl);
                //用来保存当前图标
                global_soft.Add(Device.move_contrl);
                //设置标记
                Device.move_contrl.ShowGroupTag(true);
                if (1 < GetGlobalSoftCoachCount(Device.move_contrl))
                    Device.move_contrl.SetGroupTagName("...");
                else
                    Device.move_contrl.SetGroupTagName(GroupNumb.ToString());
                Device.move_contrl = null;
                success = true;
            }
            Device.move_contrl = null;
            return success;
        }
        //查找是否存在一个教员在多个分组里
        private int GetGlobalSoftCoachCount(Soft st)
        {
            return global_soft.Where(o => o.SoftName == st.SoftName && o.Devicename == st.Devicename).Count();
        }
        //底端Label点击事件
        private void LabelClick(object sender,EventArgs e)
        {
            try
            {
                if (sender is Label)
                {
                    Label L = sender as Label;
                    int Tag = Convert.ToInt32(L.Tag);
                    switch (Tag)
                    {
                        case 1://加载
                            if (null == label_Load.Image.Tag)
                            {
                                if (null != e)//手动点击事件
                                {
                                    CreateTrainGroup();
                                }
                                label_Load.Image = DeviceMonitor.Properties.Resources.icon_load_on_1x;
                                label_Load.Image.Tag = 1;
                            }
                            else
                            {
                                label_Load.Image = DeviceMonitor.Properties.Resources.icon_load_off_1x;
                            }
                            break;
                        case 2://启动 暂停 继续
                            //if (!IsCreate())
                            //    return;
                            if (null == label_StartOrPause.Image.Tag)//启动
                            {
                                if (null != e)//手动点击事件
                                {
                                    AddUserToGroup();
                                    Form_Main.service.startTrainningAsync(GroupName);

                                }
                                label_StartOrPause.Image = DeviceMonitor.Properties.Resources.icon_play_on_1x;
                                label_StartOrPause.Image.Tag = 2;
                            }
                            else if (2 == (int)label_StartOrPause.Image.Tag)//暂停
                            {
                                Form_Main.service.pauseTrainningAsync(GroupName);
                                label_StartOrPause.Image = DeviceMonitor.Properties.Resources.icon_pause_on_1x;
                                label_StartOrPause.Image.Tag = 3;
                            }
                            else//继续
                            {
                                Form_Main.service.continueTrainningAsync(GroupName);
                                label_StartOrPause.Image = DeviceMonitor.Properties.Resources.icon_play_on_1x;
                                label_StartOrPause.Image.Tag = 2;
                            }
                            break;
                        case 3://结束训练
                            //if (!IsCreate())
                            //    return;
                            if (null == label_End.Image.Tag)
                            {
                                Form_Main.service.stopTrainningAsync(GroupName);
                                label_End.Image = DeviceMonitor.Properties.Resources.icon_stop_on_1x;
                                label_End.Image.Tag = 3;
                            }
                            else
                            {
                                label_End.Image = DeviceMonitor.Properties.Resources.icon_stop_off_1x;
                            }
                            break;
                        case 4://录制视频
                            if (!IsCreate())
                                return;
                            if (null == label_Record.Image.Tag)
                            {
                                label_Record.Image = DeviceMonitor.Properties.Resources.icon_record_on_1x;
                                label_Record.Image.Tag = 4;
                            }
                            else
                            {
                                label_Record.Image = DeviceMonitor.Properties.Resources.icon_record_off_1x;
                            }
                            break;
                        case 5://考试 /勾选考试就自动点击录制视频按钮
                            if (!IsCreate())
                                return;
                            if (label_Exam.BackColor.Equals(Color.FromArgb(132, 132, 132)))
                            {
                                label_Exam.BackColor = Color.FromArgb(255, 255, 255);
                                if(label_Record.Image.Tag==null)
                                LabelClick(label_Record, e);
                            }
                            else
                            {
                                label_Exam.BackColor = Color.FromArgb(132, 132, 132);
                                LabelClick(label_Record, e);
                            }
                            break;
                        default: break;
                    }
                }
            }
            catch(Exception err)
            {

            }
        }
        //界面显示与后台数据同步
        ServiceReference1.TrainPlan trainPlan = null;
        public void DataSync(ServiceReference1.TrainPlan tp)
        {
            if(tp!=null)
            {
                switch (tp.trainingGroupState)
                {
                    case ServiceReference1.TrainningGroupState.Started:
                        dateTime = tp.StartedTime;
                        SetLabelStartTimeValue();
                        LoadGroupF();
                        StartGroupF();
                        break;
                    case ServiceReference1.TrainningGroupState.Pause:
                        dateTime = tp.StartedTime;
                        SetLabelStartTimeValue();
                        LoadGroupF();
                        PauseGroupF();
                        break;
                    case ServiceReference1.TrainningGroupState.Stop:
                        dateTime = tp.StartedTime;
                        SetLabelStartTimeValue();
                        LoadGroupF();
                        StopGroupF();
                        break;
                    default:
                        //LoadGroupF();
                        break;
                }
            }
        }
        //加载
        public void LoadGroupF()
        {
            label_Load.Image = DeviceMonitor.Properties.Resources.icon_load_on_1x;
            label_Load.Image.Tag = 1;
        }
        //启动训练组
        public void StartGroupF()
        {
            label_StartOrPause.Image = DeviceMonitor.Properties.Resources.icon_play_on_1x;
            label_StartOrPause.Image.Tag = 2;
        }
        //暂停训练组
        public void PauseGroupF()
        {
            label_StartOrPause.Image = DeviceMonitor.Properties.Resources.icon_pause_on_1x;
            label_StartOrPause.Image.Tag = 3;
        }
        //继续训练组
        public void ContinueGroupF()
        {
            label_Load.Image = DeviceMonitor.Properties.Resources.icon_load_on_1x;
            label_Load.Image.Tag = null;
        }
        //结束训练组
        public void StopGroupF()
        {
            label_End.Image = DeviceMonitor.Properties.Resources.icon_stop_on_1x;
            label_End.Image.Tag = 3;

            //重新启动
            label_StartOrPause.Image = DeviceMonitor.Properties.Resources.icon_play_off_1x;
            label_StartOrPause.Image.Tag = null;
        }
        
        //给组添加成员
        private void AddUserToGroup()
        {
            foreach(var v in flowLayoutPanel1.Controls)
            {
                Form_Main.service.addUserToTrainningGroupAsync(GroupName, ((Soft)v).SoftName, ((Soft)v).Devicename);
            }
        }
        //机场改变时
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text != "")
            {
                if (ThreadBase.trainPlans.Count > 0)
                {
                    comboBox3.Items.Clear();
                    //ThreadBase.trainPlans.Where(o => o.airportName!=null && o.airportName.Equals(comboBox1.Text)).ToList().ForEach(l =>
                    //  comboBox3.Items.Add(l.trainingPlanName));
                    //update on 20200331 一个训练计划可以对应多个机场
                    var airport = ThreadBase.airportInfoBases.Find(o => o.airportName.Equals(comboBox1.Text.Trim()));
                    if(airport!=null)
                    {
                        foreach(var v in ThreadBase.trainPlans)
                        {
                            var temp = v.trainingCoacheeInfoList.Find(o => o.userId.Equals(airport.airportId));
                            if(temp!=null)
                            comboBox3.Items.Add(v.trainingPlanName);
                        }
                    }
                    if(comboBox3.Items.Count>0)
                    comboBox3.SelectedIndex = 0;
                }
            }
        }
        //检测是否已经创建训练计划组
        private bool IsCreate()
        {
            bool success = false;
            if (label_Load.Image.Tag != null)
                success = true;
            return success;
        }
        //创建训练计划组
        private void CreateTrainGroup()
        {
            if(SendDataToWcf())
            {

            }
        }
        private bool SendDataToWcf()
        {
            bool success = false;
            //Dictionary<string, Dictionary<ServiceReference1.PlanType, string>> lg = new Dictionary<string, Dictionary<ServiceReference1.PlanType, string>>();
            //string strGroupName = GroupName;
            //Dictionary<ServiceReference1.PlanType, string> dt_plane = new Dictionary<ServiceReference1.PlanType, string>();
            //string strTm = GetFlightplan(comboBox3.Text);
            //if (strTm == "")
            //{
            //    MessageBox.Show("没有飞行计划");
            //    return success;
            //}
            //dt_plane.Add(ServiceReference1.PlanType.FLIGHT, strTm);
            //strTm = "";
            //strTm = GetConditionCommandInfo(ThreadBase.trainPlans.Find(oct => oct.trainingPlanName.Equals(comboBox3.Text)).trainingPlanId);
            //dt_plane.Add(ServiceReference1.PlanType.CONDITIONCOMMAND, strTm);
            //lg.Add(strGroupName, dt_plane);

            var trainPlan = ThreadBase.trainPlans.Find(oct => oct.trainingPlanName.Equals(comboBox3.Text));
            ServiceReference1.TrainPlan trainGroupPlan = new ServiceReference1.TrainPlan();
            trainGroupPlan.trainPlanGroupID = GroupName;
            trainGroupPlan.trainPlanGroupName = GroupName;
            trainGroupPlan.trainPlanID = (trainPlan?.trainingPlanId ?? 0).ToString();
            trainGroupPlan.trainPlanName = trainPlan.trainingPlanName;
            //trainGroupPlan.airPortId = trainPlan.airportId.ToString();
            //update on 20200331 给机场id
            var airport = ThreadBase.airportInfoBases.Find(o => o.airportName.Equals(comboBox1.Text.Trim()));
            if(airport != null)
            trainGroupPlan.airPortId = airport.airportId.ToString();
            //
            Form_Main.service.createTrainningGroupByTrainingIdAsync(trainGroupPlan);//.createTrainningGroupAsync(lg);
            success = true;
            return success;
        }
        private string GetFlightplan(string strtrainname)
        {
            int index = ThreadBase.trainPlans.FindIndex(oct => oct.trainingPlanName.Equals(strtrainname));
            if (index == -1)
                return "";
            //update on 20190927
            int airportid = ThreadBase.trainPlans[index].airportId;
            //
            index = ThreadBase.trainPlans[index].trainingPlanId;
            string strParm = "{\"userId\":1,\"airportId\":" + airportid + ",\"trainingPlanId\":" + index + ",\"trainingPlanName\":\"" + strtrainname + "\"}";
            string strlink = ThreadBase.GetHttpUrl("readFlightPlan");
            strParm = cla_http.GetHttpData(strlink, strParm);
            if (strParm == "")
                return "";
            return strParm;
        }
        //筛选条件性命令
        private string GetConditionCommandInfo(int trainId)
        {
            string reslut = "";
            if (ThreadBase.conditionCommands == null)
                return reslut;
            var v = ThreadBase.conditionCommands.Where(oct => oct.TrainingPlanId.Equals(trainId));
            if (v != null || v.Count() > 0)
            {
                reslut = cla_http.SerialStringToJs(v);
            }
            return reslut;
        }
        //训练计划
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            var v = ThreadBase.trainPlans.Find(o => o.trainingPlanName.Equals(comboBox3.Text));
            if (v != null)
            {
                //label_TrainTime.Text = "/" + string.Format("{0}:{1}", v.beginTime.Minute, v.beginTime.Second);
                //update on 20200331 时间转换成hh：mm:ss
                string starttime = v.beginTime.Insert(2, ":");
                string endtime = v.endTime.Insert(2, ":");
                label_TrainTime.Text = "/" + (DateTime.Parse(endtime)-DateTime.Parse(starttime)).ToString();
            }
        }

        private void Group_Load(object sender, EventArgs e)
        {
            Tread_GIS();
        }
    }
}
