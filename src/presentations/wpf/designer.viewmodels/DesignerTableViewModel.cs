using Mov.Designer.Models;
using Mov.Designer.Models.interfaces;
using Mov.WpfViewModels;
using Mov.WpfViewModels.Components.Tables;
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

        #region クラス

        public class TableModel
        {
            public ReactivePropertySlim<int> Id { get; } = new ReactivePropertySlim<int>();
            public ReactivePropertySlim<string> Code { get; } = new ReactivePropertySlim<string>();
            public ReactivePropertySlim<string> Name { get; } = new ReactivePropertySlim<string>();
            public ReactivePropertySlim<string> Command { get; } = new ReactivePropertySlim<string>();
            public ReactivePropertySlim<string> ControlType { get; } = new ReactivePropertySlim<string>();
            public ReactivePropertySlim<string> ControlStyle { get; } = new ReactivePropertySlim<string>();
            public ReactivePropertySlim<string> Parameter { get; } = new ReactivePropertySlim<string>();
            public TableModel(ContentTable item)
            {
                Id.Value = item.Index;
                Code.Value = item.Code;
                Name.Value = item.Name;
                Command.Value = item.Command;
                ControlType.Value = item.ControlType;
                ControlStyle.Value = item.ControlStyle;
                Parameter.Value = item.Parameter;
            }
        }

        public class TableModelAttribute
        {
            public ColumnAttribute Id { get; } = new ColumnAttribute() { Header = "id", Width = 30 };
            public ColumnAttribute Code { get; } = new ColumnAttribute() { Header = "code", Width = 100 };
            public ColumnAttribute Name { get; } = new ColumnAttribute() { Header = "name", Width = 100 };
            public ColumnAttribute Command { get; } = new ColumnAttribute() { Header = "command", Width = 150 };
            public ColumnAttribute ControlType { get; } = new ColumnAttribute() { Header = "controlType", Width = 150 };
            public ColumnAttribute ControlStyle { get; } = new ColumnAttribute() { Header = "controlStyle", Width = 150 };
            public ColumnAttribute Parameter { get; } = new ColumnAttribute() { Header = "parameter", Width = 150 };

        }

        #endregion クラス

    }
}
