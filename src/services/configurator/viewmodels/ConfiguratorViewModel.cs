using Mov.WpfViewModels;
using Prism.Regions;
using Prism.Services.Dialogs;
using Reactive.Bindings;
using System;
using System.Collections.Generic;

namespace Mov.Configurator.ViewModels
{
    /// <summary>コンフィグ設定のビューモデル</summary>
    public class ConfiguratorViewModel : RegionViewModelBase
    {
        #region フィールド

        public const string REGION_NAME_CENTER = "CONFIG_CENTER";

        public const string PAGE_NAME_USER_SETTING = "UserSetting";

        public const string PAGE_NAME_APP_SETTING = "AppSetting";

        public const string PAGE_NAME_VARIABLE = "Variable";

        private readonly IDictionary<string, string> pageDictionary = new Dictionary<string, string>() {
            { PAGE_NAME_USER_SETTING, "UserSettingTableView" },
            { PAGE_NAME_APP_SETTING, "AppSettingTableView" },
            { PAGE_NAME_VARIABLE, "VariableTableView" },
        };

        private string pageName = PAGE_NAME_APP_SETTING;

        #endregion フィールド

        #region コマンド

        public ReactiveCommand<string> ShowPageCommand { get; } = new ReactiveCommand<string>();
        public ReactiveCommand ShowUserSettingCommand { get; } = new ReactiveCommand();
        public ReactiveCommand ShowVariableCommand { get; } = new ReactiveCommand();

        #endregion コマンド

        public ConfiguratorViewModel(IRegionManager regionManager, IDialogService dialogService) : base(regionManager, dialogService)
        {
            ShowPageCommand.Subscribe(DisplayPage);
        }

        #region イベント

        protected override void OnLoaded() => DisplayPage(this.pageName);

        #endregion イベント

        #region メソッド

        private void DisplayPage(string pageName)
        {
            this.pageName = pageName;
            this.RegionManager.RequestNavigate(REGION_NAME_CENTER, pageDictionary[this.pageName]);
        }

        #endregion

    }
}