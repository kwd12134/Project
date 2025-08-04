using MachineVision.Defect.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MachineVision.Defect.Controls
{
    public class ErrorManagerView : System.Windows.Controls.Control
    {

        public InspectionResult Result
        {
            get { return (InspectionResult)GetValue(ResultProperty); }
            set { SetValue(ResultProperty, value); }
        }

        public static readonly DependencyProperty ResultProperty =
            DependencyProperty.Register("Result", typeof(InspectionResult), typeof(ErrorManagerView), new PropertyMetadata(DefectResultCallBack));

        private ShowErrorControl[] Errors = new ShowErrorControl[5];

        private static void DefectResultCallBack(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is ErrorManagerView view)
            {
                view.Display();
            }
        }

        private void Display()
        {
            var count = Result.ContextResults.Count;
            for (int i = 0; i < count; i++)
            {
                if(count>5) break;
                Errors[i].DisPlay(Result.ContextResults[i]);
            }
        }

        public override void OnApplyTemplate()
        {
            Errors[0] = (ShowErrorControl)GetTemplateChild("PART1");
            Errors[1] = (ShowErrorControl)GetTemplateChild("PART2");
            Errors[2] = (ShowErrorControl)GetTemplateChild("PART3");
            Errors[3] = (ShowErrorControl)GetTemplateChild("PART4");
            Errors[4] = (ShowErrorControl)GetTemplateChild("PART5");
            base.OnApplyTemplate();
        }

    }
}
