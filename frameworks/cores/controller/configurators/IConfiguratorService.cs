using Mov.Core.Configurators.Models.Entities;
using Mov.Core.Stores;
using System;

namespace Mov.Core.Configurators
{
    public interface IConfiguratorService : IDisposable
    {
        #region property

        IStoreQuery<ApiSetting, string> ApiSettingQuery { get; }

        IStoreQuery<UserSetting, Guid> UserSettingQuery { get; }

        #endregion property
    }
}
