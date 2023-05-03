using Mov.Accessors.Crud.Persistence.Implement;
using Mov.Configurator.Models;
using Mov.Configurator.Models.Schemas;
using Mov.Controllers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Configurator.Engine.Persistences
{
    public class ConfiguratorPersistenceCommand : IConfiguratorCommand
    {
        #region プロパティ

        public IPersistenceCommand<UserSettingSchema> UserSetting { get; }

        public IPersistenceCommand<SystemSettingSchema> SystemSetting { get; }

        public IPersistenceCommand<LanguageSchema> Language { get; }

        #endregion プロパティ

        #region コンストラクター

        public ConfiguratorPersistenceCommand(IConfiguratorRepository repository)
        {
            UserSetting = new DbObjectRepositoryCommand<UserSettingSchema, UserSettingCollectionSchema>(repository.UserSettings);
        }

        #endregion コンストラクター
    }
}
