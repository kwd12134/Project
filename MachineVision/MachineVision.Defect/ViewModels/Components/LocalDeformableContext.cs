using HalconDotNet;
using MachineVision.Core.Extensions;
using MachineVision.Core.TemplateMatch.LocalDeformable;
using MachineVision.Defect.Extensions;
using MachineVision.Defect.Models;
using MachineVision.Defect.ViewModels.Components.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineVision.Defect.ViewModels.Components
{
    /// <summary>
    /// 缺陷检测服务
    /// </summary>
    public class LocalDeformableContext : IRegionContext, IRestoreMatchRegion
    {
        public LocalDeformableContext()
        {
            Setting = new VariationSetting();
        }

        public VariationSetting Setting { get; set; }

        private LocalDeformableRunParameter input = new LocalDeformableRunParameter();
        HTuple hv_Score = new HTuple();
        HTuple hv_Row = new HTuple();
        HTuple hv_Column = new HTuple();
        private HTuple StandardId = new HTuple();
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string GetJsonParameter() => JsonConvert.SerializeObject(Setting);

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="Parameter"></param>
        public void Import(string Parameter)
        {

        }

        public void Run(HObject image)
        {

        }

        public void UpdateVariationModel(HObject image, InspecRegionModel model)
        {
            var url = model.GetRegionUrl();

            Setting.StdFileName = "standard.vam";

            var size = image.GetImageSize();

            model.MatchSetting.Width = size[0];
            model.MatchSetting.Height = size[1];

            //创建差异模型 训练 与 保存
            HOperatorSet.CreateVariationModel(size[0], size[1], "byte", "standard", out HTuple modelID);
            //使用裁剪的灰度图进行形变训练
            HOperatorSet.TrainVariationModel(image, modelID);
            HOperatorSet.WriteVariationModel(modelID, url + Setting.StdFileName);
        }

        /// <summary>
        /// 还原检测区域的实际位置
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        public void RestorePosition(HObject Image, InspecRegionModel RegionModel, double ReferRow, double ReferColumn)
        {
            var temp = RegionModel.MatchSetting;
            if (temp.ModelId == null) return;

            //1.获取检测区域在大图像当中的相对位置
            RectangleLocation rl = temp.GetMatchRectangle(ReferRow, ReferColumn);            

            //2.在相对位置中查找该检测区域的实际位置
            HOperatorSet.FindLocalDeformableModel(Image.ReduceDomain(rl.GenRectangle1()),
                out input.ImageRectified,
                out input.VectorField,
                out input.DeformedContours,
                temp.ModelId,
                input.AngleStart,
                input.AngleExtent,
                input.ScaleRmin,
                input.ScaleRmax,
                input.ScaleCmin,
                input.ScaleCmax,
                input.MinScore,
                input.NumMatches,
                input.MaxOverlap,
                input.NumLevels,
                input.Greediness,
                ((new HTuple("image_rectified"))
                .TupleConcat("vector_field"))
                .TupleConcat("deformed_contours"),
                new HTuple(),
                new HTuple(), out hv_Score, out hv_Row, out hv_Column);

            if (hv_Score > 0)
            {
                //相当于校验一遍
               var location =  RectangleExtension.GetRectangleLocation(temp.Width, temp.Height, hv_Row.D, hv_Column.D);
                temp.X1 = location.X1;
                temp.X2 = location.X2;
                temp.Y1 = location.Y1;
                temp.Y2 = location.Y2;
            }

        }

        public void Dispose()
        {

        }
    }
}
