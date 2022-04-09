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
    public class AppSettingTableViewModel : ViewModelBase, ITableViewModel
    {
        public ReactiveCollection<ITableViewModelContent> TableModels { get; } = new ReactiveCollection<ITableViewModelContent>();
        public ITableViewModelColumnAttribute TableAttribute { get; } = new TableModelAttribute();

        private readonly IConfiguratorRepositoryCollection repository;

        public AppSettingTableViewModel(IConfiguratorRepositoryCollection repository)
        {
            this.repository = repository;
            foreach (var item in this.repository.AppSettings.Gets())
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
            public ReactivePropertySlim<string> Default { get; } = new ReactivePropertySlim<string>();
            public ReactivePropertySlim<int> AccessLv { get; } = new ReactivePropertySlim<int>();
            public TableModel(AppSetting appSetting)
            {
                Id.Value = appSetting.Id;
                Category.Value = appSetting.Category;
                Code.Value = appSetting.Code;
                Name.Value = appSetting.Name;
                Value.Value = appSetting.Value;
                Description.Value = appSetting.Description;
            }
        }

        public class TableModelAttribute : ITableViewModelColumnAttribute
        {
            public TableColumnAttribute Id { get; } = new TableColumnAttribute() { Header = "id" };
            public TableColumnAttribute Category { get; } = new TableColumnAttribute() { Header = "category" };
            public TableColumnAttribute Code { get; } = new TableColumnAttribute() { Header = "code" };
            public TableColumnAttribute Name { get; } = new TableColumnAttribute() { Header = "name" };
            public TableColumnAttribute Description { get; } = new TableColumnAttribute() { Header = "description" };
        }
    }
}
