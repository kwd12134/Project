using HalconDotNet;
using MachineVision.Defect.Models;
using MachineVision.Defect.ViewModels.Components;
using MachineVision.Core.Extensions;

namespace MachineVision.Defect.Extensions
{
    public static class InspecRegionModelExtensions
    {
        public static IRegionContext GetRegionContext(this InspecRegionModel Model)
        {
            LocalDeformableContext context = new LocalDeformableContext();
            context.Import(Model.Parameter);

            return context;
        }

        /// <summary>
        /// 获取检测图像基于参考点计算出来的位置Domain图像
        /// </summary>
        /// <param name="Image"></param>
        /// <param name="RegionModel"></param>
        /// <param name="ReferRow"></param>
        /// <param name="ReferColumn"></param>
        /// <returns></returns>
        public static HObject GetInspectImage(this InspecRegionModel Model, HObject ImageSource, double ReferRow, double ReferColumn)
        {
            var temp = Model.MatchSetting;
            RectangleLocation rl = temp.GetMatchRectangle(ReferRow, ReferColumn);
            return ImageSource.ReduceDomain(rl.GenRectangle1());
        }

    }
}
