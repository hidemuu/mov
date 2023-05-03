using Mov.Configurator.Models;
using Mov.Configurator.Models.Schemas;
using Mov.Controllers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Configurators
{
    public interface IConfiguratorService
    {
        IConfiguratorCommand Command { get; }

        IConfiguratorQuery Query { get; }
    }
}
