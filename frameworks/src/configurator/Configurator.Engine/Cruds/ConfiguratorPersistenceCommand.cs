﻿using Mov.Configurator.Models;
using Mov.Configurator.Models.Persistences;
using Mov.Repositories.Services.Cruds;
using Mov.Utilities.Templates.Crud;
using System;

namespace Configurator.Engine.Persistences
{
    public class ConfiguratorPersistenceCommand : IConfiguratorCommand
    {
        #region フィールド

        private readonly IPersistenceCommand<UserSetting> _userSetting;

        #endregion フィールド

        #region プロパティ

        public ISave<UserSetting> UserSettingSaver { get; }

        public IDelete<UserSetting> UserSettingDeleter { get; }

        public IPersistenceCommand<UserSetting> UserSetting => throw new NotImplementedException();

        #endregion プロパティ

        #region コンストラクター

        public ConfiguratorPersistenceCommand(IConfiguratorRepository repository)
        {
            _userSetting = new DbObjectRepositoryCommand<UserSetting, UserSettingCollection>(repository.UserSettings);
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