using MachineVision.Core;
using MachineVision.Extensions;
using MachineVision.Models;
using MachineVision.Shared.Events;
using Prism.Events;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
namespace MachineVision.ViewModels
{
    public class SettingViewModel : NavigationViewModel
    {
        /// <summary>
        /// aggregator聚合器
        /// </summary>
        /// <param name="aggregator"></param>
        public SettingViewModel(IEventAggregator aggregator)
        {
            LanguageInfo = new ObservableCollection<LanguageInfo>();
            Aggregator = aggregator;
        }

        private ObservableCollection<LanguageInfo> languageInfo;

        public ObservableCollection<LanguageInfo> LanguageInfo
        {
            get { return languageInfo; }
            set { languageInfo = value; RaisePropertyChanged(); }
        }

        private LanguageInfo currentLanguage;

        public LanguageInfo CurrentLanguage
        {
            get { return currentLanguage; }
            set
            {
                currentLanguage = value;
                LanguageChanged();
                RaisePropertyChanged();
            }
        }

        public IEventAggregator Aggregator { get; }

        private void LanguageChanged()
        {
            LanguageHelper.SetLanguage(CurrentLanguage.Key);
            //发布事件订阅
            Aggregator.GetEvent<LanguageEventBus>().Publish(true);
        }

        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            base.OnNavigatedTo(navigationContext);
            InitLanguageInfo();
        }

        private void InitLanguageInfo()
        {
            LanguageInfo.Add(new LanguageInfo() { Key = "zh-CN", Value = "Chinese" });
            LanguageInfo.Add(new LanguageInfo() { Key = "en-US", Value = "English" });
        }

    }
}
