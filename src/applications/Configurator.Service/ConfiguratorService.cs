using System;
using System.Collections.Generic;
using System.Text;
using Mov.Configurators.Schemas;
using Mov.Controllers;

namespace Mov.Configurators
{
    public class ConfiguratorService : IConfiguratorService
    {
        public IPersistenceCommand<Config> Command { get; }

        public IPersistenceQuery<Config> Query { get; }

        public ConfiguratorService(IPersistenceCommand<Config> command, IPersistenceQuery<Config> query)
        {
            this.Command = command;
            this.Query = query;
        }

        public override string ToString()
        {
            return this.Query.ToString();
        }
    }
}
