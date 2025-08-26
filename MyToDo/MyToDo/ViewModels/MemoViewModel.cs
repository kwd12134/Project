using MyToDo.Common.Models;
using MyToDo.Service;
using MyToDo.Shared.Dtos;
using MyToDo.Shared.Parameters;
using Prism.Ioc;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToDo.ViewModels
{
    public class MemoViewModel : NavigationViewModel
    {
        public MemoViewModel(IMemoService service, IContainerProvider Provider) : base(Provider)
        {
            AddCommand = new DelegateCommand(Add);
            MemoDtos = new ObservableCollection<MemoDto>();
            this.service = service;
            CreateToDo();
        }

        private void Add()
        {
            IsRightDrawerOpen = true;
        }

        private bool isRightDrawerOpen;

        public bool IsRightDrawerOpen
        {
            get { return isRightDrawerOpen; }
            set { isRightDrawerOpen = value; RaisePropertyChanged(); }
        }

        public DelegateCommand AddCommand { get; set; }


        private ObservableCollection<MemoDto> memoDtos;
        private readonly IMemoService service;

        public ObservableCollection<MemoDto> MemoDtos
        {
            get { return memoDtos; }
            set { memoDtos = value; RaisePropertyChanged(); }
        }

        async void CreateToDo()
        {
            var MemoResult = await service.GetAllAsync(new QueryParameter()
            {
                PageIndex = 0,
                PageSize=100
            });

            if (MemoResult.Status)
            {
                foreach (var item in MemoResult.Result.Items)
                {
                    MemoDtos.Add(item);
                }
            }

        }
    }



}
