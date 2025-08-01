using HalconDotNet;
using MachineVision.Defect.Extensions;
using Newtonsoft.Json;
using Prism.Mvvm;
using System.IO;

namespace MachineVision.Defect.ViewModels.Components.Models
{
    /// <summary>
    /// 模型id与保存地址   roi区域数据
    /// </summary>
    public class TemplateSetting : RectangleSetting
    {
        private string templateFileName, prewViewFileName;

        /// <summary>
        /// 参考点模板文件
        /// </summary>
        public string TemplateFileName
        {
            get { return templateFileName; }
            set
            {
                templateFileName = value; RaisePropertyChanged();
            }
        }

        /// <summary>
        /// 参考点预览图像
        /// </summary>
        public string PrewViewFileName
        {
            get { return prewViewFileName; }
            set
            {
                prewViewFileName = value; RaisePropertyChanged();
            }
        }

        [JsonIgnore]
        public HTuple ModelId;

        /// <summary>
        /// 初始化已保存的模版设置参数
        /// </summary>
        public void InitParameter(string Path)
        {
            string Template = $"{Path}{templateFileName}";
            if (!string.IsNullOrWhiteSpace(Template))
            {
                if (File.Exists(Template))
                {
                    if (Template.Contains("ncm"))
                    {
                        HOperatorSet.ReadNccModel(Template, out ModelId);
                    }
                    else if (Template.Contains("dfm"))
                    {
                        HOperatorSet.ReadDeformableModel(Template, out ModelId);
                    }
                }
            }
        }

        /// <summary>
        /// 释放非托管的资源
        /// </summary>
        public void Dispose()
        {
            TemplateFileName = string.Empty;
            PrewViewFileName = string.Empty;

            ModelId?.Dispose();
        }

    }
}
