using Mov.Configurator.Models;
using Mov.Controllers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Mov.UseCases
{
    public class ConfiguratorCommandExecuter : CommandExecuterBase<IConfiguratorRepositoryCollection>
    {
        protected override IDictionary<string, ICommand<IConfiguratorRepositoryCollection>> Handler => new Dictionary<string, ICommand<IConfiguratorRepositoryCollection>>() 
        {
            { ConfiguratorCommandKey.WriteConsole.ToString(), new WriteConsoleCommand() },
        };

        public ConfiguratorCommandExecuter(IConfiguratorRepositoryCollection database) : base(database)
        {
        }

        public Response Invoke(ConfiguratorCommandKey key)
        {
            return Invoke(key.ToString());
        }

    }
}
