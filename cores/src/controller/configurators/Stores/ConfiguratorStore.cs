using Mov.Core.Configurators.Models.Entities;
using Mov.Core.Stores;
using System;

namespace Mov.Core.Configurators.Stores
{
    internal class ConfiguratorStore : IConfiguratorStore
    {
        #region field

        private readonly IConfiguratorRepository _repository;

        #endregion field

        #region property

        public IStore<ApiSetting, string> ApiSetting { get; }

        public IStore<UserSetting, Guid> UserSetting { get; }

        #endregion property

        #region constructor

        public ConfiguratorStore(IConfiguratorRepository repository)
        {
            this._repository = repository;
            this.ApiSetting = new ApiSettingStore(repository);
            this.UserSetting = new UserSettingStore(repository);
        }

        #endregion constructor
    }
}
