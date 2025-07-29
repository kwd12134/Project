using MachineVision.Core;
using MachineVision.Defect.Models;
using MachineVision.Defect.Service;
using MaterialDesignColors;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineVision.Defect.ViewModels
{
    public class DefectViewModel : NavigationViewModel
    {
        public DefectViewModel(ProjectService appService,
            IDialogService dialogService,
            IRegionManager region)
        {
            AppService = appService;
            DialogService = dialogService;
            Region = region;
            CreateCommand = new DelegateCommand(Create);
            SearchCommand = new DelegateCommand(Search);
            DeleteCommand = new DelegateCommand<ProjectModel>(Delete);
            EditCommand = new DelegateCommand<ProjectModel>(Edit);
            FilterText = string.Empty;
            Models = new ObservableCollection<ProjectModel>();
        }


        public ProjectService AppService { get; }
        public IDialogService DialogService { get; }
        public IRegionManager Region { get; }
        public DelegateCommand CreateCommand { get; private set; }
        public DelegateCommand SearchCommand { get; private set; }
        public DelegateCommand<ProjectModel> EditCommand { get; private set; }
        public DelegateCommand<ProjectModel> DeleteCommand { get; private set; }

        private ObservableCollection<ProjectModel> models;

        public ObservableCollection<ProjectModel> Models
        {
            get { return models; }
            set { models = value; RaisePropertyChanged(); }
        }

        private string filterText;

        public string FilterText
        {
            get { return filterText; }
            set { filterText = value; }
        }
        /// <summary>
        /// 非常之关键!!!导航之间的数据传输
        /// </summary>
        /// <param name="model"></param>
        private void Edit(ProjectModel model)
        {
            //目前这块是导入数据   想要导出数据可以通过回调实现 back 也可用事件聚合区PubSubEvent
            NavigationParameters param = new NavigationParameters();

            //初始化判断是否为新项目,否的话导入旧的参数
            model.InitParameter();
            param.Add("Value", model);

            Region.Regions["MainViewRegion"].RequestNavigate("DefectEditView", back => { },param);
        }

        /// <summary>
        /// 由于binding的对象为DataTemplate,界面上使用了相关性绑定command并传递会当前command的ProjectModel参数
        /// </summary>
        /// <param name="model"></param>
        private async void Delete(ProjectModel model)
        {
            if (model == null) return;
            await AppService.DeleteAsync(model.Id);
            await GetListAsync();
        }

        private async void Search()
        {
            await GetListAsync();
        }

        private async void Create()
        {
            //
            DialogService.ShowDialog("CreateProjectView");
            await GetListAsync();
        }

        /// <summary>
        /// 初始化数据
        /// </summary>
        /// <returns></returns>
        public async Task GetListAsync()
        {
            var List = await AppService.GetListAsync(FilterText);
            Models.Clear();
            if (List != null)
            {
                foreach (var item in List)
                {
                    Models.Add(item);
                }
            }
        }

        public override async void OnNavigatedTo(NavigationContext navigationContext)
        {
            await GetListAsync();
            base.OnNavigatedTo(navigationContext);
        }
    }
}
