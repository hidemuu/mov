using Mov.Configurator.Models;
using Mov.Utilities.Attributes;
using Mov.WpfControls;
using Mov.WpfControls.ViewModels;
using Prism.Regions;
using Prism.Services.Dialogs;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace Mov.Configurator.ViewModels
{
    /// <summary>コンフィグ設定のビューモデル</summary>
    public class ConfiguratorViewModel : RegionViewModelBase
    {
        #region 定数

        private const string DATA_NAME_CONFIG = "Config";

        private const string DATA_NAME_ACCOUNTS = "Account";

        private const string DATA_NAME_TRANSLATES = "Translate";

        #endregion 定数

        #region フィールド

        private readonly IConfiguratorRepositoryCollection repository;

        private string currentComboItem;

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
            switch (currentComboItem) 
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

            currentComboItem = selectedItem;
        }

        private void Import()
        {
            switch (SelectedComboItem.Value)
            {
                case DATA_NAME_CONFIG:
                    this.repository.Configs.Import();
                    break;
                case DATA_NAME_ACCOUNTS:
                    this.repository.Accounts.Import();
                    break;
                case DATA_NAME_TRANSLATES:
                    this.repository.Translates.Import();
                    break;
            }
        }

        private void Export()
        {
            switch (SelectedComboItem.Value)
            {
                case DATA_NAME_CONFIG:
                    this.repository.Configs.Export();
                    break;
                case DATA_NAME_ACCOUNTS:
                    this.repository.Accounts.Export();
                    break;
                case DATA_NAME_TRANSLATES:
                    this.repository.Translates.Export();
                    break;
            }
        }

        #endregion イベント

        #region メソッド

        private void GetConfigs()
        {
            Items.Clear();
            var properties = GetProperties<Config>().OrderBy(x => x.index);
            foreach (Config item in this.repository.Configs?.Gets())
            {
                Items.Add(GetColumnItems<Config>(properties.Select(x => x.propertyInfo), item).ToArray());
            }
            Attributes.Value = GetColumnAttributes<Config>(properties.Select(x => x.name)).ToArray();
        }

        private IEnumerable<(PropertyInfo propertyInfo, int index, string name)> GetProperties<T>()
        {
            var properties = typeof(T).GetProperties();
            foreach(var property in properties)
            {
                var index = AttributeHelper.GetAttribute<DisplayIndexAttribute>(property).Index;
                var name = AttributeHelper.GetAttribute<DisplayNameAttribute>(property).DisplayName;
                yield return (property, index, name);
            }
        }

        private IEnumerable<ColumnItem> GetColumnItems<T>(IEnumerable<PropertyInfo> propertyInfos, T item)
        {
            foreach(var propertyInfo in propertyInfos)
            {
                yield return new ColumnItem(propertyInfo.Name, propertyInfo.GetValue(item));
            }
        }

        private IEnumerable<ColumnAttribute> GetColumnAttributes<T>(IEnumerable<string> names)
        {
            foreach(var name in names)
            {
                yield return new ColumnAttribute(name);
            }
        }

        private void SetConfigs()
        {
            var configs = new List<Config>();
            foreach(var item in Items)
            {
                configs.Add(new Config
                {
                    Id = (Guid)item[0].Value.Value,
                    Index = (int)item[1].Value.Value,
                    Code = (string)item[2].Value.Value,
                    Category = (string)item[3].Value.Value,
                    Name = (string)item[4].Value.Value,
                    Value = (string)item[5].Value.Value,
                    Default = (string)item[6].Value.Value,
                    AccessLv = (int)item[7].Value.Value,
                    Description = (string)item[8].Value.Value,
                });
            }
            this.repository.Configs.Posts(configs);
        }

        private void GetAccounts()
        {
            Items.Clear();
            foreach (var item in this.repository.Accounts?.Gets())
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

        private void SetAccounts()
        {
            var accounts = new List<Account>();
            foreach (var item in Items)
            {
                accounts.Add(new Account
                {
                    Id = (Guid)item[0].Value.Value,
                    Index = (int)item[1].Value.Value,
                    Code = (string)item[2].Value.Value,
                    LoginId = (string)item[3].Value.Value,
                    Password = (string)item[4].Value.Value,
                });
            }
            this.repository.Accounts.Posts(accounts);
        }

        private void GetTranslates()
        {
            Items.Clear();
            foreach (var item in this.repository.Translates?.Gets())
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

        private void SetTranslates()
        {
            var translates = new List<Translate>();
            foreach (var item in Items)
            {
                translates.Add(new Translate
                {
                    Id = (Guid)item[0].Value.Value,
                    Index = (int)item[1].Value.Value,
                    Code = (string)item[2].Value.Value,
                    JP = (string)item[3].Value.Value,
                    EN = (string)item[4].Value.Value,
                    CN = (string)item[5].Value.Value,
                });
            }
            this.repository.Translates.Posts(translates);
        }

        #endregion メソッド
    }
}