using HalconDotNet;
using MachineVision.Core.Extensions;
using MachineVision.Defect.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace MachineVision.Defect.Extensions
{
    public static partial class ProjectExtensions
    {
        /// <summary>
        /// 更新项目的参考点模板
        /// </summary>
        /// <param name="Model"></param>
        /// <param name="Template"></param>
        /// <returns></returns>
        public static async Task UpdateReferTemplate(this ProjectModel Model, HObject Template)
        {
            var url = Model.GetReferUrl();
            var refer = Model.ReferSetting;
            refer.PrewViewFileName = "default.png";
            refer.TemplateFileName = "default.ncm";

            refer.ModelId = await CreateNccTemplateModel(Template, url + refer.TemplateFileName);
        }

        public static async Task<HTuple> CreateNccTemplateModel(HObject template, string fileName)
        {
            return await Task.Run(() =>
            {
                var grayImage = template.RgbToGray();
                HOperatorSet.CreateNccModel(grayImage, "auto", 0, 0, "auto", "use_polarity", out HTuple ModelId);
                string imageFileName = $"{fileName.Replace(".ncm", "")}.png";
                HOperatorSet.WriteImage(grayImage, "png", 0, imageFileName);
                HOperatorSet.WriteNccModel(ModelId, fileName);
                return ModelId;
            });
        }
    }
}
