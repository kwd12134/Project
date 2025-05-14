using CurrentVariable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Ports;
using System.Xml.Linq;
using System.Threading;
using System.Windows.Forms;

namespace BL12
{
    public class StaticMethod
    {
        /// <summary>
        /// 参数变量
        /// </summary>
        public static Variable variable { get; set; }

        public static SerialPort _SerialPort { get; set; }

        public static SimpleHybirdLock simpleHybirdLock { get; set; } = new SimpleHybirdLock();

        public static int SleepTime { get; set; } = 80;
        public static double ReadTimeout { get; private set; } = 1000;

        public static string WriteRuqire_ResultData(string cmd)
        {
            simpleHybirdLock.Enter();

            string data = null;

            try
            {
                _SerialPort.Write(cmd);

                //定义一个开始时间

                DateTime dateTime = DateTime.Now;

                while (true)
                {
                    Thread.Sleep(SleepTime);
                    if (_SerialPort.BytesToRead > 0)
                    {
                        data = _SerialPort.ReadExisting();
                        return data;
                    }
                    else
                    {
                        if ((DateTime.Now - dateTime).TotalMilliseconds > ReadTimeout)
                        {
                            return null;
                        }
                        else if (data.Length>0)
                        {
                            break;
                        }
                    }
                }
            }
            catch (InvalidOperationException)
            {

            }
            catch (Exception ex)
            {
                GlobalVariable.AddLog(2, "参数读取失败: " + ex.Message);
                return null;
            }
            finally
            {
                simpleHybirdLock.Leave();
            }
            return data;

        }

        public static bool conncet(string name)
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
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void disconncet()
        {
            if (_SerialPort.IsOpen)
            {
                _SerialPort.Close();
            }
        }

        /// <summary>
        /// 分割返回数据
        /// </summary>
        /// <param name="Result"></param>
        /// <returns></returns>
        public static string[] General_Split_Result(string Result)
        {

            string[] ResultData = null;


            if (Result == "" || Result == null)
            {
                return null;
            }

            ResultData = Result.Split('$');
            return ResultData;
        }
    }
}
