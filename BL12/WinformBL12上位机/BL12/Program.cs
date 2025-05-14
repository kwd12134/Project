using CurrentVariable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using thinger.DataConvertLib;

namespace BL12
{
    internal static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            IniConfigHelper.IniPath = SettingPath;

            DateTime NowDataTime = DateTime.Now;
            DateTime dateTimeDayShift = DateTime.Parse(IniConfigHelper.ReadIniData("CheckTime", "DayShift", ""));
            DateTime dateTimeNightShift = DateTime.Parse(IniConfigHelper.ReadIniData("CheckTime", "NightShift", ""));
            DateTime LoginTime = DateTime.Parse(IniConfigHelper.ReadIniData("CheckTime", "LoginTime", ""));
            DateTime endOfDateTimeDayShift = dateTimeDayShift.AddDays(1);

            GlobalVariable.CheckTime.DayShiftSpotCheck = IniConfigHelper.ReadIniData("CheckTime", "DayShiftSpotCheck", "") == "1" ? true : false;
            GlobalVariable.CheckTime.NightShiftSpotCheck = IniConfigHelper.ReadIniData("CheckTime", "NightShiftSpotCheck", "") == "1" ? true : false;

            if (NowDataTime >= dateTimeDayShift && NowDataTime <= dateTimeNightShift)
            {
                if (GlobalVariable.CheckTime.DayShiftSpotCheck&& LoginTime>=dateTimeDayShift)
                {
                    Application.Run(new FrmMain());
                    return;
                }
            }
            if (NowDataTime >= dateTimeNightShift && NowDataTime <= endOfDateTimeDayShift)
            {
                if (GlobalVariable.CheckTime.NightShiftSpotCheck&& LoginTime>=dateTimeNightShift)
                {
                    Application.Run(new FrmMain());
                    return;
                }
            }

            FrmSpotCheck frmSpotCheck = new FrmSpotCheck(IniConfigHelper.ReadIniData("CheckTime", "LoginTime", ""), dateTimeDayShift, dateTimeNightShift);

            if (frmSpotCheck.ShowDialog() == DialogResult.OK)
            {
                Application.Run(new FrmMain());
            }
        }

        public static string SettingPath = Application.StartupPath + "\\Setting.ini";

    }
}
