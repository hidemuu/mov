using Mov.Accessors;
using Mov.Configurator.Models;
using Mov.Configurator.Models.Persistences;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Configurator.Repository
{
    public class ConfiguratorQuery : IConfiguratorQuery
    {
        #region プロパティ

        public IPersistenceQuery<Error> Error { get; }

        public IPersistenceQuery<Schema> Schema { get; }

        public IPersistenceQuery<UserSetting> UserSetting { get; }

        #endregion プロパティ

        #region コンストラクター

        public ConfiguratorQuery(IConfiguratorRepository repository)
        {
            this.Error = new ErrorQuery(repository);
            this.Schema = new SchemaQuery(repository);
            this.UserSetting = new UserSettingQuery(repository);
        }

        #endregion コンストラクター
    }
}
