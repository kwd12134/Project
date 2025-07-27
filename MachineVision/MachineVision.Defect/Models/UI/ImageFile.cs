using HalconDotNet;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineVision.Defect.Models.UI
{
    public class ImageFile : BindableBase
    {
        private string fileName, filePath;

        public string FileName
        {
            get { return fileName; }
            set { fileName = value; RaisePropertyChanged(); }
        }

        public string FilePath
        {
            get { return filePath; }
            set { filePath = value; RaisePropertyChanged(); }
        }

        public HObject GetImage()
        {
            var image = new HImage();
            image.ReadImage(FilePath);
            return image;
        }
    }
}
