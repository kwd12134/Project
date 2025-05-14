using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using XmlCollection;

namespace CurrentVariable
{
    public class GlobalVariable
    {

        public static McmqSetting McmqSetting { get; set; } = new McmqSetting();

        public static Action<int, string> AddLog { get; set; }

        public static string OperatorID { get; set; }

        public static string PassWord { get; set; }

        public static XmlData XmlData { get; set; } = new XmlData();

        public static CheckTime CheckTime { get; set; } = new CheckTime();


        public static Dictionary<string, double> ResistSpec = new Dictionary<string, double>();

        public static double ResistLower {  get; set; }

        public static double ResistUpper {  get; set; }

        public static double NtcLower { get; set; }

        public static double NtcUpper { get; set; }

        public static Jince Jince { get; set; } = new Jince();

        public static string ConfigName { get; set; }

        public static string Model_No { get; set; }

    }
}
