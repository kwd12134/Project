
using MachineVision.Core;
using MachineVision.Defect.Extensions;
using MachineVision.Defect.Models;
using MachineVision.Defect.ViewModels.Components;
using Prism.Commands;
using Prism.Ioc;
using Prism.Services.Dialogs;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows.Media.Imaging;

namespace MachineVision.Defect.ViewModels
{
    public class TrainViewModel : DialogViewModel
    {
        public TrainViewModel()
        {
            Files = new ObservableCollection<ImageInfo>();
            DeleteCommand = new DelegateCommand(Delete);
        }

        public DelegateCommand DeleteCommand { get; set; }

        private ObservableCollection<InspecRegionModel> regionList;

        public ObservableCollection<InspecRegionModel> RegionList
        {
            get { return regionList; }
            set { regionList = value; RaisePropertyChanged(); }
        }

        private InspecRegionModel selectedRegion;

        public InspecRegionModel SelectedRegion
        {
            get { return selectedRegion; }
            set
            {
                selectedRegion = value;
                GetRegionImage();
                RaisePropertyChanged();
            }
        }

        private ObservableCollection<ImageInfo> files;

        public ObservableCollection<ImageInfo> Files
        {
            get { return files; }
            set { files = value; RaisePropertyChanged(); }
        }

        private ImageInfo selectedFile;

        public ImageInfo SelectedFile
        {
            get { return selectedFile; }
            set
            {
                selectedFile = value;
                ShowImage(value);
                RaisePropertyChanged();
            }
        }

        private BitmapImage image;

        public BitmapImage Image
        {
            get { return image; }
            set { image = value; RaisePropertyChanged(); }
        }

        private void Delete()
        {
            if (SelectedFile == null) return;
            if (SelectedRegion == null) return;

            if (File.Exists(SelectedFile.FullPath))
            {
                //移除本地和界面上的数据
                File.Delete(SelectedFile.FullPath);
                var file = Files.FirstOrDefault(t => t.FileName == SelectedFile.FileName);
                if (file != null)
                    Files.Remove(file);

                if (SelectedRegion.Context is LocalDeformableContext context)
                    context.RefreshVariationModel(SelectedRegion);
            }

        }

        /// <summary>
        /// 获取选中区域的选中训练图像
        /// </summary>
        private void GetRegionImage()
        {
            if (Files == null) return;
            string url = SelectedRegion.GetRegionTrainUrl();

            if (Directory.Exists(url))
            {
                string[] files = Directory.GetFiles(url);
                Files.Clear();
                foreach (var file in files)
                {
                    Files.Add(new ImageInfo()
                    {
                        FileName = Path.GetFileName(file),
                        FullPath = file,
                    });
                }
            }
        }

        /// <summary>
        /// 避免磁盘 IO，速度快；
        ///方便对接只接受 Stream 接口的类库；
        ///便于在内存中操作数据，适合中间处理；
        ///线程安全（只读或只写场景下）；
        ///可重置位置、重复读取。
        /// </summary>
        /// <param name="img"></param>
        private void ShowImage(ImageInfo img)
        {
            if (img == null) return;
            var bytes = File.ReadAllBytes(img.FullPath);
            MemoryStream ms = new MemoryStream(bytes);
            BitmapImage b = new BitmapImage();
            // 4. 开始初始化图像
            b.BeginInit();
            // 5. 设置图像源为刚刚创建的内存流
            b.StreamSource = ms;
            // 6. 结束初始化，图像就加载进来了
            b.EndInit();
            Image = b;
        }


        public override void OnDialogOpened(IDialogParameters parameters)
        {
            if (parameters.ContainsKey("Value"))
            {
                RegionList = parameters.GetValue<ObservableCollection<InspecRegionModel>>("Value");
            }
            base.OnDialogOpened(parameters);
        }


    }
}
