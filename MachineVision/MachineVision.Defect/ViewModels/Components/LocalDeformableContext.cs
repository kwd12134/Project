using HalconDotNet;
using MachineVision.Core.Extensions;
using MachineVision.Core.TemplateMatch.LocalDeformable;
using MachineVision.Defect.Extensions;
using MachineVision.Defect.Models;
using MachineVision.Defect.ViewModels.Components.Models;
using Newtonsoft.Json;
using System.IO;

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

        public void InitStandardId(string Path)
        {
            var fileName = Path + Setting.StdFileName;
            if (File.Exists(fileName))
            {
                HOperatorSet.ReadVariationModel(fileName, out StandardId);
            }
        }

        public RegionContextResult Run(HObject image, InspecRegionModel Model)
        {
            //Image : 等待形变匹配的一个图像
            //Model : 待检测区域的对象
            HOperatorSet.FindLocalDeformableModel(image.RgbToGray(),
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
                //获取实际检测的目标位置
                var location = RectangleExtension.GetRectangleLocation(Model.MatchSetting.Width, Model.MatchSetting.Height, hv_Row.D, hv_Column.D);

                //input.ImageRectified.SaveIamge("C:\\Users\\86153\\OneDrive\\图片\\Image\\test1.bmp");
                //input.ImageRectified最终形变纠正后的标准图像  LocalDeformable
                //拿这个图像跟差分模型中的ModelID进行差分也就是    Variation
                //差分过程中,将我们界面设置的条件进行筛选 : 亮阈值,面积,暗阈值,面积进行筛选
                //最终输出结果
                var render = GetPrePareVariationModel();
                if (render != null)
                {
                    return new RegionContextResult() { IsSuccess = false, Render = render, Location = location, Name = Model.Name };
                }
                return new RegionContextResult() { IsSuccess = true, Location = location, Message = "未发现缺陷", Name = Model.Name };
            }
            return new RegionContextResult() { IsSuccess = false, Message = "未匹配", Name = Model.Name };
        }

        /// <summary> 
        /// 获取模型中的缺陷数据汇总 亮缺陷  暗缺陷
        /// </summary>
        /// <returns></returns>
        private LightAndDarkRegion? GetPrePareVariationModel()
        {
            if (Setting.Parameters == null) return null;
            foreach (var item in Setting.Parameters)
            {
                item.InitThresholds();
                //AbsThreshold: 0-255 [0~255,0~255]  当你的参数是一个值的时候,这个值就代表亮和暗的绝对阈值,如果是数值就是[亮,暗]
                //VarThreshold: 相对阈值 halcon示例中默认为3

                //亮缺陷筛选
                HOperatorSet.PrepareVariationModel(StandardId, item.H_AbsThreshold, item.H_VarThreshold);
                HOperatorSet.CompareVariationModel(input.ImageRectified, out HObject light, StandardId);
                HOperatorSet.Connection(light, out HObject LightRegions);
                HOperatorSet.SelectShape(LightRegions, out HObject LightError, "area", "and", item.MinArea, 999999999);

                //暗缺陷筛选
                HOperatorSet.PrepareVariationModel(StandardId, item.H_DarkAbsThreshold, item.H_DarkVarThreshold);
                HOperatorSet.CompareVariationModel(input.ImageRectified, out HObject dark, StandardId);
                HOperatorSet.Connection(dark, out HObject DarkRegions);
                HOperatorSet.SelectShape(DarkRegions, out HObject DarkError, "area", "and", item.MinDarkArea, 999999999);

                //查看是否有缺陷
                HOperatorSet.CountObj(LightError, out HTuple LightCount);
                HOperatorSet.CountObj(DarkError, out HTuple DarkCount);

                if (LightCount.D == 0 && DarkCount == 0) return null;

                //有缺陷就发返回
                return new LightAndDarkRegion() { Image = input.ImageRectified, Light = LightError, Dark = DarkError, };
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
                //设置形变参数
                (new HTuple("deformation_smoothness").TupleConcat("expand_border").TupleConcat("subpixel").TupleConcat("scale_c_step").TupleConcat("scale_r_step")),
                //设置形变参数 对应的值
                (new HTuple(70).TupleConcat(0).TupleConcat(1).TupleConcat(0.1).TupleConcat(0.1)),
                out hv_Score, out hv_Row, out hv_Column); ;

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
            HOperatorSet.CreateVariationModel(size[0], size[1], "byte", "standard", out StandardId);

            //使用裁剪的灰度图进行形变训练  相当于设置标准的差异模型以便后续的形变完成的差异匹配
            HOperatorSet.TrainVariationModel(image, StandardId);
            HOperatorSet.WriteVariationModel(StandardId, url + Setting.StdFileName);

            var stdUrl = model.GetRegionTrainUrl() + "standard.bmp";
            image.SaveIamge(stdUrl);
        }

        /// <summary>
        /// 更新本地的模型
        /// </summary>
        /// <param name="model"></param>
        public void RefreshVariationModel(InspecRegionModel model)
        {
            string url = model.GetRegionTrainUrl();
            var stdurl = model.GetRegionUrl();
            if (Directory.Exists(url))
            {
                string[] files = Directory.GetFiles(url);
                if (files.Length == 0) return;
                List<HImage> images = new List<HImage>();
                foreach (string file in files)
                {
                    if (Path.GetExtension(file) != ".bmp") continue;
                    HImage hImage = new HImage();
                    hImage.ReadImage(file);
                    images.Add(hImage);
                }

                //创建差异模型 训练 与 保存
                HOperatorSet.CreateVariationModel(model.MatchSetting.Width, model.MatchSetting.Height, "byte", "standard", out StandardId);

                //训练本地的缓存图像
                foreach (var image in images)
                {
                    HOperatorSet.TrainVariationModel(image, StandardId);
                }
                HOperatorSet.WriteVariationModel(StandardId, stdurl + Setting.StdFileName);

            }
        }

        public void AddTrainImage(InspecRegionModel model,HObject image)
        {
            string url = model.GetRegionUrl();
            HOperatorSet.TrainVariationModel(image, StandardId);
            HOperatorSet.WriteVariationModel(StandardId, url + Setting.StdFileName);

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
