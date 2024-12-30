using Mov.Core.Configurators.Models.Entities;
using Mov.Core.Stores;
using System;

namespace Mov.Core.Configurators
{
    public interface IConfiguratorStore
    {
        IStore<ApiSetting, string> ApiSetting { get; }

        IStore<UserSetting, Guid> UserSetting { get; }
    }
}
