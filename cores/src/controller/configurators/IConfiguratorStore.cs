using Mov.Core.Configurators.Models.Entities;
using Mov.Core.Stores;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Core.Configurators.Stores
{
    internal interface IConfiguratorStore
    {
        IStore<UserSetting, Guid> UserSetting { get; }
    }
}
