using HalconDotNet;
using MachineVision.Core;
using MachineVision.Core.TemplateMatch;
using MachineVision.Core.TemplateMatch.Shared;
using MachineVision.Shared.Controls;
using Microsoft.Win32;
using Prism.Commands;
using Prism.Common;
using Prism.Ioc;
using Prism.Mvvm;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Documents;

namespace MachineVision.TemplateMatch.ViewModels
{

    public class LocalDeformableViewModel : BindableBase
    {
        /// <summary>
        /// 只能访问ITemplateMatchService这个接口中有定义的熟悉或者函数
        /// </summary>
        public ITemplateMatchService MatchService { get; set; }

        public LocalDeformableViewModel()
        {
            //这是 Prism 提供的全局静态入口，用来访问当前的 IOC 容器（Container），它实现了 IContainerProvider 接口。 外部注册
            MatchService = ContainerLocator.Current.Resolve<ITemplateMatchService>(nameof(TemplateMatchType.LocalDeformable));
            RunCommand = new DelegateCommand(Run);
            CreateTemplateCommand = new DelegateCommand(CreateTemplate);
            SetRangeCommand = new DelegateCommand(SetRange);
            LoadImageCommand = new DelegateCommand(LoadImage);
            DrawObjectList = new ObservableCollection<DrawingObjectInfo>();
            MacthResults = new MatchResult();
        }
        private HObject maskObj;
        private HObject image;
        private ObservableCollection<DrawingObjectInfo> drawObjectList;

        /// <summary>
        /// 掩膜
        /// </summary>
        public HObject MaskObj
        {
            get { return maskObj; }
            set { maskObj = value; RaisePropertyChanged(); }
        }

        public HObject Image
        {
            get { return image; }
            set { image = value; RaisePropertyChanged(); }
        }

        /// <summary>
        /// 属性就绑定到了自定义控件中用于获取到内部参数
        /// </summary>
        public ObservableCollection<DrawingObjectInfo> DrawObjectList
        {
            get { return drawObjectList; }
            set { drawObjectList = value; RaisePropertyChanged(); }
        }

        private MatchResult matchResults;

        public MatchResult MacthResults
        {
            get { return matchResults; }
            set { matchResults = value; RaisePropertyChanged(); }
        }

        public DelegateCommand RunCommand { get; set; }
        public DelegateCommand CreateTemplateCommand { get; set; }
        public DelegateCommand SetRangeCommand { get; set; }
        public DelegateCommand LoadImageCommand { get; set; }

        /// <summary>
        /// 加载图像源
        /// </summary>
        private void LoadImage()
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
        /// <summary>
        /// 设置识别ROI范围
        /// </summary>
        private void SetRange()
        {
            var hobject = drawObjectList.FirstOrDefault();
            if (hobject != null && hobject.ShapeType == ShapeType.Rectangle)
            {
                //获取ROI
                MatchService.Roi = new RoiParameter()
                {
                    Row1 = hobject.hTuples[0],
                    Column1 = hobject.hTuples[1],
                    Row2 = hobject.hTuples[2],
                    Column2 = hobject.hTuples[3],
                };

                matchResults.Message = $"{DateTime.Now}: 创建ROI成功!";
            }
            else
                matchResults.Message = $"{DateTime.Now}: 创建ROI失败!";
        }
        /// <summary>
        /// 创建匹配模版
        /// </summary>
        private void CreateTemplate()
        {
            if (drawObjectList == null) return;
            var hobject = drawObjectList.FirstOrDefault();
            if (hobject != null)
            {
                if (MaskObj != null)
                {
                    //裁剪出掩膜的区分差异
                    HOperatorSet.Difference(hobject.Hobject, MaskObj, out HObject regionDifference);
                    MatchService.CreateTemplate(Image, regionDifference);
                }
                else
                {
                    MatchService.CreateTemplate(Image, hobject.Hobject);
                }
                matchResults.Message = $"{DateTime.Now}: 创建模版成功!";
            }
            else
                matchResults.Message = $"{DateTime.Now}: 创建模版失败!";
        }
        /// <summary>
        /// 执行
        /// </summary>
        private void Run()
        {
            MacthResults = MatchService.Run(image);
        }
    }
}
