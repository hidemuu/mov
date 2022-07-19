using Mov.Configurator.Models;
using Mov.WpfControls;
using Mov.WpfControls.ViewModels;
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

        private readonly IConfiguratorRepositoryCollection repository;

        public const string REGION_NAME_CENTER = "CONFIG_CENTER";

        public const string PAGE_NAME_CONFIG = "Config";

        public const string PAGE_NAME_APP_SETTING = "AppSetting";

        public const string PAGE_NAME_VARIABLE = "Variable";

        private readonly IDictionary<string, string> pageDictionary = new Dictionary<string, string>() {
            { PAGE_NAME_CONFIG, "ConfigTableView" },
            { PAGE_NAME_APP_SETTING, "AppSettingTableView" },
            { PAGE_NAME_VARIABLE, "VariableTableView" },
        };

        private string pageName = PAGE_NAME_APP_SETTING;

        #endregion フィールド

        #region プロパティ

        public ReactiveCollection<ColumnItem[]> Items { get; } = new ReactiveCollection<ColumnItem[]>();
        public ColumnAttribute[] Attributes { get; }

        #endregion プロパティ

        #region コマンド

        public ReactiveCommand<string> ShowPageCommand { get; } = new ReactiveCommand<string>();
        public ReactiveCommand ShowUserSettingCommand { get; } = new ReactiveCommand();
        public ReactiveCommand ShowVariableCommand { get; } = new ReactiveCommand();

        #endregion コマンド

        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="regionManager"></param>
        /// <param name="dialogService"></param>
        public ConfiguratorViewModel(IRegionManager regionManager, IDialogService dialogService, IConfiguratorRepositoryCollection repository) : base(regionManager, dialogService)
        {
            ShowPageCommand.Subscribe(DisplayPage);

            this.repository = repository;
            foreach (var item in this.repository.Configs.Gets())
            {
                Items.Add(new ColumnItem[]
                {
                    new ColumnItem(item.Id),
                    new ColumnItem(item.Index),
                    new ColumnItem(item.Code),
                    new ColumnItem(item.Category),
                    new ColumnItem(item.Name),
                    new ColumnItem(item.Value),
                    new ColumnItem(item.Default),
                    new ColumnItem(item.AccessLv),
                    new ColumnItem(item.Description),
                });
            }

            Attributes = new ColumnAttribute[]
            {
                new ColumnAttribute("id"),
                new ColumnAttribute("index"),
                new ColumnAttribute("code"),
                new ColumnAttribute("category"),
                new ColumnAttribute("name"),
                new ColumnAttribute("value"),
                new ColumnAttribute("default"),
                new ColumnAttribute("accessLv"),
                new ColumnAttribute("description"),
            };
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

        #endregion メソッド
    }
}