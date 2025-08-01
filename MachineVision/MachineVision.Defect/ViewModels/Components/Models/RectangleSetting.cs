using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineVision.Defect.ViewModels.Components.Models
{
    /// <summary>
    /// 矩形参数
    /// </summary>
    public class RectangleSetting : BindableBase
    {
        private double x1, x2, y1, y2;

        public double X1
        {
            get { return x1; }
            set { x1 = value; RaisePropertyChanged(); }
        }

        public double X2
        {
            get { return x2; }
            set { x2 = value; RaisePropertyChanged(); }
        }

        public double Y1
        {
            get { return y1; }
            set { y1 = value; RaisePropertyChanged(); }
        }

        public double Y2
        {
            get { return y2; }
            set { y2 = value; RaisePropertyChanged(); }
        }

        /// <summary>
        /// 行坐标
        /// </summary>
        public double Row { get; set; }

        /// <summary>
        /// 列坐标
        /// </summary>
        public double Column { get; set; }

        /// <summary>
        /// 行偏移
        /// </summary>
        public double RowSpacing { get; set; }

        /// <summary>
        /// 列偏移
        /// </summary>
        public double ColumnSpacing { get; set; }

        /// <summary>
        /// 宽度
        /// </summary>
        public double Width { get; set; }

        /// <summary>
        /// 高度
        /// </summary>
        public double Height { get; set; }
    }
}
