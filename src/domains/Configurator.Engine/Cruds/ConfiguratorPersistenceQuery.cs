using Mov.Accessors.Crud.Persistence.Implement;
using Mov.Configurator.Models;
using Mov.Configurator.Models.Schemas;
using Mov.Controllers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Configurator.Engine.Persistences
{
    public class ConfiguratorPersistenceQuery : IConfiguratorQuery
    {
        #region フィールド

        private readonly IPersistenceQuery<UserSettingSchema> _userSetting;

        private readonly IPersistenceQuery<SystemSettingSchema> _systemSetting;

        private readonly IPersistenceQuery<LanguageSchema> _language;

        #endregion フィールド

        #region プロパティ

        public IRead<UserSettingSchema> UserSettingReader { get; }

        #endregion プロパティ

        #region コンストラクター

        public ConfiguratorPersistenceQuery(IConfiguratorRepository repository)
        {
            _userSetting = new DbObjectRepositoryQuery<UserSettingSchema, UserSettingCollectionSchema>(repository.UserSettings);
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
