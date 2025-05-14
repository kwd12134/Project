using System;
using System.Collections.Generic;
using System.IO;

namespace SendReceiveCom
{

	public static class Common
	{

		public static void GetCheck(int lng, ref byte[] ombuffer, string CheckMode, byte EndByte)
		{
			int i = 0;
			if (!(CheckMode == "0"))
			{
				if (!(CheckMode == "1"))
				{
					if (CheckMode == "2")
					{
						ombuffer[lng] = EndByte;
					}
				}
				else
				{
					byte lo = 0;
					for (int j = 0; j < lng; j++)
					{
						lo += ombuffer[i];
						i++;
					}
					ombuffer[i] = lo;
					ombuffer[i + 1] = EndByte;
				}
			}
			else
			{
				byte hi = byte.MaxValue;
				byte lo = byte.MaxValue;
				for (int j = 0; j < lng; j++)
				{
					lo ^= ombuffer[i];
					for (int k = 0; k < 8; k++)
					{
						byte c = lo;
						byte c2 = hi;
						lo = (byte)(lo >> 1);
						hi = (byte)(hi >> 1);
						bool flag = (c2 & 1) > 0;
						if (flag)
						{
							lo |= 128;
						}
						bool flag2 = (c & 1) > 0;
						if (flag2)
						{
							hi ^= 160;
							lo ^= 1;
						}
					}
					i++;
				}
				ombuffer[i] = lo;
				ombuffer[i + 1] = hi;
				ombuffer[i + 2] = EndByte;
			}
		}


		public static bool CheckSum(int lng, byte[] ombuffer)
		{
			int i = 0;
			byte hi = byte.MaxValue;
			byte lo = byte.MaxValue;
			bool flag = lng < 4;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				byte c;
				byte c2;
				for (int j = 0; j < lng - 2; j++)
				{
					lo ^= ombuffer[i];
					for (int k = 0; k < 8; k++)
					{
						c = lo;
						c2 = hi;
						lo = (byte)(lo >> 1);
						hi = (byte)(hi >> 1);
						bool flag2 = (c2 & 1) > 0;
						if (flag2)
						{
							lo |= 128;
						}
						bool flag3 = (c & 1) > 0;
						if (flag3)
						{
							hi ^= 160;
							lo ^= 1;
						}
					}
					i++;
				}
				c = ombuffer[i];
				i++;
				c2 = ombuffer[i];
				bool flag4 = c == lo && c2 == hi;
				result = flag4;
			}
			return result;
		}


		public static List<string> LoadFile(string filename, out string ErrorString)
		{
			ErrorString = string.Empty;
			List<string> FileData = new List<string>();
			StreamReader myStream = null;
			bool flag = !File.Exists(filename);
			List<string> result;
			if (flag)
			{
				ErrorString = "找不到配置文件";
				result = FileData;
			}
			else
			{
				try
				{
					myStream = new StreamReader(filename);
					bool endOfStream;
					do
					{
						string sLine = myStream.ReadLine();
						FileData.Add(sLine);
						endOfStream = myStream.EndOfStream;
					}
					while (!endOfStream);
				}
				catch (Exception ex)
				{
					ErrorString = ex.Message;
				}
				finally
				{
					myStream.Close();
				}
				result = FileData;
			}
			return result;
		}


		public static string SaveFile(string filename, List<string> FileData)
		{
			string ErrorString = string.Empty;
			FileStream fs = null;
			StreamWriter m_streamWriter = null;
			try
			{
				fs = new FileStream(filename, FileMode.OpenOrCreate, FileAccess.Write);
				m_streamWriter = new StreamWriter(fs);
				foreach (string str in FileData)
				{
					m_streamWriter.WriteLine(str);
				}
			}
			catch (Exception ex)
			{
				ErrorString = ex.Message;
			}
			finally
			{
				m_streamWriter.Close();
				fs.Close();
			}
			return ErrorString;
		}
	}
}
