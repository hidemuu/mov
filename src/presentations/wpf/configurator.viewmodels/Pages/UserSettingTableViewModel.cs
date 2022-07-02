using Mov.Configurator.Models;
using Mov.Designer.Service.Layouts;
using Mov.WpfControls.ViewModels;
using Reactive.Bindings;

namespace Mov.Configurator.ViewModels
{
    public class UserSettingTableViewModel : ViewModelBase
    {
        #region フィールド

        private readonly IConfiguratorRepositoryCollection repository;

        #endregion フィールド

        #region プロパティ

        public ReactiveCollection<TableModel> TableModels { get; } = new ReactiveCollection<TableModel>();
        public TableModelAttribute TableAttribute { get; } = new TableModelAttribute();

        #endregion プロパティ

        /// <summary>コンストラクター</summary>
        public UserSettingTableViewModel(IConfiguratorRepositoryCollection repository)
        {
            this.repository = repository;
            foreach (var item in this.repository.Configs.Gets())
            {
                TableModels.Add(new TableModel(item));
            }
        }

        #region クラス
        
        public class TableModel
        {
            #region フィールド

            private Config userSetting;

            #endregion フィールド

            #region プロパティ

            public ReactivePropertySlim<int> Id => new ReactivePropertySlim<int>(userSetting.Index);
            public ReactivePropertySlim<string> Category => new ReactivePropertySlim<string>(userSetting.Category);
            public ReactivePropertySlim<string> Code => new ReactivePropertySlim<string>(userSetting.Code);
            public ReactivePropertySlim<string> Name => new ReactivePropertySlim<string>(userSetting.Name);
            public ReactivePropertySlim<string> Value => new ReactivePropertySlim<string>(userSetting.Value);
            public ReactivePropertySlim<string> Description => new ReactivePropertySlim<string>(userSetting.Description);
            public ReactivePropertySlim<string> Default => new ReactivePropertySlim<string>(userSetting.Default);
            public ReactivePropertySlim<int> AccessLv => new ReactivePropertySlim<int>(userSetting.AccessLv);

            #endregion プロパティ

            public TableModel(Config userSetting)
            {
                this.userSetting = userSetting;
            }
        }

        public class TableModelAttribute
        {
            public ColumnAttribute Id { get; } = new ColumnAttribute("id");
            public ColumnAttribute Category { get; } = new ColumnAttribute("category");
            public ColumnAttribute Code { get; } = new ColumnAttribute("code");
            public ColumnAttribute Name { get; } = new ColumnAttribute("name");
            public ColumnAttribute Description { get; } = new ColumnAttribute("description");
            public ColumnAttribute Default { get; } = new ColumnAttribute("default");
            public ColumnAttribute AccessLv { get; } = new ColumnAttribute("accessLv");
        }

        #endregion クラス
    }
}