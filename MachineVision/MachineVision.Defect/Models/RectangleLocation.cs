using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineVision.Defect.Models
{
    /// <summary>
    /// 结构体是值类型，赋值或传参时会 复制数据，而不是引用。 不适合放大量数据字段（推荐字段数量不要超过 5-10 个）。
    /// 在 C# 中，struct（结构体）是一个值类型的数据结构，用于封装一组相关的变量（字段）和方法。它通常用于表示一些轻量级的数据对象，比如坐标点、颜色、矩形、传感器数据等等。
    /// 实体类（class）适合表示业务逻辑丰富、生命周期长、需要共享或引用的对象。
    /// 结构体（struct）适合短生命周期、小型封装、无需引用共享的值对象。
    /// </summary>
    public struct RectangleLocation
    {
        public RectangleLocation(double x1, double y1, double x2, double y2)
        {
            X1 = x1;
            Y1 = y1;
            X2 = x2;
            Y2 = y2;
        }

        public double X1 { get; set; }
        public double Y1 { get; set; }
        public double X2 { get; set; }
        public double Y2 { get; set; }
    }
}
