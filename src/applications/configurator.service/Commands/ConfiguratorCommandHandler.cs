using Mov.Configurator.Models;
using Mov.Utilities;
using Mov.Utilities.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Mov.Configurator.Service.Commands
{
    public class ConfiguratorCommandHandler : CommandHandlerBase<IConfiguratorDatabase>
    {
        protected override IDictionary<string, ICommand<IConfiguratorDatabase>> Handler => new Dictionary<string, ICommand<IConfiguratorDatabase>>() 
        {
            { ConfiguratorCommandKey.WriteConsole.ToString(), new WriteConsoleCommand() },
        };

        public ConfiguratorCommandHandler(IConfiguratorDatabase database) : base(database)
        {
        }

        public Response Invoke(ConfiguratorCommandKey key)
        {
            return Invoke(key.ToString());
        }

    }
}
