using Mov.Configurator.Models.Entities;
using Mov.Configurator.Models.Persistences;
using Mov.Configurator.Models.Repositories;
using Mov.Core.Repositories.Cruds;
using Mov.Core.Templates.Crud;
using System;

namespace Mov.Configurator.Engine.Cruds
{
    public class ConfiguratorPersistenceQuery : IConfiguratorQuery
    {
        #region フィールド

        private readonly IPersistenceQuery<UserSetting> _userSetting;

        #endregion フィールド

        #region プロパティ

        public IRead<UserSetting> UserSettingReader { get; }

        public IPersistenceQuery<UserSetting> UserSetting => throw new NotImplementedException();

        #endregion プロパティ

        #region コンストラクター

        public ConfiguratorPersistenceQuery(IConfiguratorRepository repository)
        {
            _userSetting = new DbObjectRepositoryQuery<UserSetting, UserSettingCollection>(repository.UserSettings);
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