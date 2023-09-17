using Mov.Core.Configurators.Models.Entities;
using Mov.Core.Configurators.Stores.Commands;
using Mov.Core.Configurators.Stores.Queries;
using Mov.Core.Stores;
using System;

namespace Mov.Core.Configurators.Stores
{
    internal class ConfiguratorStore : IConfiguratorStore
    {
        #region property

        public IStore<UserSetting, Guid> UserSetting { get; }

        #endregion property

        #region constructor

        public ConfiguratorStore(IConfiguratorRepository repository)
        {
            this.UserSetting = new UserSettingStore(repository);
        }

        #endregion constructor
    }
}
