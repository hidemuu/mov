using Mov.Core.Configurators.Models.Entities;
using Mov.Core.Configurators.Stores;
using Mov.Core.Stores;
using System;

namespace Mov.Core.Configurators.Services
{
    public class ConfiguratorService : IConfiguratorService
    {
        #region field

        private readonly IConfiguratorRepository _repository;

        private readonly ConfiguratorStore _store;

        #endregion field

        #region property
        public IStoreQuery<UserSetting, Guid> UserSettingQuery { get; }

        #endregion property

        #region constructor

        public ConfiguratorService(IConfiguratorRepository repository)
        {
            this._repository = repository;
            this._store = new ConfiguratorStore(repository);
            this.UserSettingQuery = _store.UserSetting.Query;
        }

        #endregion constructor

    }
}
