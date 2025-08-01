using HalconDotNet;
using Newtonsoft.Json;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineVision.Defect.ViewModels.Components.Models
{
    /// <summary>
    /// 缺陷检测参数
    /// </summary>
    public class VariationParameter : BindableBase
    {
        public int Id { get; set; }

        private int absThreshold;
        private int varThreshold;
        private int darkAbsThreshold;
        private int darkVarThreshold;
        private int minArea;
        private int minDarkArea;

        /// <summary>
        /// 绝对亮阈值
        /// </summary>
        public int AbsThreshold
        {
            get { return absThreshold; }
            set { absThreshold = value; RaisePropertyChanged(); }
        }

        /// <summary>
        /// 相对亮阈值
        /// </summary>
        public int VarThreshold
        {
            get { return varThreshold; }
            set { varThreshold = value; RaisePropertyChanged(); }
        }

        /// <summary>
        /// 亮 最小缺陷面积
        /// </summary>
        public int MinArea
        {
            get { return minArea; }
            set { minArea = value; RaisePropertyChanged(); }
        }

        /// <summary>
        /// 绝对暗阈值
        /// </summary>
        public int DarkAbsThreshold
        {
            get { return darkAbsThreshold; }
            set { darkAbsThreshold = value; RaisePropertyChanged(); }
        }

        /// <summary>
        /// 相对暗阈值
        /// </summary>
        public int DarkVarThreshold
        {
            get { return darkVarThreshold; }
            set { darkVarThreshold = value; RaisePropertyChanged(); }
        }

        /// <summary>
        /// 暗 最小缺陷面积
        /// </summary>
        public int MinDarkArea
        {
            get { return minDarkArea; }
            set { minDarkArea = value; RaisePropertyChanged(); }
        }

        [JsonIgnore]
        public HTuple H_AbsThreshold, H_VarThreshold, H_DarkAbsThreshold, H_DarkVarThreshold;

        public void ApplyDefaultValue()
        {
            AbsThreshold = 50;
            VarThreshold = 3;
            MinArea = 50;

            DarkAbsThreshold = 50;
            DarkVarThreshold = 3;
            MinDarkArea = 50;
        }

        public void InitThresholds()
        {
            //亮缺陷参数
            H_AbsThreshold = (new HTuple(AbsThreshold)).TupleConcat(255);
            H_VarThreshold = (new HTuple(VarThreshold)).TupleConcat(255);

            //暗缺陷参数
            H_DarkAbsThreshold = (new HTuple(255)).TupleConcat(DarkAbsThreshold);
            H_DarkVarThreshold = (new HTuple(255)).TupleConcat(DarkVarThreshold);
        }
    }
}
