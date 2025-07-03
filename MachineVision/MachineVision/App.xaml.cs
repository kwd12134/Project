using MachineVision.Services;
using MachineVision.Shared.Services;
using MachineVision.TemplateMatch;
using MachineVision.ViewModels;
using MachineVision.Views;
using Prism.DryIoc;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using System.Windows;

namespace MachineVision
{
    public partial class App : PrismApplication
    {
        protected override Window CreateShell() => null;

        protected override void OnInitialized()
        {
            //从容器当中获取MainView的实例对象
            var container = ContainerLocator.Container;
            var shell = container.Resolve<object>("MainView");
            
            if (shell is Window view)
            {
                //更新Prism注册区域信息
                var regionManager = container.Resolve<IRegionManager>();
                RegionManager.SetRegionManager(view, regionManager);
                RegionManager.UpdateRegions();

                //调用首页的INavigationAware 接口做一个初始化操作
                if (view.DataContext is INavigationAware navigationAware)
                {
                    navigationAware.OnNavigatedTo(null);
                    //呈现首页
                    App.Current.MainWindow = view;
                }
            }
            base.OnInitialized();
        }
        /// <summary>
        /// Register<TService, TImplementation>()	瞬态（Transient），每次请求都创建新实例
        /// RegisterSingleton<TService, TImplementation>()	单例（Singleton），整个应用共用同一个实例
        /// RegisterInstance<TService>(T instance)	注册现有实例，手动控制生命周期
        /// </summary>
        /// <param name="services"></param>
        protected override void RegisterTypes(IContainerRegistry services)
        { 
            //freesql数据库注册
            services.RegisterSingleton<ISettingService, SettingService>();

            services.RegisterForNavigation<MainView, MainViewModel>();
            services.RegisterForNavigation<DashboardView, DashboardViewModel>();
            services.RegisterForNavigation<SettingView, SettingViewModel>();

            services.RegisterSingleton<INavigationMenuService, NavigationMenuService>();

        }
        /// <summary>
        /// Catalog目录；登记
        /// </summary>
        /// <param name="moduleCatalog"></param>
        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            //加载模块
            moduleCatalog.AddModule<TemplateMatchModule>();
        }
    }
}
