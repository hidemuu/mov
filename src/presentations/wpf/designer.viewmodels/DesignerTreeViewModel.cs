using Mov.Designer.Models;
using Mov.Designer.Service;
using Mov.WpfControls;
using Mov.WpfControls.ViewModels;
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

        private readonly IDesignerDatabase database;

        private IDesignerRepository repository;

        private ICollection<ReactiveCommand<Guid>> addCommands = new List<ReactiveCommand<Guid>>();

        private ICollection<ReactiveCommand<Guid>> removeCommands = new List<ReactiveCommand<Guid>>();

        private CompositeDisposable modelDisposables = new CompositeDisposable();

        #endregion フィールド

        #region プロパティ

        public ReactiveCollection<DesignerTreeModel> Models { get; } = new ReactiveCollection<DesignerTreeModel>();
        public DesignerTreeModelAttribute Attribute { get; } = new DesignerTreeModelAttribute();
        public ReactivePropertySlim<bool> IsEdit { get; } = new ReactivePropertySlim<bool>(false);

        #endregion プロパティ

        #region コマンド

        public ReactiveCommand UnLoadedCommand { get; } = new ReactiveCommand();
        public ReactiveCommand<string> EditCommand { get; } = new ReactiveCommand<string>();
        public ReactiveCommand<string> SaveCommand { get; } = new ReactiveCommand<string>();

        #endregion コマンド

        #region コンストラクター

        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="repository"></param>
        public DesignerTreeViewModel(IDesignerDatabase database)
        {
            this.database = database;
            this.repository = database.GetRepository("");
            SaveCommand.Subscribe(OnSaveCommand).AddTo(Disposables);
            EditCommand.Subscribe(OnEditCommand).AddTo(Disposables);
            UnLoadedCommand.Subscribe(() => OnUnLoaded()).AddTo(Disposables);
            modelDisposables.AddTo(Disposables);
            CreateModels();
        }

        #endregion コンストラクター

        #region イベント

        protected override void OnLoaded()
        {

        }

        protected void OnUnLoaded()
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
            var trees = new List<LayoutNode>();
            GetLayoutTrees(trees, Models);
            repository.LayoutNodes.Posts(trees);
            repository.LayoutNodes.Export();
            var tables = new List<Content>();
            GetContentTables(tables, Models);
            repository.Contents.Posts(tables);
            repository.Contents.Export();
            MessageBox.Show("保存しました");
        }

        private void OnAddCommand(Guid id)
        {
            var tree = this.repository.LayoutNodes.Get(id);
            if (tree == null) return;
            this.repository.LayoutNodes.Put(new LayoutNode(), tree.Id);
            CreateModels();
            UpdateEditMode(Models);
        }

        private void OnRemoveCommand(Guid id)
        {
            var tree = this.repository.LayoutNodes.Get(id);
            if (tree == null) return;
            this.repository.LayoutNodes.Delete(tree);
            CreateModels();
            UpdateEditMode(Models);
        }

        #endregion イベント

        #region メソッド
        private void CreateModels()
        {
            Models.Clear();
            modelDisposables.Clear();
            foreach (var tree in repository.LayoutNodes.Gets())
            {
                Models.Add(new DesignerTreeModel(tree, repository.Contents.Get(tree.Code), repository, addCommands, removeCommands));
            }
            foreach (var addCommand in addCommands)
            {
                addCommand.Subscribe(OnAddCommand).AddTo(modelDisposables);
            }
            foreach (var removeCommand in removeCommands)
            {
                removeCommand.Subscribe(OnRemoveCommand).AddTo(modelDisposables);
            }
        }

        private void GetLayoutTrees(ICollection<LayoutNode> items, IEnumerable<DesignerTreeModel> models)
        {
            foreach (var model in models)
            {
                var item = new LayoutNode
                {
                    Id = model.Id.Value,
                    Index = model.Index.Value,
                    Code = model.Code.Value,
                    IsExpand = model.IsExpand.Value,
                    LayoutNodeType = model.LayoutType.Value,
                    Style = model.LayoutStyle.Value,
                    Parameter = model.LayoutParameter.Value,
                };
                items.Add(item);
                GetLayoutTrees(item.Children, model.Children);
            }
        }

        private void GetContentTables(ICollection<Content> items, IEnumerable<DesignerTreeModel> models)
        {
            foreach (var model in models)
            {
                var item = new Content
                {
                    Id = model.Id.Value,
                    Index = model.Index.Value,
                    Code = model.Code.Value,
                    ControlType = model.ControlType.Value,
                };
                items.Add(item);
                GetContentTables(items, model.Children);
            }
        }

        private void UpdateEditMode(IEnumerable<DesignerTreeModel> treeModels)
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

    public class DesignerTreeModel : DesignerTableModel
    {
        #region フィールド

        private CompositeDisposable disposables = new CompositeDisposable();

        private IDesignerRepository repository;

        #endregion フィールド

        #region プロパティ

        public ReactivePropertySlim<LayoutNodeType> LayoutType { get; } = new ReactivePropertySlim<LayoutNodeType>(LayoutNodeType.Content);
        public ReactivePropertySlim<OrientationType> OrientationType { get; } = new ReactivePropertySlim<OrientationType>(Designer.Models.OrientationType.Horizontal);
        public ReactivePropertySlim<string> LayoutStyle { get; } = new ReactivePropertySlim<string>();
        public ReactivePropertySlim<string> LayoutParameter { get; } = new ReactivePropertySlim<string>();
        public ReactivePropertySlim<bool> IsExpand { get; } = new ReactivePropertySlim<bool>(true);

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

        public List<DesignerTreeModel> Children { get; set; } = new List<DesignerTreeModel>();

        #endregion プロパティ

        #region コンストラクター

        public DesignerTreeModel(LayoutNode tree, Content table, IDesignerRepository repository, ICollection<ReactiveCommand<Guid>> addCommands, ICollection<ReactiveCommand<Guid>> removeCommands) : base(table, addCommands, removeCommands)
        {
            this.repository = repository;
            Codes = repository.Contents.Gets().Select(x => x.Code).Distinct().ToList();
            //プロパティ
            Id.Value = tree.Id;
            Index.Value = tree.Index;
            Code.Value = tree.Code;
            IsExpand.Value = tree.IsExpand;
            LayoutType.Value = tree.LayoutNodeType;
            OrientationType.Value = tree.OrientationType;
            LayoutStyle.Value = tree.Style;
            LayoutParameter.Value = tree.Parameter;
            //子階層へ
            foreach (var child in tree.Children)
            {
                Children.Add(new DesignerTreeModel(child, repository.Contents.Get(child.Code), repository, addCommands, removeCommands));
            }
            Code.Subscribe(OnChangeCodeCommand).AddTo(disposables);
        }

        #endregion コンストラクター

        #region イベント

        private void OnChangeCodeCommand(string code)
        {
            var item = this.repository.Contents.Get(code);
            if (item == null) return;
            Update(item);
        }

        protected override void Update(Content item)
        {
            if (item == null) return;
            var table = new Content(item);
            table.Id = Id.Value;
            table.Index = Index.Value;
            base.Update(table);
        }

        #endregion イベント

    }

    public class DesignerTreeModelAttribute : DesignerTableModelAttribute
    {
        public ColumnAttribute LayoutType { get; } = new ColumnAttribute("layoutType", 100);
        public ColumnAttribute OrientationType { get; } = new ColumnAttribute("orientation", 100);
        public ColumnAttribute LayoutStyle { get; } = new ColumnAttribute("layoutStyle", 100);
        public ColumnAttribute LayoutParameter { get; } = new ColumnAttribute("layoutParameter", 100);
        public ColumnAttribute IsExpand { get; } = new ColumnAttribute("isExpand", 40);
    }

    #endregion クラス
}
