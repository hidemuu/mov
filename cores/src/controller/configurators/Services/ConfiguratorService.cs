using Mov.Core.Configurators.Stores;

namespace Mov.Core.Configurators.Services
{
    public class ConfiguratorService : IConfiguratorService
    {
        #region field

        private readonly IConfiguratorRepository _repository;

        private readonly IConfiguratorStore _store;

        #endregion field

        #region property

        public IConfiguratorStoreQuery Query { get; }

        #endregion property

        #region constructor

        public ConfiguratorService(IConfiguratorRepository repository)
        {
            this._repository = repository;
            this._store = new ConfiguratorStore(repository);
            this.Query = _store;
        }

        #endregion constructor

    }
}
