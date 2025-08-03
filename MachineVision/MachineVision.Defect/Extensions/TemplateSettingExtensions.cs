using HalconDotNet;
using MachineVision.Defect.Models;
using MachineVision.Defect.ViewModels.Components.Models;
using MachineVision.Shared.Controls;

namespace MachineVision.Defect.Extensions
{
    public static class TemplateSettingExtensions
    {
        /// <summary>
        /// 设置矩形的两点坐标和尺寸信息  会直接修改原始对象的字段，因为它们指向的是同一个内存地址。this
        /// </summary>
        /// <param name="setting"></param>
        /// <param name="drawObj"></param>
        public static void SetReferParam(this TemplateSetting setting, HDrawingObjectInfo drawObj)
        {
            //设置矩形的两点坐标
            setting.Y1 = (int)drawObj.HTuples[0].D;
            setting.X1 = (int)drawObj.HTuples[1].D;
            setting.Y2 = (int)drawObj.HTuples[2].D;
            setting.X2 = (int)drawObj.HTuples[3].D;

            //区域的中点坐标
            setting.Row = setting.Y1 + (setting.Y2 - setting.Y1) / 2;
            setting.Column = setting.X1 + (setting.X2 - setting.X1) / 2;

            //计算矩形的宽度和高度
            //setting.Width = Math.Abs(setting.X1 - setting.X2);
            //setting.Height = Math.Abs(setting.Y1 - setting.Y2);
        }

        /// <summary>
        /// 获取模板相对参考点的位置
        /// </summary>
        /// <param name="setting"></param>
        /// <param name="Row"></param>
        /// <param name="Column"></param>
        /// <returns></returns>
        public static RectangleLocation GetMatchRectangle(this TemplateSetting setting, double Row, double Column)
        {
            setting.Row = Row - setting.RowSpacing;
            setting.Column = Column - setting.ColumnSpacing;

            return RectangleExtension.GetRectangleLocation(setting.Width, setting.Height, setting.Row, setting.Column);
        }
    }
}
