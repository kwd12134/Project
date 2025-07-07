using HalconDotNet;
using MachineVision.Core;
using MachineVision.Core.TemplateMatch;
using MachineVision.Shared.Controls;
using Microsoft.Win32;
using Prism.Commands;
using Prism.Common;
using Prism.Ioc;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace MachineVision.TemplateMatch.ViewModels
{
    public class ShapeViewModel : NavigationViewModel
    {
        public ITemplateMatchService MatchService { get; set; }
        /// <summary>
        /// 可以用构造函数依赖输入也可以如下使用静态入口获取
        /// </summary>
        public ShapeViewModel()
        {
            //这是 Prism 提供的全局静态入口，用来访问当前的 IOC 容器（Container），它实现了 IContainerProvider 接口。 外部注册
            MatchService = ContainerLocator.Current.Resolve<ITemplateMatchService>(nameof(TemplateMatchType.ShapeModel));
            RunCommand = new DelegateCommand(Run);
            CreateTemplateCommand = new DelegateCommand(CreateTemplate);
            SetRangeCommand = new DelegateCommand(SetRange);
            LoadImageCommand = new DelegateCommand(LoadImage);

            MatchResults = new ObservableCollection<TemplateMatchResult>();
            image = new HObject();
            drawObjectList = new ObservableCollection<DrawingObjectInfo>();
        }
        #region Command && Property

        private ObservableCollection<TemplateMatchResult> matchResults;
        /// <summary>
        /// datagrid匹配结果集合
        /// </summary>
        public ObservableCollection<TemplateMatchResult> MatchResults
        {
            get { return matchResults; }
            set { matchResults = value; RaisePropertyChanged(); }
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
            set { drawObjectList = value; RaisePropertyChanged(); }
        }

        public DelegateCommand RunCommand { get; set; }
        public DelegateCommand CreateTemplateCommand { get; set; }
        public DelegateCommand SetRangeCommand { get; set; }
        public DelegateCommand LoadImageCommand { get; set; }

        #endregion

        #region Command Method

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

        }
        /// <summary>
        /// 创建匹配模版
        /// </summary>
        private void CreateTemplate()
        {
            var hobject = drawObjectList.FirstOrDefault();
            if (hobject != null)
            {
                MatchService.CreateTemplate(Image, hobject.Hobject);

            }
        }
        /// <summary>
        /// 执行
        /// </summary>
        private void Run()
        {

        }
        #endregion

    }
}
