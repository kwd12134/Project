using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace thinger.MTHHelper
{
    public class ModbusTCP
    {
        #region 字段与属性
        /// <summary>
        /// 发送超时时间
        /// </summary>
        public int SendTimeOut { get; set; } = 2000;

        /// <summary>
        /// 接收超时时间
        /// </summary>
        public int ReceiveTimeOut { get; set; } = 2000;

        //创建一个Socket对象
        private Socket socket;

        /// <summary>
        ///  锁对象
        /// </summary>
        private SimpleHybirdLock hybirdLock = new SimpleHybirdLock();

        /// <summary>
        /// 每次接收前延时的时间
        /// </summary>
        public int SleepTime { get; set; } =50;

        /// <summary>
        /// 最大的等待次数
        /// </summary>
        public int MaxWaitTimes { get; set; } = 20;

        /// <summary>
        /// 单元标识符
        /// </summary>
        public byte SlaveId { get; set; } = 0x01;

        #endregion

        #region 建立连接与断开连接
        /// <summary>
        /// 建立连接
        /// </summary>
        /// <param name="ip">IP地址</param>
        /// <param name="port">端口号</param>
        /// <returns>返回结果</returns>
        public bool Connect(string ip, int port)
        {
            //Socket实例化
            this.socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            this.socket.SendTimeout = SendTimeOut;
            this.socket.ReceiveTimeout = ReceiveTimeOut;

            try
            {
                if (IPAddress.TryParse(ip, out IPAddress ipAddress))
                {
                    this.socket.Connect(ipAddress, port);
                }
                else
                {
                    this.socket.Connect(ip, port);
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// 断开连接
        /// </summary>
        public void DisConnect()
        {
            if (this.socket != null)
            {
                this.socket.Close();
            }
        }

        #endregion

        #region 01H读取输出线圈 
        /// <summary>
        /// 01H读取输出线圈
        /// </summary>
        /// <param name="start">起始线圈地址</param>
        /// <param name="length">线圈长度</param>
        /// <returns>返回数据</returns>
        public byte[] ReadOutputCoils(ushort start, ushort length)
        {
            //第一步：拼接报文

            //创建一个ByteArray对象
            ByteArray SendCommand = new ByteArray();

            //事务处理 + 协议标识 + 长度 + 单元标识 + 功能码 + 起始线圈地址 + 线圈长度

            //事务处理 + 协议标识
            SendCommand.Add(0x00, 0x00, 0x00, 0x00);

            //长度 + 单元标识  + 功能码
            SendCommand.Add(0x00, 0x06, SlaveId, 0x01);

            //起始线圈地址 + 线圈长度
            SendCommand.Add(start);
            SendCommand.Add(length);

            byte[] receive = null;

            int byteLength = length % 8 == 0 ? length / 8 : length / 8 + 1;

            //第二步 第三步：发送并接收报文
            if (SendAndReceive(SendCommand.Array, ref receive))
            {
                //第四步：验证报文

                if (receive.Length == 9 + byteLength)
                {
                    if (receive[6] == SlaveId && receive[7] == 0x01 && receive[8] == byteLength)
                    {
                        //第五步：解析报文
                        byte[] result = new byte[byteLength];

                        Array.Copy(receive, 9, result, 0, byteLength);

                        return result;
                    }
                }
            }
            return null;
        }
        #endregion

        #region 02H读取输入线圈 
        /// <summary>
        /// 002H读取输入线圈 
        /// </summary>
        /// <param name="start">起始线圈地址</param>
        /// <param name="length">线圈长度</param>
        /// <returns>返回数据</returns>
        public byte[] ReadInputCoils(ushort start, ushort length)
        {
            //第一步：拼接报文

            //创建一个ByteArray对象
            ByteArray SendCommand = new ByteArray();

            //事务处理 + 协议标识 + 长度 + 单元标识 + 功能码 + 起始线圈地址 + 线圈长度

            //事务处理 + 协议标识
            SendCommand.Add(0x00, 0x00, 0x00, 0x00);

            //长度 + 单元标识  + 功能码
            SendCommand.Add(0x00, 0x06, SlaveId, 0x02);

            //起始线圈地址 + 线圈长度
            SendCommand.Add(start);
            SendCommand.Add(length);

            byte[] receive = null;

            int byteLength = length % 8 == 0 ? length / 8 : length / 8 + 1;

            //第二步 第三步：发送并接收报文
            if (SendAndReceive(SendCommand.Array, ref receive))
            {
                //第四步：验证报文

                if (receive.Length == 9 + byteLength)
                {
                    if (receive[6] == SlaveId && receive[7] == 0x02 && receive[8] == byteLength)
                    {
                        //第五步：解析报文
                        byte[] result = new byte[byteLength];

                        Array.Copy(receive, 9, result, 0, byteLength);

                        return result;
                    }
                }
            }
            return null;
        }
        #endregion

        #region 03H读取输出寄存器

        /// <summary>
        /// 读取输出寄存器
        /// </summary>
        /// <param name="start">起始寄存器地址</param>
        /// <param name="length">寄存器长度</param>
        /// <returns>返回字节数组</returns>
        public byte[] ReadOutputRegisters(ushort start, ushort length)
        {
            //第一步：拼接报文

            //创建一个ByteArray对象
            ByteArray SendCommand = new ByteArray();

            //事务处理 + 协议标识 + 长度 + 单元标识 + 功能码 + 起始寄存器地址 + 寄存器长度

            //事务处理 + 协议标识
            SendCommand.Add(0x00, 0x00, 0x00, 0x00);

            //长度 + 单元标识  + 功能码
            SendCommand.Add(0x00, 0x06, SlaveId, 0x03);

            //起始寄存器地址 + 寄存器长度
            SendCommand.Add(start);
            SendCommand.Add(length);

            byte[] receive = null;

            int byteLength = length * 2;

            //第二步 第三步：发送并接收报文
            if (SendAndReceive(SendCommand.Array, ref receive))
            {
                //第四步：验证报文

                if (receive.Length == 9 + byteLength)
                {
                    if (receive[6] == SlaveId && receive[7] == 0x03 && receive[8] == byteLength)
                    {
                        //第五步：解析报文
                        byte[] result = new byte[byteLength];

                        Array.Copy(receive, 9, result, 0, byteLength);

                        return result;
                    }
                }
            }
            return null;
        }

        #endregion

        #region 04H读取输入寄存器

        /// <summary>
        /// 读取输入寄存器
        /// </summary>
        /// <param name="start">起始寄存器地址</param>
        /// <param name="length">寄存器长度</param>
        /// <returns>返回字节数组</returns>
        public byte[] ReadInputRegisters(ushort start, ushort length)
        {
            //第一步：拼接报文

            //创建一个ByteArray对象
            ByteArray SendCommand = new ByteArray();

            //事务处理 + 协议标识 + 长度 + 单元标识 + 功能码 + 起始寄存器地址 + 寄存器长度

            //事务处理 + 协议标识
            SendCommand.Add(0x00, 0x00, 0x00, 0x00);

            //长度 + 单元标识  + 功能码
            SendCommand.Add(0x00, 0x06, SlaveId, 0x04);

            //起始寄存器地址 + 寄存器长度
            SendCommand.Add(start);
            SendCommand.Add(length);

            byte[] receive = null;

            int byteLength = length * 2;

            //第二步 第三步：发送并接收报文
            if (SendAndReceive(SendCommand.Array, ref receive))
            {
                //第四步：验证报文

                if (receive.Length == 9 + byteLength)
                {
                    if (receive[6] == SlaveId && receive[7] == 0x04 && receive[8] == byteLength)
                    {
                        //第五步：解析报文
                        byte[] result = new byte[byteLength];

                        Array.Copy(receive, 9, result, 0, byteLength);

                        return result;
                    }
                }
            }
            return null;
        }

        #endregion

        #region 05H预置单线圈

        /// <summary>
        /// 预置单线圈
        /// </summary>
        /// <param name="start">线圈地址</param>
        /// <param name="value">线圈值</param>
        /// <returns>返回结果</returns>
        public bool PreSetSingleCoil(ushort start, bool value)
        {
            //第一步：拼接报文

            //创建一个ByteArray对象
            ByteArray SendCommand = new ByteArray();

            //事务处理 + 协议标识 + 长度 + 单元标识 + 功能码 + 线圈地址 + 线圈值（0xFF 0x00 / 0x00 0x00）

            //事务处理 + 协议标识
            SendCommand.Add(0x00, 0x00, 0x00, 0x00);

            //长度 + 单元标识  + 功能码
            SendCommand.Add(0x00, 0x06, SlaveId, 0x05);

            //线圈地址
            SendCommand.Add(start);

            //线圈值
            SendCommand.Add(value ? (byte)0xFF : (byte)0x00, 0x00);

            byte[] receive = null;

            //第二步 第三步：发送并接收报文
            if (SendAndReceive(SendCommand.Array, ref receive))
            {
                //第四步：验证报文
                if (receive.Length == 12)
                {
                    return ByteArrayEquals(SendCommand.Array, receive);
                }
            }
            return false;
        }

        #endregion

        #region 06H预置单寄存器

        /// <summary>
        /// 预置单寄存器
        /// </summary>
        /// <param name="start">寄存器地址</param>
        /// <param name="value">寄存器值</param>
        /// <returns>返回结果</returns>
        public bool PreSetSingleRegister(ushort start, byte[] value)
        {
            //第一步：拼接报文

            //创建一个ByteArray对象
            ByteArray SendCommand = new ByteArray();

            //事务处理 + 协议标识 + 长度 + 单元标识 + 功能码 + 寄存器地址 + 寄存器值

            //事务处理 + 协议标识
            SendCommand.Add(0x00, 0x00, 0x00, 0x00);

            //长度 + 单元标识  + 功能码
            SendCommand.Add(0x00, 0x06, SlaveId, 0x06);

            //寄存器地址
            SendCommand.Add(start);

            //寄存器值
            SendCommand.Add(value);

            byte[] receive = null;

            //第二步 第三步：发送并接收报文
            if (SendAndReceive(SendCommand.Array, ref receive))
            {
                //第四步：验证报文
                if (receive.Length == 12)
                {
                    return ByteArrayEquals(SendCommand.Array, receive);
                }
            }
            return false;
        }

        /// <summary>
        /// 预置单寄存器
        /// </summary>
        /// <param name="start">寄存器地址</param>
        /// <param name="value">Short类型</param>
        /// <returns>返回结果</returns>
        public bool PreSetSingleRegister(ushort start, short value)
        {
            return PreSetSingleRegister(start, BitConverter.GetBytes(value).Reverse().ToArray());
        }

        /// <summary>
        /// 预置单寄存器
        /// </summary>
        /// <param name="start">寄存器地址</param>
        /// <param name="value">UShort类型</param>
        /// <returns>返回结果</returns>
        public bool PreSetSingleRegister(ushort start, ushort value)
        {
            return PreSetSingleRegister(start, BitConverter.GetBytes(value).Reverse().ToArray());
        }

        #endregion

        #region 0FH预置多线圈

        /// <summary>
        /// 预置多线圈
        /// </summary>
        /// <param name="start">起始线圈地址</param>
        /// <param name="value">写入值</param>
        /// <returns>返回结果</returns>
        public bool PreSetMultiCoils(ushort start, bool[] value)
        {
            //第一步：拼接报文

            //创建一个ByteArray对象
            ByteArray SendCommand = new ByteArray();

            byte[] setArray = GetByteArrayFromBoolArray(value);

            //事务处理 + 协议标识 + 长度 + 单元标识 + 功能码 + 起始线圈地址 + 线圈数量 + 字节计数 + 字节数据

            //事务处理 + 协议标识
            SendCommand.Add(0x00, 0x00, 0x00, 0x00);

            //长度 
            SendCommand.Add((short)(7 + setArray.Length));

            //单元标识 + 功能码

            SendCommand.Add(SlaveId, 0x0F);

            //起始线圈地址
            SendCommand.Add(start);

            //线圈数量
            SendCommand.Add((short)value.Length);

            //字节计数
            SendCommand.Add((byte)setArray.Length);

            //字节数据
            SendCommand.Add(setArray);

            byte[] receive = null;

            //第二步 第三步：发送并接收报文
            if (SendAndReceive(SendCommand.Array, ref receive))
            {
                //第四步：验证报文
                byte[] send = new byte[12];

                Array.Copy(SendCommand.Array, 0, send, 0, 12);

                send[4] = 0x00;
                send[5] = 0x06;

                return ByteArrayEquals(send, receive);
            }
            return false;
        }
        #endregion

        #region 10H预置多寄存器

        /// <summary>
        /// 预置多寄存器
        /// </summary>
        /// <param name="start">起始寄存器地址</param>
        /// <param name="value">写入值</param>
        /// <returns>返回结果</returns>
        public bool PreSetMultiRegisters(ushort start, byte[] values)
        {
            //第一步：拼接报文

            if (values == null || values.Length == 0 || values.Length % 2 == 1)
            {
                return false;
            }

            //创建一个ByteArray对象
            ByteArray SendCommand = new ByteArray();

            //事务处理 + 协议标识 + 长度 + 单元标识 + 功能码 + 起始寄存器地址 + 寄存器数量 + 字节计数 + 字节数据

            //事务处理 + 协议标识
            SendCommand.Add(0x00, 0x00, 0x00, 0x00);

            //长度 
            SendCommand.Add((short)(7 + values.Length));

            //单元标识 + 功能码

            SendCommand.Add(SlaveId, 0x10);

            //起始寄存器地址
            SendCommand.Add(start);

            //寄存器数量
            SendCommand.Add((short)(values.Length / 2));

            //字节计数
            SendCommand.Add((byte)(values.Length));

            //字节数据
            SendCommand.Add(values);

            byte[] receive = null;

            //第二步 第三步：发送并接收报文
            if (SendAndReceive(SendCommand.Array, ref receive))
            {
                //第四步：验证报文
                byte[] send = new byte[12];

                Array.Copy(SendCommand.Array, 0, send, 0, 12);

                send[4] = 0x00;
                send[5] = 0x06;

                return ByteArrayEquals(send, receive);
            }
            return false;
        }
        #endregion

        #region 通用发送并接收方法
        /// <summary>
        /// 发送并接收方法
        /// </summary>
        /// <param name="send">发送报文</param>
        /// <param name="receive">接收报文</param>
        /// <returns>返回结果</returns>
        private bool SendAndReceive(byte[] send, ref byte[] receive)
        {
            //加锁
            hybirdLock.Enter();

            byte[] buffer = new byte[1024];
            MemoryStream stream = new MemoryStream();

            try
            {
                //发送报文
                socket.Send(send, send.Length, SocketFlags.None);

                int timer = 0;

                while (true)
                {
                    Thread.Sleep(SleepTime);

                    //判断缓冲区有没有数据
                    if (socket.Available > 0)
                    {
                        //接收数据并放到Buffer
                        int count = socket.Receive(buffer, SocketFlags.None);

                        //将读取的数据放到Stream中
                        stream.Write(buffer, 0, count);
                    }
                    else
                    {
                        timer++;
                        //先判断Stream有没有数据
                        if (stream.Length > 0)
                        {
                            break;
                        }
                        //超时读取
                        else if (timer > MaxWaitTimes)
                        {
                            return false;
                        }
                        else if (stream.Length > 0)
                        {
                            break;
                        }
                    }
                }

                receive = stream.ToArray();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                hybirdLock.Leave();
            }
        }

        #endregion

        #region 数组比较方法

        /// <summary>
        /// 数组比较方法    0x01 0x02   01-02
        /// </summary>
        /// <param name="b1"></param>
        /// <param name="b2"></param>
        /// <returns></returns>
        private bool ByteArrayEquals(byte[] b1, byte[] b2)
        {
            return BitConverter.ToString(b1) == BitConverter.ToString(b2);
        }

        #endregion

        #region 将布尔数组转换成字节数组

        private byte[] GetByteArrayFromBoolArray(bool[] value)
        {
            int byteLength = value.Length % 8 == 0 ? value.Length / 8 : value.Length / 8 + 1;

            byte[] result = new byte[byteLength];

            for (int i = 0; i < result.Length; i++)
            {
                //获取每个字节的值

                int total = value.Length < 8 * (i + 1) ? value.Length - 8 * i : 8;

                for (int j = 0; j < total; j++)
                {
                    result[i] = SetBitValue(result[i], j, value[8 * i + j]);
                }
            }
            return result;
        }

        /// <summary>
        /// 将某个字节某个位置位或复位
        /// </summary>
        /// <param name="src"></param>
        /// <param name="bit"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        private byte SetBitValue(byte src, int bit, bool value)
        {
            return value ? (byte)(src | (byte)Math.Pow(2, bit)) : (byte)(src & ~(byte)Math.Pow(2, bit));
        }
        #endregion
    }

    #region ByteArray
    /// <summary>
    /// ByteArray工具类，一般用来做报文拼接
    /// </summary>
    public class ByteArray
    {
        #region 初始化

        private List<byte> list = new List<byte>();

        #endregion

        #region 属性
        /// <summary>
        /// List集合
        /// </summary>
        public List<byte> List
        {
            get { return list; }
        }

        /// <summary>
        /// Array数组
        /// </summary>
        public byte[] Array
        {
            get { return list.ToArray(); }
        }

        /// <summary>
        /// 长度
        /// </summary>
        public int Length
        {
            get { return list.Count; }
        }

        #endregion

        #region 方法

        /// <summary>
        /// 添加一个字节
        /// </summary>
        /// <param name="item"></param>
        public void Add(byte item)
        {
            list.Add(item);
        }

        /// <summary>
        /// 添加一个数组
        /// </summary>
        /// <param name="item"></param>
        public void Add(byte[] array)
        {
            list.AddRange(array);
        }

        /// <summary>
        /// 添加一个集合
        /// </summary>
        /// <param name="list"></param>
        public void Add(List<byte> list)
        {
            list.AddRange(list);
        }

        /// <summary>
        /// 连续添加两个字节
        /// </summary>
        /// <param name="item1"></param>
        /// <param name="item2"></param>
        public void Add(byte item1, byte item2)
        {
            Add(new byte[] { item1, item2 });
        }

        /// <summary>
        /// 连续添加三个字节
        /// </summary>
        /// <param name="item1"></param>
        /// <param name="item2"></param>
        /// <param name="item3"></param>
        public void Add(byte item1, byte item2, byte item3)
        {
            Add(new byte[] { item1, item2, item3 });
        }


        /// <summary>
        /// 连续添加四个字节
        /// </summary>
        /// <param name="item1"></param>
        /// <param name="item2"></param>
        /// <param name="item3"></param>
        /// <param name="item4"></param>
        public void Add(byte item1, byte item2, byte item3, byte item4)
        {
            Add(new byte[] { item1, item2, item3, item4 });
        }


        /// <summary>
        /// 连续添加五个字节
        /// </summary>
        /// <param name="item1"></param>
        /// <param name="item2"></param>
        /// <param name="item3"></param>
        /// <param name="item4"></param>
        /// <param name="item5"></param>
        public void Add(byte item1, byte item2, byte item3, byte item4, byte item5)
        {
            Add(new byte[] { item1, item2, item3, item4, item5 });
        }

        /// <summary>
        /// 添加一个ByteArray对象
        /// </summary>
        /// <param name="byteArray"></param>
        public void Add(ByteArray byteArray)
        {
            Add(byteArray.Array);
        }

        /// <summary>
        /// 添加一个Short类型
        /// </summary>
        /// <param name="value"></param>
        public void Add(short value)
        {
            Add((byte)(value >> 8));
            Add((byte)(value));
        }

        /// <summary>
        /// 添加一个UShort类型
        /// </summary>
        /// <param name="value"></param>
        public void Add(ushort value)
        {
            Add((byte)(value >> 8));
            Add((byte)(value));
        }

        /// <summary>
        /// 清空
        /// </summary>
        public void Clear()
        {
            list.Clear();
        }
        #endregion
    }

    #endregion

    #region 简单的混合锁
    /// <summary>
    /// 一个简单的混合线程同步锁，采用了基元用户加基元内核同步构造实现
    /// </summary>

    public sealed class SimpleHybirdLock : IDisposable
    {

        #region IDisposable Support
        private bool disposedValue = false; // 要检测冗余调用

        void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: 释放托管状态(托管对象)。
                }

                // TODO: 释放未托管的资源(未托管的对象)并在以下内容中替代终结器。
                // TODO: 将大型字段设置为 null。
                m_waiterLock.Close();

                disposedValue = true;
            }
        }

        // TODO: 仅当以上 Dispose(bool disposing) 拥有用于释放未托管资源的代码时才替代终结器。
        // ~SimpleHybirdLock() {
        //   // 请勿更改此代码。将清理代码放入以上 Dispose(bool disposing) 中。
        //   Dispose(false);
        // }

        // 添加此代码以正确实现可处置模式。
        /// <summary>
        /// 释放资源
        /// </summary>
        public void Dispose()
        {
            // 请勿更改此代码。将清理代码放入以上 Dispose(bool disposing) 中。
            Dispose(true);
            // TODO: 如果在以上内容中替代了终结器，则取消注释以下行。
            // GC.SuppressFinalize(this);
        }
        #endregion

        /// <summary>
        /// 基元用户模式构造同步锁
        /// </summary>
        private Int32 m_waiters = 0;
        /// <summary>
        /// 基元内核模式构造同步锁
        /// </summary>
        private AutoResetEvent m_waiterLock = new AutoResetEvent(false);

        /// <summary>
        /// 获取锁
        /// </summary>
        public void Enter()
        {
            if (Interlocked.Increment(ref m_waiters) == 1) return;//用户锁可以使用的时候，直接返回，第一次调用时发生
                                                                  //当发生锁竞争时，使用内核同步构造锁
            m_waiterLock.WaitOne();
        }

        /// <summary>
        /// 离开锁
        /// </summary>
        public void Leave()
        {
            if (Interlocked.Decrement(ref m_waiters) == 0) return;//没有可用的锁的时候
            m_waiterLock.Set();
        }

        /// <summary>
        /// 获取当前锁是否在等待当中
        /// </summary>
        public bool IsWaitting => m_waiters == 0;
    }
    #endregion

}
