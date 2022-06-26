using Mov.Designer.Models;
using Mov.Designer.Models.interfaces;
using Mov.Designer.Service.Layouts;
using Mov.WpfViewModels;
using Reactive.Bindings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mov.Designer.ViewModels
{
    public class DesignerTableViewModel : ViewModelBase
    {
        #region フィールド

        private readonly IDesignerRepositoryCollection repository;

        #endregion フィールド

        #region プロパティ

        public ReactiveCollection<TableModel> Models { get; } = new ReactiveCollection<TableModel>();
        public TableModelAttribute Attribute { get; } = new TableModelAttribute();

        #endregion プロパティ

        #region コンストラクター

        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="repository"></param>
        public DesignerTableViewModel(IDesignerRepositoryCollection repository)
        {
            this.repository = repository;
            foreach(var table in repository.ContentTables.Gets())
            {
                Models.Add(new TableModel(table));
            }
        }

        #endregion コンストラクター

        #region イベントハンドラ

        protected override void OnLoaded()
        {

        }

        #endregion イベントハンドラ

    }
    #region クラス

    public class TableModel
    {
        #region プロパティ

        public ReactivePropertySlim<Guid> Id { get; } = new ReactivePropertySlim<Guid>();
        public ReactivePropertySlim<int> Index { get; } = new ReactivePropertySlim<int>();
        public ReactivePropertySlim<string> Code { get; } = new ReactivePropertySlim<string>();
        public ReactivePropertySlim<string> Name { get; } = new ReactivePropertySlim<string>();
        public ReactivePropertySlim<string> Command { get; } = new ReactivePropertySlim<string>();
        public ReactivePropertySlim<string> ControlType { get; } = new ReactivePropertySlim<string>();
        public ReactivePropertySlim<string> ControlStyle { get; } = new ReactivePropertySlim<string>();
        public ReactivePropertySlim<string> Parameter { get; } = new ReactivePropertySlim<string>();

        #endregion プロパティ

        #region コンストラクター

        public TableModel(ContentTable item)
        {
            Update(item);
        }

        #endregion コンストラクター

        #region 継承メソッド

        protected void Update(ContentTable item)
        {
            if (item == null) return;
            Id.Value = item.Id;
            Index.Value = item.Index;
            Code.Value = item.Code;
            Name.Value = item.Name;
            Command.Value = item.Command;
            ControlType.Value = item.ControlType;
            ControlStyle.Value = item.ControlStyle;
            Parameter.Value = item.Parameter;
        }

        #endregion 継承メソッド

    }

    public class TableModelAttribute
    {
        public ColumnAttribute Index { get; } = new ColumnAttribute("index", 30);
        public ColumnAttribute Code { get; } = new ColumnAttribute("code", 100);
        public ColumnAttribute Name { get; } = new ColumnAttribute("name", 100);
        public ColumnAttribute Command { get; } = new ColumnAttribute("command", 100);
        public ColumnAttribute ControlType { get; } = new ColumnAttribute("controlType", 100);
        public ColumnAttribute ControlStyle { get; } = new ColumnAttribute("controlStyle", 100);
        public ColumnAttribute Parameter { get; } = new ColumnAttribute("parameter", 100);

    }

    #endregion クラス
}
