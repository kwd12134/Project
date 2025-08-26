
using MyToDo.Extensions;

namespace MyToDo.ViewModels
{
    public class NavigationViewModel : BindableBase, INavigationAware
    {
        private readonly IContainerProvider containerProvider;
        private readonly IEventAggregator aggregator;
        /// <summary>
        /// containerProvider.Resolve<IEventAggregator>();从容器中解析出来
        /// 或者ViewModel构造参数直接引入
        /// </summary>
        /// <param name="containerProvider"></param>
        public NavigationViewModel(IContainerProvider containerProvider)
        {
            this.containerProvider = containerProvider;
            this.aggregator = containerProvider.Resolve<IEventAggregator>();
        }
        public virtual bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public virtual void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }

        public virtual void OnNavigatedTo(NavigationContext navigationContext)
        {
        }

        /// <summary>
        /// 开启界面等待事件窗口
        /// </summary>
        /// <param name="IsOpen"></param>
        public void UpdateLoading(bool IsOpen)
        {
            aggregator.UpdateLoading(new Common.Events.UpdateModel() { IsOpen = IsOpen });
        }

    }
}
