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

        /// <summary>
        /// ロード時のイベント
        /// </summary>
        protected override void OnLoaded()
        {

        }

        /// <summary>
        /// コンボボックスの選択を変更した時のイベント
        /// </summary>
        /// <param name="selectedItem"></param>
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
            this.repository.Configs.Import();
            this.repository.Accounts.Import();
            this.repository.Translates.Import();
        }

        private void Export()
        {
            this.repository.Configs.Export();
            this.repository.Accounts.Export();
            this.repository.Translates.Export();
        }

        #endregion イベント

        #region メソッド

        private void GetConfigs()
        {
            Items.Clear();
            var properties = Config.GetProperties();
            foreach (Config item in this.repository.Configs?.Gets())
            {
                Items.Add(GetColumnItems<Config>(properties.Select(x => x.propertyInfo), item).ToArray());
            }
            Attributes.Value = GetColumnAttributes<Config>(properties.Select(x => x.name)).ToArray();
        }

        private void GetAccounts()
        {
            Items.Clear();
            var properties = Account.GetProperties();
            foreach (Account item in this.repository.Accounts?.Gets())
            {
                Items.Add(GetColumnItems<Account>(properties.Select(x => x.propertyInfo), item).ToArray());
            }
            Attributes.Value = GetColumnAttributes<Account>(properties.Select(x => x.name)).ToArray();
        }

        private void GetTranslates()
        {
            Items.Clear();
            var properties = Translate.GetProperties();
            foreach (Translate item in this.repository.Translates?.Gets())
            {
                Items.Add(GetColumnItems<Translate>(properties.Select(x => x.propertyInfo), item).ToArray());
            }
            Attributes.Value = GetColumnAttributes<Translate>(properties.Select(x => x.name)).ToArray();
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
            var configs = GetDbObjects<Config>(Config.GetProperties().Select(x => x.propertyInfo)).ToList();
            this.repository.Configs.Posts(configs);
        }

        private void SetAccounts()
        {
            var accounts = GetDbObjects<Account>(Account.GetProperties().Select(x => x.propertyInfo)).ToList();
            this.repository.Accounts.Posts(accounts);
        }

        private void SetTranslates()
        {
            var translates = GetDbObjects<Translate>(Translate.GetProperties().Select(x => x.propertyInfo)).ToList();
            this.repository.Translates.Posts(translates);
        }

        private IEnumerable<T> GetDbObjects<T>(IEnumerable<PropertyInfo> propertyInfos)
        {
            foreach(var item in Items)
            {
                var dbObject = (T)Activator.CreateInstance(typeof(T));
                int i = 0;
                foreach(var propertyInfo in propertyInfos)
                {
                    var value = item[i].GetValue();
                    propertyInfo.SetValue(dbObject, value);
                    i++;
                }
                yield return dbObject;
            }
        }

        #endregion メソッド
    }
}