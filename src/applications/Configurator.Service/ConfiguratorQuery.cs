using Configurator.Repository.File;
using Mov.Accessors;
using Mov.Accessors.Persistance.Implement;
using Mov.Configurator.Models.Schemas;
using Mov.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mov.Configurators.Services.Persistences
{
    public class ConfiguratorQuery : IPersistenceQuery<UserSettingSchema>
    {
        #region フィールド

        private readonly FileConfiguratorRepository repository;

        #endregion フィールド

        #region プロパティ

        public IRead<UserSettingSchema> Reader { get; }

        #endregion プロパティ

        #region コンストラクター

        public ConfiguratorQuery(FileConfiguratorRepository repository)
        {
            this.repository = repository;
            Reader = new DbObjectRepositoryReader<UserSettingSchema, UserSettingCollectionSchema>(repository.Configs);
        }

        #endregion コンストラクター

        #region メソッド

        public override string ToString() => repository.Configs.ToString();

        #endregion メソッド
    }
}
