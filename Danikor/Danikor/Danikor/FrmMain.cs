using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sunny.UI;
using Communication;
using thinger.DataConvertLib;
using Data;
using Helper;
using System.IO;
using MCMQ;
using System.Xml;
using System.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
namespace Danikor
{
    public partial class FrmMain : UIForm
    {
        public FrmMain()
        {
            InitializeComponent();
            Variable.ListAddLog = new Action<int, string>(AddLog);
            //Variable.DgvAddLog = new Action<string, string>(DgvAddRow);
            Variable.CurrentDateLogPath = Application.StartupPath + "\\Log\\";
            AddLog(0, "登录成功");
            Initial();
            this.FormClosing += FrmMain_FormClosing;
            this.dgvLog.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(214, 96, 20);

            //依赖注入

            // 创建服务集合   这就是我们的IoC容器  控制反转
            ServiceCollection services = new ServiceCollection();

            // 注册服务
            //Transient：每次请求都会创建一个新的实例，适用于无状态服务。
            //Scoped：在同一个请求范围内共享实例，适用于基于请求的服务，如Web应用中的服务。
            //Singleton：整个应用程序生命周期内共享同一个实例，适用于无状态且需要全局共享的服务。
            services.AddTransient<ITcpClient, TClient>();
            services.AddSingleton<IMcmq, Mcmq>();
            //services.AddSingleton<IMcmq, Mcmq>();
            // 构建服务提供者
            var serviceProvider = services.BuildServiceProvider();

            // 初始化服务定位器
            ServiceLocator.Init(serviceProvider);

            mcmqServer = new McmqServer(ServiceLocator.GetService<IMcmq>());

            //  MCMQ初始化连接
            if (SystemSetting.EnabledMCMQ)
            {
                mcmqServer.McmqConnet(SystemSetting.McmqIP, SystemSetting.McmqPort, SystemSetting.MCMQQueueName, SystemSetting.MCMQReplyQueueName);

                mcmqServer.McmqReceiveEvent += McmqServer_McmqReceiveEvent;
            }
        }

        #region property

        public McmqServer mcmqServer { get; set; } 

        public string SystemSettingPath { get; set; } = Application.StartupPath + "\\System\\System.ini";

        public bool ScrewDownJudge { get; set; } = true;

        public string ProductLogPath { get; set; } = Application.StartupPath + "\\Product_Log\\";

        #endregion

        #region 关闭窗口前存放参数

        /// <summary>
        /// 关闭窗口前存放参数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            mcmqServer.McmqClose();

            Helper.IniConfigHelper.WriteIniData("Parameter", "ScrewBitsCount", this.lab_ScrewBitsCount.Text, SystemSettingPath);
        }

        #endregion

        #region 初始化设备参数

        /// <summary>
        /// 初始化设备参数与
        /// </summary>
        public void Initial()
        {
            // 创建并启动 Stopwatch 实例
            Stopwatch stopwatch = Stopwatch.StartNew();
            //系统参数
            SystemSetting.DeviceIP = IniConfigHelper.ReadIniData("System", "DeviceIP", "", SystemSettingPath);
            SystemSetting.DeviceIpPort = int.Parse(IniConfigHelper.ReadIniData("System", "DeviceIpPort", "", SystemSettingPath));
            SystemSetting.DeviceRTUPort = IniConfigHelper.ReadIniData("System", "DeviceRTUPort", "", SystemSettingPath);
            SystemSetting.McmqIP = IniConfigHelper.ReadIniData("System", "McmqIP", "", SystemSettingPath);
            SystemSetting.MCMQQueueName = IniConfigHelper.ReadIniData("System", "MCMQQueueName", "", SystemSettingPath);
            SystemSetting.MCMQReplyQueueName = IniConfigHelper.ReadIniData("System", "MCMQReplyQueueName", "", SystemSettingPath);
            SystemSetting.McmqIP = IniConfigHelper.ReadIniData("System", "McmqIP", "", SystemSettingPath);
            SystemSetting.McmqPort = int.Parse(IniConfigHelper.ReadIniData("System", "McmqPort", "", SystemSettingPath));
            SystemSetting.FtpIP = IniConfigHelper.ReadIniData("System", "FtpIP", "", SystemSettingPath);
            SystemSetting.FtpPort = int.Parse(IniConfigHelper.ReadIniData("System", "FtpPort", "", SystemSettingPath));
            SystemSetting.FtpRootPath = IniConfigHelper.ReadIniData("System", "FtpRootPath", "", SystemSettingPath);
            SystemSetting.FtpUserName = IniConfigHelper.ReadIniData("System", "FtpUserName", "", SystemSettingPath);
            SystemSetting.FtpUserPwd = IniConfigHelper.ReadIniData("System", "FtpUserPwd", "", SystemSettingPath);
            Variable.UserPwd = IniConfigHelper.ReadIniData("System", "UserPwd", "", SystemSettingPath);
            InitialChart();

            //界面参数显示
            this.lab_PsetName.Text = Helper.IniConfigHelper.ReadIniData("Parameter", "Pset", Variable.deviceParameters.PsetName, SystemSettingPath);
            this.lab_Nm.Text = Helper.IniConfigHelper.ReadIniData("Parameter", "Nm", Variable.deviceParameters.Nm, SystemSettingPath);
            this.lab_Angle.Text = Helper.IniConfigHelper.ReadIniData("Parameter", "Angle", Variable.deviceParameters.Angle, SystemSettingPath);
            this.lab_AngleDownLimit.Text = Helper.IniConfigHelper.ReadIniData("Parameter", "AngleDownLimit", Variable.deviceParameters.AngleDownLimit, SystemSettingPath);
            this.lab_AngleUpperLimit.Text = Helper.IniConfigHelper.ReadIniData("Parameter", "AngleUpperLimit", Variable.deviceParameters.AngleUpperLimit, SystemSettingPath);
            this.lab_NmDownLimit.Text = Helper.IniConfigHelper.ReadIniData("Parameter", "NmDownLimit", Variable.deviceParameters.NmDownLimit, SystemSettingPath);
            this.lab_NmUpperLimit.Text = Helper.IniConfigHelper.ReadIniData("Parameter", "NmUpperLimit", Variable.deviceParameters.NmUpperLimit, SystemSettingPath);
            this.lab_Rotate_Speed.Text = Helper.IniConfigHelper.ReadIniData("Parameter", "Rotate_Speed", Variable.deviceParameters.Rotate_Speed, SystemSettingPath);
            this.lab_Rotation_Angle.Text = Helper.IniConfigHelper.ReadIniData("Parameter", "Rotation_Angle", "0", SystemSettingPath);
            this.lab_OK_Count.Text = Helper.IniConfigHelper.ReadIniData("Parameter", "OK_Count", "0", SystemSettingPath);
            this.lab_NG_Count.Text = Helper.IniConfigHelper.ReadIniData("Parameter", "NG_Count", "0", SystemSettingPath);
            this.lab_ScrewDownFPY.Text = Helper.IniConfigHelper.ReadIniData("Parameter", "ScrewDownFPY", "0", SystemSettingPath);
            this.lab_Product_Count.Text = Helper.IniConfigHelper.ReadIniData("Parameter", "Product_Count", "0", SystemSettingPath);

            this.lab_ScrewBitsCount.Text = Helper.IniConfigHelper.ReadIniData("Parameter", "ScrewBitsCount", "0", SystemSettingPath);

            this.lab_ScrewCount.Text = Helper.IniConfigHelper.ReadIniData("Parameter", "ScrewCount", "0", SystemSettingPath);

            //XML
            XMLData.Operation = Helper.IniConfigHelper.ReadIniData("XML", "Operation", "", SystemSettingPath);
            XMLData.Area = Helper.IniConfigHelper.ReadIniData("XML", "Area", "", SystemSettingPath);
            XMLData.Station = Helper.IniConfigHelper.ReadIniData("XML", "Station", "", SystemSettingPath);
            XMLData.Line = Helper.IniConfigHelper.ReadIniData("XML", "Line", "", SystemSettingPath);
            XMLData.EQP_ID = Helper.IniConfigHelper.ReadIniData("XML", "EQP_ID", "", SystemSettingPath);
            XMLData.Model_No = Helper.IniConfigHelper.ReadIniData("XML", "Model_No", "", SystemSettingPath);
            XMLData.P_Area = Helper.IniConfigHelper.ReadIniData("XML", "P_Area", "", SystemSettingPath);
            XMLData.Sys_Para = Helper.IniConfigHelper.ReadIniData("XML", "Sys_Para", "", SystemSettingPath);
            XMLData.Function = Helper.IniConfigHelper.ReadIniData("XML", "Function", "", SystemSettingPath);
            XMLData.Measure_Type = Helper.IniConfigHelper.ReadIniData("XML", "Measure_Type", "", SystemSettingPath);
            XMLData.Next_Operation = Helper.IniConfigHelper.ReadIniData("XML", "Next_Operation", "", SystemSettingPath);
            XMLData.Port_ID = Helper.IniConfigHelper.ReadIniData("XML", "Port_ID", "", SystemSettingPath);
            XMLData.Mlp_ID = Helper.IniConfigHelper.ReadIniData("XML", "Mlp_ID", "", SystemSettingPath);
            XMLData.Jig_ID = Helper.IniConfigHelper.ReadIniData("XML", "Jig_ID", "", SystemSettingPath);
            XMLData.Chip_Info = Helper.IniConfigHelper.ReadIniData("XML", "Chip_Info", "", SystemSettingPath);

            this.lab_Repair.Text = Helper.IniConfigHelper.ReadIniData("Parameter", "Repair", "开启", SystemSettingPath);

            SystemSetting.EnabledMCMQ = Helper.IniConfigHelper.ReadIniData("System", "EnabledMCMQ", "0", SystemSettingPath) == "1" ? true : false;

            // 停止 Stopwatch
            stopwatch.Stop();

            // 获取并显示运行时间
            TimeSpan ts = stopwatch.Elapsed;
            Console.WriteLine($"运行时间: {ts.TotalMilliseconds} 毫秒");

        }

        #endregion

        #region dgvLog

        /// <summary>
        /// 队列锁
        /// </summary>
        public QueueLock queueLock = new QueueLock();

        public void DgvAddRow(string logLevel, string text)
        {
            lock (Variable.Logs)
            {
                if (Variable.Logs.Count > 1000)
                {
                    Variable.Logs.RemoveAt(0);  //  限制行数,防止超内存
                }
                Variable.Logs.Add($"{DateTime.Now} {logLevel}: {text}\r\n");
                string Log = Variable.Logs[Variable.Logs.Count - 1];
                WriteLog(Log, Variable.CurrentDateLogPath);
            }

            if (this.dgvLog.InvokeRequired)
            {
                //跨线程访问会调用方法体的invoke属性所以在这边加判断并把快线程的的数据传进来编程本地函数内部调用
                this.dgvLog.Invoke(new Action<string, string>(DgvAddRow), logLevel, text);
            }
            else
            {
                this.dgvLog.BeginInvoke((MethodInvoker)delegate
                {
                    this.dgvLog.RowCount = Variable.Logs.Count;   //更新行数,触发CellValueNeeded事件
                    //if (!this.dgvLog.Focused)
                    this.dgvLog.FirstDisplayedScrollingRowIndex = this.dgvLog.RowCount - 1;
                    this.dgvLog.Invalidate();//刷新控件
                });
            }
        }
        private void dgvLog_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < Variable.Logs.Count)
            {
                e.Value = Variable.Logs[e.RowIndex];   // 提供日志数据给单元格
            }
        }



        #endregion

        #region ListLog

        /// <summary>
        /// 通用日志方法
        /// </summary>
        /// <param name="Level">级别012</param>
        /// <param name="Log"></param>
        public void AddLog(int Level, string Log)
        {
            if (Level > 2)
            {
                Level = 2;
            }
            if (Level < 0)
            {
                Level = 2;
            }
            if (this.list_info.InvokeRequired)
            {
                //跨线程访问会调用方法体的invoke属性所以在这边加判断并把快线程的的数据传进来编程本地函数内部调用
                //new Action<int, string>(AddLog),Level,Log 后面的参数是外部委托传进来的参数
                this.list_info.Invoke(new Action<int, string>(AddLog), Level, Log);
            }
            else
            {
                //上面的委托把跨线程访问该为内部委托调用 不用调用invoke方法从而还会跳转到else分支里面  + "  " + Log
                //没有跨线程的处理方法 此方案不需要跨线程
                string Time = Variable.CurrentTime;
                ListViewItem listViewItem = new ListViewItem("  " + Time, Level);
                listViewItem.SubItems.Add(Log);
                this.list_info.Items.Add(listViewItem);
                WriteLog(Time + "  " + Log + "\r\n", Variable.CurrentDateLogPath);
                //让最新的显示出来
                this.list_info.Items[this.list_info.Items.Count - 1].EnsureVisible();

                Func<int, Color> color = c =>
                {
                    switch (c)
                    {
                        case 0:
                            return Color.Green;
                        case 1:
                            return Color.Red;
                        case 2:
                            return Color.Red;
                        default:
                            return Color.Red;
                    }
                };
                this.list_info.Items[this.list_info.Items.Count - 1].ForeColor = color(Level);
            }
        }

        private async void WriteLog(string Log, string Path)
        {
            await Task.Run(() =>
            {
                queueLock.Enter();
                try
                {
                    using (StreamWriter sw = new StreamWriter(Path, append: true))
                    {
                        sw.Write(Log);
                    }
                }
                catch (Exception ex)
                {
                    AddLog(2, "ExecuteWriteLogError : " + ex.Message);
                }
                finally
                {
                    queueLock.Leave();
                }
            });
        }

        #endregion

        #region 绘制DatagridView行数字

        private void uiDataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridViewHelper.DgvRowPostPaint((DataGridView)sender, e);
        }

        #endregion

        #region 订阅运行状态数据读取

        /// <summary>
        /// 订阅运行状态数据读取
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="value"></param>
        private void uiSwitch__ValueChanged(object sender, bool value)
        {
            ITcpClient tcpClient = ServiceLocator.GetService<ITcpClient>();
            if (value)
            {
                tcpClient = ServiceLocator.GetService<ITcpClient>();
                tcpClient.DataReceived += TClient_DataReceived;
                tcpClient.TcpClienttConnect(SystemSetting.DeviceIP, SystemSetting.DeviceIpPort, DeviceEnums.运行状态0201, "02 00 00 00 05 52 30 32 30 31 03");
            }
            else
            {
                if (tcpClient.Tcp_Client.Connected)
                {
                    // RunTcpClient.TcpClienttConnect(SystemSetting.DeviceIP, SystemSetting.DeviceIpPort, "02 00 00 00 0b 57 31 30 30 30 30 30 31 3d 31 3b 03");
                    tcpClient.cts.Cancel();
                    tcpClient.Tcp_Client?.Close();
                    tcpClient.heartbeatTimer?.Dispose();
                }
                // Variable.DgvAddLog("连接", "Client DisConnected.");
            }
        }

        #region 数据更新事件触发控件更新
        /// <summary>
        /// 数据更新事件触发控件更新
        /// </summary>
        /// <param name="sender"></param>
        private void TClient_DataReceived()
        {
            //this.uiDataGridView_info.DataSource = null;
            //this.uiDataGridView_info.DataSource = Variable.deviceRunStatusData;
            //this.uiDataGridView_info.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //this.uiDataGridView_info.FirstDisplayedScrollingRowIndex = uiDataGridView_info.RowCount - 1;

            //foreach (DataGridViewRow row in uiDataGridView_info.Rows)
            //{
            //    DeviceRunStatusData deviceRunStatusData = (DeviceRunStatusData)row.DataBoundItem;

            //    if (deviceRunStatusData.拧紧状态 == "拧紧合格")
            //    {
            //        row.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(51, 205, 43);
            //    }
            //    else if (deviceRunStatusData.拧紧状态 == "")
            //    {
            //        continue;
            //    }
            //    else
            //    {
            //        //   拧紧不合格判断部分
            //        row.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(196, 33, 33);                    
            //    }
            //}
        }
        #endregion

        #endregion

        #region 订阅拧紧结果数据读取

        /// <summary>
        /// 订阅拧紧结果数据读取
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="value"></param>
        private void ScrewResultRead()
        {
            var tcpClient = ServiceLocator.GetService<ITcpClient>();
            tcpClient.DataReceived += TClient_ResultDatad;
            tcpClient.Complete += ResultTcpClient_Complete;
            tcpClient.TcpClienttConnect(SystemSetting.DeviceIP, SystemSetting.DeviceIpPort, DeviceEnums.最终拧紧结果0202, "02 00 00 00 05 52 30 32 30 32 03");
        }

        #endregion

        #region 返回结果订阅数据返回,数据更新事件触发控件更新

        /// <summary>
        /// 数据更新事件触发控件更新
        /// </summary>
        /// <param name="sender"></param>
        private void TClient_ResultDatad()
        {
            int Count = Variable.deviceResultReadDates.Count;

            this.Invoke(new Action(() =>
            {
                Variable.deviceResultReadDates[Count - 1].工号 = this.uiTextBox_UserID.Text;
                Variable.deviceResultReadDates[Count - 1].SN码 = this.uiTextBox_SN.Text;
                this.uiDataGridView1.DataSource = null;
                this.uiDataGridView1.DataSource = Variable.deviceResultReadDates;
                this.uiDataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                this.uiDataGridView1.FirstDisplayedScrollingRowIndex = uiDataGridView1.RowCount - 1;
                this.lab_ScrewBitsCount.Text = (int.Parse(this.lab_ScrewBitsCount.Text) + 1).ToString();
            }));

            DeviceResultReadDate Group = Variable.deviceResultReadDates[Count - 1];

            foreach (DataGridViewRow row in uiDataGridView1.Rows)
            {
                DeviceResultReadDate deviceResultReadDate = (DeviceResultReadDate)row.DataBoundItem;
                if (deviceResultReadDate.NG结果 == "拧紧合格" && deviceResultReadDate.拧紧结果状态 == "拧紧合格")
                {
                    row.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(51, 205, 43);
                }
                else
                {
                    //   返回结果不合格部分
                    row.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(196, 33, 33);
                }
            }
            if (Group.拧紧结果状态 == "拧紧不合格")
            {
                if (this.lab_Repair.Text == "关闭")
                {
                    // 重新激活job组已达到刷新螺丝顺序
                    var tcpClient = ServiceLocator.GetService<ITcpClient>();
                    tcpClient.TcpClienttConnect(SystemSetting.DeviceIP, SystemSetting.DeviceIpPort, DeviceEnums.设置激活0111, "02 00 00 00 0D 52 30 31 31 31 30 30 31 3D 32 2C 39 3B 03");

                    ResultTcpClient_Complete();
                    AddLog(2, "拧紧错误,未开启返修策略请重新输入SN码! ");
                }
                else
                {
                    AddLog(2, "拧紧错误,请重新拧紧! ");
                }

                this.Invoke(new Action(() =>
                {
                    this.lab_NG_Count.Text = (int.Parse(this.lab_NG_Count.Text) + 1).ToString();
                }));

            }
            else
            {
                AddLog(0, "" + Group.拧紧结果状态);
                this.Invoke(new Action(() =>
                {
                    this.lab_OK_Count.Text = (int.Parse(this.lab_OK_Count.Text) + 1).ToString();
                }));
            }
            this.Invoke(new Action(() =>
            {
                this.lab_Product_Count.Text = (int.Parse(this.lab_OK_Count.Text) + int.Parse(this.lab_NG_Count.Text)).ToString();
                this.lab_ScrewDownFPY.Text = Math.Round((double.Parse(this.lab_OK_Count.Text) / double.Parse(this.lab_Product_Count.Text)) * 100, 2).ToString() + "%";

                WriteProduct_Log(Group, this.uiTextBox_SN.Text, this.uiTextBox_UserID.Text);

            }));
        }

        private async void WriteProduct_Log(DeviceResultReadDate group, string SN, string UserID)
        {
            await Task.Run(() =>
            {
                queueLock.Enter();
                bool fileExists = File.Exists(ProductLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".csv");
                try
                {
                    using (StreamWriter sw = new StreamWriter(ProductLogPath + DateTime.Now.ToString("yyyy-MM-dd") + ".csv", append: true))
                    {
                        if (!fileExists)
                        {
                            sw.WriteLine("时间,操作员ID,SN,工号,执行顺序进度,最终扭矩,最终角度,监控角度,执行时间,拧紧结果状态,NG结果");
                        }
                        else
                        {
                            sw.WriteLine($"{Variable.CurrentTime},{UserID},{SN},{group.工号},[{group.执行顺序进度}],{group.最终扭矩}," +
                                $"{group.最终角度},{group.监控角度},{group.执行时间},{group.拧紧结果状态},{group.NG结果}");
                        }
                    }
                }
                catch (Exception ex)
                {
                    AddLog(2, "Execute WriteProduct_Log Error:" + ex.Message);
                }
                queueLock.Leave();
            });
        }

        #endregion

        #region 订阅实时数据

        private void RealTimeData()
        {
            ITcpClient RealTimeData = ServiceLocator.GetService<ITcpClient>();
            RealTimeData.RefreshChart += RunTcpClient_RefreshChart;
            RealTimeData.RealTimeData += RealTimeDataClient_RealTimeData;
            RealTimeData.TcpClienttConnect(SystemSetting.DeviceIP, SystemSetting.DeviceIpPort, DeviceEnums.实时曲线数据0203, "02 00 00 00 05 52 30 32 30 33 03");
        }

        private async void RealTimeDataClient_RealTimeData(TClient.RealTimeDataEventArgs obj)
        {
            await Task.Run(() =>
            {
                queueLock.Enter();
                try
                {
                    LineChart.Option.AddData("Line1", obj.Angle, obj.Nm);

                    LineChart.Refresh();
                }
                catch (Exception ex)
                {
                    Variable.ListAddLog(2, "ERROR:" + ex.Message);
                }
                finally
                {
                    queueLock.Leave();
                }
            });
        }

        #endregion

        #region 完成一组Job工作

        /// <summary> 
        /// 完成一组Job工作
        /// </summary>
        public void ResultTcpClient_Complete()
        {
            int Count = Variable.deviceResultReadDates.Count;

            DeviceResultReadDate Group = Variable.deviceResultReadDates[Count - 1];

            if (Group.拧紧结果状态 == "拧紧不合格" && this.lab_Repair.Text == "开启")
            {
                return;
            }

            if (SystemSetting.EnabledMCMQ)
            {
                XmlDataReport(Group);

                XmlPassStation();
            }

            //依赖注入
            PausORcontinue(false);

            AddLog(0, "该设备完成装配");
        }

        #region Xml数据上抛和过站


        public static string JoinXmlRunSummary()
        {
            int count = 0;

            string Result = "";

            foreach (var item in Variable.deviceResultReadDates)
            {
                count++;
                Result += $"<TORQUE_P{count}>{item.最终扭矩}</TORQUE_P{count}><ANGLE_P{count}>{item.最终角度}</ANGLE_P{count}>";
            }
            return Result;
        }

        private void XmlDataReport(DeviceResultReadDate Group)
        {
            string xmlContent = JoinXmlRunSummary();

            XmlDocument doc = new XmlDocument();
            XmlElement element = doc.CreateElement("RunSummary");
            element.InnerXml = xmlContent;

            //  上传XML数据给服务器

            XmlDataReport xmlDataReport = new XmlDataReport()
            {
                TrxName = "BUGlassTraceDataRpt",
                TypeId = "I",
                ChamberId = IsNull(XMLData.EQP_ID),   //  会议厅 ID
                EqpId = IsNull(XMLData.EQP_ID),   //  设备 ID
                EqpRunId = IsNull(XMLData.EQP_ID),   //  设备运行 ID
                GlassStartTime = ".000",   //  玻璃开始时间
                GlassEndTime = Variable.CurrentTime,   //  玻璃结束时间
                LmTime = Variable.CurrentTime,   //  LM 时间
                LogonTime = ".000",   //  登录时间
                LotId = this.uiTextBox_SN.Text.Trim(),   // SN
                ModelNo = IsNull(XMLData.Model_No),   //  模型号
                OpId = IsNull(XMLData.Line),   //  操作 线
                RecipeId = this.uiTextBox_SN.Text.Trim(),
                SheetId = this.uiTextBox_SN.Text.Trim(),
                runSummaryString = new RunSummaryString()
                {
                    ScrewResult = (Group.NG结果 != "拧紧合格") ? "NG" : "OK",
                    ScrewUnit = "Nm",
                    TimeUnit = "s"
                },
                RunSummary = element
            };

            string Xml = Helper.XmlHelper.EntityToXml(xmlDataReport);

            mcmqServer.McmqSend(SystemSetting.MCMQQueueName, SystemSetting.MCMQReplyQueueName, Xml);
        }
        /// <summary>
        /// 上抛过站
        /// </summary>
        private void XmlPassStation()
        {
            XmlStationRequest xmlStationRequest = new XmlStationRequest()
            {
                MessageId = "track_out_request",
                TypeId = "I",
                LogId = "48EF3AC4CEC744B156BC",   //  
                PanelId = this.uiTextBox_SN.Text.Trim(),   // SN
                Station = IsNull(XMLData.Station),   //  站点
                UserId = this.uiTextBox_UserID.Text.Trim(),   //  用户 ID
                Grade = "Z",
                IsScrap = "N",
                IsRepair = "N",
                FullTestFlag = "N",
                IsNgWithoutTrackout = "N",
                Result = "good",
                MlpId = IsNull(XMLData.Mlp_ID),   //  MLP ID
                JigId = IsNull(XMLData.Jig_ID),   //  JIG ID
                PortId = IsNull(XMLData.Port_ID),   //  端口 ID
                SysPara = IsNull(XMLData.Sys_Para),   //  系统参数
                PArea = IsNull(XMLData.P_Area),   //  P 区域
                Area = IsNull(XMLData.Area),   //  区域
                Line = IsNull(XMLData.Line),   //  线
                Operation = IsNull(XMLData.Operation),   //  操作
                NextOperation = IsNull(XMLData.Next_Operation),   //  下一个操作
            };

            string Xml = Helper.XmlHelper.EntityToXml(xmlStationRequest);

            mcmqServer.McmqSend(SystemSetting.MCMQQueueName, SystemSetting.MCMQReplyQueueName, Xml);

            mcmqServer.McmqReceiveStation(SystemSetting.MCMQReplyQueueName);

        }

        #endregion

        #endregion

        #region 急停与取消急停

        private void PausORcontinue(bool value)
        {
            ITcpClient StopServer = ServiceLocator.GetService<ITcpClient>();
            //3 = 急停
            //4 = 取消急停
            if (value)
            {
                StopServer.TcpClienttConnect(SystemSetting.DeviceIP, SystemSetting.DeviceIpPort, DeviceEnums.电机运行停止使能0301, "02 00 00 00 0a 57 30 33 30 31 30 30 31 3d 34 03");
            }
            else
            {
                StopServer.TcpClienttConnect(SystemSetting.DeviceIP, SystemSetting.DeviceIpPort, DeviceEnums.电机运行停止使能0301, "02 00 00 00 0a 57 30 33 30 31 30 30 31 3d 33 03");
            }
        }

        #endregion

        #region SN条码读取取消急停
        private void uiTextBoxSN_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.uiTextBox_SN.Text == "" || this.uiTextBox_SN.Text == null)
                {
                    this.ShowErrorTip("SN不能为空");
                    return;
                }
                if (Variable.UserID == "" || Variable.UserID.Length != 8)
                {
                    this.ShowErrorTip("请登录操作员ID");
                    return;
                }
                //软件开启第一次绑定
                if (ScrewDownJudge)
                {
                    RealTimeData();
                    ScrewResultRead();
                }
                //是否开启mcmq上抛
                if (!SystemSetting.EnabledMCMQ)
                {
                    Variable.deviceResultReadDates = new List<DeviceResultReadDate>();
                    Stopwatch stopwatch = new Stopwatch();
                    stopwatch.Start();
                    PausORcontinue(true);
                    stopwatch.Stop();
                    TimeSpan ts = stopwatch.Elapsed;
                    Console.WriteLine($"运行时间: {ts.TotalMilliseconds} 毫秒");   // 依赖注入的性能不怎么样    
                }
                else
                {
                    //  上传SN码到服务器
                    XmlSnValidationRequest SnUpthorw = new XmlSnValidationRequest()
                    {
                        MessageId = "validate_lot",
                        Version = "1.6.7",
                        Function = IsNull(XMLData.Function),
                        UserId = this.uiTextBox_UserID.Text.Trim(),
                        SysPara = IsNull(XMLData.Sys_Para),
                        PArea = IsNull(XMLData.P_Area),
                        Area = IsNull(XMLData.Area),
                        Line = IsNull(XMLData.Line),
                        Operation = IsNull(XMLData.Operation),
                        LotNo = this.uiTextBox_SN.Text.Trim()
                    };

                    string Xml = XmlHelper.EntityToXml(SnUpthorw);

                    mcmqServer.McmqSend(SystemSetting.MCMQQueueName, SystemSetting.MCMQReplyQueueName, Xml);

                    mcmqServer.McmqReceiveVerifySN(SystemSetting.MCMQReplyQueueName);
                }
                ScrewDownJudge = false;
            }
        }
        private void McmqServer_McmqReceiveEvent(string obj)
        {
            var result = XmlHelper.XmlToEntity<XmlSnValidationResult>(obj);

            if (!(result.Result == "valid"))
            {
                AddLog(0, "远程校验SN成功");
                //mcmqServer.McmqReceiveVerifySN(SystemSetting.MCMQQueueName);
                if (ScrewDownJudge)
                {
                    RealTimeData();

                    ScrewResultRead();
                }

                Variable.deviceResultReadDates = new List<DeviceResultReadDate>();

                PausORcontinue(false);
                ScrewDownJudge = false;
            }
            else
            {
                AddLog(2, "SN码校验失败,请重新输入!");
            }
        }

        public string IsNull(string Data)
        {
            return string.IsNullOrEmpty(Data) ? " " : Data;
        }

        #endregion

        #region 系统设置窗体

        private void uiHeaderButton_Setting_Click(object sender, EventArgs e)
        {
            if (Login)
            {
                FrmCommunicateConfig frmCommunicateConfig = new FrmCommunicateConfig(SystemSettingPath, mcmqServer);
                frmCommunicateConfig.ShowDialog();
            }
            else
            {
                this.ShowErrorTip("请登录!");
            }
        }

        #endregion

        #region 历史数据读取


        private void uiHeaderButton_HistoryData_Click(object sender, EventArgs e)
        {
            FrmHistory frmHistory = new FrmHistory();
            frmHistory.ShowDialog();
        }

        #endregion

        #region 用户登录

        public bool Login = false;

        private void uiHeaderButton_User_Click(object sender, EventArgs e)
        {
            FrmLogin frmLogin = new FrmLogin();
            frmLogin.ShowDialog();
            if (frmLogin.DialogResult == DialogResult.OK)
            {
                Login = true;
            }
            else
            {
                Login = false;
            }
        }

        #endregion

        #region 用户密码修改

        private void uiHeaderButton_ModifyPwd_Click(object sender, EventArgs e)
        {
            FrmChangePassword frmChangePassword = new FrmChangePassword(SystemSettingPath);
            frmChangePassword.ShowDialog();
        }

        #endregion

        #region 编辑

        private void uiHeaderButton_Menu_Click(object sender, EventArgs e)
        {
            //XMLData XmlData = new XMLData() { deviceResultReadDate = Variable.deviceResultReadDates};
            //_ = XML.SendToServer(XmlData, "127.0.0.1:21");

            FrmParamentRecipe frmParamentRecipe;

            if (Login)
            {

                frmParamentRecipe = new FrmParamentRecipe();
                frmParamentRecipe.ShowDialog();
            }
            else
            {
                this.ShowErrorTip("请登录!");
                return;
            }

            if (frmParamentRecipe.DialogResult == DialogResult.OK)
            {
                var Parameter = Variable.deviceRecipeInfo.RecipeParameters;
                this.lab_PsetName.Text = Variable.deviceRecipeInfo.RecipeName;
                this.lab_Nm.Text = Parameter.Nm;
                this.lab_Angle.Text = Parameter.RotitionDirection;
                this.lab_AngleDownLimit.Text = Parameter.AngleLowerLimit;
                this.lab_AngleUpperLimit.Text = Parameter.AngleUpperLimit;
                this.lab_NmDownLimit.Text = Parameter.NmLowerLimit;
                this.lab_NmUpperLimit.Text = Parameter.NmUpperLimit;
                this.lab_Rotate_Speed.Text = Parameter.Rotate_Speed.ToString();
                lab_Rotation_Angle.Text = "null";
                this.lab_Repair.Text = Parameter.Repair;
                this.lab_ScrewCount.Text = Parameter.ScrewDownCount.ToString();

                IniConfigHelper.WriteIniData("Parameter", "Pset", Variable.deviceRecipeInfo.RecipeName, SystemSettingPath);
                IniConfigHelper.WriteIniData("Parameter", "Nm", Parameter.Nm, SystemSettingPath);
                IniConfigHelper.WriteIniData("Parameter", "Angle", Parameter.RotitionDirection, SystemSettingPath);
                IniConfigHelper.WriteIniData("Parameter", "AngleDownLimit", Parameter.AngleLowerLimit, SystemSettingPath);
                IniConfigHelper.WriteIniData("Parameter", "AngleUpperLimit", Parameter.AngleUpperLimit, SystemSettingPath);
                IniConfigHelper.WriteIniData("Parameter", "NmDownLimit", Parameter.NmLowerLimit, SystemSettingPath);
                IniConfigHelper.WriteIniData("Parameter", "NmUpperLimit", Parameter.NmUpperLimit, SystemSettingPath);
                IniConfigHelper.WriteIniData("Parameter", "Rotate_Speed", Parameter.Rotate_Speed.ToString(), SystemSettingPath);

                IniConfigHelper.WriteIniData("Parameter", "Repair", Parameter.Repair, SystemSettingPath);

                IniConfigHelper.WriteIniData("Parameter", "ScrewCount", Parameter.ScrewDownCount.ToString(), SystemSettingPath);
            }

        }

        #endregion

        #region 初始化曲线图

        private void RunTcpClient_RefreshChart()
        {
            InitialChart();
        }

        private void InitialChart()
        {
            LineChart.Option.Clear();
            LineChart.DoubleBuffered();
            UILineOption option = new UILineOption();
            option.Title = new UITitle();
            option.Title.Text = "螺丝机";
            option.XAxis.Name = "角度(°)";
            option.YAxis.Name = "扭矩(Nm)";
            option.ToolTip.Visible = true;
            UIChartGrid uIChartGrid = new UIChartGrid();
            uIChartGrid.Right = 10;
            uIChartGrid.Left = 70;
            uIChartGrid.Top = 40;
            option.Grid = uIChartGrid;
            var series = option.AddSeries(new UILineSeries("Line1"));

            //设置曲线显示最大点数，超过后自动清理
            series.SetMaxCount(2500);

            //坐标轴显示小数位数
            option.XAxis.AxisLabel.DecimalPlaces = 2;
            option.YAxis.AxisLabel.DecimalPlaces = 4;
            LineChart.SetOption(option);
        }

        #endregion

        #region 参数刷新

        private void uiHeaderButton1_Click(object sender, EventArgs e)
        {

            if (Login)
            {
                FrmTest frmTest = new FrmTest();
                frmTest.ShowDialog();
            }
            else
            {
                this.ShowErrorTip("请登录!");
                return;
            }

            Stopwatch stopwatch = Stopwatch.StartNew();

            // 停止 Stopwatch
            stopwatch.Stop();

            // 获取并显示运行时间
            TimeSpan ts = stopwatch.Elapsed;
            Console.WriteLine($"运行时间: {ts.TotalMilliseconds} 毫秒");

        }

        private void Client_DataReceived(object sender)
        {
            this.lab_Nm.Text = Variable.deviceParameters.Nm;
            this.lab_Angle.Text = RotationDirection(Variable.deviceParameters.Angle);

            this.lab_AngleDownLimit.Text = Variable.deviceParameters.AngleDownLimit;
            this.lab_AngleUpperLimit.Text = Variable.deviceParameters.AngleUpperLimit;
            this.lab_NmDownLimit.Text = Variable.deviceParameters.NmDownLimit;
            this.lab_NmUpperLimit.Text = Variable.deviceParameters.NmUpperLimit;
            this.lab_Rotate_Speed.Text = Variable.deviceParameters.Rotate_Speed;
            this.lab_PsetName.Text = Variable.deviceParameters.PsetName;
            lab_Rotation_Angle.Text = Variable.deviceParameters.Rotation_Angle + "°";

            Helper.IniConfigHelper.WriteIniData("Parameter", "Pset", Variable.deviceParameters.PsetName, SystemSettingPath);
            Helper.IniConfigHelper.WriteIniData("Parameter", "Nm", Variable.deviceParameters.Nm, SystemSettingPath);
            Helper.IniConfigHelper.WriteIniData("Parameter", "Angle", Variable.deviceParameters.Angle, SystemSettingPath);
            Helper.IniConfigHelper.WriteIniData("Parameter", "AngleDownLimit", Variable.deviceParameters.AngleDownLimit, SystemSettingPath);
            Helper.IniConfigHelper.WriteIniData("Parameter", "AngleUpperLimit", Variable.deviceParameters.AngleUpperLimit, SystemSettingPath);
            Helper.IniConfigHelper.WriteIniData("Parameter", "NmDownLimit", Variable.deviceParameters.NmDownLimit, SystemSettingPath);
            Helper.IniConfigHelper.WriteIniData("Parameter", "NmUpperLimit", Variable.deviceParameters.NmUpperLimit, SystemSettingPath);
            Helper.IniConfigHelper.WriteIniData("Parameter", "Rotate_Speed", Variable.deviceParameters.Rotate_Speed, SystemSettingPath);

            try
            {
                //PsetReadClient.Tcp_Client.Close();
            }
            catch (Exception ex)
            {
                AddLog(2, "Execute Client_DataReceived:" + ex.Message);
            }
        }

        public string RotationDirection(string Direction)
        {
            switch (Direction)
            {
                case "0":
                    return "正转";
                case "1":
                    return "反转";
                default:
                    return null;
            }
        }

        #endregion

        #region User登录

        private void but_UserLogin_Click(object sender, EventArgs e)
        {
            FrmUserLogin frmUserLogin = new FrmUserLogin();
            frmUserLogin.ShowDialog();
            if (frmUserLogin.DialogResult == DialogResult.OK)
            {
                this.uiTextBox_UserID.Text = Variable.UserID;
                AddLog(0, $"操作员:{Variable.UserID} 登录成功 ");
            }
        }

        #endregion

        #region 刷新批头次数

        private void but_ReplaceScrewBits_Click(object sender, EventArgs e)
        {
            if (Login)
            {
                if (this.ShowAskDialog("确认刷新批头"))
                {
                    this.lab_ScrewBitsCount.Text = "0";
                    Helper.IniConfigHelper.WriteIniData("Parameter", "ScrewBitsCount", "0", SystemSettingPath);
                }
            }
            else
            {
                this.ShowErrorTip("请登录!");
            }
        }

        #endregion

    }
}
