using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class DeviceRealTimeData
    {

        public string 曲线采集间隔 { get; set; }

        public string 所对应的Pset { get; set; }

        public string 拧紧曲线是否结束 { get; set; }

        public string 拧紧曲线是否是开始端 { get; set; }

        public string[] 扭矩 { get; set; }

        public string[] 角度 { get; set; }

    }
}
