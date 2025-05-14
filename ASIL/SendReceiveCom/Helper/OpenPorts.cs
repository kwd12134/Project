using System;
using System.Windows.Forms;

namespace SendReceiveCom
{

	internal class OpenPorts
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
							this.SP.StopBits = 2;
						}
					}
					else
					{
						this.SP.StopBits = 1;
					}
				}
				else
				{
					this.SP.StopBits = 0;
				}
				this.SP.DataBits = (byte)dataBits;
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
									this.SP.Parity = 4;
								}
							}
							else
							{
								this.SP.Parity = 3;
							}
						}
						else
						{
							this.SP.Parity = 1;
						}
					}
					else
					{
						this.SP.Parity = 2;
					}
				}
				else
				{
					this.SP.Parity = 0;
				}
				this.SP.SetTimeOut(-1);
				try
				{
					bool flag = this.SP.Open() == 0;
					if (flag)
					{
						return true;
					}
					MessageBox.Show("无法打开串口", "出错了", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
			catch
			{
			}
			return false;
		}


		public CommPort SP { get; set; } = new CommPort();
	}
}
