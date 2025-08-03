using Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using thinger.DataConvertLib;

namespace Communication
{
    public class TClient : ITcpClient
    {
        public TcpClient Tcp_Client { get; set; } = new TcpClient();

        public bool listening { get; set; }

        public CancellationTokenSource cts { get; set; } = new CancellationTokenSource();

        #region 事件创建
        // 1. 定义事件处理程序委托类型
        //public delegate void DataReceivedEventHandler(object sender);

        // 2. 定义事件
        //public event DataReceivedEventHandler DataReceived;
        public event Action DataReceived;

        // 3. 定义事件数据类
        //public class DataReceivedEventArgs : EventArgs
        //{
        //    //public string Message { get; }

        //    public DataReceivedEventArgs()
        //    {
        //        //Message = message;
        //    }
        //}

        // 5. 触发事件的方法   把事件消息传出去  
        protected virtual void OnDataReceived()
        {
            DataReceived?.Invoke(); // 如果有订阅者，触发事件
        }


        public event Action Complete;

        protected virtual void OnCompletionQueue()
        {
            Complete?.Invoke();
        }

        #endregion

        #region 主体连接部分
        public async void TcpClienttConnect(string ipAddress, int port, DeviceEnums DeviceCommandEnum, string Command, int Count = 0)
        {
            try
            {
                if (!Tcp_Client.Connected)
                {
                    Tcp_Client = new TcpClient();
                    await Tcp_Client.ConnectAsync(ipAddress, port);
                    Variable.ListAddLog(0, $"Connected to {ipAddress}:{port}");
                }
                listening = true;

                switch (DeviceCommandEnum)
                {
                    case DeviceEnums.写指定PSET参数0103:
                    case DeviceEnums.写JOB参数0107:
                    case DeviceEnums.设置激活0111:
                        _ = GeneralWriteState(Tcp_Client, Command);
                        break;
                    case DeviceEnums.运行状态0201:
                        //心跳包处理   period周期   duetime到期时间
                        heartbeatTimer = new Timer(SendHeartbeat, null, heartbeatInterval, heartbeatInterval);
                        HandleClientAsyncRunStatus(Tcp_Client, Command); // 异步处理客户端连接  读取运行数据
                        break;
                    case DeviceEnums.最终拧紧结果0202:
                        heartbeatTimer = new Timer(SendHeartbeat, null, heartbeatInterval, heartbeatInterval);
                        _ = HandleClientAsyncResultDataRead(Tcp_Client, Command); 
                        break;
                    case DeviceEnums.实时曲线数据0203:
                        heartbeatTimer = new Timer(SendHeartbeat, null, heartbeatInterval, heartbeatInterval);
                        _ = HandleClientAsyncRealTimeData(Tcp_Client, Command); 
                        break;
                    case DeviceEnums.电机运行停止使能0301:
                        _ = GeneralWriteState(Tcp_Client, Command);
                        break;
                    case DeviceEnums.历史数据读取0401:
                        _ = HandleClientAsyncHistory(Tcp_Client, Command, Count); 
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                Variable.ListAddLog(2, $"Error Connecting to {ipAddress}:{port} - {ex.Message}");
            }
        }

        #endregion

        #region 心跳包定时处理
        public Timer heartbeatTimer { get; set; }

        private int heartbeatInterval = 30000; // 心跳包间隔时间30秒

        private void SendHeartbeat(object state)
        {
            if (Tcp_Client != null && Tcp_Client.Connected)
            {
                try
                {
                    // 你的心跳包内容，这里使用简单的0字节数据作为示例
                    byte[] heartbeatPacket = Encoding.ASCII.GetBytes("02 00 00 00 07 57 30 30 31 3d 31 31 03");
                    Tcp_Client.GetStream().Write(heartbeatPacket, 0, heartbeatPacket.Length);
                    Variable.ListAddLog(0, "Heartbeat sent.");
                }
                catch (Exception ex)
                {
                    Variable.ListAddLog(2, $"Error Sending Heartbeat: {ex.Message}");
                }
            }
        }
        #endregion

        #region 绑定运行状态数据

        /// <summary>
        /// 绑定运行状态数据
        /// </summary>
        /// <param name="client"></param>
        /// <param name="Command"></param>
        /// <returns></returns>
        private async void HandleClientAsyncRunStatus(TcpClient client, string Command)
        {
            var buffer = new byte[1024];
            var stream = client.GetStream();
            byte[] data = ByteArrayLib.GetByteArrayFromHexString(Command);
            await stream.WriteAsync(data, 0, data.Length);

            Func<string, string> RunStatus = c => c == "1,0" ? "准备运行" : "正在运行";

            Func<string, string> IsOKNG = c =>
            {
                switch (c)
                {
                    case "1,0":
                        return "拧紧合格";
                    case "0,1":
                        return "拧紧不合格";
                    case "0,0":
                        return "";
                    default:
                        return "";
                }
            };

            Func<string, string> ToolsVerifyStatus = c => c == "1" ? "未满足标定要求" : "达到标定要求";

            while (true)
            {
                int bytesRead;
                try
                {
                    //Thread.Sleep(100);
                    bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length, cts.Token);
                }
                catch (Exception ex)
                {

                    Variable.ListAddLog(2, $"HandleClientAsyncRunStatus:Error: {ex.Message}");
                    break;
                }

                if (bytesRead == 0)
                {
                    Variable.ListAddLog(1, "Client DisConnected.");
                    //TcpClienttConnect("192.168.2.32", 5000, Command);
                    break;
                }

                string[] result = StringLib.GetStringFromByteArrayByEncoding(buffer, 0, buffer.Length - 1, Encoding.ASCII).Split('=');


                if (result[0].Contains("ERROR"))
                {
                    Variable.ListAddLog(2, $"HandleClientAsyncRunStatus:ERROR: {result[1].Substring(0, 5)}");
                    break;
                }
                if (result[0].Contains("ACK"))
                {
                    continue;
                }
                //Variable.DgvAddLog($"Received:RunStatus");

                string[] SystemMalfunction = result[3].Split(',');

                DeviceRunStatusData deviceRunStatusData = new DeviceRunStatusData()
                {
                    运行时间 = Variable.CurrentTime,
                    工作模式 = DataHelper.JudgementModel(result[1].Substring(0, 1)) + $"[{result[1].Substring(2, 1)}]",
                    运行状态 = RunStatus(result[2].Substring(0, 3)),
                    拧紧状态 = IsOKNG(result[2].Substring(4, 3)),
                    系统故障状态 = DataHelper.SystemMalfunctionStatus(SystemMalfunction[1].Split(';')),
                    工具校验状态 = ToolsVerifyStatus(result[3].Substring(0, 1)),
                    拧紧错误代码 = DataHelper.JudgeERROR("0" + result[5].Substring(0, 1))
                };
                Variable.deviceRunStatusData.Add(deviceRunStatusData);

                //防止栈溢出
                if (Variable.deviceRunStatusData.Count > 100)
                {
                    Variable.deviceRunStatusData.RemoveRange(0, 1);
                }

                // 4. 触发事件  

                OnDataReceived();
            }
            //if (client.Connected)
            //{
            //    client?.Close();
            //    heartbeatTimer?.Dispose();
            //}
        }
        #endregion

        #region 绑定拧紧结果数据

        /// <summary>
        /// 绑定拧紧结果数据
        /// </summary>
        /// <param name="client"></param>
        /// <param name="Command"></param>
        /// <returns></returns>
        private async Task HandleClientAsyncResultDataRead(TcpClient client, string Command)
        {
            var buffer = new byte[1024];
            var stream = client.GetStream();
            byte[] data = ByteArrayLib.GetByteArrayFromHexString(Command);
            await stream.WriteAsync(data, 0, data.Length);
            Func<string, string> IsOK = c => c == "1" ? "拧紧合格" : "拧紧不合格";
            while (true)
            {
                int bytesRead;
                try
                {
                    bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length, cts.Token);
                }
                catch (Exception ex)
                {
                    Variable.ListAddLog(2, $"HandleClientAsyncResultDataReadError: {ex.Message}");
                    break;
                }

                if (bytesRead == 0)
                {
                    Variable.ListAddLog(1, "HandleClientAsyncResultDataRead,Client DisConnected.");
                    break;
                }

                string[] result = StringLib.GetStringFromByteArrayByEncoding(buffer, 0, buffer.Length - 1, Encoding.ASCII).Split('=');

                if (result[0].Contains("ERROR"))
                {
                    Variable.ListAddLog(2, $"Received: {result[1].Substring(0, 5)}");
                    break;
                }

                if (result[0].Contains("ACK"))
                {
                    continue;
                }

                Variable.ListAddLog(1, $"Received:ResultData");

                string[] ResultData = result[1].Split(',');

                string[] FinalParament = result[2].Split(',');

                DeviceResultReadDate deviceResultReadDate = new DeviceResultReadDate()
                {
                //    工作模式 = DataHelper.JudgementModel(ResultData[0]),
                //    模式序号 = $"job[{ResultData[1]}]/Pset[{ResultData[3]}]",
                    执行顺序进度 = $"{ResultData[2]}/{ResultData[4]}",
                    最终扭矩 = ResultData[5],
                    最终角度 = ResultData[6],
                    监控角度 = ResultData[7],
                    执行时间 = ResultData[8],
                    拧紧结果状态 = IsOK(ResultData[9]),
                    NG结果 = DataHelper.JudgeERROR(ResultData[10].Substring(0, 2))
                };

                Variable.deviceResultReadDates.Add(deviceResultReadDate);

                if (Variable.deviceResultReadDates.Count > 100)
                {
                    Variable.deviceResultReadDates.RemoveRange(0, 1);
                }
                
                // 4. 触发事件   
                OnDataReceived(); 
                //触发完成job组任务事件
                if (ResultData[2] == ResultData[4])
                {
                    OnCompletionQueue();
                }
            }
            //if (client.Connected)
            //{
            //    client?.Close();
            //    heartbeatTimer?.Dispose();
            //}

        }
        #endregion

        #region 绑定实时数据读取

        public event Action RefreshChart;

        protected virtual void OnRefreshChart()
        {
            RefreshChart?.Invoke();
        }

        public class RealTimeDataEventArgs : EventArgs
        {
            public double[] Nm;
            public double[] Angle;

            public RealTimeDataEventArgs(string[] nm, string[] angle)
            {
                Nm = nm.Select(double.Parse).ToArray();
                Angle = angle.Select(double.Parse).ToArray();
            }
        }

        public event Action<RealTimeDataEventArgs> RealTimeData;

        protected virtual void OnRealTimeDataReceived(RealTimeDataEventArgs realTimeDataEventArgs)
        {
            RealTimeData?.Invoke(realTimeDataEventArgs);
        }

        private async Task HandleClientAsyncRealTimeData(TcpClient client, string Command)
        {
            var buffer = new byte[1024];
            var stream = client.GetStream();
            byte[] data = ByteArrayLib.GetByteArrayFromHexString(Command);
            await stream.WriteAsync(data, 0, data.Length);
            List<string[]> strings = new List<string[]>();
            while (true)
            {
                int bytesRead;
                try
                {
                    bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length, cts.Token);
                }
                catch (Exception ex)
                {
                    Variable.ListAddLog(2, $"HandleClientAsyncRealTimeData: {ex.Message}");
                    break;
                }

                if (bytesRead == 0)
                {
                    Variable.ListAddLog(1, "HandleClientAsyncRealTimeData,Client DisConnected.");
                    break;
                }

                string[] result = StringLib.GetStringFromByteArrayByEncoding(buffer, 0, buffer.Length - 1, Encoding.ASCII).Split('=');

                if (result[0].Contains("ERROR"))
                {
                    Variable.ListAddLog(2, $"HandleClientAsyncRealTimeData,Received: {result[1].Substring(0, 5)}");
                    break;
                }

                if (result[0].Contains("ACK"))
                {
                    continue;
                }

                strings.Add(result);

                //Variable.DgvAddLog("连接", "Receive Data");

                string[] Param = result[1].Split(',');

                string[] Nm = result[2].Split(';');

                Nm = Nm[0].Split(',');

                string[] Angle = result[3].Split(';');

                Angle = Angle[0].Split(',');

                //DeviceRealTimeData deviceRealTimeData = new DeviceRealTimeData()
                //{
                //    曲线采集间隔 = Param[0],
                //    所对应的Pset = Param[1],
                //    拧紧曲线是否结束 = Param[2],
                //    拧紧曲线是否是开始端 = Param[3].Substring(0, 1),
                //    扭矩 = Nm,
                //    角度 = Angle
                //};

                if (Param[3].Substring(0, 1) == "1")
                {
                    OnRefreshChart();
                }
                //   4.触发事件
                OnRealTimeDataReceived(new RealTimeDataEventArgs(Nm, Angle));
            }
        }

        #endregion

        #region 读取历史参数
        /// <summary>
        /// 读取历史参数
        /// </summary>
        /// <param name="client"></param>
        /// <param name="Command"></param>
        /// <returns></returns>
        private async Task HandleClientAsyncHistory(TcpClient client, string Command, int Count)
        {
            var buffer = new byte[10000];
            var stream = client.GetStream();
            string countHexString;
            string Length;
            int Delay = 0;

            if (Count < 10)
            {
                // 如果 Count 小于 10，则转换成一个字符的十六进制表示
                countHexString = Convert.ToInt32((char)('0' + Count)).ToString("X");
                Length = "0d";
                Delay = 200;
            }
            else if (Count < 100)
            {
                // 如果 Count 大于或等于 10，则转换成两个字符的十六进制表示
                countHexString = $"{(Count / 10 + '0'):X2} {(Count % 10 + '0'):X2}";
                Length = "0e";
                Delay = 1500;
            }
            else
            {
                //:X2 将字符转换为两位十六进制表示。
                countHexString = $"{(Count / 100 + '0'):X2} {(Count / 10 % 10 + '0'):X2} {(Count % 10 + '0'):X2}";
                Length = "0f";
                Delay = 5000;
            }

            // 生成 byte[] 数据
            byte[] data = ByteArrayLib.GetByteArrayFromHexString($"02 00 00 00 {Length} 52 30 34 30 31 30 30 31 3d 30 2c {countHexString} 3b 03");

            await stream.WriteAsync(data, 0, data.Length);
            Func<string, string> IsOK = c => c == "01" ? "拧紧合格" : "拧紧不合格";
            Variable.DeviceHistory = new List<DeviceHistoryData>();
            while (true)
            {
                int bytesRead;
                try
                {
                    Thread.Sleep(Delay);
                    bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
                }
                catch (Exception ex)
                {
                    Variable.ListAddLog(2, $"HandleClientAsyncHistory :{ex.Message}");
                    break;
                }

                if (bytesRead == 0)
                {
                    Variable.ListAddLog(1, "Client DisConnected.");
                    break;
                }
                string[] result = StringLib.GetStringFromByteArrayByEncoding(buffer, 0, buffer.Length - 1, Encoding.ASCII).Split('=');
               // var message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                Variable.ListAddLog(0, $"Received: History");

                Variable.DeviceHistory = new List<DeviceHistoryData>();

                if (result[0].Contains("ERROR"))
                {
                    Variable.ListAddLog(2, $"HandleClientAsyncHistory,Received: {result[1].Substring(0, 6)}");
                    break;
                }

                if (result.Length == 1)
                {
                    continue;
                }

                for (int i = 0; i < Count; i++)
                {
                    try
                    {
                        var Data = result[i + 2].Split(',');

                        if (Data != null)
                        {

                            DeviceHistoryData deviceData = new DeviceHistoryData()
                            {
                                时间 = Data[0],
                                模式 = DataHelper.JudgementModel(Data[1]) + $"/job{Data[2].Substring(0, 1)}/Pset{Data[3].Substring(0, 1)}",
                                扭矩 = Data[4],
                                角度 = Data[5],
                                时长 = Data[6],
                                拧紧结果状态 = IsOK(Data[7].Substring(0, 1)),
                                错误码ID = Data[8].Substring(0, 2),
                                错误码信息 = DataHelper.JudgeERROR(Data[8].Substring(0, 2))
                            };
                            Variable.DeviceHistory.Add(deviceData);
                        }
                    }
                    catch (Exception)
                    {
                        //Variable.DgvAddLog("参数解析失败:" + ex.Message);
                    }
                }
                // 4. 触发事件   
                OnDataReceived();
            }
            if (client.Connected)
            {
                client?.Close();
            }
        }
        #endregion

        #region 读取Pset当前参数

        private async Task HandleClientAsyncPsetParameterRead(TcpClient client, string Command, string Hex)
        {
            var buffer = new byte[1024];
            var stream = client.GetStream();
            byte[] command = ByteArrayLib.GetByteArrayFromHexString($"02 00 00 00 0b 52 {Command} 30 30 31 3d {Hex} 3b 03");
            await stream.WriteAsync(command, 0, command.Length);
            List<string[]> strings = new List<string[]>();
            while (true)
            {
                int bytesRead;
                try
                {
                    bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length, cts.Token);
                }
                catch (Exception ex)
                {
                    Variable.ListAddLog(2, $"HandleClientAsyncRealTimeData: {ex.Message}");
                    break;
                }

                if (bytesRead == 0)
                {
                    Variable.ListAddLog(1, "Client DisConnected.");
                    break;
                }

                string[] result = StringLib.GetStringFromByteArrayByEncoding(buffer, 0, buffer.Length - 1, Encoding.ASCII).Split('=');

                if (result[0].Contains("ERROR"))
                {
                    Variable.ListAddLog(2, $"HandleClientAsyncRealTimeData,Received: {result[1].Substring(0, 5)}");
                    break;
                }

                if (result[0].Contains("ACK"))
                {
                    continue;
                }

                string PsetName = result[1].Split(',')[1].Replace(";002", "");

                Variable.deviceParameters = new DeviceParameter()
                {
                    PsetName = PsetName,
                    Nm = ExtractValueAfterTarget(result[3], "7"),
                    Angle = ExtractValueAfterTarget(result[3], "3"),
                    NmDownLimit = ExtractValueAfterTarget(result[3], "4"),
                    NmUpperLimit = ExtractValueAfterTarget(result[3], "5"),
                    AngleDownLimit = ExtractValueAfterTarget(result[3], "9"),
                    AngleUpperLimit = ExtractValueAfterTarget(result[3], "10"),
                    Rotation_Angle = ExtractValueAfterTarget(result[3], "14"),
                    Rotate_Speed = ExtractValueAfterTarget(result[3], "2")
                };

                DataReceived();

                break;

            }
        }
        public static string ExtractValueAfterTarget(string input, string target)
        {
            // 去掉末尾的分号
            input = input.TrimEnd(';');

            // 分割字符串成数组
            string[] parts = input.Split(',');

            // 遍历数组查找目标值
            for (int i = 4; i < parts.Length; i++)
            {
                if (parts[i] == target && i + 1 < parts.Length)
                {
                    return parts[i + 1];
                }
            }

            // 如果找不到目标值，返回 null 或空字符串
            return "null";
        }

        #endregion

        #region 通用写入螺丝机设备状态

        public async Task GeneralWriteState(TcpClient Client, string Command)
        {
            var buffer = new byte[1024];
            var stream = Client.GetStream();
            byte[] data = ByteArrayLib.GetByteArrayFromHexString(Command);
            await stream.WriteAsync(data, 0, data.Length);

            int bytesRead = 0;
            try
            {
                bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length, cts.Token);
            }
            catch (Exception ex)
            {
                Variable.ListAddLog(2, $"GeneralWriteState Error: {ex.Message}");
            }

            if (bytesRead == 0)
            {
                Variable.ListAddLog(1, "GeneralWriteState:Client DisConnected.");
            }
            string[] result = StringLib.GetStringFromByteArrayByEncoding(buffer, 0, buffer.Length - 1, Encoding.ASCII).Split('=');

            if (result[0].Contains("ERROR"))
            {
                Variable.ListAddLog(2, $"GeneralWriteState:ERROR: {result[1].Substring(0, 5)}");
            }
            if (result[0].Contains("ACK"))
            {
                Variable.ListAddLog(0, "Execute GeneralWriteState SuccessFull:" + Command);
                OnDataReceived();
            }

            try
            {
                Client?.Close();
                cts?.Cancel();
            }
            catch (Exception ex)
            {
                Variable.ListAddLog(2, $"GeneralWriteState Error: {ex.Message}");
            }
        }
        #endregion

        #region 事件

        //namespace Communication
        //    {
        //        public class TClient
        //        {
        //            public TcpClient client = new TcpClient();
        //            public bool listening;

        //            // 1. 定义事件处理程序委托类型
        //            public delegate void DataReceivedEventHandler(object sender, DataReceivedEventArgs e);

        //            // 2. 定义事件
        //            public event DataReceivedEventHandler DataReceived;

        //            // 3. 定义事件数据类
        //            public class DataReceivedEventArgs : EventArgs
        //            {
        //                public string Message { get; }

        //                public DataReceivedEventArgs(string message)
        //                {
        //                    Message = message;
        //                }
        //            }

        //            public async void TcpClienttConnect(string ipAddress, int port, string Command)
        //            {
        //                client = new TcpClient();
        //                try
        //                {
        //                    await client.ConnectAsync(ipAddress, port);
        //                    Variable.DgvAddLog($"Connected to {ipAddress}:{port}");
        //                    listening = true;
        //                    switch (Command)
        //                    {
        //                        case "02 00 00 00 05 52 30 32 30 31 03":
        //                            _ = HandleClientAsync(client, Command); // 异步处理客户端连接
        //                            break;
        //                        default:
        //                            break;
        //                    }
        //                }
        //                catch (Exception ex)
        //                {
        //                    Variable.DgvAddLog($"Error connecting to {ipAddress}:{port} - {ex.Message}");
        //                }
        //            }

        //            private async Task HandleClientAsync(TcpClient client, string Command)
        //            {
        //                var buffer = new byte[1024];
        //                var stream = client.GetStream();
        //                byte[] data = ByteArrayLib.GetByteArrayFromHexString(Command);
        //                await stream.WriteAsync(data, 0, data.Length);
        //                while (true)
        //                {
        //                    int bytesRead;
        //                    try
        //                    {
        //                        bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
        //                    }
        //                    catch (Exception ex)
        //                    {
        //                        Variable.DgvAddLog($"Error reading from client: {ex.Message}");
        //                        break;
        //                    }

        //                    if (bytesRead == 0)
        //                    {
        //                        Variable.DgvAddLog("Client DisConnected.");
        //                        break;
        //                    }

        //                    var message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
        //                    Variable.DgvAddLog($"Received: {message}");

        //                    // 4. 触发事件
        //                    OnDataReceived(new DataReceivedEventArgs(message));
        //                }

        //                client.Close();
        //            }

        //            // 5. 触发事件的方法
        //            protected virtual void OnDataReceived(DataReceivedEventArgs e)
        //            {
        //                DataReceived?.Invoke(this, e); // 如果有订阅者，触发事件
        //            }
        //        }
        //    }

        #endregion

    }
}
