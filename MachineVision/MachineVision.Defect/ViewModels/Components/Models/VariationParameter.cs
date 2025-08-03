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
        /// <summary>
        /// 对于亮缺陷来说：检测的是比背景亮的区域，一般设置为 (阈值, 255)，表示只检测灰度大于阈值的区域。
        /// 对于暗缺陷来说：检测的是比背景暗的区域，设置为(255, 阈值) 并不是错误，而是一种差分逻辑的特例用法。
        /// </summary>
        public void InitThresholds()
        {
            //亮缺陷参数
            H_AbsThreshold = (new HTuple(AbsThreshold)).TupleConcat(255); //(AbsThreshold,255)构造一个元组 (AbsThreshold, 255)，一般用于 Halcon 中的一些算子需要提供两个阈值（如上下限）
            H_VarThreshold = (new HTuple(VarThreshold)).TupleConcat(255); //(VarThreshold,255)

            //暗缺陷参数
            H_DarkAbsThreshold = (new HTuple(255)).TupleConcat(DarkAbsThreshold); //(255,DarkAbsThreshold) 构造一个元组 (255, DarkAbsThreshold)，可能是表示暗区域的上下限阈值。
            H_DarkVarThreshold = (new HTuple(255)).TupleConcat(DarkVarThreshold); //(255,DarkVarThreshold)
        }
    }
}
