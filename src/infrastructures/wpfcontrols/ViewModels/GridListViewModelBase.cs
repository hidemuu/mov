using Prism.Regions;
using Prism.Services.Dialogs;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Mov.WpfControls.ViewModels
{
    public abstract class GridListViewModelBase<T> : RegionViewModelBase
    {
        #region プロパティ

        public ReactiveCollection<ColumnItem[]> Items { get; } = new ReactiveCollection<ColumnItem[]>();
        public ReactivePropertySlim<ColumnAttribute[]> Attributes { get; private set; } = new ReactivePropertySlim<ColumnAttribute[]>();
        public ReactivePropertySlim<ColumnItem[]> SelectedItem { get; } = new ReactivePropertySlim<ColumnItem[]>();


        #endregion プロパティ

        #region コマンド

        public ReactiveCommand<object> AddCommand { get; } = new ReactiveCommand<object>();

        public ReactiveCommand<object> DeleteCommand { get; } = new ReactiveCommand<object>();

        #endregion コマンド

        #region コンストラクター

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="regionManager"></param>
        /// <param name="dialogService"></param>
        public GridListViewModelBase(IRegionManager regionManager, IDialogService dialogService) : base(regionManager, dialogService)
        {
            AddCommand.Subscribe(OnAddCommand).AddTo(Disposables);
            DeleteCommand.Subscribe(OnDeleteCommand).AddTo(Disposables);
        }

        #endregion コンストラクター

        #region イベント

        public override void OnNavigatedFrom(NavigationContext navigationContext)
        {
            base.OnNavigatedFrom(navigationContext);
            PostItems();
            Export();
        }

        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            base.OnNavigatedTo(navigationContext);
            Import(navigationContext);
            BindItems();
        }

        private void OnAddCommand(object parameter)
        {
            PutItem();
            BindItems();
        }

        private void OnDeleteCommand(object parameter)
        {
            DeleteItem();
            BindItems();
        }

        #endregion イベント

        #region 継承メソッド

        protected abstract void Import(NavigationContext navigationContext);

        protected abstract void Export();

        protected abstract void BindItems();

        protected abstract void PostItems();

        protected abstract void PutItem();

        protected abstract void DeleteItem();

        
        protected IEnumerable<ColumnItem> GetColumnItems(IEnumerable<PropertyInfo> propertyInfos, T item)
        {
            foreach (var propertyInfo in propertyInfos)
            {
                yield return new ColumnItem(propertyInfo.Name, propertyInfo.GetValue(item));
            }
        }

        protected IEnumerable<ColumnAttribute> GetColumnAttributes(IEnumerable<string> names)
        {
            foreach (var name in names)
            {
                yield return new ColumnAttribute(name);
            }
        }

        
        protected IEnumerable<T> GetDbObjects(IEnumerable<PropertyInfo> propertyInfos)
        {
            foreach (var item in Items)
            {
                var dbObject = (T)Activator.CreateInstance(typeof(T));
                int i = 0;
                foreach (var propertyInfo in propertyInfos)
                {
                    var value = item[i].GetValue();
                    propertyInfo.SetValue(dbObject, value);
                    i++;
                }
                yield return dbObject;
            }
        }

        #endregion 継承メソッド
    }
}
