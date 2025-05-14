using System;
using System.Runtime.InteropServices;
using System.Text;
using McmqApi;

namespace SendReceiveCom.com
{

	internal class MCMQClass
	{

		[DllImport("E:\\BaiduNetdiskDownload\\ASIL\\ASIL\\ASIL_20230506\\SendReceiveCom\\SendReceiveCom\\Properties\\MCMQIPC.dll\"MCMQIPC.dll")]
		private static extern string Mcmqn(string[] args);


		private string Mcmqn()
		{
			cMcmqCommApi mcmq = new cMcmqCommApi();
			string sendQueue = "CIMTEST123";
			string replyQueue = "CIMRLY123";
			Console.WriteLine("start to Connect MCMQ");
			string returnCode = mcmq.connectMCMQ("10.12.XXX.XXX", 7600, false);
			bool flag = !returnCode.Equals("0000");
			if (flag)
			{
				Console.WriteLine("Connect MCMQ Error Code=" + returnCode);
			}
			else
			{
				Console.WriteLine("Connect MCMQ Success ...");
			}
			mcmq.openQueue(replyQueue, 1024000, 1000, 1000, 1000, 140, false, "Q的描述");
			mcmq.cleanQueue(mcmq.strQueueHandle);
			string sendMessage = "XXXXXX";
			byte[] message = Encoding.UTF8.GetBytes(sendMessage);
			returnCode = mcmq.putQueue(sendQueue, message, replyQueue, "CorrelationId", cMcmqCommApi.McmqMsgEncrypted.NONE);
			Console.WriteLine("Send MCMQ Success ..." + sendQueue + ",sendMessage= " + sendMessage);
			returnCode = mcmq.getQueue(mcmq.strQueueHandle, 6000, cMcmqCommApi.McmqMsgEncrypted.NONE);
			byte[] returnByteMessage = mcmq.getBinMessage;
			string returnMessage = Encoding.UTF8.GetString(returnByteMessage);
			Console.WriteLine("returnMessage returnCode=" + returnCode + " ,returnMessage=" + returnMessage);
			mcmq.disconnect();
			return "";
		}
	}
}
