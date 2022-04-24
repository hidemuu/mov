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
            public ColumnAttribute Id { get; } = new ColumnAttribute() { Header = "id" };
            public ColumnAttribute Category { get; } = new ColumnAttribute() { Header = "category" };
            public ColumnAttribute Code { get; } = new ColumnAttribute() { Header = "code" };
            public ColumnAttribute Name { get; } = new ColumnAttribute() { Header = "name" };
            public ColumnAttribute Description { get; } = new ColumnAttribute() { Header = "description" };
            public ColumnAttribute Default { get; } = new ColumnAttribute() { Header = "default" };
            public ColumnAttribute AccessLv { get; } = new ColumnAttribute() { Header = "accessLv" };
        }

        #endregion クラス
    }
}