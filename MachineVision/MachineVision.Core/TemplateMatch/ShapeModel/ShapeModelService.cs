using HalconDotNet;
using MachineVision.Core.Extensions;
using MachineVision.Core.TemplateMatch.Shared;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace MachineVision.Core.TemplateMatch.ShapeModel
{
    /// <summary>
    /// 模板匹配与实际见面分离    
    /// </summary>
    public class ShapeModelService : BindableBase, ITemplateMatchService
    {
        public ShapeModelService()
        {
            Info = new MethodInfo()
            {
                Name = "find_shape_model",
                Description = "Find the best matches of a shape model in an image.",
                Parameters = new List<MethodParameter>()
                {
                   new MethodParameter(){ Name="Image", Description="Input image in which the model should be found." },
                   new MethodParameter(){ Name="ModelID", Description="Handle of the model." },
                   new MethodParameter(){ Name="AngleStart", Description="Smallest rotation of the model." },
                   new MethodParameter(){ Name="AngleExtent", Description="Extent of the rotation angles." },
                   new MethodParameter(){ Name="MinScore", Description="Minimum score of the instances of the model to be found." },
                   new MethodParameter(){ Name="NumMatches", Description="Number of instances of the model to be found (or 0 for all matches)." },
                   new MethodParameter(){ Name="MaxOverlap ", Description="Maximum overlap of the instances of the model to be found." },
                   new MethodParameter(){ Name="SubPixel", Description="Subpixel accuracy if not equal to 'none'." },
                   new MethodParameter(){ Name="NumLevels", Description="Number of pyramid levels used in the matching (and lowest pyramid level to use if |NumLevels| = 2)." },
                   new MethodParameter(){ Name="Greediness", Description="“Greediness” of the search heuristic (0: safe but slow; 1: fast but matches may be missed)." },
                   new MethodParameter(){ Name="Row", Description="Row coordinate of the found instances of the model." },
                   new MethodParameter(){ Name="Column", Description="Column coordinate of the found instances of the model." },
                   new MethodParameter(){ Name="Angle", Description="Rotation angle of the found instances of the model." },
                   new MethodParameter(){ Name="Score", Description="Score of the found instances of the model." },
                },
                Predecessors = new List<string>()
                {
                     "create_shape_model",
                     "read_shape_model",
                     "write_shape_model",
                }
            };

            //初始化默认值
            TemplateParameter = new ShapeModelInputParameter();
            TemplateParameter.ApplyDefaultParameter();

            runParameter = new ShapeModelRunParameter();
            runParameter.ApplyDefaultParameter();

            Setting = new MatchResultSetting();
            Roi = new RoiParameter();

        }
        private HTuple ModelId;
        HTuple hv_Row = new HTuple(), hv_Column = new HTuple();
        HTuple hv_Angle = new HTuple(), hv_Score = new HTuple();
        public MethodInfo Info { get; set; }

        private ShapeModelInputParameter templateParameter;
        /// <summary>
        /// 模版匹配参数
        /// </summary>
        public ShapeModelInputParameter TemplateParameter
        {
            get { return templateParameter; }
            set { templateParameter = value; RaisePropertyChanged(); }
        }

        private ShapeModelRunParameter runParameter;
        /// <summary>
        /// 运行参数
        /// </summary>
        public ShapeModelRunParameter RunParameter
        {
            get { return runParameter; }
            set { runParameter = value; RaisePropertyChanged(); }
        }

        private MatchResultSetting setting;

        public MatchResultSetting Setting
        {
            get { return setting; }
            set { setting = value; RaisePropertyChanged(); }
        }

        public RoiParameter Roi { get; set; }

        private HWindow hWindow;

        public HWindow HWindow
        {
            get { return hWindow; }
            set { hWindow = value; RaisePropertyChanged(); }
        }



        public async Task CreateTemplate(HObject image, HObject hObject)
        {
            await Task.Run(() =>
            {
                HObject DomainImage;
                HOperatorSet.ReduceDomain(image, hObject, out DomainImage);
                HOperatorSet.CreateShapeModel(DomainImage,
                    TemplateParameter.NumLevels,
                    TemplateParameter.AngleStart,
                    TemplateParameter.AngleExtent,
                    TemplateParameter.AngleStep,
                    TemplateParameter.Optimization,
                    TemplateParameter.Metric,
                    TemplateParameter.Contrast,
                    TemplateParameter.MinContrast,
                    out ModelId
                    );
            });
        }

        public void SetRunParamter()
        {

        }

        public void SetTemplateParamter()
        {

        }

        public MatchResult Run(HObject image)
        {

            MatchResult matchResult = new MatchResult();
            if (image == null)
            {
                matchResult.Message = "图片异常,请检查!";
                return matchResult;
            }
            if (ModelId == null)
            {
                matchResult.Message = "未创建模版,请检查!";
                return matchResult;
            }
            matchResult.TimeSpan = SetTimerHelper.SetTimer(() =>
            {
                //生成roi的范围图像
                if (Roi.Row1 != 0 && Roi.Column1 != 0 && Roi.Column2 != 0)
                {
                    HObject hobject;
                    HOperatorSet.GenEmptyObj(out hobject);//halcon中生成一个空对象
                    HOperatorSet.GenRectangle1(out HObject rectangle, Roi.Row1, Roi.Column1, Roi.Row2, Roi.Column2);
                    HOperatorSet.ReduceDomain(image, rectangle, out image);
                }
                HOperatorSet.FindShapeModel(
                        image,
                        ModelId,
                        RunParameter.AngleStart,
                        RunParameter.AngleExtent,
                        RunParameter.MinScore,
                        RunParameter.NumMatches,
                        RunParameter.MaxOverlap,
                        RunParameter.SubPixel,
                        RunParameter.NumLevels,
                        RunParameter.Greediness,
                        out hv_Row, out hv_Column, out hv_Angle, out hv_Score);
                //获取形状模型轮廓
                HOperatorSet.GetShapeModelContours(out HObject contour, ModelId, 1);

                for (int i = 0; i < hv_Score.Length; i++)
                {
                    //提取轮廓仿射变换  计算轮廓匹配的目标位置对象
                    HOperatorSet.VectorAngleToRigid(0, 0, 0, hv_Row.DArr[i], hv_Column.DArr[i], hv_Angle.DArr[i], out HTuple homMat2D);
                    //AffineTrans仿射变换  计算一个刚性仿射变换矩阵，也就是旋转 + 平移（不缩放）
                    HOperatorSet.AffineTransContourXld(contour, out HObject contoursAffineTrans, homMat2D);

                    matchResult.Results.Add(new TemplateMatchResult()
                    {
                        Index = i + 1,
                        Row = hv_Row.DArr[i],
                        Column = hv_Column.DArr[i],
                        Angle = hv_Angle.DArr[i],
                        Score = hv_Score.DArr[i],
                        ContoursAffineTrans = contoursAffineTrans
                    });
                }
            });

            //在窗口中渲染结果
            if (matchResult.Results != null)
            {
                foreach (var item in matchResult.Results)
                {
                    if (Setting.IsShowCenter)
                        HWindow.DispCross(item.Row, item.Column, 30, item.Angle);

                    if (Setting.IsShowDisplayText)
                        HWindow.SetString($"({Math.Round(item.Row, 2)},{Math.Round(item.Column, 2)})", "image", item.Row, item.Column, "black", "true");

                    if (Setting.IsShowMatchRange)
                        HWindow.DispObj(item.ContoursAffineTrans);
                }
                matchResult.Message = $"{DateTime.Now}:匹配耗时:{matchResult.TimeSpan}ms,匹配个数{matchResult.Results.Count}";
            }

            matchResult.Setting = Setting;

            return matchResult;

        }

    }
}
