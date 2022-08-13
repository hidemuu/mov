using Mov.Designer.Models;
using Mov.Designer.Service;
using Mov.WpfControls;
using Mov.WpfControls.ViewModels;
using Prism.Regions;
using Prism.Services.Dialogs;
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
    public class DesignerTreeViewModel : RegionViewModelBase
    {
        #region フィールド

        private readonly IDesignerDatabase database;

        private IDesignerRepository repository;

        private CompositeDisposable modelDisposables = new CompositeDisposable();

        #endregion フィールド

        #region プロパティ

        public ReactiveCollection<DesignerTreeModel> Models { get; } = new ReactiveCollection<DesignerTreeModel>();
        public DesignerTreeModelAttribute Attribute { get; } = new DesignerTreeModelAttribute();

        #endregion プロパティ

        #region コマンド

        public ReactiveCommand UnLoadedCommand { get; } = new ReactiveCommand();
        public ReactiveCommand<string> SaveCommand { get; } = new ReactiveCommand<string>();

        public ReactiveCommand<object> AddCommand { get; } = new ReactiveCommand<object>();

        public ReactiveCommand<object> DeleteCommand { get; } = new ReactiveCommand<object>();


        #endregion コマンド

        #region コンストラクター

        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="repository"></param>
        public DesignerTreeViewModel(IRegionManager regionManager, IDialogService dialogService, IDesignerDatabase database) : base(regionManager, dialogService)
        {
            this.database = database;
            SaveCommand.Subscribe(OnSaveCommand).AddTo(Disposables);
            UnLoadedCommand.Subscribe(() => OnUnLoaded()).AddTo(Disposables);
            AddCommand.Subscribe(OnAddCommand).AddTo(Disposables);
            DeleteCommand.Subscribe(OnRemoveCommand).AddTo(Disposables);
            modelDisposables.AddTo(Disposables);
        }

        #endregion コンストラクター

        #region イベント

        protected override void OnLoaded()
        {

        }

        protected void OnUnLoaded()
        {

        }

        public override void OnNavigatedFrom(NavigationContext navigationContext)
        {
            base.OnNavigatedFrom(navigationContext);
            Post();
        }

        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            base.OnNavigatedTo(navigationContext);
            this.repository = navigationContext.Parameters[DesignerViewModel.PARAM_NAME_DESIGN_REPOSITORY] as IDesignerRepository;
            CreateModels();
        }

        private void OnSaveCommand(string parameter)
        {
            Post();
            repository.LayoutNodes.Export();
            repository.Contents.Export();
            MessageBox.Show("保存しました");
        }

        private void Post()
        {
            var trees = new List<LayoutNode>();
            GetLayoutTrees(trees, Models);
            repository.LayoutNodes.Posts(trees);
            //var tables = new List<LayoutContent>();
            //GetContentTables(tables, Models);
            //repository.Contents.Posts(tables);
        }

        private void OnAddCommand(object parameter)
        {
            if(parameter is DesignerTreeModel model)
            {
                var tree = this.repository.LayoutNodes.Get(model.Id.Value);
                if (tree == null) return;
                this.repository.LayoutNodes.Put(new LayoutNode(), tree.Id);
                CreateModels();
            }
        }

        private void OnRemoveCommand(object parameter)
        {
            if (parameter is DesignerTreeModel model)
            {
                var tree = this.repository.LayoutNodes.Get(model.Id.Value);
                if (tree == null) return;
                this.repository.LayoutNodes.Delete(tree);
                CreateModels();
            }
        }

        #endregion イベント

        #region メソッド
        private void CreateModels()
        {
            Models.Clear();
            modelDisposables.Clear();
            foreach (var tree in repository.LayoutNodes.Gets())
            {
                Models.Add(new DesignerTreeModel(tree, repository.Contents.Get(tree.Code), repository));
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

        private void GetContentTables(ICollection<LayoutContent> items, IEnumerable<DesignerTreeModel> models)
        {
            foreach (var model in models)
            {
                var item = new LayoutContent
                {
                    Id = model.Id.Value,
                    Index = model.Index.Value,
                    Code = model.Code.Value,
                    ControlType = model.ControlType.Value,
                    Name = model.Name.Value,
                };
                items.Add(item);
                GetContentTables(items, model.Children);
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

        public DesignerTreeModel(LayoutNode node, LayoutContent table, IDesignerRepository repository) : base(table)
        {
            this.repository = repository;
            Codes = repository.Contents.Gets().Select(x => x.Code).Distinct().ToList();
            //プロパティ
            Id.Value = node.Id;
            Index.Value = node.Index;
            Code.Value = node.Code;
            IsExpand.Value = node.IsExpand;
            LayoutType.Value = node.LayoutNodeType;
            OrientationType.Value = node.OrientationType;
            LayoutStyle.Value = node.Style;
            LayoutParameter.Value = node.Parameter;
            //子階層へ
            foreach (var child in node.Children)
            {
                Children.Add(new DesignerTreeModel(child, repository.Contents.Get(child.Code), repository));
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

        protected override void Update(LayoutContent item)
        {
            if (item == null) return;
            var table = new LayoutContent(item);
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
