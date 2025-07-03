using MyToDo.Common.Models;
using MyToDo.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToDo.ViewModels
{
    public class SettingViewModel:BindableBase
    {
        public SettingViewModel(IRegionManager regionManager)
        {
            MenuBar = new ObservableCollection<MenuBar>();
            NavigateCommand = new DelegateCommand<MenuBar>(Navigate);
            CreateMenuBar();
            this.RegionManager = regionManager;
        }

        private void Navigate(MenuBar bar)
        {
            if (bar == null || string.IsNullOrEmpty(bar.NameSpace))
                return;
            RegionManager.Regions[PrismManager.SettingsViewRegionName].RequestNavigate(bar.NameSpace);
        }

        public DelegateCommand<MenuBar> NavigateCommand { get; set; }

        private readonly IRegionManager RegionManager;

        private ObservableCollection<MenuBar> menuBar;

        public ObservableCollection<MenuBar> MenuBar
        {
            get { return menuBar; }
            set
            {
                menuBar = value;

                RaisePropertyChanged();
            }
        }

        void CreateMenuBar()
        {
            MenuBar.Add(new MenuBar() { Icon = "Palette", Title = "个性化", NameSpace = "SkinView" });
            MenuBar.Add(new MenuBar() { Icon = "Cog", Title = "系统设置", NameSpace = "" });
            MenuBar.Add(new MenuBar() { Icon = "Infomation", Title = "关于更多", NameSpace = "AboutView" });
        }
    }
}
