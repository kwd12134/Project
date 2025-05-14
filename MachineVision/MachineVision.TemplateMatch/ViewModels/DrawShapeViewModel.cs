using HalconDotNet;
using MachineVision.Core;
using MachineVision.Shared.Controls;
using Microsoft.Win32;
using Prism.Commands;
using System.Collections.ObjectModel;

namespace MachineVision.TemplateMatch.ViewModels
{
    public class DrawShapeViewModel : NavigationViewModel
    {
        public DrawShapeViewModel()
        {
            LoadImageCommand = new DelegateCommand(LoadImage);
            DrawObjectList = new ObservableCollection<DrawingObjectInfo>();
        }

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
            set { drawObjectList = value;RaisePropertyChanged(); }
        }

        public DelegateCommand LoadImageCommand { get; set; }

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

    }
}
