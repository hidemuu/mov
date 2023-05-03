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
        #region フィールド

        private readonly IPersistenceCommand<UserSettingSchema> _userSetting;

        private readonly IPersistenceCommand<SystemSettingSchema> _systemSetting;

        private readonly IPersistenceCommand<LanguageSchema> _language;


        #endregion フィールド

        #region プロパティ

        public ISave<UserSettingSchema> UserSettingSaver { get; }

        public IDelete<UserSettingSchema> UserSettingDeleter { get; }

        #endregion プロパティ

        #region コンストラクター

        public ConfiguratorPersistenceCommand(IConfiguratorRepository repository)
        {
            _userSetting = new DbObjectRepositoryCommand<UserSettingSchema, UserSettingCollectionSchema>(repository.UserSettings);
        }

        #endregion コンストラクター

        #region メソッド

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        #endregion メソッド
    }
}
