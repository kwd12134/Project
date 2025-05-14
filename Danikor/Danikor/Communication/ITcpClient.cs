using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static Communication.TClient;

namespace Communication
{
    /// <summary>
    /// tcp客户端接口
    /// </summary>
    public interface ITcpClient
    {
        void TcpClienttConnect(string ipAddress, int port, DeviceEnums DeviceCommandEnum , string Command, int Count = 0);

        event Action Complete;

        event Action DataReceived;

        event Action RefreshChart;

        event Action<RealTimeDataEventArgs> RealTimeData;

        TcpClient Tcp_Client { get; set; }

        CancellationTokenSource cts { get; set; }

        Timer heartbeatTimer { get; set; }
    }
}
