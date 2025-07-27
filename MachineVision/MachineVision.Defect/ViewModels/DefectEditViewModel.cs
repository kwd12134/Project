using HalconDotNet;
using MachineVision.Core;
using MachineVision.Defect.Models;
using MachineVision.Defect.Models.UI;
using Prism.Commands;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineVision.Defect.ViewModels
{
    public class DefectEditViewModel:NavigationViewModel
    {
        public DefectEditViewModel()
        {
            LoadImageCommand = new DelegateCommand(LoadImage);
            Files = new ObservableCollection<ImageFile>();
        }

        public DelegateCommand LoadImageCommand { get; set; }

        private ProjectModel model;

        public ProjectModel Model
        {
            get { return model; }
            set { model = value; RaisePropertyChanged(); }
        }


        private ObservableCollection<ImageFile> files;

        public ObservableCollection<ImageFile> Files
        {
            get { return files; }
            set { files = value; RaisePropertyChanged(); }
        }

        private HObject image;

        public HObject Image
        {
            get { return image; }
            set { image = value; RaisePropertyChanged(); }
        }

        private void LoadImage()
        {
            //由于该方法是Winform的类,所以要双击MachineVision.Defect 进入Project当中添加一个	  <UseWindowsForms>true</UseWindowsForms>
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "请选择导入的图像";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var files = new DirectoryInfo(dialog.SelectedPath).GetFiles();
                Files.Clear();

                foreach (var item in files)
                {
                    Files.Add(new ImageFile()
                    {
                        FileName = item.Name,
                        FilePath = item.FullName
                    });
                }
            }
        }

        /// <summary>
        /// 导航被执行触发  可以拿到DefectViewModel传进来的数据
        /// 
        /// </summary>
        /// <param name="navigationContext"></param>
        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            if (navigationContext.Parameters.ContainsKey("Value"))
            {
                Model = navigationContext.Parameters.GetValue<ProjectModel>("Value");
            }
            base.OnNavigatedTo(navigationContext);
        }

    }
}
