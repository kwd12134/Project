using MachineVision.Core;
using MachineVision.Models;
using MachineVision.Services;
using Prism.Commands;
using Prism.Regions;

namespace MachineVision.ViewModels
{
    public class DashboardViewModel:NavigationViewModel
    {
        /// <summary>
        /// Dashboard 仪表盘
        /// </summary>
        /// <param name="manager"></param>
        /// <param name="navigationService"></param>
        public DashboardViewModel(IRegionManager manager,INavigationMenuService navigationService)
        {
            Manager = manager;
            NavigationService = navigationService;
            OpenPageCommand = new DelegateCommand<NavigationItem>(OpenPage);
        }


        public DelegateCommand<NavigationItem> OpenPageCommand { get; set; }
        public IRegionManager Manager { get; }
        public INavigationMenuService NavigationService { get; }

        public void OpenPage(NavigationItem Item)
        {
            Manager.Regions["MainViewRegion"].RequestNavigate(Item.PageName);
        }
        public override void OnNavigatedTo(NavigationContext navigationContext)
        {

            base.OnNavigatedTo(navigationContext);
        }
    }
}
