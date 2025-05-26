using MachineVision.Core;
using MachineVision.Extensions;
using MachineVision.Models;
using MachineVision.Services;
using MachineVision.Shared.Events;
using MaterialDesignThemes.Wpf;
using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using System;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Media;

namespace MachineVision.ViewModels
{
    public class MainViewModel : NavigationViewModel
    {
        public MainViewModel(IRegionManager manager,IEventAggregator aggregator ,INavigationMenuService navigationService)
        {
            Manager = manager;
            NavigationService = navigationService;
            NavigateCommand = new DelegateCommand<NavigationItem>(Navigate);
            //订阅事件
            aggregator.GetEvent<LanguageEventBus>().Subscribe(LanguageChanged);
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
        public INavigationMenuService NavigationService { get; }

        public DelegateCommand<NavigationItem> NavigateCommand { get; private set; }

        private void Navigate(NavigationItem item)
        {
            if (item == null) return;

            if (item.Name.Equals("全部"))
            {
                IsTopDrawerOpen = true;
                return;
            }

            IsTopDrawerOpen = false;
            NavigatePage(item.PageName);
        }

        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            NavigationService.InitMenus();
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

        private void LanguageChanged(bool status)
        {

        }

    }
}
