using HalconDotNet;
using MachineVision.Core;
using MachineVision.Core.Ocr;
using MachineVision.Core.TemplateMatch.Shared;
using MachineVision.Shared.Controls;
using Microsoft.Win32;
using Prism.Commands;
using System.Collections.ObjectModel;

namespace MachineVision.Ocr.Models
{
    public class QrCodeViewModel:NavigationViewModel
    {
        public QrCodeViewModel(QrCodeService qrCodeService)
        {
            QrCodeService = qrCodeService;
            RunCommand = new DelegateCommand(Run);
            SetRangeCommand = new DelegateCommand(SetRange);
            LoadImageCommand = new DelegateCommand(LoadImage);
            DrawObjectList = new ObservableCollection<DrawingObjectInfo>();
            MaskObj = new HObject();
            OcrResults = new OcrResult();
        }

        public QrCodeService QrCodeService { get; }

        public DelegateCommand RunCommand { get; set; }
        public DelegateCommand SetRangeCommand { get; set; }
        public DelegateCommand LoadImageCommand { get; set; }

        private HObject image;
        private OcrResult ocrResults;
        private HObject maskObj;
        private ObservableCollection<DrawingObjectInfo> drawObjectList;

        public HObject Image
        {
            get { return image; }
            set { image = value; RaisePropertyChanged(); }
        }

        /// <summary>
        /// 掩膜
        /// </summary>
        public HObject MaskObj
        {
            get { return maskObj; }
            set { maskObj = value; RaisePropertyChanged(); }
        }

        /// <summary>
        /// 属性就绑定到了自定义控件中用于获取到内部参数
        /// </summary>
        public ObservableCollection<DrawingObjectInfo> DrawObjectList
        {
            get { return drawObjectList; }
            set { drawObjectList = value; RaisePropertyChanged(); }
        }

        public OcrResult OcrResults
        {
            get { return ocrResults; }
            set { ocrResults = value; RaisePropertyChanged(); }
        }

        public void Run()
        {
            OcrResults = QrCodeService.Run(Image);
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
                QrCodeService.Roi = new RoiParameter()
                {
                    Row1 = hobject.hTuples[0],
                    Column1 = hobject.hTuples[1],
                    Row2 = hobject.hTuples[2],
                    Column2 = hobject.hTuples[3],
                };

                OcrResults.Message = $"{DateTime.Now}: 创建ROI成功!";
            }
            else
                OcrResults.Message = $"{DateTime.Now}: 创建ROI失败!";
        }
    }
}
