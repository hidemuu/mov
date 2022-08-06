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

        private readonly IConfiguratorDatabase database;

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

        public ReactivePropertySlim<ColumnItem[]> SelectedItem { get; } = new ReactivePropertySlim<ColumnItem[]>();

        #endregion プロパティ

        #region コマンド

        public ReactiveCommand ImportCommand { get; } = new ReactiveCommand();

        public ReactiveCommand ExportCommand { get; } = new ReactiveCommand();

        public ReactiveCommand<object> AddCommand { get; } = new ReactiveCommand<object>();

        public ReactiveCommand<object> DeleteCommand { get; } = new ReactiveCommand<object>();

        #endregion コマンド

        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="regionManager"></param>
        /// <param name="dialogService"></param>
        public ConfiguratorViewModel(IRegionManager regionManager, IDialogService dialogService, IConfiguratorDatabase database) : base(regionManager, dialogService)
        {
            this.database = database;
            //サブスクライブ
            SelectedComboItem.Subscribe(OnSelectedComboItemChanged).AddTo(Disposables);
            ImportCommand.Subscribe(Import).AddTo(Disposables);
            ExportCommand.Subscribe(Export).AddTo(Disposables);
            AddCommand.Subscribe(Add).AddTo(Disposables);
            DeleteCommand.Subscribe(Delete).AddTo(Disposables);
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
            //切替前のデータを登録
            PostItems();
            //選択データをバインド
            BindItems(selectedItem);
            //選択データを更新
            currentComboItem = selectedItem;
        }

        private void Import()
        {
            this.database.Repositories[""].UserSettings.Import();
            this.database.Repositories[""].Accounts.Import();
            this.database.Repositories[""].Translates.Import();
        }

        private void Export()
        {
            PostItems();
            this.database.Repositories[""].UserSettings.Export();
            this.database.Repositories[""].Accounts.Export();
            this.database.Repositories[""].Translates.Export();
        }

        private void Add(object parameter)
        {
            switch (this.currentComboItem)
            {
                case DATA_NAME_CONFIG:
                    this.database.Repositories[""].UserSettings.Put(new UserSetting());
                    BindConfigs();
                    break;
                case DATA_NAME_ACCOUNTS:
                    this.database.Repositories[""].Accounts.Put(new Account());
                    BindAccounts();
                    break;
                case DATA_NAME_TRANSLATES:
                    this.database.Repositories[""].Translates.Put(new Translate());
                    BindTranslates();
                    break;
            }
        }

        private void Delete(object parameter)
        {
            var selectedItem = SelectedItem.Value;
            switch (this.currentComboItem)
            {
                case DATA_NAME_CONFIG:
                    this.database.Repositories[""].UserSettings.Delete((Guid)selectedItem[0].GetValue());
                    BindConfigs();
                    break;
                case DATA_NAME_ACCOUNTS:
                    this.database.Repositories[""].Accounts.Delete((Guid)selectedItem[0].GetValue());
                    BindAccounts();
                    break;
                case DATA_NAME_TRANSLATES:
                    this.database.Repositories[""].Translates.Delete((Guid)selectedItem[0].GetValue());
                    BindTranslates();
                    break;
            }
        }

        #endregion イベント

        #region メソッド

        private void BindItems(string selectedItem)
        {
            switch (selectedItem)
            {
                case DATA_NAME_CONFIG:
                    BindConfigs();
                    break;
                case DATA_NAME_ACCOUNTS:
                    BindAccounts();
                    break;
                case DATA_NAME_TRANSLATES:
                    BindTranslates();
                    break;
            }
        }

        private void BindConfigs()
        {
            Items.Clear();
            var properties = UserSetting.GetProperties();
            foreach (UserSetting item in this.database.Repositories[""].UserSettings?.Gets())
            {
                Items.Add(GetColumnItems<UserSetting>(properties.Select(x => x.propertyInfo), item).ToArray());
            }
            Attributes.Value = GetColumnAttributes<UserSetting>(properties.Select(x => x.name)).ToArray();
        }

        private void BindAccounts()
        {
            Items.Clear();
            var properties = Account.GetProperties();
            foreach (Account item in this.database.Repositories[""].Accounts?.Gets())
            {
                Items.Add(GetColumnItems<Account>(properties.Select(x => x.propertyInfo), item).ToArray());
            }
            Attributes.Value = GetColumnAttributes<Account>(properties.Select(x => x.name)).ToArray();
        }

        private void BindTranslates()
        {
            Items.Clear();
            var properties = Translate.GetProperties();
            foreach (Translate item in this.database.Repositories[""].Translates?.Gets())
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

        private void PostItems()
        {
            switch (currentComboItem)
            {
                case DATA_NAME_CONFIG:
                    PostConfigs();
                    break;
                case DATA_NAME_ACCOUNTS:
                    PostAccounts();
                    break;
                case DATA_NAME_TRANSLATES:
                    PostTranslates();
                    break;
            }
        }

        private void PostConfigs()
        {
            var configs = GetDbObjects<UserSetting>(UserSetting.GetProperties().Select(x => x.propertyInfo)).ToList();
            this.database.Repositories[""].UserSettings.Posts(configs);
        }

        private void PostAccounts()
        {
            var accounts = GetDbObjects<Account>(Account.GetProperties().Select(x => x.propertyInfo)).ToList();
            this.database.Repositories[""].Accounts.Posts(accounts);
        }

        private void PostTranslates()
        {
            var translates = GetDbObjects<Translate>(Translate.GetProperties().Select(x => x.propertyInfo)).ToList();
            this.database.Repositories[""].Translates.Posts(translates);
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