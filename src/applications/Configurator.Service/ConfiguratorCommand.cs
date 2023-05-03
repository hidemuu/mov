using Mov.Accessors;
using Mov.Accessors.Crud.Persistence.Implement;
using Mov.Configurators.Schemas;
using Mov.Controllers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Configurators.Services.Persistences
{
    public class ConfiguratorCommand : IPersistenceCommand<Config>
    {
        #region フィールド

        private readonly FileConfiguratorRepository repository;

        #endregion フィールド

        #region プロパティ

        public ISave<Config> Saver { get; }

        public IDelete<Config> Deleter { get; }

        #endregion プロパティ

        #region コンストラクター

        public ConfiguratorCommand(FileConfiguratorRepository repository)
        {
            this.repository = repository;
            Saver = new DbObjectRepositorySaver<Config, ConfigCollection>(repository.Configs);
            Deleter = new DbObjectRepositoryDeleter<Config, ConfigCollection>(repository.Configs);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        #endregion コンストラクター

        #region メソッド



        #endregion メソッド
    }
}
