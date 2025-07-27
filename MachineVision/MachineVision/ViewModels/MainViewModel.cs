using MachineVision.Core;
using MachineVision.Extensions;
using MachineVision.Models;
using MachineVision.Services;
using MachineVision.Shared.Events;
using MachineVision.Shared.Services;
using MaterialDesignThemes.Wpf;
using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Media;

namespace MachineVision.ViewModels
{
    public class MainViewModel : NavigationViewModel
    {
        /// <summary>
        /// 构造参数由app.xaml中注册的依赖传入
        /// </summary>
        /// <param name="manager"></param>
        /// <param name="aggregator"></param>
        /// <param name="settingService"></param>
        /// <param name="navigationService"></param>
        public MainViewModel(
            IRegionManager manager,
            IEventAggregator aggregator,
            ISettingService settingService,
            INavigationMenuService navigationService)
        {
            Manager = manager;
            Aggregator = aggregator;
            SettingService = settingService;
            NavigationService = navigationService;
            NavigateCommand = new DelegateCommand<NavigationItem>(Navigate);
            //订阅事件 聚合器
            aggregator.GetEvent<LanguageEventBus>().Subscribe(LanguageChanged);
            HomeCommand = new DelegateCommand(Home);
        }

        private bool isTopDrawerOpen;

        /// <summary>
        /// 顶部工具栏展开状态
        /// </summary>
        public bool IsTopDrawerOpen
        {
            get { return isTopDrawerOpen; }
            set { isTopDrawerOpen = value; RaisePropertyChanged(); }
        }

        public IRegionManager Manager { get; set; }
        public IEventAggregator Aggregator { get; }
        public ISettingService SettingService { get; }
        public INavigationMenuService NavigationService { get; }

        public DelegateCommand<NavigationItem> NavigateCommand { get; private set; }
        public DelegateCommand HomeCommand { get; set; }

        private void Navigate(NavigationItem item)
        {
            if (item == null) return;

            if (item.Name.Equals("全部") || item.Name.Equals("All"))
            {
                IsTopDrawerOpen = true;
                return;
            }

            IsTopDrawerOpen = false;
            NavigatePage(item.PageName);
        }

        public override async void OnNavigatedTo(NavigationContext navigationContext)
        {
            await ApplySettingAsync();
            NavigationService.InitMenus();
            Aggregator.GetEvent<LanguageEventBus>().Publish(true);
            NavigatePage("DashboardView");
            base.OnNavigatedTo(navigationContext);
        }

        private void NavigatePage(string PageName)
        {
            Manager.Regions["MainViewRegion"].RequestNavigate(PageName, back =>
            {
                if (!(bool)back.Result)
                {
                    System.Diagnostics.Debug.WriteLine(back.Error.Message);
                }
            });
        }
        /// <summary>
        /// 语言更改事件
        /// </summary>
        /// <param name="status"></param>
        private void LanguageChanged(bool status)
        {
            NavigationService.RefreshMenus();
        }

        private void Home()
        {
            NavigatePage("DashboardView");
        }

        /// <summary>
        /// 引用系统设置
        /// </summary>
        /// <returns></returns>
        private async Task ApplySettingAsync()
        {
           var setting = await SettingService.GetSettingAsync();
            if (setting!=null)
            {
                LanguageHelper.SetLanguage(setting.Language);
            }
        }

    }
}
