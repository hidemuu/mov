using Mov.Configurator.Models;
using Mov.WpfControls;
using Mov.WpfControls.ViewModels;
using Prism.Regions;
using Prism.Services.Dialogs;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System;
using System.Collections.Generic;

namespace Mov.Configurator.ViewModels
{
    /// <summary>コンフィグ設定のビューモデル</summary>
    public class ConfiguratorViewModel : RegionViewModelBase
    {
        #region フィールド

        private readonly IConfiguratorRepositoryCollection repository;

        public const string DATA_NAME_CONFIG = "Config";

        public const string DATA_NAME_ACCOUNTS = "Account";

        public const string DATA_NAME_TRANSLATES = "Translate";

        #endregion フィールド

        #region プロパティ

        public ReactiveCollection<ColumnItem[]> Items { get; } = new ReactiveCollection<ColumnItem[]>();
        public ReactivePropertySlim<ColumnAttribute[]> Attributes { get; private set; } = new ReactivePropertySlim<ColumnAttribute[]>();

        public ReactiveCollection<string> ComboItems { get; } = new ReactiveCollection<string>()
        {
            DATA_NAME_CONFIG, DATA_NAME_ACCOUNTS, DATA_NAME_TRANSLATES,
        };

        public ReactivePropertySlim<string> SelectedComboItem { get; } = new ReactivePropertySlim<string>(DATA_NAME_CONFIG);

        #endregion プロパティ

        #region コマンド

        public ReactiveCommand ImportCommand { get; } = new ReactiveCommand();

        public ReactiveCommand ExportCommand { get; } = new ReactiveCommand();

        #endregion コマンド

        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="regionManager"></param>
        /// <param name="dialogService"></param>
        public ConfiguratorViewModel(IRegionManager regionManager, IDialogService dialogService, IConfiguratorRepositoryCollection repository) : base(regionManager, dialogService)
        {
            this.repository = repository;
            //サブスクライブ
            SelectedComboItem.Subscribe(OnSelectedComboItemChanged).AddTo(Disposables);
            ImportCommand.Subscribe(Import).AddTo(Disposables);
            ExportCommand.Subscribe(Export).AddTo(Disposables);
        }

        #region イベント

        protected override void OnLoaded()
        {

        }

        private void OnSelectedComboItemChanged(string selectedItem)
        {
            switch (selectedItem) 
            {
                case DATA_NAME_CONFIG:
                    GetConfigs();
                    break;
                case DATA_NAME_ACCOUNTS:
                    GetAccounts();
                    break;
                case DATA_NAME_TRANSLATES:
                    GetTranslates();
                    break;
            }
        }

        private void Import()
        {

        }

        private void Export()
        {

        }

        #endregion イベント

        #region メソッド

        private void GetConfigs()
        {
            Items.Clear();
            foreach (var item in this.repository.Configs.Gets())
            {
                Items.Add(new ColumnItem[]
                {
                    new ColumnItem("id", item.Id),
                    new ColumnItem("index", item.Index),
                    new ColumnItem("code", item.Code),
                    new ColumnItem("category", item.Category),
                    new ColumnItem("name", item.Name),
                    new ColumnItem("value", item.Value),
                    new ColumnItem("default", item.Default),
                    new ColumnItem("access_lv", item.AccessLv),
                    new ColumnItem("description", item.Description),
                });
            }

            Attributes.Value = new ColumnAttribute[]
            {
                new ColumnAttribute("ID"),
                new ColumnAttribute("項目"),
                new ColumnAttribute("コード"),
                new ColumnAttribute("カテゴリ"),
                new ColumnAttribute("名称"),
                new ColumnAttribute("設定値"),
                new ColumnAttribute("初期値"),
                new ColumnAttribute("Lv"),
                new ColumnAttribute("備考"),
            };
        }

        private void SetConfigs()
        {
            var configs = new List<Config>();
            foreach(var item in Items)
            {
                configs.Add(new Config
                {
                    Id = Guid.Parse(item[0].Value.Value),
                    Index = int.Parse(item[1].Value.Value),
                    Code = item[2].Value.Value,
                    Category = item[3].Value.Value,
                    Name = item[4].Value.Value,
                    Value = item[5].Value.Value,
                    Default = item[6].Value.Value,
                    AccessLv = int.Parse(item[7].Value.Value),
                    Description = item[8].Value.Value,
                });
            }
        }

        private void GetAccounts()
        {
            Items.Clear();
            foreach (var item in this.repository.Accounts.Gets())
            {
                Items.Add(new ColumnItem[]
                {
                    new ColumnItem("id", item.Id),
                    new ColumnItem("index", item.Index),
                    new ColumnItem("code", item.Code),
                    new ColumnItem("login_id", item.LoginId),
                    new ColumnItem("password", item.Password),
                });
            }

            Attributes.Value = new ColumnAttribute[]
            {
                new ColumnAttribute("ID"),
                new ColumnAttribute("項目"),
                new ColumnAttribute("コード"),
                new ColumnAttribute("ログイン"),
                new ColumnAttribute("パスワード"),
            };
        }

        private void GetTranslates()
        {
            Items.Clear();
            foreach (var item in this.repository.Translates.Gets())
            {
                Items.Add(new ColumnItem[]
                {
                    new ColumnItem("id", item.Id),
                    new ColumnItem("index", item.Index),
                    new ColumnItem("code", item.Code),
                    new ColumnItem("jp", item.JP),
                    new ColumnItem("en", item.EN),
                    new ColumnItem("cn", item.CN),
                });
            }

            Attributes.Value = new ColumnAttribute[]
            {
                new ColumnAttribute("ID"),
                new ColumnAttribute("項目"),
                new ColumnAttribute("コード"),
                new ColumnAttribute("日本語"),
                new ColumnAttribute("英語"),
                new ColumnAttribute("中国語"),
            };
        }

        #endregion メソッド
    }
}