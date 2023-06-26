using Configurator.Engine.Persistences;
using Mov.Configurator.Models;
using Mov.Configurator.Models.Persistences;

namespace Mov.Configurators
{
    public class ConfiguratorService : IConfiguratorService
    {
        public IConfiguratorCommand Command { get; }

        public IConfiguratorQuery Query { get; }

        public ConfiguratorService(IConfiguratorRepository repository)
        {
            this.Command = new ConfiguratorPersistenceCommand(repository);
            this.Query = new ConfiguratorPersistenceQuery(repository);
        }

        public override string ToString()
        {
            return this.Query.ToString();
        }
    }
}