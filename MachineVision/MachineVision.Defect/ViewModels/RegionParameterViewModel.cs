using MachineVision.Core;
using MachineVision.Defect.Models;
using MachineVision.Defect.Service;
using MachineVision.Defect.ViewModels.Components;
using MachineVision.Defect.ViewModels.Components.Models;
using Prism.Commands;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineVision.Defect.ViewModels
{
    public class RegionParameterViewModel : DialogViewModel
    {
        public RegionParameterViewModel(ProjectService appService)
        {
            AddParameterCommand = new DelegateCommand(AddParameter);
            DelectParameterCommand = new DelegateCommand<VariationParameter>(DelectParameter);
            AppService = appService;
        }


        public DelegateCommand AddParameterCommand { get; set; }
        public DelegateCommand<VariationParameter> DelectParameterCommand { get; set; }

        private InspecRegionModel model;

        public InspecRegionModel Model
        {
            get { return model; }
            set { model = value; RaisePropertyChanged(); }
        }

        public ProjectService AppService { get; }

        private void AddParameter()
        {
            if (Model.Context != null && Model.Context is LocalDeformableContext context)
            {
                var param = new VariationParameter();
                param.ApplyDefaultValue();
               
                context.Setting.Parameters.Add(param);
            }
        }

        private void DelectParameter(VariationParameter input)
        {
            if (Model.Context != null && Model.Context is LocalDeformableContext context)
            {
                var param=  context.Setting.Parameters.FirstOrDefault(q => q.Equals(input));
                if (param!=null)
                {
                    context.Setting.Parameters.Remove(param);
                }
            }
        }

        public async override void Save()
        {
            if (Model.Context is LocalDeformableContext context)
            {
                context.Setting.InitParameters();
            }
            await AppService.UpdateRegionAsync(Model);
            base.Save();
        }

        public override void OnDialogOpened(IDialogParameters parameters)
        {

            if (parameters.ContainsKey("Value"))
            {
                Model = parameters.GetValue<InspecRegionModel>("Value");
                if (Model.Context is LocalDeformableContext context)
                {
                    if (context.Setting.Parameters == null)
                        context.Setting.Parameters = new ObservableCollection<VariationParameter>();
                }
            }

            base.OnDialogOpened(parameters);
        }

    }
}
