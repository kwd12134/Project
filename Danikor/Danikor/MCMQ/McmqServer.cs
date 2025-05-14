using Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Helper;
using System.Xml;
using System.Net.Sockets;
using System.Threading;

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
        private readonly IMcmq _Mcmq;

        public McmqServer(IMcmq mcmq)
        {
            _Mcmq = mcmq;
        }

        #region 事件

        public event Action<string> McmqReceiveEvent;

        protected void OnMcmqReceiveVerifySNEvent(string data)
        {
            McmqReceiveEvent?.Invoke(data);
        }

        public event Action<string> McmqReceiveStationEvent;

        protected void OnMcmqReceiveStationEvent(string data)
        {
            McmqReceiveStationEvent?.Invoke(data);
            
        }

        #endregion


        public bool IsConnected { get; set; } = false;
        public async void McmqConnet(string ip, int port, string SenderQueue, string ReceiveQueue)
        {

            await Task.Run((Action)(() =>
            {
                int result = _Mcmq.ConnectMCMQ(ref handle, ip, port.ToString());
                if (result == 0)
                {
                    Variable.ListAddLog(0, $"连接MCMQ服务器成功:{ip}:{port}");
                    //开启一个回复查询的队列                                                                                              //开启一个发送消息的队列 
                    if (_Mcmq.OpenQueue(handle, ReceiveQueue, 1000000, 5000, 500000, 2500, 0, 0, ReceiveQueue, replyQueueHandle, 0) == 0 && _Mcmq.OpenQueue(handle, SenderQueue, 1000000, 5000, 500000, 2500, 0, 0, SenderQueue, QueueHandles, 0) == 0)
                    {
                        Variable.ListAddLog(0, $"成功开启发送消息队列:{SenderQueue},成功开启回复查询队列:{ReceiveQueue}");
                        IsConnected = true;
                    }
                    else
                    {
                        Variable.ListAddLog(2, $"开启发送消息队列失败:{SenderQueue},开启回复查询队列失败:{ReceiveQueue}");
                        IsConnected = false;
                    }
                }
                else
                {
                    Variable.ListAddLog(2, $"连接MCMQ服务器失败:{ip}:{port}");
                }
            }));
        }

        public async void McmqSend(string SenderQueue, string ReceiveQueue, string data)
        {
            await Task.Run((Action)(() =>
            {
                if (!IsConnected)
                {
                    Variable.ListAddLog(2, "未连接MCMQ服务器与队列发送与队列查询");
                    return;
                }
                byte[] dataByte = Encoding.UTF8.GetBytes(data);

                string correlationId = Guid.NewGuid().ToString("N").ToUpper();

                int result = _Mcmq.PutQueue(handle, SenderQueue, ReceiveQueue, correlationId, dataByte, dataByte.Length);
                if (result == 0)
                {
                    Variable.ListAddLog(0, $"发送消息到队列:{SenderQueue},消息内容:\r\n{data}");
                }
                else
                {
                    Variable.ListAddLog(2, $"发送消息失败: {result}");
                }
            }));
        }

        private byte[] replyData = new byte[1024 * 20]; // 用于接收的缓冲区

        public async void McmqReceiveVerifySN(string ReceiveQueue)
        {
            await Task.Run(() =>
            {
                if (!IsConnected)
                {
                    Variable.ListAddLog(2, "未连接MCMQ服务器与队列发送与队列查询");
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
                    result = _Mcmq.GetQueue(handle, replyQueueHandle.ToString(), ReceiveQueue, timeStamp, correlationId, 2500, replyData.Length, replyData, ref dataLength);
                    if (result == 0 && dataLength > 0)
                    {
                        receivedMessage = Encoding.UTF8.GetString(replyData, 0, dataLength);
                        Variable.ListAddLog(0, $"接收队列:{ReceiveQueue},接收到消息:\r\n{receivedMessage}");
                        OnMcmqReceiveVerifySNEvent(receivedMessage);
                        return;
                    }
                } while (--cnt != 0);
                Variable.ListAddLog(2, $"接收MCMQ查询消息失败: {result}");
            });
        }

        public async void McmqReceiveStation(string ReceiveQueue)
        {
            await Task.Run(() =>
            {
                if (!IsConnected)
                {
                    Variable.ListAddLog(2, "未连接MCMQ服务器与队列发送与队列查询");
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
                    result = _Mcmq.GetQueue(handle, replyQueueHandle.ToString(), ReceiveQueue, timeStamp, correlationId, 2500, replyData.Length, replyData, ref dataLength);
                    if (result == 0 && dataLength > 0)
                    {
                        receivedMessage = Encoding.UTF8.GetString(replyData, 0, dataLength);
                        Variable.ListAddLog(0, $"接收队列:{ReceiveQueue},接收到消息:\r\n{receivedMessage}");
                        OnMcmqReceiveStationEvent(receivedMessage);
                        return;
                    }
                } while (--cnt != 0);
                Variable.ListAddLog(2, $"接收消息失败: {result}");
            });
        }

        public async void McmqClose()
        {
            await Task.Run((Action)(() =>
            {
                if (!IsConnected)
                {
                    Variable.ListAddLog(2, "未连接MCMQ服务器与队列发送与队列查询");
                    return;
                }
                _Mcmq.CloseQueue(handle, QueueHandles.ToString());
                Variable.ListAddLog(0, $"关闭发送消息队列:{QueueHandles}");
                _Mcmq.CloseQueue(handle, replyQueueHandle.ToString());
                Variable.ListAddLog(0, $"关闭回复查询队列:{replyQueueHandle}");
                _Mcmq.Disconnect(ref handle);
                Variable.ListAddLog(0, $"断开MCMQ服务器");
                IsConnected = false;
            }));
        }
    }
}
