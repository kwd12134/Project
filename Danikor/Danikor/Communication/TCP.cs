﻿using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using thinger.DataConvertLib;

namespace Communication
{
    public class TCP
    {

        public Socket socket;

        public int ReadTimeOut { get; private set; } = 2000;
        public int WriteTimeOut { get; private set; } = 2000;

        //public SimpleHybirdLock SimpleHybirdLock = new SimpleHybirdLock();

        /// <summary>
        ///TCP连接
        /// </summary>
        /// <param name="Port"></param>
        public async void SocketConnect(string iporhost, int port,string Command)
        {
            await Task.Run(() => {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //设置超时时间
            socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveTimeout, this.ReadTimeOut);
            socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.SendTimeout, this.WriteTimeOut);
            byte[] buffer = new byte[1024];
            try
            {
                IAsyncResult asyncResult = socket.BeginConnect(iporhost, port, null, null);

                bool connectResult = asyncResult.AsyncWaitHandle.WaitOne(1000, false);

                if (connectResult == false)
                {
                    return;
                }
                socket.Send(ByteArrayLib.GetByteArrayFromHexString(Command));
                var receiveArgs = new SocketAsyncEventArgs();
                receiveArgs.SetBuffer(buffer, 0, buffer.Length);
                socket.ReceiveAsync(receiveArgs);
            }
            catch (Exception ex)
            {
                    Variable.DgvAddLog("错误","急停命名出错:"+ex.Message);
            }
            });

        }
        /// <summary>
        /// 断开连接
        /// </summary>
        public void DisConnect()
        {
            if (socket != null)
            {
                socket.Close();
            }
        }

        public  bool SendAndReceive(byte[] Sender, ref string[] Receive)
        {
            byte[] result = new byte[1200];
            try
            {
                socket.Send(Sender);
                Thread.Sleep(1000);
                socket.Receive(result);
                Receive = StringLib.GetStringFromByteArrayByEncoding(result, 0, result.Length - 1, Encoding.ASCII).Split('=');// result[18]+18
                if (Receive.Length <= 2)
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                //SimpleHybirdLock.Leave();
            }
            return true;
        }


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
            private int m_waiters = 0;
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
}
