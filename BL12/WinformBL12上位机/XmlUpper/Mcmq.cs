using System;
using System.Runtime.InteropServices;
using System.Text;
using XmlUpper;
namespace MCMQ
{
    public class Mcmq : IMcmq
    {
        public const string DLL_NAME = "MCMQWin32Api32.dll";

        [DllImport(DLL_NAME, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        private static extern int connectMCMQ(ref int handle, string ip, string port);

        [DllImport(DLL_NAME, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        private static extern int openQueue(int handle, string queueName, int maxSize, int maxCount, int alarmSize, int alarmCount,
                                            int persist, int longQueue, string queueDesc, StringBuilder queueHandle, int queueType);

        [DllImport(DLL_NAME, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        private static extern int putQueue(int handle, string queueName, string replyQueueName, string correlationId, byte[] data, int length);

        [DllImport(DLL_NAME, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        private static extern int getQueue(int handle, string queueHandle, string queueName, StringBuilder timeStamp, StringBuilder correlationId,
                                           int timeout, int bufferLength, byte[] data, ref int dataLength);

        [DllImport(DLL_NAME, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        private static extern int closeQueue(int handle, string queueHandle);

        [DllImport(DLL_NAME, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        private static extern int disconnect(ref int handle);

        public int ConnectMCMQ(ref int handle, string ip, string port)
            => Mcmq.connectMCMQ(ref handle, ip, port);

        public int OpenQueue(int handle, string queueName, int maxSize, int maxCount, int alarmSize, int alarmCount, int persist, int longQueue, string queueDesc, StringBuilder queueHandle, int queueType)
            => Mcmq.openQueue(handle, queueName, maxSize, maxCount, alarmSize, alarmCount, persist, longQueue, queueDesc, queueHandle, queueType);

        public int PutQueue(int handle, string queueName, string replyQueueName, string correlationId, byte[] data, int length)
            => Mcmq.putQueue(handle, queueName, replyQueueName, correlationId, data, length);

        public int GetQueue(int handle, string queueHandle, string queueName, StringBuilder timeStamp, StringBuilder correlationId, int timeout, int bufferLength, byte[] data, ref int dataLength)
            => Mcmq.getQueue(handle, queueHandle, queueName, timeStamp, correlationId, timeout, bufferLength, data, ref dataLength);

        public int CloseQueue(int handle, string queueHandle)
            => Mcmq.closeQueue(handle, queueHandle);

        public int Disconnect(ref int handle)
            => Mcmq.disconnect(ref handle);
    }
}
