using MachineVision.Ocr.Models;
using MachineVision.Ocr.Views;
using Prism.Ioc;
using Prism.Modularity;

namespace MachineVision.Ocr
{
    public class OcrModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<QrCodeView, QrCodeViewModel>();
            containerRegistry.RegisterForNavigation<BarCodeView, BarCodeViewModel>();
        }
    }
}
