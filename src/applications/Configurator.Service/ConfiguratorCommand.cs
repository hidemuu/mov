using Configurator.Repository.File;
using Mov.Accessors;
using Mov.Accessors.Crud.Persistence.Implement;
using Mov.Configurator.Models.Schemas;
using Mov.Controllers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Configurators.Services.Persistences
{
    public class ConfiguratorCommand : IPersistenceCommand<UserSettingSchema>
    {
        #region フィールド

        private readonly FileConfiguratorRepository repository;

        #endregion フィールド

        #region プロパティ

        public ISave<UserSettingSchema> Saver { get; }

        public IDelete<UserSettingSchema> Deleter { get; }

        #endregion プロパティ

        #region コンストラクター

        public ConfiguratorCommand(FileConfiguratorRepository repository)
        {
            this.repository = repository;
            Saver = new DbObjectRepositorySaver<UserSettingSchema, UserSettingCollectionSchema>(repository.Configs);
            Deleter = new DbObjectRepositoryDeleter<UserSettingSchema, UserSettingCollectionSchema>(repository.Configs);
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
