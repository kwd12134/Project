using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    
    public class Helper
    {

        //        TX：@Get_VEML6046_HEX#

        //[2024 - 04 - 15 09:35:08.511]
        //        RX：@FFFF,FFFF,FFFF,FFFF,FFFF#
        //[2024 - 04 - 15 09:35:19.425]
        //        TX：@Get_VEML6046_ASCII#

        //[2024 - 04 - 15 09:35:19.691]
        //        RX：@65535,65535,65535,65535,65535#
        //[2024-04-15 09:35:40.624]
        //        TX：@Set_VEML6046_Config(0x30,0x09)#

        //[2024-04-15 09:35:40.893]
        //        RX：@FFFF,FFFF,FFFF,FFFF,FFFF#

        private SerialPort _SerialPort;

        public bool IsOpen { get; set; } = false;

        public int[] Variableint { get; set; }

        public int SleepTime { get; set; } = 300;
        public double ReadTimeout { get; private set; } = 1000;

        public string Result_data { get; set; }

        public bool WriteRuqire()
        { 
            try
            {
                //this._SerialPort.Write("@Get_VEML6046_HEX#");/
                this._SerialPort.Write("@Get_VEML6046_HEX#");
            }
            catch (Exception)
            {
                return false;
            }
            return true;
            
        }

        public string Result_Data()
        {
            string data = null;

            //定义一个开始时间

            DateTime dateTime = DateTime.Now;

            while (IsOpen)
            {
                if (data == null)
                {
                    Thread.Sleep(SleepTime);
                    Result_data = this._SerialPort.ReadExisting();
                    data = Result_data;
                    if (Result_data == "")
                    {
                        return null;
                    }
                    Result_data = data.Replace("@", "").Replace("#", "");
                }
                else
                {
                    if (data.Length > 0)
                    {
                        break;
                    }
                    else if ((DateTime.Now - dateTime).TotalMilliseconds > this.ReadTimeout)
                    {
                        return null;
                    }
                }
            }
            return Result_data;
        }
        /// <summary>
        /// 分割字符串返回一个int数组
        /// </summary>
        /// <param name="hexString"></param>
        /// <returns></returns>
        public int[] ConvertHexStringToByteArray(string hexString)
        {

            // 按逗号分割字符串
            string[] Variablestring = hexString.Split(',');

            Variableint = new int[Variablestring.Length];

            for (int i = 0; i < Variablestring.Length; i++)
            {
                Variableint[i] = Convert.ToInt32(Variablestring[i], 16);
            }

            return Variableint;
        }

        /// <summary>
        /// 断开连接
        /// </summary>
        public  void DisConncet()
        {
            if (_SerialPort.IsOpen)
            {
                _SerialPort.Close();
            }
        }
        /// <summary>
        /// 连接串口
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool conncet(string name)
        {
            _SerialPort = new SerialPort(name);
            _SerialPort.BaudRate = 115200;
            _SerialPort.Parity = Parity.None;
            _SerialPort.StopBits = StopBits.One;
            _SerialPort.DataBits = 8;
            _SerialPort.Handshake = Handshake.None;
            if (!_SerialPort.IsOpen)
            {
                try
                {
                    _SerialPort.Open();
                }
                catch (Exception)
                {
                    return false;
                }
                IsOpen = true;
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 判断NG或者OK
        /// </summary>
        public bool Judge_OKorNG(int rmin,int rmax,int gmin ,int gmax,int bmin ,int bmax,int irmin,int irmax)
        {
                if (rmax>= Variableint[0] && rmin<= Variableint[0])
                {
                    if (gmax >= Variableint[1] && gmin <= Variableint[1])
                    {
                        if (bmax >= Variableint[2] && bmin <= Variableint[2])
                        {
                            if (irmax >= Variableint[3] && irmin <= Variableint[3])
                            {
                                return true;
                            }
                        }
                    }
                }
            return false;
        }



    }
}

