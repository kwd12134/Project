using System;
using System.Runtime.InteropServices;

namespace SendReceiveCom
{

	public class CommPort
	{

		[DllImport("kernel32")]
		private static extern int CreateFile(string lpFileName, uint dwDesiredAccess, int dwShareMode, int lpSecurityAttributes, int dwCreationDisposition, int dwFlagsAndAttributes, int hTemplateFile);


		[DllImport("kernel32")]
		private static extern bool GetCommState(int hFile, ref CommPort.DCB lpDCB);


		[DllImport("kernel32")]
		private static extern bool SetCommState(int hFile, ref CommPort.DCB lpDCB);


		[DllImport("kernel32")]
		private static extern bool GetCommTimeouts(int hFile, ref CommPort.COMMTIMEOUTS lpCommTimeouts);


		[DllImport("kernel32")]
		private static extern bool SetCommTimeouts(int hFile, ref CommPort.COMMTIMEOUTS lpCommTimeouts);


		[DllImport("kernel32")]
		private static extern bool ReadFile(int hFile, byte[] lpBuffer, int nNumberOfBytesToRead, ref int lpNumberOfBytesRead, ref CommPort.OVERLAPPED lpOverlapped);


		[DllImport("kernel32")]
		private static extern bool WriteFile(int hFile, byte[] lpBuffer, int nNumberOfBytesToWrite, ref int lpNumberOfBytesWritten, ref CommPort.OVERLAPPED lpOverlapped);


		[DllImport("kernel32", SetLastError = true)]
		private static extern bool FlushFileBuffers(int hFile);


		[DllImport("kernel32", SetLastError = true)]
		private static extern bool PurgeComm(int hFile, uint dwFlags);


		[DllImport("kernel32")]
		private static extern bool CloseHandle(int hObject);


		[DllImport("kernel32")]
		private static extern uint GetLastError();


		internal void SetDcbFlag(int whichFlag, int setting, CommPort.DCB dcb)
		{
			setting <<= whichFlag;
			bool flag = whichFlag == 4 || whichFlag == 12;
			uint num;
			if (flag)
			{
				num = 3u;
			}
			else
			{
				bool flag2 = whichFlag == 15;
				if (flag2)
				{
					num = 131071u;
				}
				else
				{
					num = 1u;
				}
			}
			dcb.flags &= ~(num << whichFlag);
			dcb.flags |= (uint)setting;
		}


		public int SetTimeOut(int ReadTimeout)
		{
			bool flag = this.hComm == -1;
			int result;
			if (flag)
			{
				result = -1;
			}
			else
			{
				CommPort.COMMTIMEOUTS ctoCommPort = default(CommPort.COMMTIMEOUTS);
				CommPort.GetCommTimeouts(this.hComm, ref ctoCommPort);
				ctoCommPort.ReadTotalTimeoutConstant = ReadTimeout;
				ctoCommPort.ReadTotalTimeoutMultiplier = 0;
				ctoCommPort.WriteTotalTimeoutMultiplier = 0;
				ctoCommPort.WriteTotalTimeoutConstant = 0;
				CommPort.SetCommTimeouts(this.hComm, ref ctoCommPort);
				result = 0;
			}
			return result;
		}


		public int Open()
		{
			CommPort.DCB dcb = default(CommPort.DCB);
			this.hComm = CommPort.CreateFile(this.PortName, 3221225472u, 0, 0, 3, 0, 0);
			bool flag = this.hComm == -1;
			int result;
			if (flag)
			{
				result = -1;
			}
			else
			{
				CommPort.GetCommState(this.hComm, ref dcb);
				dcb.DCBlength = Marshal.SizeOf(dcb);
				dcb.BaudRate = this.BaudRate;
				dcb.flags = 0u;
				dcb.ByteSize = this.DataBits;
				dcb.StopBits = this.StopBits;
				dcb.Parity = this.Parity;
				this.SetDcbFlag(0, 1, dcb);
				this.SetDcbFlag(1, (this.Parity == 0) ? 0 : 1, dcb);
				this.SetDcbFlag(2, 0, dcb);
				this.SetDcbFlag(3, 0, dcb);
				this.SetDcbFlag(4, 0, dcb);
				this.SetDcbFlag(6, 0, dcb);
				this.SetDcbFlag(9, 1, dcb);
				this.SetDcbFlag(8, 0, dcb);
				this.SetDcbFlag(10, 0, dcb);
				this.SetDcbFlag(11, 0, dcb);
				this.SetDcbFlag(12, 0, dcb);
				this.SetDcbFlag(14, 0, dcb);
				dcb.wReserved = 0;
				dcb.XonLim = 0;
				dcb.XoffLim = 0;
				dcb.XonChar = 0;
				dcb.XoffChar = 0;
				dcb.ErrorChar = 0;
				dcb.EofChar = 0;
				dcb.EvtChar = 0;
				dcb.wReserved1 = 0;
				bool flag2 = !CommPort.SetCommState(this.hComm, ref dcb);
				if (flag2)
				{
					result = -2;
				}
				else
				{
					this.Opened = true;
					result = 0;
				}
			}
			return result;
		}


		public void Close()
		{
			bool flag = this.hComm != -1;
			if (flag)
			{
				CommPort.CloseHandle(this.hComm);
				this.Opened = false;
			}
		}


		public int Read(ref byte[] bytData, int ReadIndex, int NumBytes)
		{
			byte[] ReadData = new byte[NumBytes];
			bool flag = this.hComm != -1;
			int result;
			if (flag)
			{
				CommPort.OVERLAPPED ovlCommPort = default(CommPort.OVERLAPPED);
				int BytesRead = 0;
				CommPort.ReadFile(this.hComm, ReadData, NumBytes, ref BytesRead, ref ovlCommPort);
				for (int i = 0; i < NumBytes; i++)
				{
					bytData[i + ReadIndex] = ReadData[i];
				}
				result = BytesRead;
			}
			else
			{
				result = -1;
			}
			return result;
		}


		public int Write(byte[] WriteBytes, int WriteIndex, int intSize)
		{
			byte[] NewWriteBytes = new byte[intSize];
			for (int i = 0; i < intSize; i++)
			{
				NewWriteBytes[i] = WriteBytes[i + WriteIndex];
			}
			bool flag = this.hComm != -1;
			int result;
			if (flag)
			{
				CommPort.OVERLAPPED ovlCommPort = default(CommPort.OVERLAPPED);
				int BytesWritten = 0;
				CommPort.WriteFile(this.hComm, NewWriteBytes, intSize, ref BytesWritten, ref ovlCommPort);
				result = BytesWritten;
			}
			else
			{
				result = -1;
			}
			return result;
		}


		public void ClearReceiveBuf()
		{
			bool flag = this.hComm != -1;
			if (flag)
			{
				CommPort.PurgeComm(this.hComm, 10u);
			}
		}


		public void ClearSendBuf()
		{
			bool flag = this.hComm != -1;
			if (flag)
			{
				CommPort.PurgeComm(this.hComm, 5u);
			}
		}


		public string PortName;


		public int BaudRate = 9600;


		public byte DataBits = 8;


		public byte Parity = 0;


		public byte StopBits = 0;


		public bool Opened = false;


		private int hComm = -1;


		private const string DLLPATH = "kernel32";


		private const uint GENERIC_READ = 2147483648u;


		private const uint GENERIC_WRITE = 1073741824u;


		private const int OPEN_EXISTING = 3;


		private const int INVALID_HANDLE_VALUE = -1;


		private const int PURGE_RXABORT = 2;


		private const int PURGE_RXCLEAR = 8;


		private const int PURGE_TXABORT = 1;


		private const int PURGE_TXCLEAR = 4;


		public struct DCB
		{

			public int DCBlength;


			public int BaudRate;


			public uint flags;


			public ushort wReserved;


			public ushort XonLim;


			public ushort XoffLim;


			public byte ByteSize;


			public byte Parity;


			public byte StopBits;


			public byte XonChar;


			public byte XoffChar;


			public byte ErrorChar;


			public byte EofChar;


			public byte EvtChar;


			public ushort wReserved1;
		}


		private struct COMMTIMEOUTS
		{

			public int ReadIntervalTimeout;


			public int ReadTotalTimeoutMultiplier;


			public int ReadTotalTimeoutConstant;


			public int WriteTotalTimeoutMultiplier;


			public int WriteTotalTimeoutConstant;
		}


		private struct OVERLAPPED
		{

			public int Internal;


			public int InternalHigh;


			public int Offset;


			public int OffsetHigh;


			public int hEvent;
		}
	}
}
