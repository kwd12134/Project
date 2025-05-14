using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace SendReceiveCom.com
{
	// Token: 0x0200000D RID: 13
	public class LogMethod
	{
        private static QueueLock queueLock { get; set; } = new QueueLock();
        private static QueueLock SpotCheckQueueLock { get; set; } = new QueueLock();

        public static async void log(string logMessage)
		{            
            await Task.Run(() =>
			{
                try
				{
					queueLock.Enter();
                    string path = AppDomain.CurrentDomain.BaseDirectory;
					path = path.Remove(path.Length - 1, 1);
					path = path.Replace("/", "\\");
					path = path + "\\logs\\" + DateTime.Now.Date.ToString("yyyy-MM-dd") + "\\";
					bool flag = !Directory.Exists(path);
					if (flag)
					{
						Directory.CreateDirectory(path);
					}
					path = path + DateTime.Now.Date.ToString("yyyyMMdd") + "_log.txt";
					using (StreamWriter writer = new StreamWriter(path, true, Encoding.UTF8))
					{
                        writer.WriteLine(DateTime.Now.ToString("yyyy_MM_dd_HH:mm:ss:fff") + ":" + logMessage);
                    }
				}
				catch
				{
				}
				finally
				{
					queueLock.Leave();
				}
			});
		}


        public static async void SpotChecklog(string logMessage)
        {
            await Task.Run(() =>
            {
                try
                {
                    SpotCheckQueueLock.Enter();
                    string path = AppDomain.CurrentDomain.BaseDirectory;
                    path = path.Remove(path.Length - 1, 1);
                    path = path.Replace("/", "\\");
                    path = path + "\\SpotCheck\\" + DateTime.Now.Date.ToString("yyyy-MM-dd") + "\\";
                    bool flag = !Directory.Exists(path);
                    if (flag)
                    {
                        Directory.CreateDirectory(path);
                    }
                    path = path + DateTime.Now.Date.ToString("yyyyMMdd") + "_log.txt";
                    using (StreamWriter writer = new StreamWriter(path, true, Encoding.UTF8))
                    {
                        writer.WriteLine(DateTime.Now.ToString("yyyy_MM_dd_HH:mm:ss:fff") + ":" + logMessage);
                    }
                }
                catch
                {
                }
                finally
                {
                    SpotCheckQueueLock.Leave();
                }
            });
        }

    }
}
