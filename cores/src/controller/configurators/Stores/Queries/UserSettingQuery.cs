using Mov.Core.Configurators.Models.Entities;
using Mov.Core.Stores;
using System;

namespace Mov.Core.Configurators.Stores.Queries
{
    internal class UserSettingQuery : IStoreQuery<UserSetting, Guid>
    {
        #region property

        public IRead<UserSetting, Guid> Reader { get; }

        #endregion property

        #region constructor

        public UserSettingQuery(IConfiguratorRepository repository)
        {
            this.Reader = new UserSettingReader(repository);
        }

        #endregion constructor
    }
}
