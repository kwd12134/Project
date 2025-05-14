using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class DeviceHistoryData
    {
        
        public string 时间 { get; set; } = string.Empty;
        public string 模式 { get; set; } = string.Empty;
        public string 扭矩 { get; set; } = string.Empty;
        public string 角度 { get; set; } = string.Empty;
        public string 时长 { get; set; } = string.Empty;
        /// <summary>
        /// 
        // 01:系统故障
        // 02:系统急停
        // 03:总时间超限
        // 04:总角度过大
        // 05:总角度过小
        // 06:反松扭矩过大
        // 07:滑牙
        // 08:浮高
        /// </summary>
        public string 拧紧结果状态 { get; set; } = string.Empty;

        public string 错误码ID { get; set; } = string.Empty;

        public string 错误码信息 { get; set; } = string.Empty;
    }
}
