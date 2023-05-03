using Mov.Configurators.Schemas;
using Mov.Controllers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Configurators
{
    public interface IConfiguratorService
    {
        IPersistenceCommand<Config> Command { get; }

        IPersistenceQuery<Config> Query { get; }
    }
}
