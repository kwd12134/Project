using MachineVision.Core;
using MachineVision.Defect.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineVision.Defect.ViewModels
{
    public class CreateProjectViewModel: DialogViewModel
    {
        public CreateProjectViewModel(ProjectService service)
        {
            AppService = service;
            Name = string.Empty;
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value;RaisePropertyChanged(); }
        }

        public ProjectService AppService { get; }

        public override async void Save()
        {
            await AppService.CreateOrUpdateAsync(new Models.ProjectModel()
            {
                Name = this.Name,
            });
            base.Save();
        }
    }
}
