using Mov.Configurator.Models.Entities;
using Mov.Configurator.Models.Persistences;
using Mov.Configurator.Models.Repositories;
using Mov.Core.Repositories.Cruds;
using Mov.Core.Templates.Crud;
using System;

namespace Mov.Configurator.Engine.Cruds
{
    public class ConfiguratorPersistenceCommand : IConfiguratorCommand
    {
        #region フィールド

        private readonly IPersistenceCommand<UserSettingSchema> _userSetting;

        #endregion フィールド

        #region プロパティ

        public ISave<UserSettingSchema> UserSettingSaver { get; }

        public IDelete<UserSettingSchema> UserSettingDeleter { get; }

        public IPersistenceCommand<UserSettingSchema> UserSetting => throw new NotImplementedException();

        #endregion プロパティ

        #region コンストラクター

        public ConfiguratorPersistenceCommand(IConfiguratorRepository repository)
        {
            _userSetting = new DbObjectRepositoryCommand<UserSettingSchema, UserSettingSchemaCollection>(repository.UserSettings);
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