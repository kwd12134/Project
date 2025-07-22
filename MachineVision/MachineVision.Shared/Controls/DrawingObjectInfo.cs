using HalconDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineVision.Shared.Controls
{
    public enum ShapeType
    {
        Rectangle,
        Ellipse,
        Circle,
        Region
    }
    public class DrawingObjectInfo
    {
        /// <summary>
        /// 形状类型
        /// </summary>
        public ShapeType ShapeType { get; set; }

        /// <summary>
        /// 生成的形状对象
        /// </summary>
        public HObject Hobject { get; set; }

        /// <summary>
        /// 汇总ROI的范围参数
        /// </summary>
        public HTuple[] hTuples {  get; set; }

    }
}
