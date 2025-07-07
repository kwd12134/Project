using HalconDotNet;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineVision.Core.TemplateMatch.ShapeModel
{
    public class ShapeModelService :BindableBase, ITemplateMatchService
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
        }
        private HTuple ModelId;
        public MethodInfo Info { get; set; }

        private ShapeModelInputParameter templateParameter;
        /// <summary>
        /// 模版匹配参数
        /// </summary>
        public ShapeModelInputParameter TemplateParameter
        {
            get { return templateParameter; }
            set { templateParameter = value;RaisePropertyChanged(); }
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


        public async Task CreateTemplate(HObject image, HObject hObject)
        {
            await Task.Run(() =>
            {
                HObject DomainImage;
                HOperatorSet.ReduceDomain(image, hObject,out DomainImage);
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
    }
}
