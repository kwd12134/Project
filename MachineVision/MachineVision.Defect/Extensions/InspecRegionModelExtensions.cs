using MachineVision.Defect.Models;
using MachineVision.Defect.ViewModels.Components;

namespace MachineVision.Defect.Extensions
{
    public static class InspecRegionModelExtensions
    {
        public static IRegionContext GetRegionContext(this InspecRegionModel Model)
        {
            LocalDeformableContext context = new LocalDeformableContext();
            context.Import(Model.Parameter);

            return context;
        }
    }
}
