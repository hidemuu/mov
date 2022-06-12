using Mov.Designer.Models;
using Mov.Designer.Models.interfaces;
using Mov.WpfViewModels;
using Mov.WpfViewModels.Components.Tables;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Disposables;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

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
        public ReactivePropertySlim<bool> IsEdit { get; } = new ReactivePropertySlim<bool>(false);

        #endregion プロパティ

        #region コマンド

        public ReactiveCommand<string> EditCommand { get; } = new ReactiveCommand<string>();
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
            EditCommand.Subscribe(OnEditCommand).AddTo(Disposables);
            foreach (var tree in repository.LayoutTrees.Gets())
            {
                Models.Add(new TreeModel(tree, repository.ContentTables.Get(tree.Code), repository));
            }
        }

        #endregion コンストラクター

        #region イベント

        protected override void OnLoaded()
        {

        }

        private void OnEditCommand(string parameter)
        {
            IsEdit.Value = !IsEdit.Value;
            if (IsEdit.Value) Attribute.Edit.Width.Value = 45;
            else Attribute.Edit.Width.Value = 0;
            UpdateEditMode(Models);
        }

        private void OnSaveCommand(string parameter)
        {
            var trees = new List<LayoutTree>();
            GetLayoutTrees(trees, Models);
            repository.LayoutTrees.Sets(trees);
            repository.LayoutTrees.Posts();
            var tables = new List<ContentTable>();
            GetContentTables(tables, Models);
            repository.ContentTables.Sets(tables);
            repository.ContentTables.Posts();
            MessageBox.Show("保存しました");
        }

        #endregion イベント

        #region メソッド

        private void GetLayoutTrees(ICollection<LayoutTree> items, IEnumerable<TreeModel> models)
        {
            foreach (var model in models)
            {
                var item = new LayoutTree
                {
                    Id = model.Id.Value,
                    Index = model.Index.Value,
                    Code = model.Code.Value,
                    IsExpand = model.IsExpand.Value,
                    LayoutNodeType = model.LayoutType.Value,
                    LayoutStyle = model.LayoutStyle.Value,
                    LayoutParameter = model.LayoutParameter.Value,
                };
                items.Add(item);
                GetLayoutTrees(item.Children, model.Children);
            }
        }

        private void GetContentTables(ICollection<ContentTable> items, IEnumerable<TreeModel> models)
        {
            foreach (var model in models)
            {
                var item = new ContentTable
                {
                    Id = model.Id.Value,
                    Index = model.Index.Value,
                    Code = model.Code.Value,
                    Command = model.Command.Value,
                    ControlType = model.ControlType.Value,
                    ControlStyle = model.ControlStyle.Value,
                };
                items.Add(item);
                GetContentTables(items, model.Children);
            }
        }

        private void UpdateEditMode(IEnumerable<TreeModel> treeModels)
        {
            foreach(var model in treeModels)
            {
                model.IsEdit.Value = IsEdit.Value;
                UpdateEditMode(model.Children);
            }
        }

        #endregion メソッド

    }
    #region クラス

    public class TreeModel : TableModel
    {
        #region フィールド

        private CompositeDisposable disposables = new CompositeDisposable();

        private IDesignerRepositoryCollection repository;

        #endregion フィールド

        #region プロパティ

        public ReactivePropertySlim<LayoutNodeType> LayoutType { get; } = new ReactivePropertySlim<LayoutNodeType>(LayoutNodeType.Content);
        public ReactivePropertySlim<OrientationType> OrientationType { get; } = new ReactivePropertySlim<OrientationType>(Designer.Models.OrientationType.Horizontal);
        public ReactivePropertySlim<string> LayoutStyle { get; } = new ReactivePropertySlim<string>();
        public ReactivePropertySlim<string> LayoutParameter { get; } = new ReactivePropertySlim<string>();
        public ReactivePropertySlim<bool> IsExpand { get; } = new ReactivePropertySlim<bool>(true);
        public ReactivePropertySlim<string> ToolTip { get; } = new ReactivePropertySlim<string>();
        public ReactivePropertySlim<bool> IsEdit { get; } = new ReactivePropertySlim<bool>(false);

        public List<string> Codes { get; set; } = new List<string>();

        public List<LayoutNodeType> NodeTypes { get; set; } = new List<LayoutNodeType>
            {
                LayoutNodeType.Content,
                LayoutNodeType.Expander,
                LayoutNodeType.Scrollbar,
                LayoutNodeType.Tab
            };

        public List<OrientationType> OrientationTypes { get; set; } = new List<OrientationType>
            {
                Designer.Models.OrientationType.Horizontal,
                Designer.Models.OrientationType.Vertical,
            };

        public List<TreeModel> Children { get; set; } = new List<TreeModel>();

        #endregion プロパティ

        #region コマンド

        public ReactiveCommand<string> AddCommand { get; } = new ReactiveCommand<string>();

        public ReactiveCommand<string> RemoveCommand { get; } = new ReactiveCommand<string>();

        #endregion コマンド

        #region コンストラクター

        public TreeModel(LayoutTree item, ContentTable table, IDesignerRepositoryCollection repository) : base(table)
        {
            this.repository = repository;
            Codes = repository.ContentTables.Gets().Select(x => x.Code).Distinct().ToList();
            //プロパティ
            IsExpand.Value = item.IsExpand;
            LayoutType.Value = item.LayoutNodeType;
            OrientationType.Value = item.OrientationType;
            LayoutStyle.Value = item.LayoutStyle;
            LayoutParameter.Value = item.LayoutParameter;
            //コマンド
            Code.Subscribe(OnChangeCodeCommand).AddTo(disposables);
            AddCommand.Subscribe(OnAddCommand).AddTo(disposables);
            RemoveCommand.Subscribe(OnRemoveCommand).AddTo(disposables);
            //子階層へ
            foreach (var child in item.Children)
            {
                Children.Add(new TreeModel(child, repository.ContentTables.Get(child.Code), repository));
            }
        }

        #endregion コンストラクター

        #region イベント

        private void OnChangeCodeCommand(string code)
        {
            var item = this.repository.ContentTables.Get(code);
            if (item == null) return;
            Update(item);
        }

        private void OnAddCommand(string parameter)
        {

        }

        private void OnRemoveCommand(string parameter)
        {

        }

        #endregion イベント

    }

    public class TreeModelAttribute : TableModelAttribute
    {
        public ColumnAttribute Edit { get; } = new ColumnAttribute("edit", 0);
        public ColumnAttribute LayoutType { get; } = new ColumnAttribute("layoutType", 100);
        public ColumnAttribute OrientationType { get; } = new ColumnAttribute("orientation", 100);
        public ColumnAttribute LayoutStyle { get; } = new ColumnAttribute("layoutStyle", 100);
        public ColumnAttribute LayoutParameter { get; } = new ColumnAttribute("layoutParameter", 100);
        public ColumnAttribute IsExpand { get; } = new ColumnAttribute("isExpand", 40);
    }

    #endregion クラス
}
