using System;
using System.IO.Ports;
using System.Windows.Forms;

namespace SendReceiveCom
{
	// Token: 0x02000006 RID: 6
	internal class OpenSP
	{

		public bool OpenPort(string portName, int baud, string stopBits, int dataBits, string parity)
		{
			try
			{
				this.SP.PortName = portName;
				this.SP.BaudRate = baud;
				if (!(stopBits == "1"))
				{
					if (!(stopBits == "1.5"))
					{
						if (stopBits == "2")
						{
							this.SP.StopBits = StopBits.Two;
						}
					}
					else
					{
						this.SP.StopBits = StopBits.OnePointFive;
					}
				}
				else
				{
					this.SP.StopBits = StopBits.One;
				}
				this.SP.DataBits = dataBits;
				if (!(parity == "None"))
				{
					if (!(parity == "Even"))
					{
						if (!(parity == "Odd"))
						{
							if (!(parity == "Mark"))
							{
								if (parity == "Space")
								{
									this.SP.Parity = Parity.Space;
								}
							}
							else
							{
								this.SP.Parity = Parity.Mark;
							}
						}
						else
						{
							this.SP.Parity = Parity.Odd;
						}
					}
					else
					{
						this.SP.Parity = Parity.Even;
					}
				}
				else
				{
					this.SP.Parity = Parity.None;
				}
				this.SP.ReadTimeout = -1;
				try
				{
					this.SP.Open();
					return true;
				}
				catch
				{
					MessageBox.Show("无法打开串口", "出错了", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message, "出错了", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			return false;
		}


		public bool ClosePort()
		{
			try
			{
				this.SP.Close();
				return true;
			}
			catch (Exception )
			{
			}
			return false;
		}


		public SerialPort SP = new SerialPort();
	}
}
