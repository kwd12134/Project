using MachineVision.TemplateMatch.ViewModels;
using MachineVision.TemplateMatch.Views;
using Prism.Ioc;
using Prism.Modularity;

namespace MachineVision.TemplateMatch
{
    ///<summary>
    ///IModule 就像是 WPF 应用的“功能插件”，每个模块可以独立开发、独立注册、独立加载，通过 Prism 统一集成。
    ///大型项目拆分 拍照模块、用户管理模块、报告模块
    ///插件式架构 加载外部 DLL 提供的功能模块
    ///独立部署 每个模块都可以独立测试和开发
    ///</summary>
    public class TemplateMatchModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {

        }

        public void RegisterTypes(IContainerRegistry service)
        {
            service.RegisterForNavigation<DrawShapeView, DrawShapeViewModel>();
            service.RegisterForNavigation<ShapeView, ShapeViewModel>();
            service.RegisterForNavigation<NccView, NccViewModel>();
            service.RegisterForNavigation<LocalDeformableView, LocalDeformableViewModel>();
        }
    }
}
