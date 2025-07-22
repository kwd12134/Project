using HalconDotNet;
namespace MachineVision.Core.TemplateMatch.Shared
{
    /// <summary>
    /// 模板匹配结果
    /// </summary>
    public class TemplateMatchResult
    {
        /// <summary>
        /// 序号
        /// </summary>
        public int Index { get; set; }
        /// <summary>
        /// 坐标
        /// </summary>
        public double Row { get; set; }
        /// <summary>
        /// 坐标
        /// </summary>
        public double Column { get; set; }
        /// <summary>
        /// 角度
        /// </summary>
        public double Angle { get; set; }
        /// <summary>
        /// 匹配分数
        /// </summary>
        public double Score { get; set; }

        /// <summary>
        /// 匹配结果
        /// </summary>
        public HObject ContoursAffineTrans { get; set; }
    }
}
