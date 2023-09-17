using Mov.Core.Configurators.Models.Entities;
using Mov.Core.Configurators.Stores.Commands;
using Mov.Core.Configurators.Stores.Queries;
using Mov.Core.Stores;
using System;

namespace Mov.Core.Configurators.Stores
{
    internal class UserSettingStore : IStore<UserSetting, Guid>
    {

        #region property

        public IStoreCommand<UserSetting, Guid> Command { get; }

        public IStoreQuery<UserSetting, Guid> Query { get; }

        #endregion property

        #region constructor

        public UserSettingStore(IConfiguratorRepository repository)
        {
            this.Query = new UserSettingQuery(repository);
            this.Command = new UserSettingCommand(repository);
        }

        #endregion constructor
    }
}
