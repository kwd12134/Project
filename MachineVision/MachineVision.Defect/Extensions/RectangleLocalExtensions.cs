using HalconDotNet;
using MachineVision.Defect.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MachineVision.Defect.Extensions
{
    public static class RectangleLocalExtensions
    {
        /// <summary>
        /// 根据2点坐标生成一个矩形对象
        /// </summary>
        /// <param name="rl"></param>
        /// <returns></returns>
        public static HObject GenRectangle1(this RectangleLocation rl)
        {
            HOperatorSet.GenRectangle1(out HObject rect, rl.Y1, rl.X1, rl.Y2, rl.X2);
            return rect;
        }
    }
}
