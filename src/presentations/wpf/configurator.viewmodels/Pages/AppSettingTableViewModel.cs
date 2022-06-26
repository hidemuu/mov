using Mov.Configurator.Models;
using Mov.Designer.Service.Layouts;
using Mov.WpfViewModels;
using Reactive.Bindings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mov.Configurator.ViewModels
{
    public class AppSettingTableViewModel : ViewModelBase
    {
        public ReactiveCollection<TableModel> TableModels { get; } = new ReactiveCollection<TableModel>();
        public TableModelAttribute TableAttribute { get; } = new TableModelAttribute();

        private readonly IConfiguratorRepositoryCollection repository;

        public AppSettingTableViewModel(IConfiguratorRepositoryCollection repository)
        {
            this.repository = repository;
            foreach (var item in this.repository.AppSettings.Gets())
            {
                TableModels.Add(new TableModel(item));
            }
        }

        public class TableModel
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
                Id.Value = appSetting.Index;
                Category.Value = appSetting.Category;
                Code.Value = appSetting.Code;
                Name.Value = appSetting.Name;
                Value.Value = appSetting.Value;
                Description.Value = appSetting.Description;
            }
        }

        public class TableModelAttribute
        {
            public ColumnAttribute Id { get; } = new ColumnAttribute("id");
            public ColumnAttribute Category { get; } = new ColumnAttribute("category");
            public ColumnAttribute Code { get; } = new ColumnAttribute("code");
            public ColumnAttribute Name { get; } = new ColumnAttribute("name");
            public ColumnAttribute Description { get; } = new ColumnAttribute("description");
        }
    }
}
