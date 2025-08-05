using MyToDo.Common.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToDo.ViewModels
{
    public class MemoViewModel : BindableBase
    {
        public MemoViewModel()
        {
            AddCommand = new DelegateCommand(Add);
            MemoDtos = new ObservableCollection<MemoDto>();
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

        public ObservableCollection<MemoDto> MemoDtos
        {
            get { return memoDtos; }
            set { memoDtos = value; RaisePropertyChanged(); }
        }

        void CreateToDo()
        {
            for (int i = 0; i < 20; i++)
            {
                MemoDtos.Add(new MemoDto() { Title = "备忘录" + i, Content = "处理中.........." });
            }
        }
    }



}
