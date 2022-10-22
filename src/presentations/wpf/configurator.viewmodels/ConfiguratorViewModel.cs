using Mov.Accessors.Repository;
using Mov.Configurator.Models;
using Mov.Utilities.Attributes;
using Mov.WpfModels;
using Mov.WpfMvvms;
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

        private const string DATA_NAME_USER_SETTINGS = "UserSetting";

        private const string DATA_NAME_ACCOUNTS = "Account";

        private const string DATA_NAME_TRANSLATES = "Translate";

        private const string DATA_NAME_ICONS = "Icon";

        #endregion 定数

        #region フィールド

        private readonly IDomainRepositoryCollection<IConfiguratorRepository> database;

        private IConfiguratorRepository repository;

        private string currentComboItem;

        #endregion フィールド

        #region プロパティ

        public ReactiveCollection<ColumnItem[]> Items { get; } = new ReactiveCollection<ColumnItem[]>();
        public ReactivePropertySlim<ColumnAttribute[]> Attributes { get; private set; } = new ReactivePropertySlim<ColumnAttribute[]>();

        public ReactiveCollection<string> ComboItems { get; } = new ReactiveCollection<string>()
        {
            DATA_NAME_USER_SETTINGS, DATA_NAME_ACCOUNTS, DATA_NAME_TRANSLATES, DATA_NAME_ICONS,
        };

        public ReactivePropertySlim<string> SelectedComboItem { get; } = new ReactivePropertySlim<string>(DATA_NAME_USER_SETTINGS);

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
        public ConfiguratorViewModel(IRegionManager regionManager, IDialogService dialogService, IDomainRepositoryCollection<IConfiguratorRepository> database) : base(regionManager, dialogService)
        {
            this.database = database;
            this.repository = database.GetRepository("");
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
            repository.UserSettings.Read();
        }

        private void Export()
        {
            PostItems();
            repository.UserSettings.Write();
        }

        private void Add(object parameter)
        {
            switch (this.currentComboItem)
            {
                case DATA_NAME_USER_SETTINGS:
                    repository.UserSettings.Put(new UserSetting());
                    BindConfigs();
                    break;
            }
        }

        private void Delete(object parameter)
        {
            var selectedItem = SelectedItem.Value;
            switch (this.currentComboItem)
            {
                case DATA_NAME_USER_SETTINGS:
                    repository.UserSettings.Delete((Guid)selectedItem[0].GetValue());
                    BindConfigs();
                    break;
            }
        }

        #endregion イベント

        #region メソッド

        private void BindItems(string selectedItem)
        {
            switch (selectedItem)
            {
                case DATA_NAME_USER_SETTINGS:
                    BindConfigs();
                    break;
            }
        }

        private void BindConfigs()
        {
            Items.Clear();
            var properties = UserSetting.GetProperties();
            foreach (UserSetting item in this.repository?.UserSettings?.Get())
            {
                Items.Add(GetColumnItems<UserSetting>(properties.Select(x => x.propertyInfo), item).ToArray());
            }
            Attributes.Value = GetColumnAttributes<UserSetting>(properties.Select(x => x.name)).ToArray();
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
                case DATA_NAME_USER_SETTINGS:
                    PostConfigs();
                    break;
            }
        }

        private void PostConfigs()
        {
            var configs = GetDbObjects<UserSetting>(UserSetting.GetProperties().Select(x => x.propertyInfo)).ToList();
            this.repository?.UserSettings.Posts(configs);
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