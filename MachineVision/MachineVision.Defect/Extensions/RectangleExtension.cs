using MachineVision.Defect.Models;

namespace MachineVision.Defect.Extensions
{
    public static class RectangleExtension
    {
        /// <summary>
        /// 根据矩形的宽高中点生产矩形的左上角和右下角参数  x1y1两个属性代表左上角坐标 x2y2两个属性代表右下角坐标
        /// </summary>
        /// <param name="Width">宽度</param>
        /// <param name="Height">高度</param>
        /// <param name="Row">Row</param>
        /// <param name="Column">Column</param>
        /// <returns></returns>
        public static RectangleLocation GetRectangleLocation(double Width, double Height, double Row, double Column)
        {
            var x1 = Column - Width / 2;
            var y1 = Row - Height / 2;
            var x2 = Column + Width / 2;
            var y2 = Row + Height / 2;

            return new RectangleLocation(x1, y1, x2, y2);
        }
    }
}
