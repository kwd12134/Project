using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Helper
{
    public sealed class QueueLock : IDisposable
    {
        private bool disposedValue = false; // 检测冗余调用
        private readonly Queue<Thread> queue = new Queue<Thread>(); // 用于保存线程的队列
        private readonly object lockObject = new object(); // 锁对象

        /// <summary>
        /// 进入锁
        /// </summary>
        public void Enter()
        {
            lock (lockObject)
            {
                Thread currentThread = Thread.CurrentThread; // 获取当前线程
                queue.Enqueue(currentThread); // 当前线程进入队列

                while (queue.Peek() != currentThread) // 如果当前线程不是队列中的第一个线程，则等待
                {
                    Monitor.Wait(lockObject); // 等待锁对象的信号
                }
            }
        }

        /// <summary>
        /// 离开锁
        /// </summary>
        public void Leave()
        {
            lock (lockObject)
            {
                if (queue.Count > 0 && queue.Peek() == Thread.CurrentThread) // 确保队列不为空且当前线程是队列中的第一个线程
                {
                    queue.Dequeue(); // 当前线程离开队列

                    if (queue.Count > 0) // 如果队列中还有其他线程
                    {
                        Monitor.PulseAll(lockObject); // 唤醒等待中的线程
                    }
                }
            }
        }

        /// <summary>
        /// 释放资源
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // 释放托管状态(托管对象)。
                }
                // 释放未托管的资源(未托管的对象)并在以下内容中替代终结器。
                // 将大型字段设置为 null。

                disposedValue = true;
            }
        }
    }
}
