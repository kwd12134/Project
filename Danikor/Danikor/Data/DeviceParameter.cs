using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class DeviceParameter
    {

        public string PsetName { get; set; } = string.Empty;
        /// <summary>
        /// 旋转速度
        /// </summary>
        public string Rotate_Speed { get; set; } = string.Empty;

        /// <summary>
        /// 旋转角度
        /// </summary>
        public string Rotation_Angle { get; set; } = string.Empty;

        public string Nm { get; set; } = string.Empty;

        public string Angle { get; set; } = string.Empty;

        public string NmUpperLimit { get; set; } = string.Empty;

        public string NmDownLimit { get; set; } = string.Empty;

        public string AngleUpperLimit { get; set; } = string.Empty;

        public string AngleDownLimit { get; set; } = string.Empty;

    }
}
