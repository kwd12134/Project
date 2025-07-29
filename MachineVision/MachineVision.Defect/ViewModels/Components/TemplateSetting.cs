using HalconDotNet;
using MachineVision.Defect.Extensions;
using Newtonsoft.Json;
using Prism.Mvvm;
using System.IO;

namespace MachineVision.Defect.ViewModels.Components
{
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
        public void InitParameter(string Name)
        {
            string Template = $"{ProjectExtensions.BasrUrl}{Name}\\Refer\\{templateFileName}";
            if (!string.IsNullOrWhiteSpace(Template))
            {
                if (File.Exists(Template))
                {
                    HOperatorSet.ReadNccModel(Template, out ModelId);
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
