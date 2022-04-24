using Mov.Designer.Models;
using Mov.Designer.Models.interfaces;
using Mov.WpfViewModels;
using Mov.WpfViewModels.Components.Tables;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mov.Designer.ViewModels
{
    public class DesignerTreeViewModel : ViewModelBase
    {
        #region フィールド

        private readonly IDesignerRepositoryCollection repository;

        #endregion フィールド

        #region プロパティ

        public ReactiveCollection<TreeModel> Models { get; } = new ReactiveCollection<TreeModel>();
        public TreeModelAttribute Attribute { get; } = new TreeModelAttribute();

        #endregion プロパティ

        #region コマンド

        public ReactiveCommand<string> SaveCommand { get; } = new ReactiveCommand<string>();

        #endregion コマンド

        #region コンストラクター

        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="repository"></param>
        public DesignerTreeViewModel(IDesignerRepositoryCollection repository)
        {
            this.repository = repository;
            SaveCommand.Subscribe(OnSaveCommand).AddTo(Disposables);
            foreach (var tree in repository.LayoutTrees.Gets())
            {
                Models.Add(new TreeModel(tree));
            }
        }

        #endregion コンストラクター

        #region イベント

        protected override void OnLoaded()
        {

        }

        #endregion イベント

        #region メソッド

        private void OnSaveCommand(string parameter)
        {
            var items = new List<LayoutTree>();
            GetItems(items, Models);
            repository.LayoutTrees.Sets(items);
        }

        private void GetItems(ICollection<LayoutTree> items, IEnumerable<TreeModel> models)
        {
            foreach (var model in models)
            {
                var item = new LayoutTree
                {
                    Id = model.Id.Value,
                    Code = model.Code.Value,
                    IsExpand = model.IsExpand.Value,
                    LayoutType = model.LayoutType.Value,
                    LayoutStyle = model.LayoutStyle.Value,
                    LayoutParameter = model.LayoutParameter.Value,
                };
                items.Add(item);
                GetItems(item.Children, model.Children);
            }
        }

        #endregion メソッド

        #region クラス

        public class TreeModel
        {
            public ReactivePropertySlim<int> Id { get; } = new ReactivePropertySlim<int>();
            public ReactivePropertySlim<string> Code { get; } = new ReactivePropertySlim<string>();
            public ReactivePropertySlim<string> LayoutType { get; } = new ReactivePropertySlim<string>();
            public ReactivePropertySlim<string> LayoutStyle { get; } = new ReactivePropertySlim<string>();
            public ReactivePropertySlim<string> LayoutParameter { get; } = new ReactivePropertySlim<string>();
            public ReactivePropertySlim<bool> IsExpand { get; } = new ReactivePropertySlim<bool>(true);
            public ReactivePropertySlim<string> ToolTip { get; } = new ReactivePropertySlim<string>();
            public List<TreeModel> Children { get; set; } = new List<TreeModel>();

            public TreeModel(LayoutTree item)
            {
                Id.Value = item.Id;
                Code.Value = item.Code;
                IsExpand.Value = item.IsExpand;
                LayoutType.Value = item.LayoutType;
                LayoutStyle.Value = item.LayoutStyle;
                LayoutParameter.Value = item.LayoutParameter;
                foreach(var child in item.Children)
                {
                    Children.Add(new TreeModel(child));
                }
            }
        }

        public class TreeModelAttribute
        {
            public ColumnAttribute Id { get; } = new ColumnAttribute() { Header = "id" };
            public ColumnAttribute Code { get; } = new ColumnAttribute() { Header = "code" };
            public ColumnAttribute LayoutType { get; } = new ColumnAttribute() { Header = "layoutType" , Width = 150 };
            public ColumnAttribute LayoutStyle { get; } = new ColumnAttribute() { Header = "layoutStyle" , Width = 150 };
            public ColumnAttribute LayoutParameter { get; } = new ColumnAttribute() { Header = "layoutParameter", Width = 150 };
            public ColumnAttribute IsExpand { get; } = new ColumnAttribute() { Header = "isExpand", Width = 120 };
        }

        #endregion クラス
    }
}
