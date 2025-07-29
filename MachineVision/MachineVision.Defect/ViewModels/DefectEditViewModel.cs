using HalconDotNet;
using MachineVision.Core;
using MachineVision.Core.Extensions;
using MachineVision.Defect.Extensions;
using MachineVision.Defect.Models;
using MachineVision.Defect.Models.UI;
using MachineVision.Defect.Service;
using MachineVision.Shared.Controls;
using Prism.Commands;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineVision.Defect.ViewModels
{
    public class DefectEditViewModel : NavigationViewModel
    {
        public DefectEditViewModel(TargetService targetService, ProjectService appService)
        {
            LoadImageCommand = new DelegateCommand(LoadImage);
            Files = new ObservableCollection<ImageFile>();
            SetModelParamCommand = new DelegateCommand(SetModelParam);
            TargetService = targetService;
            AppService = appService;
            UpdateModelCommand = new DelegateCommand(UpdateModel);
            DrawingObjInfos = new ObservableCollection<HDrawingObjectInfo>();
        }


        public DelegateCommand LoadImageCommand { get; set; }

        public DelegateCommand SetModelParamCommand { get; set; }

        public DelegateCommand UpdateModelCommand { get; set; }

        private ProjectModel model;

        public ProjectModel Model
        {
            get { return model; }
            set { model = value; RaisePropertyChanged(); }
        }

        private ObservableCollection<ImageFile> files;

        public ObservableCollection<ImageFile> Files
        {
            get { return files; }
            set { files = value; RaisePropertyChanged(); }
        }

        private HObject image;

        public HObject Image
        {
            get { return image; }
            set { image = value; RaisePropertyChanged(); }
        }

        private bool isModelEditModel;

        public bool IsModelEditModel
        {
            get { return isModelEditModel; }
            set { isModelEditModel = value; RaisePropertyChanged(); }
        }

        private ObservableCollection<HDrawingObjectInfo> drawingObjInfos;

        public ObservableCollection<HDrawingObjectInfo> DrawingObjInfos
        {
            get { return drawingObjInfos; }
            set { drawingObjInfos = value; RaisePropertyChanged(); }
        }


        public TargetService TargetService { get; }
        public ProjectService AppService { get; }

        private void LoadImage()
        {
            //由于该方法是Winform的类,所以要双击MachineVision.Defect 进入Project当中添加一个	  <UseWindowsForms>true</UseWindowsForms>
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "请选择导入的图像";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var files = new DirectoryInfo(dialog.SelectedPath).GetFiles();
                Files.Clear();

                foreach (var item in files)
                {
                    Files.Add(new ImageFile()
                    {
                        FileName = item.Name,
                        FilePath = item.FullName
                    });
                }
            }
        }
        private void SetModelParam()
        {
            TargetService.GetRefer(Image, Model);
            IsModelEditModel = !IsModelEditModel;
        } 

        private async void UpdateModel()
        {
            var drawingObj = DrawingObjInfos.FirstOrDefault(q => q.Color == "green");
            if (drawingObj != null)
            {
                var refer = Model.ReferSetting;

                //1.记录当前的形状的尺寸信息
                refer.SetReferParam(drawingObj);

                //2.创建一个ncc匹配模版保存包本地,数据库则保存模型的绝对路径
                var cropImage = Image.ReduceDomain(refer.Y1, refer.X1, refer.Y2, refer.X2).CropDomain();
                HOperatorSet.WriteImage(cropImage, "png", 0, "F:\\Learning\\HalconLearning\\default.png");

                //3.把上面所设置的信息都保存到数据库当中   全是基于写成扩展方法是为了界面整洁,也是因为为引用类型直接进行参数完善填充进行存储
                await Model.UpdateReferTemplate(cropImage);

                //基本参数已经存储到数据库中
                await AppService.CreateOrUpdateAsync(Model);
            }
        }

        /// <summary>
        /// 导航被执行触发  可以拿到DefectViewModel传进来的数据
        /// </summary>
        /// <param name="navigationContext"></param>
        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            if (navigationContext.Parameters.ContainsKey("Value"))
            {
                Model = navigationContext.Parameters.GetValue<ProjectModel>("Value");
            }
            base.OnNavigatedTo(navigationContext);
        }

    }
}
