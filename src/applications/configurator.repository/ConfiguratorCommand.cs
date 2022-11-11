using Mov.Accessors;
using Mov.Configurator.Models;
using Mov.Configurator.Models.Persistences;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Configurator.Repository
{
    public class ConfiguratorCommand : IConfiguratorCommand
    {
        #region プロパティ

        public IPersistenceCommand<Error> Error { get; }

        public IPersistenceCommand<Schema> Schema { get; }

        public IPersistenceCommand<UserSetting> UserSetting { get; }

        #endregion プロパティ

        #region コンストラクター

        public ConfiguratorCommand(IConfiguratorRepository repository)
        {
            this.Error = new ErrorCommand(repository);
            this.Schema = new SchemaCommand(repository);
            this.UserSetting = new UserSettingCommand(repository);
        }

        #endregion コンストラクター

    }
}
