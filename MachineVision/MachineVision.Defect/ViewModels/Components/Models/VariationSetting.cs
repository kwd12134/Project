using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineVision.Defect.ViewModels.Components.Models
{
    /// <summary>
    /// 缺陷检测参数配置
    /// 说明: 包含模型名称,模型的参数
    /// </summary>
    public class VariationSetting : BindableBase
    {
        private ObservableCollection<VariationParameter> parameters;
        /// <summary>
        /// 缺陷检测参数
        /// </summary>
        public ObservableCollection<VariationParameter> Parameters
        {
            get { return parameters; }
            set { parameters = value; }
        }


        private string stdFileName;

        /// <summary>
        /// 差异模型名称
        /// </summary>
        public string StdFileName
        {
            get { return stdFileName; }
            set { stdFileName = value; RaisePropertyChanged(); }
        }

        public void InitParameters()
        {
            foreach (var item in Parameters)
            {
                item.InitThresholds();
            }
        }

    }
}
