using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
namespace CurrentVariable
{
    public class StatuVariable
    {
        /// <summary>
        /// LED_Get_ChNum    通道数量，特指开发板上有几个
        /// </summary>
        public string LED_channel_Number { get; set; } = "0";
        /// <summary>
        /// 压差 LED_GetDVal
        /// </summary>
        public string LED_DV { get; set; } = "0";
        /// <summary>
        /// 是否为有错误
        /// </summary>
        public string LED_State { get; set; } = "正常";
    }
}
