using System;
using System.Collections.Generic;
using System.Runtime;

namespace Data
{
    public class Variable
    {
        public static Action<int, string> ListAddLog { get; set; }

        public static Action<string, string> DgvAddLog { get; set; }

        public static List<string> Logs { get; set; } = new List<string>();

        public static List<DeviceHistoryData> DeviceHistory { get; set; } = new List<DeviceHistoryData>();

        public static List<DeviceRunStatusData> deviceRunStatusData { get; set; } = new List<DeviceRunStatusData>();

        public static List<DeviceResultReadDate> deviceResultReadDates { get; set; } = new List<DeviceResultReadDate>();

        public static DeviceParameter deviceParameters { get; set; } = new DeviceParameter();

        public static JobParameter jobParameter { get; set; } = new JobParameter();

        public static DeviceRecipeInfo deviceRecipeInfo { get; set; }

        public static string UserPwd { get; set; } = "";

        public static string UserID { get; set; } = "";

        public static string CurrentTime { get { return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"); } }

        public static string currentDateLogPath { get; set; }

        public static string CurrentDateLogPath
        {
            get { return currentDateLogPath + DateTime.Now.ToString("yyyy-MM-dd") + "_Log.txt"; }
            set { currentDateLogPath = value; }
        }

    }
}
