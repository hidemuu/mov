﻿using Mov.Core.Configurators.Models.Entities;
using Mov.Core.Stores;
using System;

namespace Mov.Core.Configurators
{
    public interface IConfiguratorService
    {
        #region property

        IStoreQuery<UserSetting, Guid> UserSettingQuery { get; }

        #endregion property
    }
}