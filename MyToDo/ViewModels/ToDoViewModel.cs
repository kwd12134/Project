using MyToDo.Common.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToDo.ViewModels
{
    public class ToDoViewModel:BindableBase
    {
        public ToDoViewModel()
        {
            toDoDtos = new ObservableCollection<ToDoDto>();
            AddCommand = new DelegateCommand(Add);
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


        private ObservableCollection<ToDoDto>  toDoDtos;

        public ObservableCollection<ToDoDto> ToDoDtos
        {
            get { return toDoDtos; }
            set { toDoDtos = value; RaisePropertyChanged(); }
        }

        void CreateToDo()
        {
            for (int i = 0; i < 20; i++)
            {
                ToDoDtos.Add(new ToDoDto() { Title="代办"+i,Content="处理中.........." });
            }
        }

    }
}
