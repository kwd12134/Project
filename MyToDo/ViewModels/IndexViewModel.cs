using MyToDo.Common.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;

namespace MyToDo.ViewModels
{
    public class IndexViewModel:BindableBase
    {
        public IndexViewModel()
        {
            taskBars = new ObservableCollection<TaskBar>();
            CreateTaskBar();
            CreateTest();
        }

        private ObservableCollection<TaskBar> taskBars;

        public ObservableCollection<TaskBar> TaskBars
        {
            get { return taskBars; }
            set { taskBars = value; RaisePropertyChanged(); }
        }


        private ObservableCollection<ToDoDto>  toDoDto;

        public ObservableCollection<ToDoDto> ToDoDto
        {
            get { return toDoDto; }
            set { toDoDto = value; RaisePropertyChanged(); }
        }

        private ObservableCollection<MemoDto>  memoDto;

        public ObservableCollection<MemoDto> MemoDto
        {
            get { return memoDto; }
            set { memoDto = value; RaisePropertyChanged(); }
        }

        void CreateTaskBar()
        {
            taskBars.Add(new TaskBar(){ Icon = "ClockFast",Target="",Color="#FF0CA0FF",Title="汇总", Content = "9"});
            taskBars.Add(new TaskBar(){ Icon = "ClockCheckOutLine",Target="",Color="#FF1ECA3A", Title = "已完成",Content="9"});
            taskBars.Add(new TaskBar(){ Icon = "ChartLineVariant",Target="",Color="#FF02C6DC", Title = "完成比例",Content="100%"});
            taskBars.Add(new TaskBar(){ Icon = "PlayListStar",Target="",Color="#FFFFA000", Title = "备忘录",Content="10"});
        }

        void CreateTest()
        {
            ToDoDto = new ObservableCollection<ToDoDto>();
            MemoDto = new ObservableCollection<MemoDto>();

            for (int i = 0; i < 10; i++)
            {
                toDoDto.Add(new ToDoDto() { Title = "代办" + i, Content = "处理中......" });
                MemoDto.Add(new MemoDto() { Title = "备忘" + i, Content = "处理中......" });
            }
        }

    }


}
