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

        private ICollection<ReactiveCommand<Guid>> addCommands = new List<ReactiveCommand<Guid>>();

        private ICollection<ReactiveCommand<Guid>> removeCommands = new List<ReactiveCommand<Guid>>();

        private CompositeDisposable modelDisposables = new CompositeDisposable();

        #endregion フィールド

        #region プロパティ

        public ReactiveCollection<DesignerTableModel> Models { get; } = new ReactiveCollection<DesignerTableModel>();
        public DesignerTableModelAttribute Attribute { get; } = new DesignerTableModelAttribute();
        public ReactivePropertySlim<bool> IsEdit { get; } = new ReactivePropertySlim<bool>(false);
        public ReactivePropertySlim<DesignerTableModel> SelectedModel { get; } = new ReactivePropertySlim<DesignerTableModel>();

        #endregion プロパティ

        #region コマンド

        public ReactiveCommand EditCommand { get; } = new ReactiveCommand();
        public ReactiveCommand SaveCommand { get; } = new ReactiveCommand();
        public ReactiveCommand AddCommand { get; } = new ReactiveCommand();
        public ReactiveCommand DeleteCommand { get; } = new ReactiveCommand();
        public ReactiveCommand UpCommand { get; } = new ReactiveCommand();
        public ReactiveCommand DownCommand { get; } = new ReactiveCommand();


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
            EditCommand.Subscribe(OnEditCommand).AddTo(Disposables);
            UpCommand.Subscribe(OnUpCommand).AddTo(Disposables);
            DownCommand.Subscribe(OnDownCommand).AddTo(Disposables);
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
        private void OnEditCommand()
        {
            IsEdit.Value = !IsEdit.Value;
            if (IsEdit.Value) Attribute.Edit.Width.Value = 45;
            else Attribute.Edit.Width.Value = 0;
            UpdateEditMode(Models);
        }

        private void OnSaveCommand()
        {
            Post();
            repository.Contents.Export();
            MessageBox.Show("保存しました");
        }

        private void Post()
        {
            var tables = new List<Content>();
            GetContentTables(tables, Models);
            repository.Contents.Posts(tables);
        }

        private void OnUpCommand()
        {
            var selectedModel = SelectedModel.Value;
            if (selectedModel == null) return;
            repository.Contents.MovePrev(selectedModel.Id.Value);
            CreateModels();
            UpdateEditMode(Models);
        }

        private void OnDownCommand()
        {
            var selectedModel = SelectedModel.Value;
            if (selectedModel == null) return;
            repository.Contents.MoveNext(selectedModel.Id.Value);
            CreateModels();
            UpdateEditMode(Models);
        }

        private void OnAddCommand(Guid id)
        {
            var table = this.repository.Contents.Get(id);
            if (table == null) return;
            this.repository.Contents.Put(new Content(), table.Id);
            CreateModels();
            UpdateEditMode(Models);
        }

        private void OnRemoveCommand(Guid id)
        {
            var table = this.repository.Contents.Get(id);
            if (table == null) return;
            this.repository.Contents.Delete(table);
            CreateModels();
            UpdateEditMode(Models);
        }

        #endregion イベントハンドラ

        #region メソッド
        private void CreateModels()
        {
            Models.Clear();
            modelDisposables.Clear();
            foreach (var table in repository.Contents.Gets())
            {
                Models.Add(new DesignerTableModel(table, addCommands, removeCommands));
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

        private void GetContentTables(ICollection<Content> items, IEnumerable<DesignerTableModel> models)
        {
            foreach (var model in models)
            {
                var item = new Content
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

        private void UpdateEditMode(IEnumerable<DesignerTableModel> models)
        {
            foreach (var model in models)
            {
                model.IsEdit.Value = IsEdit.Value;
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
        public ReactivePropertySlim<string> ControlType { get; } = new ReactivePropertySlim<string>();
        public ReactivePropertySlim<string> ControlStyle { get; } = new ReactivePropertySlim<string>();
        public ReactivePropertySlim<string> Parameter { get; } = new ReactivePropertySlim<string>();

        public ReactivePropertySlim<string> ToolTip { get; } = new ReactivePropertySlim<string>();
        public ReactivePropertySlim<bool> IsEdit { get; } = new ReactivePropertySlim<bool>(false);

        #endregion プロパティ

        #region コマンド

        public ReactiveCommand<Guid> AddCommand { get; } = new ReactiveCommand<Guid>();

        public ReactiveCommand<Guid> RemoveCommand { get; } = new ReactiveCommand<Guid>();

        #endregion コマンド

        #region コンストラクター

        public DesignerTableModel(Content item, ICollection<ReactiveCommand<Guid>> addCommands, ICollection<ReactiveCommand<Guid>> removeCommands)
        {
            Update(item);
            //コマンド
            addCommands.Add(AddCommand);
            removeCommands.Add(RemoveCommand);
        }

        #endregion コンストラクター

        #region 継承メソッド

        protected virtual void Update(Content item)
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
        public ColumnAttribute Code { get; } = new ColumnAttribute("code", 100);
        public ColumnAttribute Name { get; } = new ColumnAttribute("name", 100);
        public ColumnAttribute Command { get; } = new ColumnAttribute("command", 100);
        public ColumnAttribute ControlType { get; } = new ColumnAttribute("controlType", 100);
        public ColumnAttribute ControlStyle { get; } = new ColumnAttribute("controlStyle", 100);
        public ColumnAttribute Parameter { get; } = new ColumnAttribute("parameter", 100);
        public ColumnAttribute Edit { get; } = new ColumnAttribute("edit", 0);
    }

    #endregion クラス
}
