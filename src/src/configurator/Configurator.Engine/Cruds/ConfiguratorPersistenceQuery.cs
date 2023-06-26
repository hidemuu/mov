using Mov.Configurator.Models;
using Mov.Configurator.Models.Persistences;
using Mov.Repositories.Services.Cruds;
using Mov.Utilities.Templates.Crud;
using System;

namespace Configurator.Engine.Persistences
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