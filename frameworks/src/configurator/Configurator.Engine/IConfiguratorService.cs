using Mov.Configurator.Models.Persistences;

namespace Mov.Configurator.Engine
{
    public interface IConfiguratorService
    {
        IConfiguratorCommand Command { get; }

        IConfiguratorQuery Query { get; }
    }
}