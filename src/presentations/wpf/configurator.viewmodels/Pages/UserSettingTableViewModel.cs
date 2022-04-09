using Mov.Configurator.Models;
using Mov.WpfViewModels;
using Mov.WpfViewModels.Components.Tables;
using Reactive.Bindings;

namespace Mov.Configurator.ViewModels
{
    public class UserSettingTableViewModel : ViewModelBase, ITableViewModel
    {
        #region フィールド

        private readonly IConfiguratorRepositoryCollection repository;

        #endregion フィールド

        #region プロパティ

        public ReactiveCollection<ITableViewModelContent> TableModels { get; } = new ReactiveCollection<ITableViewModelContent>();
        public ITableViewModelColumnAttribute TableAttribute { get; } = new TableModelAttribute();

        #endregion プロパティ

        /// <summary>コンストラクター</summary>
        public UserSettingTableViewModel(IConfiguratorRepositoryCollection repository)
        {
            this.repository = repository;
            foreach (var item in this.repository.UserSettings.Gets())
            {
                TableModels.Add(new TableModel(item));
            }
        }

        #region クラス
        
        public class TableModel : ITableViewModelContent
        {
            #region フィールド

            private UserSetting userSetting;

            #endregion フィールド

            #region プロパティ

            public ReactivePropertySlim<int> Id => new ReactivePropertySlim<int>(userSetting.Id);
            public ReactivePropertySlim<string> Category => new ReactivePropertySlim<string>(userSetting.Category);
            public ReactivePropertySlim<string> Code => new ReactivePropertySlim<string>(userSetting.Code);
            public ReactivePropertySlim<string> Name => new ReactivePropertySlim<string>(userSetting.Name);
            public ReactivePropertySlim<string> Value => new ReactivePropertySlim<string>(userSetting.Value);
            public ReactivePropertySlim<string> Description => new ReactivePropertySlim<string>(userSetting.Description);
            public ReactivePropertySlim<string> Default => new ReactivePropertySlim<string>(userSetting.Default);
            public ReactivePropertySlim<int> AccessLv => new ReactivePropertySlim<int>(userSetting.AccessLv);

            #endregion プロパティ

            public TableModel(UserSetting userSetting)
            {
                this.userSetting = userSetting;
            }
        }

        public class TableModelAttribute : ITableViewModelColumnAttribute
        {
            public TableColumnAttribute Id { get; } = new TableColumnAttribute() { Header = "id" };
            public TableColumnAttribute Category { get; } = new TableColumnAttribute() { Header = "category" };
            public TableColumnAttribute Code { get; } = new TableColumnAttribute() { Header = "code" };
            public TableColumnAttribute Name { get; } = new TableColumnAttribute() { Header = "name" };
            public TableColumnAttribute Description { get; } = new TableColumnAttribute() { Header = "description" };
            public TableColumnAttribute Default { get; } = new TableColumnAttribute() { Header = "default" };
            public TableColumnAttribute AccessLv { get; } = new TableColumnAttribute() { Header = "accessLv" };
        }

        #endregion クラス
    }
}