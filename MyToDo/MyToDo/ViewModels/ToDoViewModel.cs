using MyToDo.Common.Models;
using MyToDo.Service;
using MyToDo.Shared.Contact;
using MyToDo.Shared.Dtos;
using MyToDo.Shared.Parameters;
using Prism.Ioc;
using System.Collections.ObjectModel;

namespace MyToDo.ViewModels
{
    public class ToDoViewModel : NavigationViewModel
    {
        public ToDoViewModel(IToDoService service, IContainerProvider Provider) : base(Provider)
        {
            toDoDtos = new ObservableCollection<ToDoDto>();
            ExecuteCommand = new DelegateCommand<string>(Execute);
            SelectedCommand = new DelegateCommand<ToDoDto>(Selected);
            Service = service;
        }

        private readonly IToDoService Service;
        public DelegateCommand<string> ExecuteCommand { get; set; }
        public DelegateCommand<ToDoDto> SelectedCommand { get; set; }

        private string search;

        public string Search
        {
            get { return search; }
            set { search = value; RaisePropertyChanged(); }
        }

        private bool isRightDrawerOpen;

        public bool IsRightDrawerOpen
        {
            get { return isRightDrawerOpen; }
            set { isRightDrawerOpen = value; RaisePropertyChanged(); }
        }

        private ObservableCollection<ToDoDto> toDoDtos;

        public ObservableCollection<ToDoDto> ToDoDtos
        {
            get { return toDoDtos; }
            set { toDoDtos = value; RaisePropertyChanged(); }
        }

        private ToDoDto currentDto;
        /// <summary>
        /// 编辑选中的对象
        /// </summary>
        public ToDoDto CurrentDto
        {
            get { return currentDto; }
            set { currentDto = value; RaisePropertyChanged(); }
        }

        private void Execute(string obj)
        {
            switch (obj)
            {
                case "新增": Add(); break;
                case "查询": GetDataAsync(); break;
                case "保存": Save(); break;
            }
        }

        private void Add()
        {
            IsRightDrawerOpen = true;
        }

        private async void Save()
        {
            if (string.IsNullOrWhiteSpace(CurrentDto.Title) || string.IsNullOrWhiteSpace(CurrentDto.Title)) return;

            UpdateLoading(true);
            try
            {
                if (CurrentDto.Id > 0)
                {
                    var updateResult = await Service.UpdateAsync(CurrentDto);
                    if (updateResult.Status)
                    {
                        var todoResult = ToDoDtos.FirstOrDefault(q => q.Id == CurrentDto.Id);
                        if (todoResult != null)
                        {
                            todoResult.Title = CurrentDto.Title;
                            todoResult.Content = CurrentDto.Content;
                            todoResult.Status = CurrentDto.Status;
                        }
                    }
                }
                else
                {
                    var addResult = await Service.AddAsync(CurrentDto);
                    if (addResult.Status)
                    {
                        ToDoDtos.Add(addResult.Result);
                        IsRightDrawerOpen = false;
                    }
                }
            }
            catch (Exception)
            {

            }
            finally
            {
                UpdateLoading(false);
            }
        }

        private async void Selected(ToDoDto dto)
        {
            try
            {
                UpdateLoading(true);
                IsRightDrawerOpen = true;
                var todeResult = await Service.GetFirstOfDefaultAsync(dto.Id);
                if (todeResult.Status)
                {
                    CurrentDto = todeResult.Result;
                }
            }
            catch (Exception)
            {
            }
            finally
            {
                UpdateLoading(false);
            }
        }

        public async void GetDataAsync()
        {
            //api等待加载界面显示
            UpdateLoading(true);

            var Todoresult = await Service.GetAllAsync(new QueryParameter()
            {
                PageIndex = 0,
                PageSize = 100,
                Search = this.Search
            });

            if (Todoresult.Status)
            {
                ToDoDtos.Clear();
                foreach (var item in Todoresult.Result.Items)
                {
                    ToDoDtos.Add(item);
                }
            }
            UpdateLoading(false);
        }

        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            base.OnNavigatedTo(navigationContext);

            GetDataAsync();
        }

    }
}
