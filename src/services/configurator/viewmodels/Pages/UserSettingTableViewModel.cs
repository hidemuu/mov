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
    public class UserSettingTableViewModel : ViewModelBase, ITableViewModel
    {
        public ReactiveCollection<ITableViewModelContent> TableModels { get; } = new ReactiveCollection<ITableViewModelContent>();
        public ITableViewModelColumnAttribute TableAttribute { get; } = new TableModelAttribute();

        private readonly IConfiguratorRepository repository;

        public UserSettingTableViewModel(IConfiguratorRepository repository)
        {
            this.repository = repository;
            foreach(var item in this.repository.UserSettings.Gets())
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
            public TableModel(UserSetting userSetting)
            {
                Id.Value = userSetting.Id;
                Category.Value = userSetting.Category;
                Code.Value = userSetting.Code;
                Name.Value = userSetting.Name;
                Value.Value = userSetting.Value;
                Description.Value = userSetting.Description;
                Default.Value = userSetting.Default;
                AccessLv.Value = userSetting.AccessLv;
            }
        }

        public class TableModelAttribute : ITableViewModelColumnAttribute
        {
            public TableColumnAttribute Id { get; } = new TableColumnAttribute("", true);
            public TableColumnAttribute Category { get; } = new TableColumnAttribute("category", true);
            public TableColumnAttribute Code { get; } = new TableColumnAttribute("code", true);
            public TableColumnAttribute Name { get; } = new TableColumnAttribute("name", true);
            public TableColumnAttribute Description { get; } = new TableColumnAttribute("description", true);
            public TableColumnAttribute Default { get; } = new TableColumnAttribute("default", true);
            public TableColumnAttribute AccessLv { get; } = new TableColumnAttribute("accessLv", true);
        }
    }
}
