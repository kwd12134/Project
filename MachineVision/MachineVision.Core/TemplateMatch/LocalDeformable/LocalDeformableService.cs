using HalconDotNet;
using MachineVision.Core.Extensions;
using MachineVision.Core.TemplateMatch.NccModel;
using MachineVision.Core.TemplateMatch.Shared;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;

namespace MachineVision.Core.TemplateMatch.LocalDeformable
{
    public class LocalDeformableService : BindableBase, ITemplateMatchService
    {
        public LocalDeformableService()
        {
            Info = new MethodInfo()
            {
                Name = "find_local_deformable_model",
                Description = "Find the best matches of a local deformable model in an image.",
                Parameters = new List<MethodParameter>()
                {
                   new MethodParameter(){ Name="Image", Description="Input image in which the model should be found." },
                   new MethodParameter(){ Name="ImageRectified", Description="Rectified image of the found model." },
                   new MethodParameter(){ Name="VectorField", Description="Vector field of the rectification transformation." },
                   new MethodParameter(){ Name="DeformedContours", Description="Contours of the found instances of the model." },
                   new MethodParameter(){ Name="ModelID", Description="Handle of the model." },
                   new MethodParameter(){ Name="AngleStart", Description="Smallest rotation of the model." },
                   new MethodParameter(){ Name="AngleExtent", Description="Extent of the rotation angles." },
                   new MethodParameter(){ Name="ScaleRMin", Description="Minimum scale of the model in row direction." },
                   new MethodParameter(){ Name="ScaleRMax", Description="Maximum scale of the model in row direction." },
                   new MethodParameter(){ Name="ScaleCMin", Description="Minimum scale of the model in column direction." },
                   new MethodParameter(){ Name="ScaleCMax", Description="Maximum scale of the model in column direction." },
                   new MethodParameter(){ Name="MinScore", Description="Minumum score of the instances of the model to be found." },
                   new MethodParameter(){ Name="NumMatches", Description="Number of instances of the model to be found (or 0 for all matches)." },
                   new MethodParameter(){ Name="MaxOverlap", Description="Maximum overlap of the instances of the model to be found." },
                   new MethodParameter(){ Name="NumLevels", Description="Number of pyramid levels used in the matching." },
                   new MethodParameter(){ Name="Greediness", Description="“Greediness” of the search heuristic (0: safe but slow; 1: fast but matches may be missed)." },
                   new MethodParameter(){ Name="ResultType", Description="Switch for requested iconic result." },
                   new MethodParameter(){ Name="GenParamName", Description="The general parameter names." },
                   new MethodParameter(){ Name="GenParamValue", Description="Values of the general parameters." },
                },
                Predecessors = new List<string>()
                {
                     "create_local_deformable_model",
                     "create_local_deformable_model_xld",
                     "read_deformable_model",
                }
            };
            Roi = new RoiParameter();
            Setting = new MatchResultSetting();
            TemplateParameter = new LocalDeformableInputParameter();
            TemplateParameter.ApplyDefaultParameter();
            RunParameter = new LocalDeformableRunParameter();
            RunParameter.ApplyDefaultParameter();
        }
        public RoiParameter Roi { get; set; }
        public MatchResultSetting Setting { get; set; }
        public MethodInfo Info { get; set; }

        public HTuple ModelId;

        private LocalDeformableInputParameter templateParameter;
        private LocalDeformableRunParameter runParameter;

        /// <summary>
        /// 相关性匹配-模板参数
        /// </summary>
        public LocalDeformableInputParameter TemplateParameter
        {
            get { return templateParameter; }
            set { templateParameter = value; RaisePropertyChanged(); }
        }

        /// <summary>
        /// 相关性匹配-运行参数
        /// </summary>
        public LocalDeformableRunParameter RunParameter
        {
            get { return runParameter; }
            set { runParameter = value; RaisePropertyChanged(); }
        }

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
                HOperatorSet.ReduceDomain(image, hObject, out HObject DomainImage);
                //灰度匹配需要转换成灰度图像 扩展方法
                HOperatorSet.CreateLocalDeformableModel(DomainImage,
                    TemplateParameter.NumLevels,
                    TemplateParameter.AngleStart,
                    TemplateParameter.AngleExtent,
                    TemplateParameter.AngleStep,
                    TemplateParameter.ScaleRmin,
                    TemplateParameter.ScaleRmax,
                    TemplateParameter.ScaleRstep,
                    TemplateParameter.ScaleCmin,
                    TemplateParameter.ScaleCmax,
                    TemplateParameter.ScaleCstep,
                    TemplateParameter.Optimization,
                    TemplateParameter.Metric,
                    TemplateParameter.Contrast,
                    TemplateParameter.MinContrast, new HTuple(), new HTuple(), out ModelId);
            });
        }

        public MatchResult Run(HObject image)
        {
            MatchResult matchResult = new MatchResult();
            matchResult.Reset();

            if (image == null)
            {
                matchResult.Message = "输入图像无效";
                return matchResult;
            }

            if (ModelId == null)
            {
                matchResult.Message = "输入模板无效";
                return matchResult;
            }

            HTuple hv_Row = new HTuple(), hv_Column = new HTuple();
            HTuple hv_Score = new HTuple();
            var timeSpan = SetTimerHelper.SetTimer(() =>
            {
                HOperatorSet.FindLocalDeformableModel(image,
                out RunParameter.ImageRectified,
                out RunParameter.VectorField,
                out RunParameter.DeformedContours,
                ModelId,
                RunParameter.AngleStart,
                RunParameter.AngleExtent,
                RunParameter.ScaleRmin,
                RunParameter.ScaleRmax,
                RunParameter.ScaleCmin,
                RunParameter.ScaleCmax,
                RunParameter.MinScore,
                RunParameter.NumMatches,
                RunParameter.MaxOverlap,
                RunParameter.NumLevels,
                RunParameter.Greediness,
                ((new HTuple("image_rectified"))
                .TupleConcat("vector_field"))
                .TupleConcat("deformed_contours"),
                new HTuple(),
                new HTuple(), out hv_Score, out hv_Row, out hv_Column);
            });
            for (int i = 0; i < hv_Score.Length; i++)
            {
                matchResult.Results.Add(new TemplateMatchResult()
                {
                    Index = i + 1,
                    Row = hv_Row.DArr[i],
                    Column = hv_Column.DArr[i],
                    Score = hv_Score.DArr[i],
                });
            }

            //在窗口中渲染结果
            if (matchResult.Results != null)
            {
                foreach (var item in matchResult.Results)
                {
                    if (Setting.IsShowCenter)
                        HWindow.DispCross(item.Row, item.Column, 30, item.Angle);

                    if (Setting.IsShowDisplayText)
                        HWindow.SetString($"({Math.Round(item.Row, 2)},{Math.Round(item.Column, 2)})", "image", item.Row, item.Column, "black", "true");
                }
                matchResult.Message = $"{DateTime.Now}: 匹配耗时:{timeSpan} ms ，匹配个数:{matchResult.Results.Count}";
            }
            matchResult.TimeSpan = timeSpan;
            return matchResult;
        }

        public void SetRunParamter()
        {

        }

        public void SetTemplateParamter()
        {

        }
    }
}
