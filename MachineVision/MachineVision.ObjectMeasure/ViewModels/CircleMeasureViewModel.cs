using HalconDotNet;
using MachineVision.Core;
using MachineVision.Core.ObjectMeasure;
using MachineVision.Core.Ocr;
using MachineVision.Core.TemplateMatch.Shared;
using MachineVision.Shared.Controls;
using Microsoft.Win32;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineVision.ObjectMeasure.ViewModels
{
    /// <summary>
    /// 查找圆模块
    /// </summary>
    public class CircleMeasureViewModel : NavigationViewModel
    {
        public CircleMeasureViewModel(CircleMeasureService service)
        {
            Service = service;
            RunCommand = new DelegateCommand(Run);
            GetParameterCommand = new DelegateCommand(GetParameter);
            SetRangeCommand = new DelegateCommand(SetRange);
            LoadImageCommand = new DelegateCommand(LoadImage);
            DrawObjectList = new ObservableCollection<DrawingObjectInfo>();
            MaskObj = new HObject();
        }

        public CircleMeasureService Service { get; }

        public DelegateCommand RunCommand { get; set; }
        public DelegateCommand GetParameterCommand { get; set; }
        public DelegateCommand SetRangeCommand { get; set; }
        public DelegateCommand LoadImageCommand { get; set; }

        private HObject image;

        public HObject Image
        {
            get { return image; }
            set { image = value; RaisePropertyChanged(); }
        }

        private ObservableCollection<DrawingObjectInfo> drawObjectList;

        /// <summary>
        /// 属性就绑定到了自定义控件中用于获取到内部参数
        /// </summary>
        public ObservableCollection<DrawingObjectInfo> DrawObjectList
        {
            get { return drawObjectList; }
            set { drawObjectList = value; RaisePropertyChanged(); }
        }

        private HObject maskObj;
        /// <summary>
        /// 掩膜
        /// </summary>
        public HObject MaskObj
        {
            get { return maskObj; }
            set { maskObj = value; RaisePropertyChanged(); }
        }

        public void Run()
        {
            Service.Run(Image);
        }
        public void LoadImage()
        {
            OpenFileDialog fileDialog = new OpenFileDialog()
            {
                Filter = "图像文件|*.jpg;*.png;*.bmp|所有文件|*.*"
            };
            bool? result = fileDialog.ShowDialog();
            if (result == true)
            {
                var img = new HImage();
                img.ReadImage(fileDialog.FileName);
                Image = img;
            }
        }

        public void SetRange()
        {
            if (drawObjectList == null) return;
            var hobject = drawObjectList.FirstOrDefault();
            if (hobject != null && hobject.ShapeType == ShapeType.Rectangle)
            {
                //获取ROI
                Service.Roi = new RoiParameter()
                {
                    Row1 = hobject.hTuples[0],
                    Column1 = hobject.hTuples[1],
                    Row2 = hobject.hTuples[2],
                    Column2 = hobject.hTuples[3],
                };
            }
        }
        public void GetParameter()
        {
            var obj = drawObjectList.FirstOrDefault(t => t.ShapeType == ShapeType.Circle);
            if (obj != null)
            {
                Service.RunParameter.Row = obj.hTuples[0];
                Service.RunParameter.Column = obj.hTuples[1];
                Service.RunParameter.Radius = obj.hTuples[2];
            }
        }

    }
}
