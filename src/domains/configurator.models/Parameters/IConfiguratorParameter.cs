using Mov.Configurator.Models.Persistences;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Configurator.Models.Parameters
{
    public interface IConfiguratorParameter
    {
        IConfiguratorCommand Command { get; }

        IConfiguratorQuery Query { get; }
    }
}
