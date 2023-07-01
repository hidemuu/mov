using Mov.Configurator.Models.Persistences;

namespace Mov.Configurator.Models.Parameters
{
    public interface IConfiguratorParameter
    {
        IConfiguratorCommand Command { get; }

        IConfiguratorQuery Query { get; }
    }
}