using MachineVision.Core;
using MachineVision.Extensions;
using MachineVision.Models;
using MachineVision.Services;
using MachineVision.Shared.Events;
using MachineVision.Shared.Services;
using MachineVision.Shared.Services.Tables;
using Prism.Commands;
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
        public SettingViewModel(
            IEventAggregator aggregator,
            ISettingService settingService)
        {
            LanguageInfo = new ObservableCollection<LanguageInfo>();
            Aggregator = aggregator;
            SettingService = settingService;

            SaveCommand = new DelegateCommand(Save);
        }

        public DelegateCommand SaveCommand { get; set; }

        private Setting setting {  get; set; }

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
                if (currentLanguage != null)
                {
                    LanguageChanged();
                }
                RaisePropertyChanged();
            }
        }

        public IEventAggregator Aggregator { get; }
        public ISettingService SettingService { get; }

        private void LanguageChanged()
        {
            if (LanguageHelper.AppCurrentLanguage == CurrentLanguage.Key) return;
            LanguageHelper.SetLanguage(CurrentLanguage.Key);
            //发布事件订阅
            Aggregator.GetEvent<LanguageEventBus>().Publish(true);
        }

        private async void Save()
        {
            setting.Language = CurrentLanguage.Key;
            setting.SkinName = "";
            setting.SkinColor = "";
            await SettingService.SaveSetting(setting);
        }

        public override async void OnNavigatedTo(NavigationContext navigationContext)
        {
            InitLanguageInfo();
            setting  = await SettingService.GetSettingAsync();

            CurrentLanguage = languageInfo.FirstOrDefault(t => t.Key.Equals(setting.Language));

            base.OnNavigatedTo(navigationContext);
        }

        private void InitLanguageInfo()
        {
            LanguageInfo.Clear();
            LanguageInfo.Add(new LanguageInfo() { Key = "zh-CN", Value = "Chinese" });
            LanguageInfo.Add(new LanguageInfo() { Key = "en-US", Value = "English" });
        }

    }
}
