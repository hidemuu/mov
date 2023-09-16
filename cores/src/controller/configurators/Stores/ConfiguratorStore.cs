using Mov.Core.Configurators.Models.Entities;
using Mov.Core.Configurators.Stores.Commands;
using Mov.Core.Configurators.Stores.Queries;
using Mov.Core.Stores;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Core.Configurators.Stores
{
    internal class ConfiguratorStore : IConfiguratorStore
    {
        #region property

        public IStoreCommand<UserSetting, Guid> UserSettingCommand { get; }

        public IStoreQuery<UserSetting, Guid> UserSettingQuery { get; }

        #endregion property

        #region constructor

        public ConfiguratorStore(IConfiguratorRepository repository)
        {
            this.UserSettingQuery = new UserSettingQuery(repository);
            this.UserSettingCommand = new UserSettingCommand(repository);
        }

        #endregion constructor
    }
}
