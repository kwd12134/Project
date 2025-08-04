using FreeSql;
using HalconDotNet;
using MachineVision.Core;
using MachineVision.Core.Extensions;
using MachineVision.Defect.Events;
using MachineVision.Defect.Extensions;
using MachineVision.Defect.Models;
using MachineVision.Defect.Models.UI;
using MachineVision.Defect.Service;
using MachineVision.Defect.ViewModels.Components;
using MachineVision.Defect.ViewModels.Components.Models;
using MachineVision.Defect.Views;
using MachineVision.Shared.Controls;
using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using Prism.Services.Dialogs;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineVision.Defect.ViewModels
{
    public class DefectEditViewModel : NavigationViewModel
    {
        /// <summary>
        /// TargetService基于参考点  ProjectService基于数据库
        /// </summary>
        /// <param name="targetService"></param>
        /// <param name="appService"></param>
        public DefectEditViewModel(TargetService targetService,
            InspectionService inspectService,
            IDialogService dialogService,
            IEventAggregator aggregator,
            ProjectService appService)
        {
            this.TargetService = targetService;
            InspectService = inspectService;
            DialogService = dialogService;
            Aggregator = aggregator;
            AppService = appService;

            DrawingObjInfos = new ObservableCollection<HDrawingObjectInfo>();
            Files = new ObservableCollection<ImageFile>();
            RegionList = new ObservableCollection<InspecRegionModel>();
            InitialCommandBinding();
        }

        #region Command Or Service

        public DelegateCommand LoadImageCommand { get; set; }

        public DelegateCommand SetModelParamCommand { get; set; }

        public DelegateCommand UpdateModelCommand { get; set; }

        public DelegateCommand UpdateRegionCommand { get; set; }

        public DelegateCommand CreateRegionCommand { get; set; }

        public DelegateCommand<InspecRegionModel> DelectInspectRegionCommand { get; set; }
        public DelegateCommand<InspecRegionModel> EditRegionCommand { get; set; }

        public DelegateCommand RunCommand { get; set; }

        private void InitialCommandBinding()
        {
            LoadImageCommand = new DelegateCommand(LoadImage);
            CreateRegionCommand = new DelegateCommand(CreateRegion);
            SetModelParamCommand = new DelegateCommand(SetModelParam);
            UpdateModelCommand = new DelegateCommand(UpdateModel);
            UpdateRegionCommand = new DelegateCommand(UpdateRegion);
            DelectInspectRegionCommand = new DelegateCommand<InspecRegionModel>(DelectInspectRegion);
            EditRegionCommand = new DelegateCommand<InspecRegionModel>(EditRegion);
            RunCommand = new DelegateCommand(Run);
        }

        /// <summary>
        /// 基于参考点
        /// </summary>
        public TargetService TargetService { get; }
        public InspectionService InspectService { get; }
        public IDialogService DialogService { get; }
        public IEventAggregator Aggregator { get; }

        /// <summary>
        /// 基于数据库
        /// </summary>
        public ProjectService AppService { get; }



        #endregion

        #region Binding Or Property

        private ObservableCollection<InspecRegionModel> regionList;

        public ObservableCollection<InspecRegionModel> RegionList
        {
            get { return regionList; }
            set { regionList = value; RaisePropertyChanged(); }
        }

        private InspecRegionModel selectedRegion;

        public InspecRegionModel SelectedRegion
        {
            get { return selectedRegion; }
            set
            {
                selectedRegion = value; RestoreRegionParameter();
            }
        }


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

        #endregion

        #region 命令实现


        private void LoadImage()
        {
            //由于该方法是Winform的类,所以要双击MachineVision.Defect 进入Project当中添加一个	  <UseWindowsForms>true</UseWindowsForms>
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "请选择导入的图像";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
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

        /// <summary>
        /// 设置储存的参考点数据
        /// </summary>
        private void SetModelParam()
        {
            TargetService.GetRefer(Image, Model);
            IsModelEditModel = !IsModelEditModel;
        }

        /// <summary>
        /// 更新项目参考点数据
        /// </summary>
        private async void UpdateModel()
        {
            var drawingObj = DrawingObjInfos.FirstOrDefault(q => q.Color == "green");
            if (drawingObj != null)
            {
                var refer = Model.ReferSetting;

                //1.记录当前的形状的尺寸信息
                refer.SetReferParam(drawingObj);
                var cropImage = Image.ReduceDomain(refer.Y1, refer.X1, refer.Y2, refer.X2).CropDomain().RgbToGray();

                refer.Width = cropImage.GetImageSize()[0];
                refer.Height = cropImage.GetImageSize()[1];

                //2.创建一个ncc匹配模版保存包本地,数据库则保存模型的绝对路径
                await Model.UpdateReferTemplate(cropImage);

                //3.把上面所设置的信息都保存到数据库当中   全是基于写成扩展方法是为了界面整洁,也是因为为引用类型直接进行参数完善填充进行存储
                //基本参数已经存储到数据库中
                await AppService.CreateOrUpdateAsync(Model);
            }
        }

        /// <summary>
        /// 创建检测区
        /// </summary>
        private async void CreateRegion()
        {
            var Name = "P" + (RegionList.Count + 1);
            await AppService.CreateRegionAsync(new InspecRegionModel()
            {
                Name = Name,
                ProjectId = Model.Id,
                MatchParameter = string.Empty,
                Parameter = string.Empty
            });
            GetRegionListAsync();
        }
        /// <summary>
        /// 删除检测区  删除非C#托管资源 释放内存
        /// </summary>
        private async void DelectInspectRegion(InspecRegionModel input)
        {
            if (input == null) return;

            var region = RegionList.FirstOrDefault(q => q.Id == input.Id);

            if (region != null)
            {
                //删除非C#托管资源 释放内存 正常C#对象内存释放是自动回收
                region.Dispose();
                await AppService.DeleteRegionAsync(region.Id);
                RegionList.Remove(region);
            }
        }

        /// <summary>
        /// 编辑检测区域参数
        /// </summary>
        /// <param name="model"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void EditRegion(InspecRegionModel model)
        {
            //因为引用变量的原因,把数据传进去在里面修改的数据就是修改传入的数据
            DialogParameters param = new DialogParameters();
            param.Add("Value", model);

            DialogService.ShowDialog(nameof(RegionParameterView), param, callback =>
            {
                if (callback.Result == ButtonResult.OK)
                {

                }

            });
        }

        /// <summary>
        /// 获取检测区域列表
        /// </summary>
        public async void GetRegionListAsync()
        {
            var list = await AppService.GetRegionListAsync(Model.Id);
            RegionList.Clear();
            foreach (var item in list)
            {
                item.ProjectName = Model.Name;
                //初始化Context ModelID MatchSetting
                item.InitRegionContext();
                RegionList.Add(item);
            }
        }

        /// <summary>
        /// 还原检测区域参数绘制
        /// </summary>
        private void RestoreRegionParameter()
        {
            if (Image == null || SelectedRegion == null) return;

            // 1 先查找基准点位置
            TargetService.GetRefer(Image, Model);

            // 2 还原选中检测区域的位置

            if (SelectedRegion.Context is IRestoreMatchRegion restore)
            {
                restore.RestorePosition(Image, SelectedRegion, Model.ReferSetting.Row, Model.ReferSetting.Column);
            }

            RaisePropertyChanged(nameof(SelectedRegion));
        }

        /// <summary>
        /// 更新区域参数
        /// </summary>
        private async void UpdateRegion()
        {

            //var referObj = DrawingObjInfos.FirstOrDefault(q => q.Color == "green");

            var drawingObj = DrawingObjInfos.FirstOrDefault(q => q.Color == "red");
            if (drawingObj != null && Model.ReferSetting.ModelId != null)
            {
                //1 保存去区域的尺寸信息

                var temp = new TemplateSetting();
                temp.SetReferParam(drawingObj);

                temp.RowSpacing = Model.ReferSetting.Row - temp.Row;
                temp.ColumnSpacing = Model.ReferSetting.Column - temp.Column;

                SelectedRegion.MatchSetting = temp;

                //2 保存区域的模版数据

                var cropImage = Image.ReduceDomain(temp.Y1, temp.X1, temp.Y2, temp.X2).CropDomain().RgbToGray();
                //  创建LocalDeformable的模板匹配
                await SelectedRegion.UpdateRegionTemplate(cropImage);

                //3 保存区域的检测模型   创建VariationModel
                //使用缺陷检测算法服务
                SelectedRegion.Context = new LocalDeformableContext();
                SelectedRegion.Context.UpdateVariationModel(cropImage, SelectedRegion);

                //4 更新数据库参数
                await AppService.UpdateRegionAsync(SelectedRegion);

            }
        }


        #endregion

        #region 检测服务

        private InspectionResult result;

        public InspectionResult Result
        {
            get { return result; }
            set { result = value; RaisePropertyChanged(); }
        }


        /// <summary>
        /// 检测图像
        /// </summary>
        private async void Run()
        {
            Result = InspectService.ExecuteAsync(Image, Model, RegionList);
        }

        #endregion

        #region 公共方法

        private void ResetDrawingObject()
        {
            //DrawingObjInfos.Clear();
        }

        #endregion

        #region 导航

        /// <summary>
        /// 导航被执行触发  可以拿到DefectViewModel传进来的数据
        /// </summary>
        /// <param name="navigationContext"></param>
        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            if (navigationContext.Parameters.ContainsKey("Value"))
            {
                Model = navigationContext.Parameters.GetValue<ProjectModel>("Value");
                GetRegionListAsync();
            }

            Aggregator.GetEvent<ImageTrainEvent>().Subscribe(ImageTrain);
            base.OnNavigatedTo(navigationContext);
        }

        /// <summary>
        /// 退出当前界面时先取消订阅,要不然就相当于订阅两次
        /// </summary>
        /// <param name="navigationContext"></param>
        public override void OnNavigatedFrom(NavigationContext navigationContext)
        {
            Aggregator.GetEvent<ImageTrainEvent>().Unsubscribe(ImageTrain);
            base.OnNavigatedFrom(navigationContext);
        }

        #endregion

        #region 模型训练

        /// <summary>
        /// 
        /// </summary>
        /// <param name="info"></param>
        private void ImageTrain(ImageTrainInfo info)
        {
            var region = RegionList.FirstOrDefault(q => q.Name == info.Name);
            if (region == null)
            {
                region.Context.UpdateVariationModel(info.Image, region);
            }
        }

        #endregion

    }
}
