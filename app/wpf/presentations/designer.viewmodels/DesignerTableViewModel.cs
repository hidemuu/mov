using Mov.Accessors.Repository;
using Mov.Designer.Models;
using Mov.Designer.Models.Entities;
using Mov.Designer.Service;
using Mov.Layouts;
using Mov.Schemas.Styles;
using Mov.WpfModels;
using Mov.WpfMvvms;
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
    public class DesignerTableViewModel : DragDropViewModelBase
    {
        #region フィールド

        private IDesignerFacade facade;

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
        public DesignerTableViewModel(IRegionManager regionManager, IDialogService dialogService) : base(regionManager, dialogService)
        {
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
            this.facade = navigationContext.Parameters[DesignerViewModel.NAVIGATION_PARAM_NAME_SERVICE] as IDesignerFacade;
            CreateModels();
        }

        private void OnSaveCommand()
        {
            Post();
            this.facade.Write();
            MessageBox.Show("保存しました");
        }

        private void Post()
        {
            var tables = new List<Content>();
            ConvertModelToContent(tables, Models);
            foreach(var table in tables)
            {
                this.facade.Command.Contents.Saver.Save(table);
            }
        }

        private void OnAddCommand(object parameter)
        {
            if(parameter is DesignerTableModel model)
            {
                var table = this.facade.Query.Contents.Reader.Read(model.Id.Value);
                if (table == null) return;
                //this.repository.Contents.Put(new LayoutContent(), table.Id);
                CreateModels();
            }
        }

        private void OnRemoveCommand(object parameter)
        {
            if (parameter is DesignerTableModel model)
            {
                var table = this.facade.Query.Contents.Reader.Read(model.Id.Value);
                if (table == null) return;
                this.facade.Command.Contents.Deleter.Delete(table);
                CreateModels();
            }
        }

        
        #endregion イベントハンドラ

        #region メソッド
        private void CreateModels()
        {
            Models.Clear();
            modelDisposables.Clear();
            foreach (var table in this.facade.Query.Contents.Reader.ReadAll())
            {
                Models.Add(new DesignerTableModel(table));
            }
        }

        private void ConvertModelToContent(ICollection<Content> items, IEnumerable<DesignerTableModel> models)
        {
            foreach (var model in models)
            {
                var item = new Content
                {
                    Id = model.Id.Value,
                    Index = model.Index.Value,
                    Code = model.Code.Value,
                    ControlType = model.ControlType.Value.Value,
                    Name = model.Name.Value,
                    Height = model.Height.Value,
                    Width = model.Width.Value,
                    HorizontalAlignment = model.HorizontalAlignment.Value,
                    VerticalAlignment = model.VerticalAlignment.Value,
                    Parameter = model.Parameter.Value,
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
        public ReactivePropertySlim<ControlStyle> ControlType { get; } = new ReactivePropertySlim<ControlStyle>();
        
        public ReactivePropertySlim<double> Width { get; } = new ReactivePropertySlim<double>(150);
        public ReactivePropertySlim<double> Height { get; } = new ReactivePropertySlim<double>(32);

        public ReactivePropertySlim<string> HorizontalAlignment { get; } = new ReactivePropertySlim<string>("Left");
        public ReactivePropertySlim<string> VerticalAlignment { get; } = new ReactivePropertySlim<string>("Center");
        public ReactivePropertySlim<string> Parameter { get; } = new ReactivePropertySlim<string>();

        public ReactivePropertySlim<string> ToolTip { get; } = new ReactivePropertySlim<string>();

        public List<string> ControlTypes { get; set; } = ControlStyle.GetStrings().ToList();

        public List<string> HolizontalAlignments { get; set; } = HorizontalAlignmentStyle.GetStrings().ToList();

        public List<string> VerticalAlignments { get; set; } = VerticalAlignmentStyle.GetStrings().ToList();

        #endregion プロパティ

        #region コマンド

        #endregion コマンド

        #region コンストラクター

        public DesignerTableModel(Content item)
        {
            Update(item);
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
            ControlType.Value = new ControlStyle(item.ControlType);
            Height.Value = item.Height;
            Width.Value = item.Width;
            HorizontalAlignment.Value = item.HorizontalAlignment;
            VerticalAlignment.Value = item.VerticalAlignment;
            Parameter.Value = item.Parameter;
        }

        #endregion 継承メソッド

    }

    public class DesignerTableModelAttribute
    {
        public ColumnAttribute Index { get; } = new ColumnAttribute("index", 30);
        public ColumnAttribute Code { get; } = new ColumnAttribute("コード", 120);
        public ColumnAttribute Name { get; } = new ColumnAttribute("名称", 120);
        public ColumnAttribute ControlType { get; } = new ColumnAttribute("タイプ", 120);
        public ColumnAttribute Height { get; } = new ColumnAttribute("高さ", 90);
        public ColumnAttribute Width { get; } = new ColumnAttribute("幅", 90);
        public ColumnAttribute HorizontalAlignment { get; } = new ColumnAttribute("水平", 120);
        public ColumnAttribute VerticalAlignment { get; } = new ColumnAttribute("垂直", 120);
        public ColumnAttribute Parameter { get; } = new ColumnAttribute("パラメータ", 120);
    }

    #endregion クラス
}
