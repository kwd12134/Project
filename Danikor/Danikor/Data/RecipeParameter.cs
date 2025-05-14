using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class RecipeParameter
    {
        /// <summary>
        /// 旋转速度
        /// </summary>
        public int Rotate_Speed { get; set; }
        /// <summary>
        /// 旋转方向
        /// </summary>
        public string RotitionDirection { get; set; }
        /// <summary>
        /// 扭矩
        /// </summary>
        public string Nm { get; set; }
        /// <summary>
        /// 扭矩门槛
        /// </summary>
        public string NmThreshold { get; set; }
        /// <summary>
        /// 启动延时
        /// </summary>
        public string StartDelay { get; set; }
        /// <summary>
        /// 斜率门槛
        /// </summary>
        public string SlopeThreshold { get; set; }
        /// <summary>
        /// 保持时间
        /// </summary>
        public string KeepTime { get; set; }
        /// <summary>
        /// 扭矩上限
        /// </summary>
        public string NmUpperLimit { get; set; }
        /// <summary>
        /// 扭矩下限
        /// </summary>
        public string NmLowerLimit { get; set; }
        /// <summary>
        /// 角度合格上限
        /// </summary>
        public string AngleUpperLimit { get; set;}
        /// <summary>
        /// 角度合格下限
        /// </summary>
        public string AngleLowerLimit { get; set; }
        /// <summary>
        /// 拧紧起始扭矩
        /// </summary>
        public string ScrewDownNm { get; set; }
        /// <summary>
        /// 拧紧角度上限
        /// </summary>
        public string ScrewDownAngleUpper { get; set; }
        /// <summary>
        /// 拧紧角度下限
        /// </summary>
        public string ScrewDownAngleLower { get; set; }
        /// <summary>
        /// 最长保持时间
        /// </summary>
        public string LengthKeepTime { get; set; }
        /// <summary>
        /// 浮高检测是否开启
        /// </summary>
        public string Upper { get; set;}
        /// <summary>
        /// 滑牙检测是否开启
        /// </summary>
        public string ScrewLosse { get; set; }
        /// <summary>
        /// 返修策略是否开启
        /// </summary>
        public string Repair { get; set; }
        /// <summary>
        /// 拧紧数量
        /// </summary>
        public int ScrewDownCount { get; set; }

    }
}
