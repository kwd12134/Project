using MachineVision.Defect.Service;
using MachineVision.Defect.ViewModels;
using MachineVision.Defect.Views;
using MachineVision.Shared.Services;
using Prism.Ioc;
using Prism.Modularity;

namespace MachineVision.Defect
{
    public class DefectModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {

        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<DefectView, DefectViewModel>();
            containerRegistry.RegisterForNavigation<DefectEditView, DefectEditViewModel>();

            containerRegistry.RegisterDialog<CreateProjectView, CreateProjectViewModel>();
            containerRegistry.RegisterDialog<RegionParameterView, RegionParameterViewModel>();
            containerRegistry.RegisterDialog<TrainView, TrainViewModel>();

            containerRegistry.Register<ProjectService>();
            containerRegistry.Register<TargetService>();
            containerRegistry.RegisterSingleton<InspectionService>();
        }
    }
}
