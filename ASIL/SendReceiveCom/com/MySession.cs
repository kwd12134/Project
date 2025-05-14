using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;

namespace SendReceiveCom.com
{
    // 我的会话
    public class MySession
	{

		public void Send(byte[] buf)
		{
			bool flag = buf != null;
			if (flag)
			{
				this.TcpSocket.Send(buf);
			}
		}


		public string GetIp()
		{
			IPEndPoint clientipe = (IPEndPoint)this.TcpSocket.RemoteEndPoint;
			return clientipe.Address.ToString();
		}


		public void Close()
		{
			this.TcpSocket.Shutdown(SocketShutdown.Both);
		}


		public byte[] GetBuffer(int startIndex, int size)
		{
			byte[] buf = new byte[size];
			this.m_Buffer.CopyTo(startIndex, buf, 0, size);
			this.m_Buffer.RemoveRange(0, startIndex + size);
			return buf;
		}


		public void AddQueue(byte[] buffer)
		{
			this.m_Buffer.AddRange(buffer);
		}


		public void ClearQueue()
		{
			this.m_Buffer.Clear();
		}


		public Socket TcpSocket { get; set; }


        public List<byte> m_Buffer { get; set; } = new List<byte>();

	}
}
