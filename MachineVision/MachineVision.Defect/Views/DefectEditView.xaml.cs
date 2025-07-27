using MachineVision.Defect.Models.UI;
using MachineVision.Defect.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MachineVision.Defect.Views
{
    /// <summary>
    /// DefectEditView.xaml 的交互逻辑
    /// </summary>
    public partial class DefectEditView : System.Windows.Controls.UserControl
    {
        public DefectEditView()
        {
            InitializeComponent();
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //当前相当于横跨域的同线程数据传输
            if (this.DataContext is DefectEditViewModel vm)
            {
                if (ListBox.SelectedItem is ImageFile file)
                {
                    if (File.Exists(file.FilePath))
                    {
                        vm.Image = file.GetImage();
                    }
                }
            }
        }
    }
}
