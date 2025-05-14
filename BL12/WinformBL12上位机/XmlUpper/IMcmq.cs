using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlUpper
{
    public interface IMcmq
    {
        int ConnectMCMQ(ref int handle, string ip, string port);

        int OpenQueue(int handle, string queueName, int maxSize, int maxCount, int alarmSize, int alarmCount,
                      int persist, int longQueue, string queueDesc, StringBuilder queueHandle, int queueType);

        int PutQueue(int handle, string queueName, string replyQueueName, string correlationId, byte[] data, int length);

        int GetQueue(int handle, string queueHandle, string queueName, StringBuilder timeStamp, StringBuilder correlationId,
                     int timeout, int bufferLength, byte[] data, ref int dataLength);

        int CloseQueue(int handle, string queueHandle);

        int Disconnect(ref int handle);
    }
}
