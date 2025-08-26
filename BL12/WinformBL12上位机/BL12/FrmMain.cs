using CurrentVariable;
using MCMQ;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Dynamic;
using System.IO;
using System.IO.Ports;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.InteropServices.ComTypes;
using Communication;
using BL12.Model;
using XmlUpper;
using XmlCollection;
using System.Linq;
using System.Text.RegularExpressions;
using System.Diagnostics;
namespace BL12
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
            InitializeParameter();
            InitializeDependencyInjection();
            //cell单元格   Column列
            this.dataGridView_LEDx.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 255, 255); // 这里设置为蓝色
            this.dataGridView_CHDV.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(255, 170, 0); // 这里设置为橙色
            this.dataGridView_NTC.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(85, 170, 127); // 这里设置为绿色
            this.dataGridView_LEDx.EnableHeadersVisualStyles = false; // 确保自定义样式被应用而不是用户的操作系统主题样式
            this.dataGridView_CHDV.EnableHeadersVisualStyles = false;
            this.dataGridView_NTC.EnableHeadersVisualStyles = false;
            this.dataGridView_LEDx.ScrollBars = ScrollBars.None;
            this.dataGridView_CHDV.ScrollBars = ScrollBars.None;
            this.dataGridView_NTC.ScrollBars = ScrollBars.None;
            this.DoubleBuffered = true;
            storeTimer.Interval = 500;
            storeTimer.AutoReset = true;
            storeTimer.Elapsed += StoreTimer_Elapsed;
            storeTimer.Start();
            this.FormClosing += FrmMain_FormClosing;
        }

        private void StoreTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            this.Invoke(new Action(() =>
            {
                try
                {
                    lbl_Time.Text = DateTime.Now.ToString("D") + DateTime.Now.ToString("t");
                    if (monitorServer.CurrentClientlist.Count > 0)
                    {
                        this.Jince.Text = "     精测机已连接";
                        this.Jince.ForeColor = Color.Green;
                    }
                    else
                    {
                        this.Jince.Text = "     精测机未连接";
                        this.Jince.ForeColor = Color.Red;
                    }
                    SetNCT();
                    SetLEDx();
                    SetDVStatu();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }
            }));

        }

        #region 属性参数

        /// <summary>
        /// 计算机名称
        /// </summary>
        public string computerName { get; set; } = Environment.MachineName;

        public McmqServer mcmqServer { get; set; }

        public IMonitorServer monitorServer { get; set; }

        public System.Timers.Timer storeTimer { get; set; } = new System.Timers.Timer();

        public bool IsUnlock { get; set; } = false;

        public bool Is_Auto { get; set; } = false;

        public QueueLock queueLock { get; set; } = new QueueLock();

        /// <summary>
        /// 全局变量初始化
        /// </summary>
        public Variable variable { get; set; } = new Variable();

        public string TempResistancePath = Application.StartupPath + "\\TempResistance\\";

        /// <summary>
        /// 获取log日志路径地址
        /// </summary>
        private string LogFilePath
        {
            get
            {
                return Application.StartupPath + "\\Log\\" + DateTime.Now.ToString("yyyy-MM").Replace("年", "-").Replace("月", "-").Replace("日", " ");
            }
        }

        /// <summary>
        /// 获取当前日期所组成的csv名称
        /// </summary>
        private string CurrentVariableCSV
        {
            get
            {
                return Application.StartupPath + "\\Log\\" + DateTime.Now.ToString("yyyy-MM").Replace("年", "-").Replace("月", "-").Replace("日", " ") +
            "//" + DateTime.Now.ToString("m").Replace("年", "-").Replace("月", "-").Replace("日", " ") + ".csv";
            }
        }

        /// <summary>
        /// 获取当前时间
        /// </summary>
        public string CurrentTimer
        {
            get { return DateTime.Now.ToString("D").Replace("年", "-").Replace("月", "-").Replace("日", " ") + DateTime.Now.ToString("t"); }
        }

        /// <summary>
        /// 配置文件路径
        /// </summary>
        public string filePath { get; set; } = null;


        private bool OpenTheilluminant;
        /// <summary>
        /// 是否开启光源
        /// </summary>
        public bool openTheilluminant
        {
            get { return OpenTheilluminant; }
            set
            {
                OpenTheilluminant = value;
                if (openTheilluminant)
                {
                    this.but_Open_optical_source.Text = "关闭读取";
                }
                else
                {
                    if (this.but_Open_optical_source.InvokeRequired)
                    {
                        this.but_Open_optical_source.Invoke(new Action(() =>
                        {
                            this.but_Open_optical_source.Text = "读取参数";
                        }));
                    }
                    else
                    {
                        this.but_Open_optical_source.Text = "读取参数";
                    }
                }
            }
        }

        /// <summary>
        /// 线程令牌
        /// </summary>
        public CancellationToken Token { get; set; } = new CancellationToken();

        public string Model_NoPath { get; private set; }

        #endregion

        #region 初始化加载参数
        /// <summary>
        /// 加载电脑串口名
        /// </summary>
        private void InitializeParameter()
        {
            GlobalVariable.McmqSetting.McmqIp = IniConfigHelper.ReadIniData("MCMQ", "IP", "");
            GlobalVariable.McmqSetting.McmqPort = IniConfigHelper.ReadIniData("MCMQ", "Port", "");
            GlobalVariable.McmqSetting.McmqQueue = IniConfigHelper.ReadIniData("MCMQ", "Queue", "");
            GlobalVariable.McmqSetting.McmqReplyQueue = IniConfigHelper.ReadIniData("MCMQ", "ReplyQueue", "");

            GlobalVariable.PassWord = IniConfigHelper.ReadIniData("System", "PassWord", "");

            this.check_NTC1Enable.Checked = IniConfigHelper.ReadIniData("System", "NTC1Enable", "") == "1" ? true : false;
            this.check_NTC2Enable.Checked = IniConfigHelper.ReadIniData("System", "NTC2Enable", "") == "1" ? true : false;

            this.cmb_Port.Text = IniConfigHelper.ReadIniData("System", "COM", "");
            this.check_MCMQ.Checked = IniConfigHelper.ReadIniData("System", "McmqStatus", "") == "1" ? true : false;

            GlobalVariable.Model_No = IniConfigHelper.ReadIniData("System", "Model_No", "");

            GlobalVariable.XmlData.Part_No = IniConfigHelper.ReadIniData("XML", "Part_No", "");
            GlobalVariable.XmlData.Port_ID = IniConfigHelper.ReadIniData("XML", "Port_ID", "");
            GlobalVariable.XmlData.Operation = IniConfigHelper.ReadIniData("XML", "Operation", "");
            GlobalVariable.XmlData.P_Area = IniConfigHelper.ReadIniData("XML", "P_Area", "");
            GlobalVariable.XmlData.Line = IniConfigHelper.ReadIniData("XML", "Line", "");
            GlobalVariable.XmlData.Eqp_ID = IniConfigHelper.ReadIniData("XML", "Eqp_ID", "");
            GlobalVariable.XmlData.Jog_ID = IniConfigHelper.ReadIniData("XML", "Jog_ID", "");

            GlobalVariable.CheckTime.DayShift = IniConfigHelper.ReadIniData("CheckTime", "DayShift", "");
            GlobalVariable.CheckTime.NightShift = IniConfigHelper.ReadIniData("CheckTime", "NightShift", "");

            this.num_NtcLower.Value = decimal.Parse(IniConfigHelper.ReadIniData("NTC", "NtcLower", ""));
            this.num_NtcUpper.Value = decimal.Parse(IniConfigHelper.ReadIniData("NTC", "NtcUpper", ""));

            GlobalVariable.Jince.JinceIP = IniConfigHelper.ReadIniData("Jince", "JinceIP", "");
            GlobalVariable.Jince.JincePort = IniConfigHelper.ReadIniData("Jince", "JincePort", "");

            AddLog(0, "*******配置参数加载成功*******");
            but_Connect_Click(null, null);
            //test
            string a = StaticMethod.WriteRuqire_ResultData(Common_Read.LED_GetModel);
            LoadResistSpec(GlobalVariable.Model_No);
            this.cmb_Model_No.Text = GlobalVariable.Model_No;
            GlobalVariable.AddLog = AddLog;
        }

        private void LoadResistSpec(string ModelNo)
        {
            Model_NoPath = Application.StartupPath + "\\ResistSpec\\" + ModelNo;

            if (!File.Exists(Model_NoPath))
            {
                this.cmb_Model_No.Text = "";
                AddLog(2, $"没有找到对应的名称配置参数,请检查是否存在{ModelNo}配置参数");
                return;
            }
            List<string> TempParam = IniConfigHelper.ReadKeys("ResistSpec", Model_NoPath);
            List<double> Lower = new List<double>();
            List<double> Upper = new List<double>();
            if (TempParam != null && TempParam.Count > 0)
            {
                List<string> TypicalParam = TempParam.Where(x => x.Contains("Typical")).ToList();
                List<string> LSL = TempParam.Where(x => x.Contains("LSL")).ToList();
                List<string> USL = TempParam.Where(x => x.Contains("USL")).ToList();

                GlobalVariable.ResistSpec.Clear();
                foreach (string lsl in LSL)
                {
                    Lower.Add(double.Parse(IniConfigHelper.ReadIniData("ResistSpec", lsl, "", Model_NoPath)));
                }
                GlobalVariable.ResistLower = Lower.Min(x => x);
                foreach (string usl in USL)
                {
                    Upper.Add(double.Parse(IniConfigHelper.ReadIniData("ResistSpec", usl, "", Model_NoPath)));
                }
                GlobalVariable.ResistUpper = Upper.Max(x => x);
                foreach (string key in TypicalParam)
                {
                    GlobalVariable.ResistSpec[DataExtract.ExtractNumber(key)] = double.Parse(IniConfigHelper.ReadIniData("ResistSpec", key, "", Model_NoPath));
                }
                AddLog(0, $"加载{ModelNo}型号阻值温度配置文件成功");
                this.cmb_Model_No.Text = ModelNo;
            }
            else
            {
                this.cmb_Model_No.Text = "";
                AddLog(2, $"没有找到对应的名称配置参数,请检查是否存在{ModelNo}配置参数");
            }

        }

        private void InitializeDependencyInjection()
        {
            ServiceCollection service = new ServiceCollection();
            service.AddTransient<IMonitorServer, MonitorServer>();
            service.AddTransient<IMcmq, Mcmq>();
            // 构建服务提供者
            var serviceProvider = service.BuildServiceProvider();
            ServiceLocator.Init(serviceProvider);
            mcmqServer = new McmqServer(ServiceLocator.GetService<IMcmq>(), AddLog);
            monitorServer = ServiceLocator.GetService<IMonitorServer>();
            monitorServer.OpenServer(GlobalVariable.Jince.JinceIP, GlobalVariable.Jince.JincePort, AddLog);
            monitorServer.GetRequestDataHandle += MonitorServer_GetRequestDataHandle;
        }

        private void MonitorServer_GetRequestDataHandle(string obj)
        {
            this.Invoke(new Action(() =>
            {
                Request request = XmlHelper.XmlToEntity<Request>(obj);
                if (request.Command == "SET_LOT_NO")
                {
                    this.text_SN.Text = request.Param1;
                    GlobalVariable.XmlData.Part_No = request.Param2;  //零件编号
                    GlobalVariable.XmlData.Operation = request.Param3;
                    this.text_Config_name.Text = request.Param4;     // 型号
                    if (request.Param4 + "\r\n" != StaticMethod.WriteRuqire_ResultData(Common_Read.LED_GetModel))
                    {
                        Response response = new Response()
                        {
                            Result = "OK"
                        };
                        monitorServer.SenderClient(XmlHelper.EntityToXml(response));
                        WriteConfigToBL12(request.Param4);
                        if (text_MODEL.Text != request.Param4)
                        {
                            AddLog(2, "BL板参数未写入,请检查");
                            MessageBox.Show("BL板参数未写入,请检查");
                        }
                        if (this.text_Result.Text == "NG")
                        {
                            AddLog(2, "配置参数写入失败,请检查");
                            MessageBox.Show("配置参数写入失败,请检查");
                        }
                    }
                    if (request.Param4 != this.cmb_Model_No.Text.Replace(".ini", ""))
                    {
                        LoadResistSpec(request.Param4 + ".ini");
                    }
                }
                else if (request.Command == "BL12")
                {
                    Is_Auto = true;
                    GlobalVariable.NtcUpper = double.Parse(this.num_NtcUpper.Text);
                    GlobalVariable.NtcLower = double.Parse(this.num_NtcLower.Text);

                    #region Judge
                    if (GlobalVariable.CheckTime.DayShift.Length < 1 || GlobalVariable.CheckTime.NightShift.Length < 1)
                    {
                        AddLog(2, "班次时间不能为空");
                        return;
                    }
                    if (this.cmb_Port.Enabled)
                    {
                        AddLog(2, "请选择连接串口连接");
                        return;
                    }
                    if (string.IsNullOrEmpty(this.cmb_Model_No.Text))
                    {
                        AddLog(2, "请选择温度阻值配置参数!");
                        return;
                    }
                    if (string.IsNullOrEmpty(this.cmb_Model_No.Text))
                    {
                        AddLog(2, "请选择温度阻值配置参数!");
                        return;
                    }
                    #endregion

                    this.but_SpotCheck.Enabled = true;
                    ReadNtc();
                }
            }));
        }

        #endregion

        #region 串窗口加载和窗口关闭事件触发
        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (StaticMethod._SerialPort != null && StaticMethod._SerialPort.IsOpen)
            {
                StaticMethod.WriteRuqire_ResultData(Common_Read.LED_OFF);
            }
            cts.Cancel();
            //thread.Abort();
        }

        public Thread thread;

        private CancellationTokenSource cts { get; set; } = new CancellationTokenSource();

        private void FrmMain_Load(object sender, EventArgs e)
        {
            //加载实例对象
            StaticMethod.variable = variable;

            Task.Run(() =>
            {
                DataDirdViewUpDate();
            }, cts.Token);
            //thread.IsBackground = true;
            //thread.Start();
        }
        #endregion

        #region 关闭窗口执行

        private void FrmMain_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            if (this.check_MCMQ.Checked)
            {
                mcmqServer.McmqClose();
            }
            IniConfigHelper.WriteIniData("NTC", "NtcUpper", this.num_NtcUpper.Value.ToString());
            IniConfigHelper.WriteIniData("NTC", "NtcLower", this.num_NtcLower.Value.ToString());
            IniConfigHelper.WriteIniData("System", "McmqStatus", this.check_MCMQ.Checked ? "1" : "0");
            IniConfigHelper.WriteIniData("System", "NTC1Enable", this.check_NTC1Enable.Checked ? "1" : "0");
            IniConfigHelper.WriteIniData("System", "NTC2Enable", this.check_NTC2Enable.Checked ? "1" : "0");

            IniConfigHelper.WriteIniData("System", "Model_No", this.cmb_Model_No.Text);

            IniConfigHelper.WriteIniData("XML", "Part_No", GlobalVariable.XmlData.Part_No);
            IniConfigHelper.WriteIniData("XML", "Port_ID", GlobalVariable.XmlData.Port_ID);
            IniConfigHelper.WriteIniData("XML", "Operation", GlobalVariable.XmlData.Operation);
            IniConfigHelper.WriteIniData("XML", "P_Area", GlobalVariable.XmlData.P_Area);
            IniConfigHelper.WriteIniData("XML", "Line", GlobalVariable.XmlData.Line);
            IniConfigHelper.WriteIniData("XML", "Eqp_ID", GlobalVariable.XmlData.Eqp_ID);
            IniConfigHelper.WriteIniData("XML", "Jog_ID", GlobalVariable.XmlData.Jog_ID);

            monitorServer.CloseServer();
        }

        #endregion

        #region 串口连接按钮

        /// <summary>
        /// 串口连接按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void but_Connect_Click(object sender, EventArgs e)
        {
            if (StaticMethod._SerialPort != null && StaticMethod._SerialPort.IsOpen)
            {
                StaticMethod.disconncet();
                this.cmb_Port.Enabled = true;
                this.but_Selcet_config.Enabled = false;
                this.but_Connect.Text = "连接";
                but_Open_optical_source.Enabled = false;
                AddLog(0, $"断开{this.cmb_Port.Text}成功");
                return;
            }
            bool result = StaticMethod.conncet(this.cmb_Port.Text);
            if (result)
            {
                AddLog(0, $"连接{this.cmb_Port.Text}成功");
                IniConfigHelper.WriteIniData("System", "COM", this.cmb_Port.Text);
                this.cmb_Port.Enabled = false;
                this.but_Selcet_config.Enabled = true;
                this.but_Connect.Text = "断开连接";
                but_Open_optical_source.Enabled = true;
            }
            else
            {
                MessageBox.Show($"连接{this.cmb_Port.Text}失败");
            }
        }

        #endregion

        #region DataDirdView实时刷新
        /// <summary>
        /// 刷新控件参数
        /// </summary>
        private void DataDirdViewUpDate()
        {
            while (true)
            {
                Thread.Sleep(500);
                SetNCT();
                SetLEDx();
                SetDVStatu();
            }
        }

        #region 实时设置datagridview
        private void SetNCT()
        {
            var NctVariable = StaticMethod.variable.ntcVariables;

            if (NctVariable.Count > 0)
            {
                if (this.dataGridView_NTC.InvokeRequired)
                {
                    this.dataGridView_NTC.Invoke(new Action(() =>
                    {
                        //dataGridView_NTC.Rows.Clear();
                        for (int i = 0; i < NctVariable.Count; i++)
                        {
                            dataGridView_NTC.Rows.Add();
                            dataGridView_NTC.Rows[i].Cells[0].Value = NctVariable[i].NTC_Name;
                            dataGridView_NTC.Rows[i].Cells[1].Value = NctVariable[i].NTC_Temp;
                            dataGridView_NTC.Rows[i].Cells[2].Value = NctVariable[i].NTC_Resist;
                        }

                        this.dataGridView_NTC.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    }));
                }
                else
                {
                    this.dataGridView_NTC.DataSource = null;
                    this.dataGridView_NTC.DataSource = NctVariable;
                }
            }
        }

        private void SetDVStatu()
        {
            //StaticMethod.variable.statuVariables;dataGridView1.
            //Columns[0].HeaderText = "新标题"; // 设置第一列的标题
            // dataGridView1.Columns[0].Width = 100; // 设置第一列的宽度

            var StateAndDV = StaticMethod.variable.statuVariables;

            if (StateAndDV.Count > 0)
            {

                if (this.dataGridView_CHDV.InvokeRequired)
                {
                    this.dataGridView_CHDV.Invoke(new Action(() =>
                    {
                        //dataGridView_CHDV.Rows.Clear();

                        dataGridView_CHDV.Rows.Add();
                        dataGridView_CHDV.Rows[0].Cells[0].Value = StateAndDV[0].LED_channel_Number;
                        dataGridView_CHDV.Rows[0].Cells[1].Value = StateAndDV[0].LED_DV;
                        dataGridView_CHDV.Rows[0].Cells[2].Value = StateAndDV[0].LED_State;
                    }));
                }
            }
        }

        private void SetLEDx()
        {
            var LedxVariable = StaticMethod.variable.LedxVariable;

            if (LedxVariable.Count > 0)
            {
                if (this.dataGridView_LEDx.InvokeRequired)
                {
                    this.dataGridView_LEDx.Invoke(new Action(() =>
                    {

                        dataGridView_LEDx.DataSource = null;
                        dataGridView_LEDx.DataSource = LedxVariable;
                        //for (int i = 0; i < LedxVariable.Count; i++)
                        //{
                        //    dataGridView_LEDx.Rows.Add();
                        //    dataGridView_LEDx.Rows[i].Cells[0].Value = LedxVariable[i].LED_Name;
                        //    dataGridView_LEDx.Rows[i].Cells[1].Value = LedxVariable[i].VF;
                        //    dataGridView_LEDx.Rows[i].Cells[2].Value = LedxVariable[i].Ima;
                        //}

                        this.dataGridView_NTC.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    }));
                }
                else
                {
                    this.dataGridView_LEDx.DataSource = null;
                    this.dataGridView_LEDx.DataSource = LedxVariable;
                }
            }

        }

        #endregion


        #endregion

        #region 开启背光按钮主体

        private void but_Open_Click(object sender, EventArgs e)
        {
            if (this.cmb_Port.Enabled)
            {
                AddLog(2, "请选择连接串口连接");
                return;
            }
            if (this.text_SN.Text.Length < 1)
            {
                AddLog(2, "请输入SN码信息");
                return;
            }
            if (this.text_Result.Text == "NG")
            {
                AddLog(2, "配置参数写入失败,请重新写入!");
                return;
            }
            openTheilluminant = !OpenTheilluminant;
            if (OpenTheilluminant)
            {
                AddLog(0, "读取背光参数中");
            }
            else
            {
                AddLog(0, "关闭读取背光参数");
                return;
            }
            Task.Run(() =>
            {
                while (openTheilluminant)
                {
                    ReadVariable();
                }
            });
            Task.Run(new Action(() =>
            {
                while (openTheilluminant)
                {
                    Thread.Sleep(500);
                    string[] NTC_RealTime = StaticMethod.General_Split_Result(StaticMethod.WriteRuqire_ResultData("LED_GetNTC_R\r\n"));
                    if (NTC_RealTime.Length > 0)
                    {
                        StaticMethod.variable.ntcVariables[0].NTC_Temp = ConvertToTemp(NTC_RealTime[1]);
                        StaticMethod.variable.ntcVariables[1].NTC_Temp = ConvertToTemp(NTC_RealTime[2]);
                        StaticMethod.variable.ntcVariables[0].NTC_Resist = NTC_RealTime[1] == "999.99" ? "未连接NTC" : NTC_RealTime[1];
                        StaticMethod.variable.ntcVariables[1].NTC_Resist = NTC_RealTime[2] == "999.99" ? "未连接NTC" : NTC_RealTime[2];
                    }
                }
            }));
        }

        #endregion

        #region 读取数据
        private int count { get; set; } = 0;
        private void ReadVariable()
        {
            string status = null;
            while (!(status = StaticMethod.WriteRuqire_ResultData(Common_Read.LED_Read_Status)).Contains("OK") || status == null) { count = 0; Thread.Sleep(500); }

            List<string> Read_result = new List<string>();

            string[] list = null;

            //       实时读取数据
            foreach (var items in Common_Read.common_Read_collection)
            {
                Read_result.Add(StaticMethod.WriteRuqire_ResultData(items));
            }
            //  判断读取的返回值是否为
            if (Read_result.Count != 7)
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(() =>
                    {
                        MessageBox.Show("设备参数读取失败");
                        AddLog(2, "设备参数读取失败");
                        openTheilluminant = false;
                    }));
                }
                return;
            }


            foreach (var item in Read_result)
            {

                try
                {
                    //if (item == null)
                    //{
                    //    openTheilluminant = false;
                    //    if (this.InvokeRequired)
                    //    {
                    //        this.Invoke(new Action(() =>
                    //        {
                    //            MessageBox.Show("Error");
                    //            AddLog(2, "设备读取失败");
                    //            StaticMethod.WriteRuqire_ResultData(Common_Read.LED_OFF);
                    //        }));
                    //    }
                    //    return;
                    //}
                    list = StaticMethod.General_Split_Result(item);
                }
                catch (Exception)
                {
                    return;
                }
                try
                {
                    //判断读取的数据进行分类存储
                    switch (list[0])
                    {
                        case "LED_GetNTC_R":
                            //StaticMethod.variable.ntcVariables[0].NTC_Now = ConvertToTemp(list[1].Replace(",", "").Replace("L", ""));
                            //StaticMethod.variable.ntcVariables[1].NTC_Now = ConvertToTemp(list[2].Replace(",", "").Replace("L", ""));
                            break;
                        case "LED_GetLEDV:A":
                            if (list.Length != 26)
                            {
                                return;
                            }
                            for (int i = 14; i < 26; i++)
                            {
                                StaticMethod.variable.LedxVariable[i - 14].VF = list[i].Replace(",", "");
                            }
                            break;
                        case "LED_GetLEDI":
                            for (int i = 1; i < 13; i++)
                            {
                                StaticMethod.variable.LedxVariable[i - 1].Ima = list[i].Replace(",", "");
                            }
                            break;
                        case "LED_GetDVal":
                            StaticMethod.variable.statuVariables[0].LED_DV = list[1].Replace(",", "");
                            break;
                        case "LED_Get_ChNum":
                            StaticMethod.variable.statuVariables[0].LED_channel_Number = list[1].Replace(",", "");
                            break;
                        case "LED_GetAlarmState":
                            if (list[1].Contains("0"))
                            {
                                StaticMethod.variable.statuVariables[0].LED_State = "正常";
                                count++;
                                if (count == 10)
                                {
                                    AddLog(0, "点亮背光参数已储存");
                                    Create_LogFile();
                                }
                            }
                            break;
                        case "LED_Alarm":
                            if (list[1].Contains("-1"))
                            {
                                AddLog(2, "背光串数异常");
                                StaticMethod.variable.statuVariables[0].LED_State = "背光串数异常";
                                StaticMethod.WriteRuqire_ResultData(Common_Read.LED_OFF);
                                Create_LogFile();
                                if (this.InvokeRequired)
                                {
                                    this.Invoke(new Action(() =>
                                    {
                                        MessageBox.Show("背光串数异常");
                                    }));
                                }
                                openTheilluminant = false;
                                return;
                            }
                            if (list[1].Contains("-2"))
                            {
                                AddLog(2, "背光灯珠短路异常");
                                StaticMethod.variable.statuVariables[0].LED_State = "背光灯珠短路异常";
                                StaticMethod.WriteRuqire_ResultData(Common_Read.LED_OFF);
                                Create_LogFile();
                                if (this.InvokeRequired)
                                {
                                    this.Invoke(new Action(() =>
                                    {
                                        MessageBox.Show("背光灯珠短路异常");
                                    }));
                                }
                                openTheilluminant = false;
                                return;
                            }
                            if (list[1].Contains("-3"))
                            {
                                AddLog(2, "未检测到背光异常");
                                StaticMethod.variable.statuVariables[0].LED_State = "未检测到背光异常";
                                StaticMethod.WriteRuqire_ResultData(Common_Read.LED_OFF);
                                Create_LogFile();
                                if (this.InvokeRequired)
                                {
                                    this.Invoke(new Action(() =>
                                    {
                                        MessageBox.Show("未检测到背光异常");
                                    }));
                                }
                                openTheilluminant = false;
                                return;
                            }
                            if (list[1].Contains("-4"))
                            {
                                AddLog(2, "电压超限");
                                StaticMethod.variable.statuVariables[0].LED_State = "电压超限";
                                StaticMethod.WriteRuqire_ResultData(Common_Read.LED_OFF);
                                Create_LogFile();
                                if (this.InvokeRequired)
                                {
                                    this.Invoke(new Action(() =>
                                    {
                                        MessageBox.Show("电压超限");
                                    }));
                                }
                                openTheilluminant = false;
                                return;
                            }
                            if (list[1].Contains("-5"))
                            {
                                AddLog(2, "电流超限");
                                StaticMethod.variable.statuVariables[0].LED_State = "电流超限";
                                StaticMethod.WriteRuqire_ResultData(Common_Read.LED_OFF);
                                Create_LogFile();
                                if (this.InvokeRequired)
                                {
                                    this.Invoke(new Action(() =>
                                    {
                                        MessageBox.Show("电流超限");
                                    }));
                                }
                                openTheilluminant = false;
                                return;
                            }
                            break;
                        default:
                            break;
                    }
                }
                catch (Exception)
                {
                    if (this.InvokeRequired)
                    {
                        this.Invoke(new Action(() =>
                        {
                            AddLog(2, "请求失败,请重新开启背光");
                            StaticMethod.WriteRuqire_ResultData(Common_Read.LED_OFF);
                            MessageBox.Show("请求失败,请重新开启背光");
                        }));
                    }
                    return;
                }
                //根据返回的数据

            }

        }
        #endregion

        #region 写入配置文件

        private void but_Selcet_config_Click(object sender, EventArgs e)
        {
            FrmConfigSelect frmConfigSelect = new FrmConfigSelect();

            if (frmConfigSelect.ShowDialog() == DialogResult.OK)
            {
                WriteConfigToBL12(GlobalVariable.ConfigName);
                LoadResistSpec(GlobalVariable.ConfigName + ".ini");
            }
        }

        public void WriteConfigToBL12(string ConfigName)
        {
            // 配置OpenFileDialog
            //openFileDialog1.InitialDirectory = Application.StartupPath;
            //openFileDialog1.Filter = "INI文件 (*.ini)|*.ini|所有文件 (*.*)|*.*";
            //openFileDialog1.Title = "请选择配置文件";
            //// 显示文件对话框
            //if (openFileDialog1.ShowDialog() == DialogResult.OK)
            //{
            // 获取选择的文件路径
            //filePath = openFileDialog1.FileName;
            string ConfigPath = Application.StartupPath + $"\\Config\\{ConfigName}.ini";
            if (!File.Exists(ConfigPath))
            {
                AddLog(2, $"没有找到对应名称的配置文件:{ConfigPath}.请检查!");
                return;
            }
            AddLog(0, "选择配置文件:" + ConfigPath);
            this.text_MODEL.Text = ConfigName;
            this.text_Channel.Text = IniConfigHelper.ReadIniData("General", "Channel", "0", ConfigPath);
            this.text_CHNum.Text = IniConfigHelper.ReadIniData("General", "CHNum", "0", ConfigPath);
            this.text_I.Text = IniConfigHelper.ReadIniData("General", "I", "0", ConfigPath);
            this.text_Imaxmin.Text = IniConfigHelper.ReadIniData("General", "Imaxmin", "0", ConfigPath);
            this.text_Vmaxmin.Text = IniConfigHelper.ReadIniData("General", "Vmaxmin", "0", ConfigPath);
            this.text_SHorl.Text = IniConfigHelper.ReadIniData("General", "SHorl", "0", ConfigPath);
            this.text_DV.Text = IniConfigHelper.ReadIniData("General", "DV", "0", ConfigPath);
            this.text_NTC_Channel.Text = IniConfigHelper.ReadIniData("General", "NTC_Channel", "0", ConfigPath);
            this.text_NTC_MODEL.Text = IniConfigHelper.ReadIniData("General", "NTC_MODEL", "0", ConfigPath);
            this.text_NTCmaxmin.Text = IniConfigHelper.ReadIniData("General", "NTCmaxmin", "0", ConfigPath);
            this.text_Config_name.Text = ConfigName + ".ini";
            List<string> config = new List<string>()
                {
                     ConfigName,
                     this.text_CHNum.Text,
                     this.text_I.Text,
                     this.text_Imaxmin.Text,
                     this.text_Vmaxmin.Text,
                     this.text_SHorl.Text,
                     this.text_DV.Text,
                     this.text_NTC_Channel.Text,
                     this.text_NTC_MODEL.Text,
                     this.text_NTCmaxmin.Text
                };
            try
            {
                List<string> IsSuccess = new List<string>();

                AddLog(0, "配置文件参数正在写入中........................");

                //将配置文件中的数据写入到开发板中
                foreach (var item in Common_Read.common_Write_collection)
                {
                    switch (item)
                    {
                        case "LED_clear_maxmin\r\n":
                            IsSuccess.Add(StaticMethod.WriteRuqire_ResultData(item));
                            break;
                        case "LED_Set_PrjNames$":
                            IsSuccess.Add(StaticMethod.WriteRuqire_ResultData("LED_Set_PrjNames$" + config[0] + "\r\n"));
                            break;
                        case "LED_Set_ChNum$":
                            IsSuccess.Add(StaticMethod.WriteRuqire_ResultData("LED_Set_ChNum$" + config[1].Trim() + "\r\n"));
                            break;
                        case "LED_Set_I$":
                            IsSuccess.Add(StaticMethod.WriteRuqire_ResultData("LED_Set_I$" + config[2].Trim() + "\r\n"));
                            break;
                        case "LED_Set_Imaxmin$":
                            string imaxmin = config[3].Replace(",", "$");
                            for (int i = 1; i < int.Parse(config[1]) + 1; i++)
                            {
                                IsSuccess.Add(StaticMethod.WriteRuqire_ResultData($"LED_Set_Imaxmin${i}$" + imaxmin + "\r\n"));
                            }
                            break;
                        case "LED_Set_Vmaxmin$":
                            string Vmaxmin = config[4].Replace(",", "$");
                            for (int i = 1; i < int.Parse(config[1]) + 1; i++)
                            {
                                IsSuccess.Add(StaticMethod.WriteRuqire_ResultData($"LED_Set_Vmaxmin${i}$" + Vmaxmin + "\r\n"));
                            }
                            break;
                        case "LED_SHorL$":
                            IsSuccess.Add(StaticMethod.WriteRuqire_ResultData("LED_SHorL$" + config[5].Trim() + "\r\n"));
                            break;
                        case "LED_DVal_maxmin$":
                            IsSuccess.Add(StaticMethod.WriteRuqire_ResultData("LED_DVal_maxmin$" + config[6].Trim() + "\r\n"));
                            break;
                        case "LED_Set_NTC_Ch$":
                            IsSuccess.Add(StaticMethod.WriteRuqire_ResultData("LED_Set_NTC_Ch$" + config[7].Trim() + "\r\n"));
                            break;
                        case "NTC_MODEL$":
                            IsSuccess.Add(StaticMethod.WriteRuqire_ResultData("NTC_MODEL$" + config[8].Trim() + "\r\n"));
                            break;
                        case "LED_SNTC_maxmin$":
                            string NTCmaxmin = config[3].Replace(",", "$");
                            IsSuccess.Add(StaticMethod.WriteRuqire_ResultData("LED_SNTC_maxmin$0$" + NTCmaxmin + "\r\n"));
                            break;
                        case "LED_refresh\r\n":
                            IsSuccess.Add(StaticMethod.WriteRuqire_ResultData(item));
                            break;
                        default:
                            break;
                    }
                }
                if (IsSuccess.Contains("NG") || IsSuccess.Contains(""))
                {
                    this.text_Result.Text = "NG";
                    this.text_Result.BackColor = Color.Red;
                }
                else
                {
                    this.text_Result.Text = "OK";
                    this.text_Result.BackColor = Color.Green;
                    this.but_Open_optical_source.Enabled = true;
                    AddLog(0, "配置文件参数写入成功");
                }
            }
            catch (Exception ex)
            {
                AddLog(0, "配置文件参数写入失败:" + ex.Message);
                MessageBox.Show("配置文件参数写入失败");
            }

            //Task<string> task = new Task<string>(() =>
            //{
            //    return NewMethod(config);
            //});
            //var result = task.GetAwaiter().GetResult();
            //}
        }

        #endregion

        #region 写入配置参数
        /// <summary>
        /// 写入配置参数
        /// </summary>
        /// <param name="config"></param>

        private string NewMethod(List<string> config)
        {
            try
            {
                List<string> IsSuccess = new List<string>();

                //将配置文件中的数据写入到开发板中

                foreach (var item in Common_Read.common_Write_collection)
                {
                    switch (item)
                    {
                        case "LED_clear_maxmin\r\n":
                            IsSuccess.Add(StaticMethod.WriteRuqire_ResultData(item));
                            break;
                        case "LED_Set_PrjNames$":
                            IsSuccess.Add(StaticMethod.WriteRuqire_ResultData("LED_Set_PrjNames$" + config[0] + "\r\n"));
                            break;
                        case "LED_Set_ChNum$":
                            IsSuccess.Add(StaticMethod.WriteRuqire_ResultData("LED_Set_ChNum$" + config[1].Trim() + "\r\n"));
                            break;
                        case "LED_Set_I$":
                            IsSuccess.Add(StaticMethod.WriteRuqire_ResultData("LED_Set_I$" + config[2].Trim() + "\r\n"));
                            break;
                        case "LED_Set_Imaxmin$":
                            string imaxmin = config[3].Replace(",", "$");
                            for (int i = 1; i < int.Parse(config[1]) + 1; i++)
                            {
                                IsSuccess.Add(StaticMethod.WriteRuqire_ResultData($"LED_Set_Imaxmin${i}$" + imaxmin + "\r\n"));
                            }
                            break;
                        case "LED_Set_Vmaxmin$":
                            string Vmaxmin = config[4].Replace(",", "$");
                            for (int i = 1; i < int.Parse(config[1]) + 1; i++)
                            {
                                IsSuccess.Add(StaticMethod.WriteRuqire_ResultData($"LED_Set_Vmaxmin${i}$" + Vmaxmin + "\r\n"));
                            }
                            break;
                        case "LED_SHorL$":
                            IsSuccess.Add(StaticMethod.WriteRuqire_ResultData("LED_SHorL$" + config[5].Trim() + "\r\n"));
                            break;
                        case "LED_DVal_maxmin$":
                            IsSuccess.Add(StaticMethod.WriteRuqire_ResultData("LED_DVal_maxmin$" + config[6].Trim() + "\r\n"));
                            break;
                        case "LED_Set_NTC_Ch$":
                            IsSuccess.Add(StaticMethod.WriteRuqire_ResultData("LED_Set_NTC_Ch$" + config[7].Trim() + "\r\n"));
                            break;
                        case "NTC_MODEL$":
                            IsSuccess.Add(StaticMethod.WriteRuqire_ResultData("NTC_MODEL$" + config[8].Trim() + "\r\n"));
                            break;
                        case "LED_SNTC_maxmin$":
                            string NTCmaxmin = config[3].Replace(",", "$");
                            IsSuccess.Add(StaticMethod.WriteRuqire_ResultData("LED_SNTC_maxmin$0$" + NTCmaxmin + "\r\n"));
                            break;
                        default:
                            break;
                    }
                }

                if (IsSuccess.Contains("NG") || IsSuccess.Contains(""))
                {
                    AddLog(0, "配置参数写入失败");
                    return "NG";
                }
                else
                {
                    AddLog(0, "配置参数写入成功");
                    return "OK";
                }

                //if (this.text_Result.InvokeRequired)
                //{
                //    this.text_Result.Invoke(new Action(() =>
                //    {
                //        if (IsSuccess.Contains("NG") || IsSuccess.Contains(""))
                //        {
                //            this.text_Result.Text = "NG";
                //            this.text_Result.BackColor = Color.Red;
                //        }
                //        else
                //        {
                //            this.text_Result.Text = "OK";
                //            this.text_Result.BackColor = Color.Green;
                //            //button2_Click(this, EventArgs.Empty);
                //        }
                //    }));
                //}
            }
            catch (Exception ex)
            {
                AddLog(0, "配置参数写入失败:" + ex.Message);
                return null;
                //this.Invoke(new Action(() =>
                //{
                //    MessageBox.Show("配置参数写入失败");
                //}));
            }
        }
        #endregion

        #region 写入日志

        private async void Create_LogFile()
        {
            await Task.Run(() =>
            {
                queueLock.Enter();
                //  写入日志
                if (File.Exists(LogFilePath))
                {
                    AddLog(2, "日志文件存放路径不存在，请检查");
                    return;
                }
                //  检查文件夹是否存在
                if (!File.Exists(LogFilePath))
                {
                    // 当月日志文件夹不存在，创建
                    DirectoryInfo Create = null;
                    try
                    {
                        Create = Directory.CreateDirectory(LogFilePath);
                    }
                    catch (Exception)
                    {
                        AddLog(2, "当月日志文件夹创建失败，请检查");
                        return;
                    }
                }
                // 文件存在，读取或者写入日志内容，判断日志是否创建
                try
                {
                    Write_LogCvs();
                }
                catch (Exception)
                {
                    AddLog(2, "无法写入数据，请检查是否正在打开文件");
                    return;
                }
                finally
                {
                    queueLock.Leave();
                }
            });
        }

        public void Write_LogCvs()
        {
            // 检查文件是否存在
            bool fileExists = File.Exists(CurrentVariableCSV);

            // 使用using语句自动关闭StreamWriter
            using (StreamWriter sw = new StreamWriter(CurrentVariableCSV, append: true))
            {
                if (!fileExists)
                {
                    // 文件刚创建，写入标题行    
                    sw.WriteLine("Time,SN,Config,VF,I(am),VF,I(am),VF,I(am),VF,I(am),VF,I(am),VF,I(am),VF,I(am),VF,I(am),VF,I(am),VF,I(am),VF,I(am),VF,I(am),LED_Channel,LED_DV,NTC,NTC,State");
                }
                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(() =>
                    {
                        sw.WriteLine($"{CurrentTimer},{this.text_SN.Text},{this.cmb_Model_No.Text},{StaticMethod.variable.LedxVariable[0].VF}," +
                            $"{StaticMethod.variable.LedxVariable[0].Ima},{StaticMethod.variable.LedxVariable[1].VF},{StaticMethod.variable.LedxVariable[1].Ima}," +
                            $"{StaticMethod.variable.LedxVariable[2].VF}, {StaticMethod.variable.LedxVariable[2].Ima},{StaticMethod.variable.LedxVariable[3].VF}," +
                            $"{StaticMethod.variable.LedxVariable[3].Ima},{StaticMethod.variable.LedxVariable[4].VF}, {StaticMethod.variable.LedxVariable[4].Ima}," +
                            $"{StaticMethod.variable.LedxVariable[5].VF}, {StaticMethod.variable.LedxVariable[5].Ima},{StaticMethod.variable.LedxVariable[6].VF}," +
                            $"{StaticMethod.variable.LedxVariable[6].Ima},{StaticMethod.variable.LedxVariable[7].VF}, {StaticMethod.variable.LedxVariable[7].Ima}," +
                            $"{StaticMethod.variable.LedxVariable[8].VF}, {StaticMethod.variable.LedxVariable[8].Ima},{StaticMethod.variable.LedxVariable[9].VF}," +
                            $"{StaticMethod.variable.LedxVariable[9].Ima},{StaticMethod.variable.LedxVariable[10].VF.Replace("\r\n", "")}," +
                            $"{StaticMethod.variable.LedxVariable[10].Ima.Replace("\r\n", "")},{StaticMethod.variable.LedxVariable[11].VF.Replace("\r\n", "")}," +
                            $"{StaticMethod.variable.LedxVariable[11].Ima.Replace("\r\n", "")},{StaticMethod.variable.statuVariables[0].LED_channel_Number.Replace("\r\n", "")}," +
                            $"{StaticMethod.variable.statuVariables[0].LED_DV.Replace("\r\n", "")},{StaticMethod.variable.ntcVariables[0].NTC_Temp.Replace("\r\n", "")}," +
                            $"{StaticMethod.variable.ntcVariables[1].NTC_Temp.Replace("\r\n", "")},{StaticMethod.variable.statuVariables[0].LED_State.Replace("\r\n", "")}");
                    }));
                }
            }
        }

        #endregion

        #region AddLog

        public string Path = Application.StartupPath + "\\SystemLog\\";

        private QueueLock AddLogQueueLock = new QueueLock();

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
                Level = 0;
            }
            if (this.list_info.InvokeRequired)
            {
                this.list_info.Invoke(new Action<int, string>(AddLog), Level, Log);
            }
            else
            {
                string Time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff");
                WriteLog(Time + "  " + Log + "\r\n", Path + DateTime.Now.ToString("yyyy-MM-dd") + ".txt");
                ListViewItem listViewItem = new ListViewItem("  " + Time, Level);
                listViewItem.SubItems.Add(Log);
                this.list_info.Items.Add(listViewItem);
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
        public QueueLock LogQueueLock = new QueueLock();
        private async void WriteLog(string Log, string Path)
        {
            await Task.Run(() =>
            {
                LogQueueLock.Enter();
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
                    LogQueueLock.Leave();
                }
            });
        }

        #endregion

        #region 参数设置
        private void 设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (IsUnlock)
            {
                FrmSetting frmSetting = new FrmSetting();
                frmSetting.ShowDialog();
            }
            else
            {
                FrmAdmin frmAdmin = new FrmAdmin();
                if (frmAdmin.ShowDialog() == DialogResult.OK)
                {
                    IsUnlock = true;
                    but_SpotCheck.Enabled = true;
                    this.num_NtcUpper.Enabled = true;
                    this.num_NtcLower.Enabled = true;
                    this.Enabled = true;
                    FrmSetting frmSetting = new FrmSetting();
                    frmSetting.ShowDialog();
                }
            }
        }

        #endregion

        #region 减少闪烁
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams parss = base.CreateParams;
                parss.ExStyle |= 0x02000000;
                return parss;
            }
        }
        #endregion

        #region 操作员登录

        private void but_UserLogin_Click(object sender, EventArgs e)
        {
            FrmOperatorLogin frmOperatorLogin = new FrmOperatorLogin();
            frmOperatorLogin.ShowDialog();
            if (frmOperatorLogin.DialogResult == DialogResult.OK)
            {
                //this.text_UserID.Text = GlobalVariable.OperatorID;
                AddLog(0, "操作员登录成功: " + GlobalVariable.OperatorID);
            }
        }


        #endregion

        #region 修改登录密码

        private void 修改密码_Click(object sender, EventArgs e)
        {
            FrmChangePwd frmChangePwd = new FrmChangePwd();
            frmChangePwd.ShowDialog();
        }


        #endregion

        #region MCMQ开关

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (check_MCMQ.Checked)
            {
                try
                {
                    mcmqServer.McmqConnet(GlobalVariable.McmqSetting.McmqIp, int.Parse(GlobalVariable.McmqSetting.McmqPort), GlobalVariable.McmqSetting.McmqQueue, GlobalVariable.McmqSetting.McmqReplyQueue);

                }
                catch (Exception)
                {

                }
            }
            else
            {
                mcmqServer.McmqClose();
            }
        }

        #endregion

        #region NTCCheck部分

        public FrmSpotCheck frmSpotCheck { get; set; }

        private void comboBox1_DropDown(object sender, EventArgs e)
        {
            string[] PortName = SerialPort.GetPortNames();
            if (PortName.Length > 0)
            {
                this.cmb_Port.Items.Clear();
                this.cmb_Port.Items.AddRange(PortName);
                this.cmb_Port.SelectedIndex = 0;
                cmb_Port.SelectedIndex = 0;
            }
        }

        private void but_SpotCheck_Click(object sender, EventArgs e)
        {
            #region judge
            if (GlobalVariable.CheckTime.DayShift.Length < 1 || GlobalVariable.CheckTime.NightShift.Length < 1)
            {
                AddLog(2, "班次时间不能为空");
                return;
            }
            if (this.cmb_Port.Enabled)
            {
                AddLog(2, "请选择连接串口连接");
                return;
            }
            if (this.text_SN.Text.Length < 1)
            {
                AddLog(2, "请输入SN码信息");
                return;
            }
            if (this.text_Result.Text == "NG")
            {
                AddLog(2, "配置参数写入失败,请检查");
                return;
            }
            if (string.IsNullOrEmpty(this.cmb_Model_No.Text))
            {
                AddLog(2, "请选择温度阻值配置参数!");
                return;
            }
            #endregion
            if (JudgeIsSpotCheck(GlobalVariable.CheckTime.DayShift, GlobalVariable.CheckTime.NightShift))
            {
                Is_Auto = false;
                num_NtcUpper.Enabled = false;
                num_NtcLower.Enabled = false;
                but_SpotCheck.Enabled = false;
                GlobalVariable.NtcUpper = double.Parse(this.num_NtcUpper.Text);
                GlobalVariable.NtcLower = double.Parse(this.num_NtcLower.Text);
                ReadNtc();
            }
        }

        /// <summary>
        /// 判断在班次时间内是否是登录过点控
        /// </summary>
        /// <param name="DayShhift"></param>
        /// <param name="NightShift"></param>
        /// <returns></returns>
        public bool JudgeIsSpotCheck(string DayShhift, string NightShift)
        {
            DateTime dateTimeDayShift = DateTime.Now;
            DateTime dateTimeNightShift = DateTime.Now;
            try
            {
                dateTimeDayShift = DateTime.Parse(DayShhift);
                dateTimeNightShift = DateTime.Parse(NightShift);
            }
            catch (Exception)
            {
                AddLog(2, "Check Time格式输入错误,请参照 7:50 该格式进行填写");
                MessageBox.Show("Check Time格式输入错误,请参照 7:50 该格式进行填写");
                return false;
            }

            DateTime LoginTime = DateTime.Parse(IniConfigHelper.ReadIniData("CheckTime", "LoginTime", ""));

            //在原有的基础上增加一天
            DateTime endOfDateTimeDayShift = dateTimeDayShift.AddDays(1);

            DateTime NowDataTime = DateTime.Now;

            if (NowDataTime >= dateTimeDayShift && NowDataTime <= dateTimeNightShift)
            {
                if (!GlobalVariable.CheckTime.DayShiftSpotCheck && LoginTime >= dateTimeDayShift)
                {
                    frmSpotCheck = new FrmSpotCheck(IniConfigHelper.ReadIniData("CheckTime", "LoginTime", ""), dateTimeDayShift, dateTimeNightShift);
                    if (frmSpotCheck.ShowDialog() == DialogResult.OK)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            if (NowDataTime >= dateTimeNightShift && NowDataTime <= endOfDateTimeDayShift)
            {
                if (!GlobalVariable.CheckTime.NightShiftSpotCheck && LoginTime >= dateTimeNightShift)
                {
                    frmSpotCheck = new FrmSpotCheck(IniConfigHelper.ReadIniData("CheckTime", "LoginTime", ""), dateTimeDayShift, dateTimeNightShift);
                    if (frmSpotCheck.ShowDialog() == DialogResult.OK)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private void cmb_NTC_TempSelect_DropDown(object sender, EventArgs e)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(TempResistancePath);
            var combox = (ComboBox)sender;
            combox.Items.Clear();
            combox.Items.AddRange(directoryInfo.GetFiles());
        }

        public int NtcError = 0;

        public string ConvertToTemp(string NTC)
        {
            double NtcResistance = double.Parse(NTC);
            if (GlobalVariable.ResistUpper < NtcResistance || GlobalVariable.ResistLower > NtcResistance)
            {
                return "Error";
            }
            double temp = 0;
            foreach (var item in GlobalVariable.ResistSpec)
            {
                if (item.Value <= NtcResistance)
                {
                    temp = double.Parse(item.Key);
                    return temp.ToString();
                }
            }
            return "Error";
        }

        public string ConvertToTempJudge(string NTC)
        {
            double NtcResistance = double.Parse(NTC);
            if (GlobalVariable.ResistUpper < NtcResistance || GlobalVariable.ResistLower > NtcResistance)
            {
                this.Invoke(new Action(() => { this.Enabled = false; }));
                AddLog(2, $"NTC读取阻值超出当前阻值配置参数设置范围: {NTC}KΩ,请检查是否连接NTC或者请联系管理员进行解锁快捷键F6");
                return "Error";
            }
            double temp = 0;
            foreach (var item in GlobalVariable.ResistSpec)
            {
                if (item.Value <= NtcResistance)
                {
                    temp = double.Parse(item.Key);
                    if (GlobalVariable.NtcUpper < NtcResistance || GlobalVariable.NtcLower > NtcResistance)
                    {
                        //NtcError++;
                        //if (NtcError == 3)
                        //{
                        this.Invoke(new Action(() => { this.Enabled = false; }));
                        NtcError = 0;
                        AddLog(2, $"NTC阻值超出限定范围,当前NTC阻值为: {NtcResistance.ToString()}KΩ.请联系管理员进行解锁快捷键F6");
                        //}
                    }
                    else
                    {
                        AddLog(0, $"当前阻值在限定范围内,当前NTC阻值为: {NtcResistance.ToString()}KΩ");
                    }
                    return temp.ToString();
                }
            }
            return "Error";
        }

        #endregion

        #region 读取电阻阻值    
        /// <summary>
        /// 读取电阻阻值
        /// </summary>
        private void ReadNtc()
        {
            try
            {
                List<string> result = new List<string>();
                Thread.Sleep(100);
                string[] NTC_Now = StaticMethod.General_Split_Result(StaticMethod.WriteRuqire_ResultData("LED_GetNTC_R\r\n"));
                if (NTC_Now == null)
                {
                    this.Enabled = false;
                    AddLog(2, "NTC读取数据为null,请检测设备连接是否正常!");
                    MessageBox.Show("NTC读取数据为null,请检测设备连接是否正常!.请联系管理员进行解锁快捷键F6");
                    return;
                }
                this.Invoke(new Action(() =>
                {
                    if (this.check_NTC1Enable.Checked)
                    {
                        this.text_SpotTemp1.Text = ConvertToTempJudge(NTC_Now[1]);
                        this.text_SpotResist1.Text = NTC_Now[1];
                    }
                    else
                    {
                        this.text_SpotTemp1.Text = "";
                        this.text_SpotResist1.Text = "";
                    }
                    if (this.check_NTC2Enable.Checked)
                    {
                        this.text_SpotTemp2.Text = ConvertToTempJudge(NTC_Now[2]);
                        this.text_SpotResist2.Text = NTC_Now[2];
                    }
                    else
                    {
                        this.text_SpotTemp2.Text = "";
                        this.text_SpotResist2.Text = "";
                    }
                }));
                Thread.Sleep(100);
                AddLog(0, "点检完成");
                but_SpotCheck.Enabled = true;

                //  NTC上抛 与mcmq上抛  
                if (this.Enabled)
                {
                    Response response = new Response()
                    {
                        Result = "PASS"
                    };
                    if (Is_Auto) monitorServer.SenderClient(XmlHelper.EntityToXml(response));
                    McmqSenderData("PASS");
                }
                else
                {
                    Response response = new Response()
                    {
                        Result = "FAIL"
                    };
                    if (Is_Auto) monitorServer.SenderClient(XmlHelper.EntityToXml(response));
                    McmqSenderData("PAIL");
                }
            }
            catch (Exception)
            {
                this.Enabled = false;
                AddLog(2, "NTC读取异常,请检测设备连接是否正常!");
                MessageBox.Show("NTC读取异常,请检测设备连接是否正常!.请联系管理员进行解锁快捷键F6");
            }
        }

        private void McmqSenderData(string Result)
        {
            CCDDataReport cCDDataReport = new CCDDataReport()
            {
                TrxName = "CCDDataRepor",
                LotNo = this.text_SN.Text,
                IaryInfos = new IaryInfos() { Iary = new List<Iary>() },
                LogID = DateTime.Now.ToString("yyyyMMddhhmm"),
                LmUser = computerName,
                LmTime = DateTime.Now.ToString("yyyy-MM-dd hh:mm"),
            };
            if (this.check_NTC1Enable.Checked)
            {
                cCDDataReport.IaryInfos.Iary.Add(new Iary()
                {
                    Ccd_Tyoe = "ResistValue1",
                    MaxLumi = " ",
                    //EqpId = GlobalVariable.XmlData.Eqp_ID,
                    // JigId = GlobalVariable.XmlData.Jog_ID,
                    Unifomity = this.text_SpotResist1.Text,
                    Judge = Result,
                });
                cCDDataReport.IaryInfos.Iary.Add(new Iary()
                {
                    Ccd_Tyoe = "Temperature1",
                    MaxLumi = " ",
                    Unifomity = this.text_SpotTemp1.Text,
                    Judge = Result,
                });
            }
            if (this.check_NTC2Enable.Checked)
            {
                cCDDataReport.IaryInfos.Iary.Add(new Iary()
                {
                    Ccd_Tyoe = "ResistValue2",
                    MaxLumi = " ",
                    Unifomity = this.text_SpotResist2.Text,
                    Judge = Result,
                });
                cCDDataReport.IaryInfos.Iary.Add(new Iary()
                {
                    Ccd_Tyoe = "Temperature2",
                    MaxLumi = " ",
                    Unifomity = this.text_SpotTemp2.Text,
                    Judge = Result,
                });
            }
            AddLog(0, "MCMQ CCD QueueName = " + GlobalVariable.McmqSetting.McmqQueue);
            mcmqServer.McmqSend(GlobalVariable.McmqSetting.McmqQueue, GlobalVariable.McmqSetting.McmqReplyQueue, XmlHelper.EntityToXml(cCDDataReport));
        }

        #endregion

        private void 解锁ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAdmin frmAdmin = new FrmAdmin();
            if (frmAdmin.ShowDialog() == DialogResult.OK)
            {
                IsUnlock = true; ;
                but_SpotCheck.Enabled = true;
                this.num_NtcUpper.Enabled = true;
                this.num_NtcLower.Enabled = true;
                this.Enabled = true;
                but_SpotCheck.Enabled = true;
                NtcError = 0;
            }
        }

        private void 锁定ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IsUnlock = false;
            this.num_NtcUpper.Enabled = false;
            this.num_NtcLower.Enabled = false;
            but_SpotCheck.Enabled = false;
        }

        private void Check_Click(object sender, EventArgs e)
        {
            if (!IsUnlock)
            {
                AddLog(2, "请解锁在操作栏中进行解锁,或者点击快捷键F6");
            }
        }

        private void cmb_Model_No_DropDown(object sender, EventArgs e)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(Application.StartupPath + "\\ResistSpec");
            List<FileInfo> fileInfos = directoryInfo.GetFiles("*.ini").ToList();
            this.cmb_Model_No.Items.Clear();
            foreach (FileInfo fileInfo in fileInfos)
            {
                this.cmb_Model_No.Items.Add(fileInfo.Name);
            }
        }

        private void cmb_Model_No_SelectionChange(object sender, EventArgs e)
        {
            LoadResistSpec(this.cmb_Model_No.Text);
        }

        private void dataGridView_LEDx_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }

    #region 简单的混合锁
    /// <summary>
    /// 一个简单的混合线程同步锁，采用了基元用户加基元内核同步构造实现
    /// </summary>

    public sealed class SimpleHybirdLock : IDisposable
    {

        #region IDisposable Support
        private bool disposedValue = false; // 要检测冗余调用

        void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: 释放托管状态(托管对象)。
                }

                // TODO: 释放未托管的资源(未托管的对象)并在以下内容中替代终结器。
                // TODO: 将大型字段设置为 null。
                m_waiterLock.Close();

                disposedValue = true;
            }
        }

        // TODO: 仅当以上 Dispose(bool disposing) 拥有用于释放未托管资源的代码时才替代终结器。
        // ~SimpleHybirdLock() {
        //   // 请勿更改此代码。将清理代码放入以上 Dispose(bool disposing) 中。
        //   Dispose(false);
        // }

        // 添加此代码以正确实现可处置模式。
        /// <summary>
        /// 释放资源
        /// </summary>
        public void Dispose()
        {
            // 请勿更改此代码。将清理代码放入以上 Dispose(bool disposing) 中。
            Dispose(true);
            // TODO: 如果在以上内容中替代了终结器，则取消注释以下行。
            // GC.SuppressFinalize(this);
        }
        #endregion

        /// <summary>
        /// 基元用户模式构造同步锁
        /// </summary>
        private Int32 m_waiters = 0;
        /// <summary>
        /// 基元内核模式构造同步锁
        /// </summary>
        private AutoResetEvent m_waiterLock = new AutoResetEvent(false);

        /// <summary>
        /// 获取锁
        /// </summary>
        public void Enter()
        {
            if (Interlocked.Increment(ref m_waiters) == 1) return;//用户锁可以使用的时候，直接返回，第一次调用时发生
                                                                  //当发生锁竞争时，使用内核同步构造锁
            m_waiterLock.WaitOne();
        }

        /// <summary>
        /// 离开锁
        /// </summary>
        public void Leave()
        {
            if (Interlocked.Decrement(ref m_waiters) == 0) return;//没有可用的锁的时候
            m_waiterLock.Set();
        }

        /// <summary>
        /// 获取当前锁是否在等待当中
        /// </summary>
        public bool IsWaitting => m_waiters == 0;
    }
    #endregion

    #region 队列锁

    public sealed class QueueLock : IDisposable
    {
        private bool disposedValue = false;
        private readonly Queue<Thread> queue = new Queue<Thread>();
        private readonly object lockObject = new object();
        /// <summary>
        /// 进入锁
        /// </summary>
        public void Enter()
        {
            lock (lockObject)
            {
                Thread currentThread = Thread.CurrentThread;
                queue.Enqueue(currentThread);

                while (queue.Peek() != currentThread)
                {
                    Monitor.Wait(lockObject);
                }
            }
        }
        /// <summary>
        /// 离开锁
        /// </summary>
        public void Leave()
        {
            lock (lockObject)
            {
                queue.Dequeue();
                if (queue.Count > 0)
                {
                    Monitor.PulseAll(lockObject);
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // 释放托管状态(托管对象)。
                }

                // 释放未托管的资源(未托管的对象)并在以下内容中替代终结器。
                // 将大型字段设置为 null。

                disposedValue = true;
            }
        }
    }

    #endregion


}