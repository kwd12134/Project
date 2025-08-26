using KWDMHTUserLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KWDHTMmodels;
using System.Diagnostics;
using thinger.MTHHelper;
using System.IO;
using MiniExcelLibs;
using System.Threading;
using thinger.DataConvertLib;
using System.Collections.ObjectModel;

namespace KWD.MTHproject
{
    public partial class FrmMian : Form
    {

        #region 属性字段

        private string devicePath = Application.StartupPath + "\\Config\\Device.ini";

        private string GroupPath = Application.StartupPath + "\\Config\\Group.xlsx";

        private string VariablePath = Application.StartupPath + "\\Config\\Variable.xlsx";

        private CancellationTokenSource cts { get; set; } = new CancellationTokenSource();

        private ObservableCollection<string> actualAlarmList = new ObservableCollection<string>();

        #endregion

        #region 初始加载   与变量加载解析Switch

        public FrmMian()
        {
            InitializeComponent();
            //初始化加载对象
            this.Load += FrmMian_Load;

            actualAlarmList.CollectionChanged += ObserveAlarm_CollectionChanged;
        }

        private void FrmMian_Load(object sender, EventArgs e)
        {

            //窗体切换功能默认加载的时候打开集中监控
            CommonnaviButton_Click(this.navi_Monitor, null);

            //日志写入   CommonMethod.AddLog = ((FrmMonitor)form).AddLog;   在上面的打开默认窗体的时候CommonMethod.AddLog已经绑定了
            //                                                                                          FrmMonitor.Addlog

            //初始化拿到配置文件及其对应绑定的Group和Variable
            CommonMethod.Deviced = LoadDevice(devicePath, GroupPath, VariablePath);

            if (CommonMethod.Deviced != null)
            {
                CommonMethod.AddLog(0, "设备信息加载成功");
                //报警触发
                CommonMethod.Deviced.AlarmTrigEvent += Deviced_AlarmTrigEvent;
                Task.Run(new Action(() =>
                {
                    //跨线程访问
                    DeviceCommunication(CommonMethod.Deviced);

                }), cts.Token);
            }
        }

        #endregion

        #region 限制报警处理  与报警显示

        private void Deviced_AlarmTrigEvent(bool acktype, Variable variable)
        {
            if (acktype)
            {
                CommonMethod.AddLog(1, variable.Remark + " 触发");

                if (!actualAlarmList.Contains(variable.Remark))
                {
                    actualAlarmList.Add(variable.Remark);
                }
            }
            else
            {
                CommonMethod.AddLog(0, variable.Remark + " 消除");

                if (actualAlarmList.Contains(variable.Remark))
                {
                    actualAlarmList.Remove(variable.Remark);
                }
            }
        }

        private void ObserveAlarm_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            //跨线程访问
            this.Invoke(new Action(() =>
            {
                //对集合数量进行处理
                switch (actualAlarmList.Count)
                {
                    case 0:
                        this.scrollingText1.Text = "当前无报警";
                        break;

                    default:
                        this.scrollingText1.Text = string.Join("   ", actualAlarmList);
                        break;
                }
            }));
        }

        #endregion

        #region 跨线程委托跨线程变量读取


        /// <summary>
        /// 委托跨线程变量读取
        /// </summary>
        /// <param name="deviced"></param>
        private void DeviceCommunication(Device deviced)
        {
            //循环连接与变量读取
            while (!cts.IsCancellationRequested)
            {

                //通信连接连接成功进行数据解析与数据更新
                if (deviced.IsConnected)
                {
                    //变量读取

                    foreach (var gp in deviced.GroupList)
                    {

                        byte[] Data = null;

                        int DataTypeLength = 0;

                        if (gp.StoreArea == "输入线圈" || gp.StoreArea == "输出线圈")
                        {
                            //  TCP连接以及判断接收数据长度的准确性
                            switch (gp.StoreArea)
                            {
                                case "输入线圈":
                                    Data = CommonMethod.ModbusTCP.ReadInputCoils(gp.Start, gp.Length);
                                    DataTypeLength = ShortLib.GetByteLengthFromBoolLength(Data.Length);
                                    break;
                                case "输出线圈":
                                    Data = CommonMethod.ModbusTCP.ReadOutputCoils(gp.Start, gp.Length);
                                    DataTypeLength = ShortLib.GetByteLengthFromBoolLength(Data.Length);
                                    break;
                                default:
                                    break;
                            }

                            if (Data != null && Data.Length == DataTypeLength)
                            {
                                //   数据解析

                                foreach (var variable in gp.VariableList)
                                {
                                    //拿到变量的值进行解析
                                    DataType dataType = (DataType)Enum.Parse(typeof(DataType), variable.DataType, true);
                                    //是的，对于Modbus TCP协议中的变量读取，索引确实是从0开始的。在Modbus TCP中，数据寄存器（Data Register）
                                    //的读取是从寄存器的起始地址开始的，而寄存器的地址索引从0开始编码。例如，如果你要读取第一个寄存器的值，
                                    //你需要使用索引0来表示。同样地，如果你要读取第n个寄存器的值，你需要使用索引n - 1来表示。请注意，
                                    //这仅适用于Modbus TCP协议，其他Modbus协议变体（如Modbus RTU）可能有不同的索引规则。

                                    //假设我们要读取线圈从10开始的10个长度     对应变量地址是10，而我们从10开始读取的把他当做为0
                                    //相减下来就是我们说对应的具体变量存储位置的值  线圈值占一个字节
                                    int start = variable.Start - gp.Start;

                                    switch (dataType)
                                    {
                                        case DataType.Bool:

                                            variable.VarValue = BitLib.GetBitArrayFromByteArray
                                                (Data, start, variable.OffsetOrLength);

                                            break;
                                        default:
                                            break;
                                    }
                                    //更新数据写入
                                    deviced.UpdateVariable(variable);

                                }
                            }
                            else
                            {
                                deviced.IsConnected = false;
                                break;
                            }

                        }
                        // 输出寄存器和输入寄存器
                        else
                        {
                            //数据解析

                            switch (gp.StoreArea)
                            {
                                case "输入寄存器":
                                    Data = CommonMethod.ModbusTCP.ReadInputRegisters(gp.Start, gp.Length);
                                    DataTypeLength = gp.Length * 2;
                                    break;
                                case "输出寄存器":
                                    //拿到Slave从站的数据
                                    Data = CommonMethod.ModbusTCP.ReadOutputRegisters(gp.Start, gp.Length);
                                    DataTypeLength = gp.Length * 2;
                                    break;
                                default:
                                    break;
                            }

                            //Data通信读取到数据下方根据数据类型进行解析



                            if (Data != null && Data.Length == DataTypeLength)
                            {
                                //变量解析

                                foreach (var variable in gp.VariableList)
                                {
                                    //拿到变量的值进行解析
                                    DataType dataType = (DataType)Enum.Parse(typeof(DataType), variable.DataType, true);
                                    //是的，对于Modbus TCP协议中的变量读取，索引确实是从0开始的。在Modbus TCP中，数据寄存器（Data Register）
                                    //的读取是从寄存器的起始地址开始的，而寄存器的地址索引从0开始编码。例如，如果你要读取第一个寄存器的值，
                                    //你需要使用索引0来表示。同样地，如果你要读取第n个寄存器的值，你需要使用索引n - 1来表示。请注意，
                                    //这仅适用于Modbus TCP协议，其他Modbus协议变体（如Modbus RTU）可能有不同的索引规则。

                                    //假设我们要读取寄存器从10开始的10个长度     对应变量地址是10，而我们从10开始读取的把他当做为0
                                    //相减下来就是我们说对应的具体变量存储位置的值   而寄存器的存储值为两个字节  
                                    int start = variable.Start - gp.Start;

                                    start *= 2;

                                    switch (dataType)
                                    {
                                        case DataType.Bool:
                                            variable.VarValue = BitLib.GetBitFrom2BytesArray(Data, start,
                                                variable.OffsetOrLength, CommonMethod.dataFormat == DataFormat.BADC || CommonMethod.dataFormat == DataFormat.DCBA);
                                            break;
                                        case DataType.Byte:
                                            variable.VarValue = ByteLib.GetByteFromByteArray(Data,
                                                CommonMethod.dataFormat == DataFormat.BADC || CommonMethod.dataFormat == DataFormat.DCBA ? start : start + 1);
                                            break;
                                        case DataType.Short:
                                            variable.VarValue = ShortLib.GetShortFromByteArray(Data, start, CommonMethod.dataFormat);
                                            break;
                                        case DataType.UShort:
                                            variable.VarValue = UShortLib.GetUShortFromByteArray(Data, start, CommonMethod.dataFormat);
                                            break;
                                        case DataType.Int:
                                            variable.VarValue = IntLib.GetIntFromByteArray(Data, start, CommonMethod.dataFormat);
                                            break;
                                        case DataType.UInt:
                                            variable.VarValue = UIntLib.GetUIntFromByteArray(Data, start, CommonMethod.dataFormat);
                                            break;
                                        case DataType.Float:
                                            variable.VarValue = FloatLib.GetFloatFromByteArray(Data, start, CommonMethod.dataFormat);
                                            break;
                                        case DataType.Double:
                                            variable.VarValue = DoubleLib.GetDoubleFromByteArray(Data, start, CommonMethod.dataFormat);
                                            break;
                                        case DataType.Long:
                                            variable.VarValue = LongLib.GetLongFromByteArray(Data, start, CommonMethod.dataFormat);
                                            break;
                                        case DataType.ULong:
                                            variable.VarValue = ULongLib.GetULongFromByteArray(Data, start, CommonMethod.dataFormat);
                                            break;
                                        case DataType.String:
                                            variable.VarValue = StringLib.GetStringFromByteArrayByEncoding
                                                (Data, start, variable.OffsetOrLength, Encoding.ASCII);
                                            break;
                                        case DataType.ByteArray:
                                            variable.VarValue = ByteArrayLib.GetByteArrayFromByteArray(Data, start, variable.OffsetOrLength);
                                            break;
                                        case DataType.HexString:
                                            variable.VarValue = StringLib.GetHexStringFromByteArray(Data, start, variable.OffsetOrLength);
                                            break;
                                        default:
                                            break;
                                    }

                                    //先做线性转换在做更新

                                    variable.VarValue = MigrationLib.GetMigrationValue
                                        (variable.VarValue, variable.Scale.ToString(), variable.OffsetOrLength.ToString()).Content;

                                    //里面还有判断报警触发   报警事件还没有挂接
                                    deviced.UpdateVariable(variable);
                                }

                            }
                            else
                            {
                                deviced.IsConnected = false;
                                break;
                            }
                        }

                    }
                }

                //首次通信或者通信不上进行连接

                else
                {
                    //通信连接
                    CommonMethod.ModbusTCP = new ModbusTCP();
                    // 非首次连接的重连延迟设置
                    if (CommonMethod.Deviced.ReConnectSign)
                    {
                        //第二次连接时关闭前关闭连接
                        CommonMethod.ModbusTCP.DisConnect();

                        Thread.Sleep(CommonMethod.Deviced.ReConnectTime);

                    }
                    //连接状态读取   如果连接成功就while循环到turn变量读取那块  否则重新进行通信读取
                    deviced.IsConnected = CommonMethod.ModbusTCP.Connect(deviced.IPAddress, deviced.Port);

                    if (deviced.ReConnectSign)
                    {
                        CommonMethod.AddLog(deviced.IsConnected ? 0 : 1, deviced.IsConnected ? "控制器重新连接成功" : "控制器重新连接失败");
                    }
                    else
                    {
                        CommonMethod.AddLog(deviced.IsConnected ? 0 : 1, deviced.IsConnected ? "控制器初次连接成功" : "控制器连接失败");
                        deviced.ReConnectSign = true;
                    }

                }
            }

        }

        #endregion

        #region 窗体切换功能
        /// <summary>
        /// 窗体切换功能
        /// </summary>
        /// <param name="sender">出发事件的成员</param>
        /// <param name="e"></param>

        private void CommonnaviButton_Click(object sender, EventArgs e)
        {
            if (sender is NaviButton navi)
            {
                if (Enum.IsDefined(typeof(FromNames), navi.TitleName))
                {
                    //拿到导航按钮对应的窗体枚举值   navi导航
                    FromNames fromnasme = (FromNames)Enum.Parse(typeof(FromNames), navi.TitleName, true);

                    //  窗体切换   Mianpanel是父容器  
                    OpenFrom(this.Mainpanel, fromnasme);
                    // 设置Title名
                    SetTitle(this.lbl_Title, fromnasme);
                    //  设置选中
                    SetNaviBottonIsSelect(TopPanel, navi);
                }
            }
        }

        #endregion

        #region 通用窗体打开

        /// <summary>
        /// 通用窗体打开
        /// </summary>
        /// <param name="MianPanel">容器控件</param>
        /// <param name="fromNames">窗体枚举名称</param>
        private void OpenFrom(Panel MianPanel, FromNames fromNames)
        {
            //获取当前容器的容量
            int total = MianPanel.Controls.Count;

            int Closepanel = 0;

            bool isfind = false;

            for (int i = 0; i < total; i++)
            {
                Control ct = MianPanel.Controls[i - Closepanel];

                if (ct is Form frm)
                {
                    //如果当前的窗体是我吗要操作的窗体名
                    if (frm.Text == fromNames.ToString())
                    {
                        frm.BringToFront();

                        isfind = true;

                        break;
                    }
                    //首次离开主窗体不会被关闭并且移除掉 Control ct = Mianpanel.Controls[i-Closepanel]; 窗体的重复打开
                    else if ((FromNames)Enum.Parse(typeof(FromNames), frm.Text, true) >= FromNames.临界窗体)
                    {
                        frm.Close();
                        Closepanel++;
                    }
                }
            }
            if (isfind == false)
            {
                Form form = null;

                switch (fromNames)
                {
                    case FromNames.集中监控:
                        form = new FrmMonitor();
                        //用一个委托静态方法调用其他form里面的方法 CommonMethod 实体类的方法一开始就被绑定了FrmMonitor.Addlog所以加载的时候调用的是日志方法
                        CommonMethod.AddLog = ((FrmMonitor)form).AddLog;
                        break;
                    case FromNames.临界窗体:
                        break;
                    case FromNames.参数设置:
                        form = new FrmParamSet(devicePath);
                        break;
                    case FromNames.配方管理:
                        form = new FrmRecipe();
                        break;
                    case FromNames.报警追溯:
                        form = new FrmAlarm();
                        break;
                    case FromNames.历史趋势:
                        form = new FrmHistory();
                        break;
                    case FromNames.用户管理:
                        form = new FrmUserManager();
                        break;
                    default:
                        break;
                }
                if (form != null)
                {
                    form.TopLevel = false;
                    //无边框
                    form.FormBorderStyle = FormBorderStyle.None;
                    //填充
                    form.Dock = DockStyle.Fill;
                    //设置父容器
                    form.Parent = MianPanel;
                    //置前
                    form.BringToFront();

                    form.Show();

                }
            }

        }

        #endregion

        #region 设置Title名
        /// <summary>
        /// 设置标题内容
        /// </summary>
        /// <param name="labels"></param>
        /// <param name="fromNames"></param>
        private void SetTitle(Label labels, FromNames fromNames)
        {
            labels.Text = fromNames.ToString();
        }

        #endregion

        #region 设置选中
        /// <summary>
        /// 设置导航按钮选中
        /// </summary>
        /// <param name="panel">导航按钮的容器</param>
        /// <param name="naviButton"></param>
        private void SetNaviBottonIsSelect(Panel panel, NaviButton naviButton)
        {
            //找到control控件里面Navibutton的控件
            foreach (var item in panel.Controls.OfType<NaviButton>())
            {
                item.IsSelected = false;
            }

            naviButton.IsSelected = true;

        }

        #endregion

        #region 关闭窗体
        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region 减少闪烁

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle = 0x02000000;
                return cp;
            }
        }

        #endregion

        #region 配置文件读取  加载设备信息   把Variable的变量添加到对应的Group里面的VariableList里面

        private Device LoadDevice(string DevicePath, string GroupPath, string VariableParth)
        {
            if (!File.Exists(DevicePath))
            {
                CommonMethod.AddLog(1, "设备配置文件不存在");
                return null;
            }

            List<Group> GpList = LoadGroup(GroupPath, VariableParth);

            if (GpList == null)
            {
                return null;
            }

            try
            {
                return new Device()
                {
                    //127.0.0.1" 默认值
                    IPAddress = IniConfigHelper.ReadIniData("设备参数", "IP地址", "127.0.0.1", DevicePath),
                    Port = Convert.ToInt32(IniConfigHelper.ReadIniData("设备参数", "端口号", "502", DevicePath)),
                    GroupList = GpList,
                };
            }
            catch (Exception ex)
            {
                //日志写入
                CommonMethod.AddLog(1, "设备文件写入失败：" + ex.Message);
                return null;
            }

        }
        /// <summary>
        /// 通信组及其通信变量的解析（就是把变量值存储的到对应的通信组上）
        /// </summary>
        /// <param name="GroupPath"></param>
        /// <param name="VariableParth"></param>
        /// <returns></returns>
        private List<Group> LoadGroup(string GroupPath, string VariableParth)
        {
            if (!File.Exists(GroupPath))
            {
                CommonMethod.AddLog(1, "通信组文件不存在");
                return null;
            }
            if (!File.Exists(VariableParth))
            {
                CommonMethod.AddLog(1, "通信变量文件不存在");
                return null;
            }
            //解析通信组
            List<Group> Gplist = null;
            try
            {
                //Query<GPlist>查询该泛型类型对应的文件
                Gplist = MiniExcel.Query<Group>(GroupPath).ToList();
            }
            catch (Exception ex)
            {
                CommonMethod.AddLog(1, "通信组加载失败：" + ex.Message);
                return null;
            }

            List<Variable> VarList = null;
            try
            {
                //Query<Variable>查询该泛型类型对应的文件
                VarList = MiniExcel.Query<Variable>(VariableParth).ToList();
            }
            catch (Exception ex)
            {
                CommonMethod.AddLog(1, "通信参数加载失败：" + ex.Message);
                return null;
            }

            if (VarList != null && Gplist != null)
            {
                foreach (var Group in Gplist)
                {
                    Group.VariableList = VarList.FindAll(c => { return c.GroupName == Group.GroupName; }).ToList();
                }
                return Gplist;
            }
            else
            {
                CommonMethod.AddLog(1, "通信组变量");
                return null;
            }

        }

        #endregion

    }
}
