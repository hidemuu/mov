using Mov.Accessors;
using Mov.Accessors.Persistance.Implement;
using Mov.Configurators.Schemas;
using Mov.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mov.Configurators.Services.Persistences
{
    public class ConfiguratorQuery : IPersistenceQuery<Config>
    {
        #region フィールド

        private readonly FileConfiguratorRepository repository;

        #endregion フィールド

        #region プロパティ

        public IRead<Config> Reader { get; }

        #endregion プロパティ

        #region コンストラクター

        public ConfiguratorQuery(FileConfiguratorRepository repository)
        {
            this.repository = repository;
            Reader = new DbObjectRepositoryReader<Config, ConfigCollection>(repository.Configs);
        }

        #endregion コンストラクター

        #region メソッド

        public override string ToString() => repository.Configs.ToString();

        #endregion メソッド
    }
}
