using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrentVariable
{
    public class Common_Read
    {
        public static string LED_ON { get; set; } = "LED_ON\r\n";

        public static string LED_OFF { get; set; } = "LED_OFF\r\n";

        public static string LED_Refresh { get; set; } = "LED_refresh\r\n";

        public static string LED_Read_Status { get; set; } = "LED_Get_Status\r\n";

        public static string LED_GetModel { get; set; } = "LED_GetModelName\r\n";

        public static List<string> common_Read_collection { get; set; } = new List<string>()
        {
            "LED_GetNTC_R\r\n",
            "LED_GetLEDV\r\n",
            "LED_GetLEDI\r\n",
            "LED_GetDVal\r\n",
            "LED_Get_ChNum\r\n",
            "LED_clear_maxmin\r\n",
            "LED_GetAlarmState\r\n"
        };

        public static List<string> common_Write_collection { get; set; } = new List<string>()
        {
            "LED_clear_maxmin\r\n",       //每次写入之前先清除之前的配置信息
            "LED_Set_PrjNames$",
            "LED_Set_ChNum$",
            "LED_Set_I$",
            "LED_Set_Imaxmin$",
            "LED_Set_Vmaxmin$",
            "LED_SHorL$",
            "LED_DVal_maxmin$",
            "LED_Set_NTC_Ch$",
            "NTC_MODEL$",
            "LED_SNTC_maxmin$",
            "LED_refresh\r\n"
        };
    }
}
