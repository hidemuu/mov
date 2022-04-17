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

        #endregion

        #region プロパティ

        public ReactiveCollection<TableModel> Models { get; } = new ReactiveCollection<TableModel>();
        public TableModelAttribute Attribute { get; } = new TableModelAttribute();

        #endregion

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

        #region イベント

        protected override void OnLoaded()
        {

        }

        #endregion

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
                Id.Value = item.Id;
                Code.Value = item.Code;
                Name.Value = item.Name;
                Command.Value = item.Commmand;
                ControlType.Value = item.ControlType;
                ControlStyle.Value = item.ControlStyle;
                Parameter.Value = item.Parameter;
            }
        }

        public class TableModelAttribute
        {
            public TableColumnAttribute Id { get; } = new TableColumnAttribute() { Header = "id" };
            public TableColumnAttribute Code { get; } = new TableColumnAttribute() { Header = "code" };
            public TableColumnAttribute Name { get; } = new TableColumnAttribute() { Header = "name" };
            public TableColumnAttribute Command { get; } = new TableColumnAttribute() { Header = "command" };
            public TableColumnAttribute ControlType { get; } = new TableColumnAttribute() { Header = "controlType" };
            public TableColumnAttribute ControlStyle { get; } = new TableColumnAttribute() { Header = "controlStyle" };
            public TableColumnAttribute Parameter { get; } = new TableColumnAttribute() { Header = "parameter" };

        }

        #endregion

    }
}
