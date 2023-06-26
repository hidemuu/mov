using Mov.Configurator.Models.Persistences;

namespace Mov.Configurators
{
    public interface IConfiguratorService
    {
        IConfiguratorCommand Command { get; }

        IConfiguratorQuery Query { get; }
    }
}