using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class SystemSetting
    {

        public static String DeviceIP { get; set; } = string.Empty;

        public static int DeviceIpPort { get; set; } = 7600;

        public static String DeviceRTUPort { get; set; } = "COM1";

        public static String McmqIP { get; set; } = string.Empty;

        public static int McmqPort { get; set; } = 7600;

        public static string MCMQQueueName { get; set; } = string.Empty;
        
        public static string MCMQReplyQueueName { get; set; } = string.Empty;

        public static String FtpIP { get; set; } = string.Empty;

        public static int FtpPort { get; set; } = 21;

        public static String FtpUserName { get; set; } = string.Empty;

        public static String FtpUserPwd { get; set; } = string.Empty;

        public static String FtpRootPath { get; set; } = string.Empty;

        public static bool EnabledMCMQ { get; set; } 

    }
}
