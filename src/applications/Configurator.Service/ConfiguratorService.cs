using System;
using System.Collections.Generic;
using System.Text;
using Mov.Configurator.Models.Schemas;
using Mov.Controllers;

namespace Mov.Configurators
{
    public class ConfiguratorService : IConfiguratorService
    {
        public IPersistenceCommand<UserSettingSchema> Command { get; }

        public IPersistenceQuery<UserSettingSchema> Query { get; }

        public ConfiguratorService(IPersistenceCommand<UserSettingSchema> command, IPersistenceQuery<UserSettingSchema> query)
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
