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

namespace Mov.Designer.ViewModels
{
    public class DesignerTableViewModel : RegionViewModelBase
    {
        #region フィールド

        private readonly IDesignerDatabase database;

        private IDesignerRepository repository;

        private CompositeDisposable modelDisposables = new CompositeDisposable();

        #endregion フィールド

        #region プロパティ

        public ReactiveCollection<DesignerTableModel> Models { get; } = new ReactiveCollection<DesignerTableModel>();
        public DesignerTableModelAttribute Attribute { get; } = new DesignerTableModelAttribute();
        public ReactivePropertySlim<DesignerTableModel> SelectedModel { get; } = new ReactivePropertySlim<DesignerTableModel>();

        #endregion プロパティ

        #region コマンド

        public ReactiveCommand SaveCommand { get; } = new ReactiveCommand();
        public ReactiveCommand<object> AddCommand { get; } = new ReactiveCommand<object>();
        public ReactiveCommand<object> DeleteCommand { get; } = new ReactiveCommand<object>();

        #endregion コマンド

        #region コンストラクター

        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="repository"></param>
        public DesignerTableViewModel(IRegionManager regionManager, IDialogService dialogService, IDesignerDatabase database) : base(regionManager, dialogService)
        {
            this.database = database;
            SaveCommand.Subscribe(OnSaveCommand).AddTo(Disposables);
            AddCommand.Subscribe(OnAddCommand).AddTo(Disposables);
            DeleteCommand.Subscribe(OnRemoveCommand).AddTo(Disposables);
        }

        #endregion コンストラクター

        #region イベントハンドラ

        protected override void OnLoaded()
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

        private void OnSaveCommand()
        {
            Post();
            repository.Contents.Export();
            MessageBox.Show("保存しました");
        }

        private void Post()
        {
            var tables = new List<LayoutContent>();
            GetContentTables(tables, Models);
            repository.Contents.Posts(tables);
        }

        private void OnAddCommand(object parameter)
        {
            if(parameter is DesignerTableModel model)
            {
                var table = this.repository.Contents.Get(model.Id.Value);
                if (table == null) return;
                this.repository.Contents.Put(new LayoutContent(), table.Id);
                CreateModels();
            }
        }

        private void OnRemoveCommand(object parameter)
        {
            if (parameter is DesignerTableModel model)
            {
                var table = this.repository.Contents.Get(model.Id.Value);
                if (table == null) return;
                this.repository.Contents.Delete(table);
                CreateModels();
            }
        }

        
        #endregion イベントハンドラ

        #region メソッド
        private void CreateModels()
        {
            Models.Clear();
            modelDisposables.Clear();
            foreach (var table in repository.Contents.Gets())
            {
                Models.Add(new DesignerTableModel(table));
            }
        }

        private void GetContentTables(ICollection<LayoutContent> items, IEnumerable<DesignerTableModel> models)
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
            }
        }


        #endregion メソッド

    }

    #region クラス

    public class DesignerTableModel
    {
        #region フィールド

        private CompositeDisposable disposables = new CompositeDisposable();

        #endregion フィールド

        #region プロパティ

        public ReactivePropertySlim<Guid> Id { get; } = new ReactivePropertySlim<Guid>();
        public ReactivePropertySlim<int> Index { get; } = new ReactivePropertySlim<int>();
        public ReactivePropertySlim<string> Code { get; } = new ReactivePropertySlim<string>();
        public ReactivePropertySlim<string> Name { get; } = new ReactivePropertySlim<string>();
        public ReactivePropertySlim<string> Command { get; } = new ReactivePropertySlim<string>();
        public ReactivePropertySlim<ControlType> ControlType { get; } = new ReactivePropertySlim<ControlType>();
        public ReactivePropertySlim<string> ControlStyle { get; } = new ReactivePropertySlim<string>();
        public ReactivePropertySlim<string> Parameter { get; } = new ReactivePropertySlim<string>();

        public ReactivePropertySlim<string> ToolTip { get; } = new ReactivePropertySlim<string>();

        public List<ControlType> ControlTypes { get; set; } = LayoutContent.GetControlTypes.ToList();

        #endregion プロパティ

        #region コマンド

        #endregion コマンド

        #region コンストラクター

        public DesignerTableModel(LayoutContent item)
        {
            Update(item);
        }

        #endregion コンストラクター

        #region 継承メソッド

        protected virtual void Update(LayoutContent item)
        {
            if (item == null) return;
            Id.Value = item.Id;
            Index.Value = item.Index;
            Code.Value = item.Code;
            Name.Value = item.Name;
            ControlType.Value = item.ControlType;
        }

        #endregion 継承メソッド

    }

    public class DesignerTableModelAttribute
    {
        public ColumnAttribute Index { get; } = new ColumnAttribute("index", 30);
        public ColumnAttribute Code { get; } = new ColumnAttribute("コード", 120);
        public ColumnAttribute Name { get; } = new ColumnAttribute("名称", 120);
        public ColumnAttribute Command { get; } = new ColumnAttribute("コマンド", 120);
        public ColumnAttribute ControlType { get; } = new ColumnAttribute("タイプ", 120);
        public ColumnAttribute ControlStyle { get; } = new ColumnAttribute("スタイル", 120);
        public ColumnAttribute Parameter { get; } = new ColumnAttribute("パラメータ", 120);
    }

    #endregion クラス
}
