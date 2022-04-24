using Mov.Configurator.Models;
using Mov.WpfViewModels;
using Mov.WpfViewModels.Components.Tables;
using Reactive.Bindings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mov.Configurator.ViewModels
{
    public class VariableTableViewModel : ViewModelBase, ITableViewModel
    {
        public ReactiveCollection<ITableViewModelContent> TableModels { get; } = new ReactiveCollection<ITableViewModelContent>();
        public ITableViewModelColumnAttribute TableAttribute { get; } = new TableModelAttribute();

        private readonly IConfiguratorRepositoryCollection repository;

        public VariableTableViewModel(IConfiguratorRepositoryCollection repository)
        {
            this.repository = repository;
            foreach (var item in this.repository.Variables.Gets())
            {
                TableModels.Add(new TableModel(item));
            }
        }

        public class TableModel : ITableViewModelContent
        {
            public ReactivePropertySlim<int> Id { get; } = new ReactivePropertySlim<int>();
            public ReactivePropertySlim<string> Category { get; } = new ReactivePropertySlim<string>();
            public ReactivePropertySlim<string> Code { get; } = new ReactivePropertySlim<string>();
            public ReactivePropertySlim<string> Name { get; } = new ReactivePropertySlim<string>();
            public ReactivePropertySlim<string> Value { get; } = new ReactivePropertySlim<string>();
            public ReactivePropertySlim<string> Description { get; } = new ReactivePropertySlim<string>();
            
            public TableModel(Variable variable)
            {
                Id.Value = variable.Id;
                Category.Value = variable.Category;
                Code.Value = variable.Code;
                Name.Value = variable.Name;
                Value.Value = variable.Value;
                Description.Value = variable.Description;
            }
        }

        public class TableModelAttribute : ITableViewModelColumnAttribute
        {
            public ColumnAttribute Id { get; } = new ColumnAttribute() { Header = "id" };
            public ColumnAttribute Category { get; } = new ColumnAttribute() { Header = "category" };
            public ColumnAttribute Code { get; } = new ColumnAttribute() { Header = "code" };
            public ColumnAttribute Name { get; } = new ColumnAttribute() { Header = "name" };
            public ColumnAttribute Description { get; } = new ColumnAttribute() { Header = "description" };
        }
    }
}
