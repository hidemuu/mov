using Mov.Configurator.Engine;
using Mov.Configurator.Engine.Cruds;
using Mov.Configurator.Models.Persistences;
using Mov.Configurator.Models.Repositories;

namespace Mov.Configurator.Service
{
    public class ConfiguratorService : IConfiguratorService
    {
        public IConfiguratorCommand Command { get; }

        public IConfiguratorQuery Query { get; }

        public ConfiguratorService(IConfiguratorRepository repository)
        {
            Command = new ConfiguratorPersistenceCommand(repository);
            Query = new ConfiguratorPersistenceQuery(repository);
        }

        public override string ToString()
        {
            return Query.ToString();
        }
    }
}