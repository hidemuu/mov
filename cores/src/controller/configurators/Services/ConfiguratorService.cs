﻿using Mov.Core.Configurators.Models.Entities;
using Mov.Core.Stores;
using System;

namespace Mov.Core.Configurators.Services
{
    public class ConfiguratorService : IConfiguratorService
    {
        #region field

        private readonly IConfiguratorStore _store;

        #endregion field

        #region property
        public IStoreQuery<UserSetting, Guid> UserSettingQuery { get; }

        #endregion property

        #region constructor

        public ConfiguratorService(IConfiguratorStore store)
        {
            this._store = store;
            this.UserSettingQuery = _store.UserSetting.Query;
        }

        #endregion constructor

    }
}