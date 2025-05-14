
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;
using System.Net.Sockets;
using System.Threading;
using CurrentVariable;
using XmlUpper;
using System.Globalization;
namespace MCMQ
{
    public class McmqServer
    {

        private int handle = 0;

        private StringBuilder replyQueueHandle = new StringBuilder(100);

        private StringBuilder QueueHandles = new StringBuilder(100);

        /// <summary>
        /// MCMQ依赖注入
        /// </summary>
        private readonly IMcmq Mcmq;

        /// <summary>
        /// 日志方法
        /// </summary>
        private readonly Action<int, string> AddLog;

        public McmqServer(IMcmq mcmq, Action<int, string> addLog)
        {
            Mcmq = mcmq;
            AddLog = addLog;
        }

        #region 事件

        public event Action<string> McmqReceiveEvent;

        protected void OnMcmqReceive(string data)
        {
            McmqReceiveEvent?.Invoke(data);
        }
        #endregion

        public bool IsConnected { get; set; } = false;
        public async void McmqConnet(string ip, int port, string SenderQueue, string ReceiveQueue)
        {

            await Task.Run(() =>
            {
                int result = Mcmq.ConnectMCMQ(ref handle, ip, port.ToString());
                if (result == 0)
                {
                    AddLog(0, $"连接MCMQ服务器成功:{ip}:{port}");
                    //开启一个回复查询的队列                                                                                              //开启一个发送消息的队列 
                    if (Mcmq.OpenQueue(handle, ReceiveQueue, 1000000, 5000, 500000, 2500, 0, 0, ReceiveQueue, replyQueueHandle, 0) == 0 && Mcmq.OpenQueue(handle, SenderQueue, 1000000, 5000, 500000, 2500, 0, 0, SenderQueue, QueueHandles, 0) == 0)
                    {
                        AddLog(0, $"成功开启发送消息队列:{SenderQueue},成功开启回复查询队列:{ReceiveQueue}");
                        IsConnected = true;
                    }
                    else
                    {
                        AddLog(2, $"开启发送消息队列失败:{SenderQueue},开启回复查询队列失败:{ReceiveQueue}");
                        IsConnected = false;
                    }
                }
                else
                {
                    AddLog(2, $"连接MCMQ服务器失败:{ip}:{port}");
                }
            });
        }

        public async void McmqSend(string SenderQueue, string ReceiveQueue, string data)
        {
            await Task.Run(() =>
            {
                if (!IsConnected)
                {
                    AddLog(2, "未连接MCMQ服务器与队列发送与队列查询");
                    return;
                }
                byte[] dataByte = Encoding.UTF8.GetBytes(data);

                string correlationId = Guid.NewGuid().ToString("N").ToUpper();

                int result = Mcmq.PutQueue(handle, SenderQueue, ReceiveQueue, correlationId, dataByte, dataByte.Length);
                if (result == 0)
                {
                    AddLog(0, $"发送消息到队列:{SenderQueue},消息内容:\r\n{data}");
                }
                else
                {
                    AddLog(2, $"发送消息失败: {result}");
                }
            });
        }

        private byte[] replyData = new byte[1024 * 20]; // 用于接收的缓冲区

        public async void McmqReceive(string ReceiveQueue)
        {
            await Task.Run(() =>
            {
                if (!IsConnected)
                {
                    AddLog(2, "未连接MCMQ服务器与队列发送与队列查询");
                    return;
                }
                StringBuilder timeStamp = new StringBuilder(16);
                StringBuilder correlationId = new StringBuilder(32);
                int dataLength = 0;

                string receivedMessage;

                int cnt = 3; // 重试次数

                int result;

                do
                {
                    timeStamp.Clear();
                    correlationId.Clear();
                    dataLength = 0;
                    Thread.Sleep(100); // 等待100毫秒
                    // 从队列中接收消息    因为我们是在发送消息的时候指定了回复队列，所以这里可以直接从回复队列中接收消息            在实际现场中有第三方系统发送消息到我们的队列，我们需要从reunknow队列中接收消息
                    result = Mcmq.GetQueue(handle, QueueHandles.ToString(), ReceiveQueue, timeStamp, correlationId, 2500, replyData.Length, replyData, ref dataLength);
                    if (result == 0 && dataLength > 0)
                    {
                        receivedMessage = Encoding.UTF8.GetString(replyData, 0, dataLength);
                        GlobalVariable.AddLog(0, $"接收队列:{ReceiveQueue},接收到消息:\r\n{receivedMessage}");
                        return;
                    }
                } while (--cnt != 0);
                AddLog(2, $"接收消息失败: {result}");
            });
        }

        public async void McmqClose()
        {
            await Task.Run(() =>
            {
                if (!IsConnected)
                {
                    GlobalVariable.AddLog(2, "未连接MCMQ服务器与队列发送与队列查询");
                    return;
                }
                Mcmq.CloseQueue(handle, QueueHandles.ToString());
                AddLog(0, $"关闭发送消息队列:{QueueHandles}");
                Mcmq.CloseQueue(handle, replyQueueHandle.ToString());
                AddLog(0, $"关闭回复查询队列:{replyQueueHandle}");
                Mcmq.Disconnect(ref handle);
                AddLog(0, $"断开MCMQ服务器");
            });
        }
    }
}
