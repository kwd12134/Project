using HalconDotNet;
using MachineVision.Core.Extensions;
using MachineVision.Defect.Models;
using System.Windows.Controls;
using Prism.Ioc;
using Prism.Events;
using MachineVision.Defect.Events;

namespace MachineVision.Defect.Controls
{
    public class ShowErrorControl : System.Windows.Controls.Control
    {
        private HWindow hWindow;
        private HSmartWindowControlWPF hsmart;
        private HObject Image;
        private string Name;

        public void DisPlay(RegionContextResult result)
        {
            var render = result.Render;
            Name=result.Name;
            if (render != null && hWindow != null)
            {
                hWindow.ClearWindow();

                this.Image = render.Image;

                //显示局部缺陷图像
                hWindow.DispObj(this.Image);

                HOperatorSet.SetColor(hWindow, "red");
                hWindow.DispObj(render.Light.GetRegionContour());
                HOperatorSet.SetColor(hWindow, "green");
                hWindow.DispObj(render.Dark.GetRegionContour());

                //设置自适应
                hWindow.SetPart(0, 0, -2, -2);
            }
        }

        public override void OnApplyTemplate()
        {
            hsmart = (HSmartWindowControlWPF)GetTemplateChild("PART_Smart");
            hsmart.Loaded += Hsmart_Loaded;
            base.OnApplyTemplate();
        }

        private void Hsmart_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            ((MenuItem)GetTemplateChild("PART_Train")).Click += (s, e) =>
            {
                var aggregator = ContainerLocator.Container.Resolve<IEventAggregator>();
                aggregator.GetEvent<ImageTrainEvent>().Publish(new ImageTrainInfo()
                {
                    Image = this.Image,
                    Name = this.Name,
                });
            };
            hWindow = hsmart.HalconWindow;
        }
    }
}
