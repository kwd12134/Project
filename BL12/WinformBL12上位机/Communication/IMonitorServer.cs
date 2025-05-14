using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Communication
{
    public interface IMonitorServer
    {
        Socket socketSever { get; set; }

        Dictionary<string, Socket> CurrentClientlist { get; set; }

        event Action<string> GetRequestDataHandle;

        void OpenServer(string IP, string Port, Action<int, string> addLog);

        void SenderClient(string Result);

        void CloseServer();
    }
}
