using Mov.WpfViewModels;
using Prism.Regions;
using Prism.Services.Dialogs;
using Reactive.Bindings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mov.Configurator.ViewModels
{
    public class ConfiguratorViewModel : RegionViewModelBase
    {
        public const string REGION_NAME_CENTER = "CONFIG_CENTER";

        public ReactiveCommand ShowAppSettingCommand { get; } = new ReactiveCommand();
        public ReactiveCommand ShowUserSettingCommand { get; } = new ReactiveCommand();
        public ReactiveCommand ShowVariableCommand { get; } = new ReactiveCommand();

        public ConfiguratorViewModel(IRegionManager regionManager, IDialogService dialogService) : base(regionManager, dialogService)
        {
            ShowAppSettingCommand.Subscribe(OnShowAppSetting);
            ShowUserSettingCommand.Subscribe(OnShowUserSetting);
            ShowVariableCommand.Subscribe(OnShowVariable);
        }

        protected override void OnLoaded()
        {
            OnShowUserSetting();
        }

        private void OnShowUserSetting() => this.RegionManager.RequestNavigate(REGION_NAME_CENTER, "UserSettingTableView");
        private void OnShowAppSetting() => this.RegionManager.RequestNavigate(REGION_NAME_CENTER, "AppSettingTableView");
        private void OnShowVariable() => this.RegionManager.RequestNavigate(REGION_NAME_CENTER, "VariableTableView");

    }
}
