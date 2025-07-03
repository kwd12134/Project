using MyToDo.Common.Models;
using MyToDo.Extensions;
using Prism.Navigation.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;

namespace MyToDo.ViewModels
{
    public class MainViewModel : BindableBase
    {
        public MainViewModel(IRegionManager regionManager)
        {
            MenuBar = new ObservableCollection<MenuBar>();
            NavigateCommand = new DelegateCommand<MenuBar>(Navigate);
            CreateMenuBar();
            this.RegionManager = regionManager;
            GoBackCommand = new DelegateCommand(() =>
            {
            if (Journal != null&& Journal.CanGoBack)
                    Journal.GoBack();
            });

            GoForwardCommand = new DelegateCommand(() =>
            {
                if (Journal != null && Journal.CanGoForward)
                    Journal.GoForward();
            });
        }

        private void Navigate(MenuBar bar)
        {
            if (bar == null || string.IsNullOrEmpty(bar.NameSpace))
                return;
            RegionManager.Regions[PrismManager.MainViewRegionName].RequestNavigate(bar.NameSpace, back =>
            {
                Journal=back.Context.NavigationService.Journal;
            });
        }

        public DelegateCommand<MenuBar> NavigateCommand { get; set; }
        public DelegateCommand GoBackCommand { get; set; }
        public DelegateCommand GoForwardCommand { get; set; }

        private IRegionNavigationJournal Journal;

        private readonly IRegionManager RegionManager;

        private ObservableCollection<MenuBar> menuBar;

        public ObservableCollection<MenuBar> MenuBar
        {
            get { return menuBar; }
            set {
                menuBar = value;

                RaisePropertyChanged();
            }
        }

        void CreateMenuBar()
        {
            MenuBar.Add(new MenuBar() { Icon= "Home", Title="首页",NameSpace="IndexView"});
            MenuBar.Add(new MenuBar() { Icon= "Notebook", Title="代办事项",NameSpace= "ToDoView" });
            MenuBar.Add(new MenuBar() { Icon= "NotebookMultiple", Title="备忘录",NameSpace="MemoView"});
            MenuBar.Add(new MenuBar() { Icon="Cog",Title="设置",NameSpace= "SettingView" });
        }

    }
}
