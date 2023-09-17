using Mov.Core.Configurators.Models.Entities;
using Mov.Core.Stores;
using System;

namespace Mov.Core.Configurators
{
    public interface IConfiguratorStoreCommand
    {
        IStoreCommand<UserSetting, Guid> UserSettingCommand { get; }
    }
}
