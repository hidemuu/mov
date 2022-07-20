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
        public ColumnAttribute[] Attributes { get; private set; }

        public ReactiveCollection<string> ComboItems { get; } = new ReactiveCollection<string>()
        {
            DATA_NAME_CONFIG, DATA_NAME_ACCOUNTS, DATA_NAME_TRANSLATES,
        };

        public ReactivePropertySlim<string> SelectedComboItem { get; } = new ReactivePropertySlim<string>(DATA_NAME_CONFIG);

        #endregion プロパティ


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
                    SetConfigs();
                    break;
                case DATA_NAME_ACCOUNTS:
                    SetAccounts();
                    break;
                case DATA_NAME_TRANSLATES:
                    SetTranslates();
                    break;
            }
        }

        #endregion イベント

        #region メソッド

        private void SetConfigs()
        {
            Items.Clear();
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

        private void SetAccounts()
        {
            Items.Clear();
            foreach (var item in this.repository.Accounts.Gets())
            {
                Items.Add(new ColumnItem[]
                {
                    new ColumnItem(item.Id),
                    new ColumnItem(item.Index),
                    new ColumnItem(item.Code),
                    new ColumnItem(item.LoginId),
                    new ColumnItem(item.Password),
                });
            }

            Attributes = new ColumnAttribute[]
            {
                new ColumnAttribute("ID"),
                new ColumnAttribute("項目"),
                new ColumnAttribute("コード"),
                new ColumnAttribute("ログイン"),
                new ColumnAttribute("パスワード"),
            };
        }

        private void SetTranslates()
        {
            Items.Clear();
            foreach (var item in this.repository.Translates.Gets())
            {
                Items.Add(new ColumnItem[]
                {
                    new ColumnItem(item.Id),
                    new ColumnItem(item.Index),
                    new ColumnItem(item.Code),
                    new ColumnItem(item.JP),
                    new ColumnItem(item.EN),
                    new ColumnItem(item.CN),
                });
            }

            Attributes = new ColumnAttribute[]
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