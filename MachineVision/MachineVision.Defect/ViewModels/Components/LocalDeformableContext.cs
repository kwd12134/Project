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
            input = new LocalDeformableRunParameter();
            input.ApplyDefaultParameter();
        }

        /// <summary>
        /// 缺陷检测服务参数
        /// </summary>
        public VariationSetting Setting { get; set; }

        private LocalDeformableRunParameter input;
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
            if (!string.IsNullOrWhiteSpace(Parameter))
                Setting = JsonConvert.DeserializeObject<VariationSetting>(Parameter);
            else
                Setting = new VariationSetting();
        }

        public void Run(HObject image, InspecRegionModel Model)
        {
            //Image : 等待形变匹配的一个图像
            //Model : 待检测区域的对象
            HOperatorSet.FindLocalDeformableModel(image,
                //这一块输出的就是对裁剪的Image矫正跟初始形变模型一样
                out input.ImageRectified,
                out input.VectorField,
                out input.DeformedContours,
                Model.MatchSetting.ModelId,
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
                //input.ImageRectified最终形变纠正后的标准图像  LocalDeformable
                //拿这个图像跟差分模型中的ModelID进行差分也就是    Variation
                //差分过程中,将我们界面设置的条件进行筛选 : 亮阈值,面积,暗阈值,面积进行筛选
                //最终输出结果
                var render = GetPrePareVariationModel();
                if (render!=null)
                {

                }
            }

        }

        /// <summary> 
        /// 获取模型中的缺陷数据汇总 亮缺陷  暗缺陷
        /// </summary>
        /// <returns></returns>
        private LightAndDarkRegion GetPrePareVariationModel()
        {

            foreach (var item in Setting.Parameters)
            {
                //亮缺陷筛选
                HOperatorSet.PrepareVariationModel(null, item.H_AbsThreshold, item.H_VarThreshold);
                HOperatorSet.CompareVariationModel(input.ImageRectified, out HObject light, null);
                HOperatorSet.Connection(light, out HObject LightRegions);
                HOperatorSet.SelectShape(LightRegions, out HObject LightError, "area", "and", item.MinArea, 999999999);

                //暗缺陷筛选
                HOperatorSet.PrepareVariationModel(null, item.H_DarkAbsThreshold, item.H_DarkVarThreshold);
                HOperatorSet.CompareVariationModel(input.ImageRectified, out HObject dark, null);
                HOperatorSet.Connection(dark, out HObject DarkRegions);
                HOperatorSet.SelectShape(DarkRegions, out HObject DarkError, "area", "and", item.MinDarkArea, 999999999);

                //查看是否有缺陷
                HOperatorSet.CountObj(LightError, out HTuple LightCount);
                HOperatorSet.CountObj(DarkError, out HTuple DarkCount);

                if (LightCount.D == 0 && DarkCount == 0) return null;

                return new LightAndDarkRegion() { Light = LightError, Dark = DarkError, };
            }
            return null;
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
                var location = RectangleExtension.GetRectangleLocation(temp.Width, temp.Height, hv_Row.D, hv_Column.D);
                temp.X1 = location.X1;
                temp.X2 = location.X2;
                temp.Y1 = location.Y1;
                temp.Y2 = location.Y2;
            }

        }
        /// <summary>
        /// 差异模型初始设定
        /// </summary>
        /// <param name="image"></param>
        /// <param name="model"></param>
        public void UpdateVariationModel(HObject image, InspecRegionModel model)
        {
            var url = model.GetRegionUrl();

            Setting.StdFileName = "standard.vam";

            var size = image.GetImageSize();

            model.MatchSetting.Width = size[0];
            model.MatchSetting.Height = size[1];

            //创建差异模型 训练 与 保存
            HOperatorSet.CreateVariationModel(size[0], size[1], "byte", "standard", out HTuple modelID);
            //使用裁剪的灰度图进行形变训练  相当于设置标准的差异模型以便后续的形变完成的差异匹配
            HOperatorSet.TrainVariationModel(image, modelID);
            HOperatorSet.WriteVariationModel(modelID, url + Setting.StdFileName);
        }


        public void Dispose()
        {
            hv_Score?.Dispose();
            hv_Column?.Dispose();
            hv_Row?.Dispose();

            input?.Disponse();
        }

    }
}
