using Mov.Configurator.Models;
using Mov.Designer.Service;
using Mov.WpfControls;
using Mov.WpfControls.ViewModels;
using Reactive.Bindings;
using System.Collections.Generic;

namespace Mov.Configurator.ViewModels
{
    public class ConfigTableViewModel : ViewModelBase
    {
        #region フィールド

        private readonly IConfiguratorRepositoryCollection repository;

        #endregion フィールド

        #region プロパティ

        public ReactiveCollection<ColumnItem[]> Items { get; } = new ReactiveCollection<ColumnItem[]>();
        public ColumnAttribute[] Attributes { get; }

        #endregion プロパティ

        /// <summary>コンストラクター</summary>
        public ConfigTableViewModel(IConfiguratorRepositoryCollection repository)
        {
            this.repository = repository;
            foreach (var item in this.repository.Configs.Gets())
            {
                Items.Add(new ColumnItem[] 
                {
                    new ColumnItem(item.Id),
                    new ColumnItem(item.Index),
                    new ColumnItem(item.Code),
                    new ColumnItem(item.Category),
                    new ColumnItem(item.Name),
                    new ColumnItem(item.Value),
                    new ColumnItem(item.Default),
                    new ColumnItem(item.AccessLv),
                    new ColumnItem(item.Description),
                });
            }

            Attributes = new ColumnAttribute[]
            {
                new ColumnAttribute("id"),
                new ColumnAttribute("index"),
                new ColumnAttribute("code"),
                new ColumnAttribute("category"),
                new ColumnAttribute("name"),
                new ColumnAttribute("value"),
                new ColumnAttribute("default"),
                new ColumnAttribute("accessLv"),
                new ColumnAttribute("description"),
            };
        }

    }
}