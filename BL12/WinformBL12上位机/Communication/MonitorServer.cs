using CurrentVariable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Communication
{
    public class MonitorServer : IMonitorServer
    {

        public Socket socketSever { get; set; }

        //创建字典集合，键是ClientIp,值是SocketClient
        public Dictionary<string, Socket> CurrentClientlist { get; set; } = new Dictionary<string, Socket>();

        public event Action<string> GetRequestDataHandle;

        protected void OnGetRequestDataHandle(string Data)
        {
            GetRequestDataHandle?.Invoke(Data);
        }

        public Action<int, string> AddLog;

        public async void OpenServer(string IP, string Port, Action<int, string> addLog)
        {
            AddLog = addLog;

            // 创建用于通信的套接字

            socketSever = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            // 绑定端口号
            IPEndPoint ipe = new IPEndPoint(IPAddress.Parse(IP), int.Parse(Port));

            try
            {
                socketSever.Bind(ipe);
            }
            catch (Exception ex)
            {
                // 写入日志
                AddLog(2, "服务器开启失败：" + ex.Message);
                return;
            }

            // 开始监听
            socketSever.Listen(10);

            // 异步监听客户端连接
            await AcceptClientsAsync(IP + ":" + Port);
        }

        private async Task AcceptClientsAsync(string ipport)
        {
            AddLog(0, "服务器监听端口开启成功:" + ipport);
            while (true)
            {
                Socket clientSocket = null;
                try
                {
                    clientSocket = await Task.Factory.FromAsync(socketSever.BeginAccept, socketSever.EndAccept, null);
                }
                catch (Exception)
                {
                    return;
                }

                // 处理客户端连接
                _ = HandleClientAsync(clientSocket);
            }
        }
        #region 处理客户端连接

        /// <summary>
        /// 异步处理客户端连接
        /// </summary>
        /// <param name="clientSocket"></param>
        /// <returns></returns>
        private async Task HandleClientAsync(Socket clientSocket)
        {
            string client = clientSocket.RemoteEndPoint.ToString();
            AddLog(0, $"客户端:{client}连接成功");

            CurrentClientlist.Add(client, clientSocket);

            try
            {
                await ReceiveMessageAsync(clientSocket);
            }
            catch (Exception ex)
            {
                AddLog(2, $"处理客户端 {client} 时发生错误: {ex.Message}");
            }
            finally
            {
                CurrentClientlist.Remove(client);
                AddLog(0, $"客户端:{client}断开连接");
            }
        }

        #endregion


        #region 异步接收消息

        private StringBuilder DataBuffer = new StringBuilder();

        /// <summary>
        /// 异步接收消息
        /// </summary>
        /// <param name="clientSocket"></param>
        /// <returns></returns>
        private async Task ReceiveMessageAsync(Socket clientSocket)
        {
            var buffer = new byte[1024];
            var receiveArgs = new SocketAsyncEventArgs();
            receiveArgs.SetBuffer(buffer, 0, buffer.Length);
            var tcs = new TaskCompletionSource<int>();

            //lambda表达式 事件处理接收

            receiveArgs.Completed += (s, e) =>
            {
                if (e.SocketError == SocketError.Success && e.BytesTransferred > 0)
                {
                    string result = null;
                   
                    if (JudgeDataIntact(clientSocket, ref result, e.Buffer, e.BytesTransferred) || result != null)
                    {
                        OnGetRequestDataHandle(result);
                        AddLog(0, $"收到来自 {clientSocket.RemoteEndPoint} 的消息: {result}");
                        tcs.SetResult(e.BytesTransferred);
                    }
                }
                else
                {
                    // 客户端断开连接
                    clientSocket.Close();
                    tcs.SetResult(0);
                }
            };

            while (true)
            {
                if (!clientSocket.ReceiveAsync(receiveArgs))
                {
                    tcs.SetResult(receiveArgs.BytesTransferred);
                }

                int bytesReceived = await tcs.Task;

                if (bytesReceived == 0)
                {
                    break;
                }

                tcs = new TaskCompletionSource<int>();
            }
        }

        #endregion
        /// <summary>
        /// 判断数据接收的完整性
        /// </summary>
        /// <param name="socket"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        private bool JudgeDataIntact(Socket socket, ref string result, byte[] buffer,int bytesRead)
        {
            string startTag = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>";

            string endTag = "</Request>";

            DataBuffer.Append(Encoding.UTF8.GetString(buffer));

            string receivedData = DataBuffer.ToString();
            int startIndex = 0;

            while ((startIndex = receivedData.IndexOf(startTag, startIndex)) != -1)
            {
                int endIndex = receivedData.IndexOf(endTag, startIndex);
                if (endIndex != -1)
                {
                    endIndex += endTag.Length;

                    string xmlData = receivedData.Substring(startIndex, endIndex - startIndex);

                    //如何数据粘包了,则抽离单独储存以便于下次数据拼接
                    string partial = receivedData.Substring(endIndex);

                    if (partial.Length > 0)
                    {
                        DataBuffer.Clear();
                        DataBuffer.Append(partial);
                    }
                    startIndex = 0;
                    result = xmlData;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        public void CloseServer()
        {
            if (socketSever.IsBound)
            {
                AddLog(0, "成功关闭服务器:");
                socketSever.Close();
            }
        }

        public void SenderClient(string Result)
        {
            if (CurrentClientlist.Count > 0)
            {
                AddLog(0, "发送内容：" + Result);

                byte[] send = Encoding.UTF8.GetBytes(Result);

                foreach (var item in CurrentClientlist.Keys)
                {
                    //获取Socket对象
                    string client = item.ToString();

                    CurrentClientlist[client]?.Send(send);
                }
            }
            else
            {
                AddLog(2, "客户端未连接,请检查");
            }
        }
    }
}
