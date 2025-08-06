using AutoMapper;
using MachineVision.Core.ObjectMeasure;
using MachineVision.Core.Ocr;
using MachineVision.Core.TemplateMatch;
using MachineVision.Core.TemplateMatch.LocalDeformable;
using MachineVision.Core.TemplateMatch.NccModel;
using MachineVision.Core.TemplateMatch.ShapeModel;
using MachineVision.Defect;
using MachineVision.ObjectMeasure;
using MachineVision.Ocr;
using MachineVision.Services;
using MachineVision.Shared.Services;
using MachineVision.TemplateMatch;
using MachineVision.ViewModels;
using MachineVision.Views;
using Prism.DryIoc;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using System;
using System.Windows;
using AutoMapper;

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
        /// 跟依赖注入差不多
        /// Register<TService, TImplementation>()	瞬态（Transient），每次请求都创建新实例
        /// RegisterSingleton<TService, TImplementation>()	单例（Singleton），整个应用共用同一个实例
        /// RegisterInstance<TService>(T instance)	注册现有实例，手动控制生命周期
        /// RegisterForNavigation 背后其实是按 Transient 生命周期 注册的，也就是每次请求都会创建新对象。
        /// RegisterDialog（默认行为：每次调用都会创建新实例）
        /// </summary>
        /// <param name="services"></param>
        protected override void RegisterTypes(IContainerRegistry services)
        { 
            //freesql数据库注册  系统服务注册
            services.RegisterSingleton<ISettingService, SettingService>();
            services.RegisterSingleton<IAppMapper, AppMapper>();

            //系统导航注册
            services.RegisterForNavigation<MainView, MainViewModel>();
            services.RegisterForNavigation<DashboardView, DashboardViewModel>();
            services.RegisterForNavigation<SettingView, SettingViewModel>();

            services.RegisterSingleton<INavigationMenuService, NavigationMenuService>();

            //模板匹配服务  nameof获取枚举成员或变量名的字符串  就是在注册时为服务起一个名字（命名注册），也叫带 Key 的注册
            services.Register<ITemplateMatchService,ShapeModelService>(nameof(TemplateMatchType.ShapeModel));
            services.Register<ITemplateMatchService, NccModelSevice>(nameof(TemplateMatchType.NccModel));
            services.Register<ITemplateMatchService, LocalDeformableService>(nameof(TemplateMatchType.LocalDeformable));

            services.Register<BarCodeService>();
            services.Register<QrCodeService>();
            services.Register<CircleMeasureService>();

        }
        /// <summary>
        /// Catalog目录；登记
        /// </summary>
        /// <param name="moduleCatalog"></param>
        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            //加载模块
            moduleCatalog.AddModule<TemplateMatchModule>();
            moduleCatalog.AddModule<OcrModule>();
            moduleCatalog.AddModule<DefectModule>();
            moduleCatalog.AddModule<ObjectMeasureModule>();
            base.ConfigureModuleCatalog(moduleCatalog);
        }
    }
}
