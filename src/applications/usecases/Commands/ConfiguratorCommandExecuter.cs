using Mov.Accessors.Repository;
using Mov.Configurator.Models;
using Mov.Controllers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Mov.UseCases
{
    public class ConfiguratorCommandExecuter : CommandExecuterBase<IDomainRepositoryCollection<IConfiguratorRepository>>
    {
        protected override IDictionary<string, ICommand<IDomainRepositoryCollection<IConfiguratorRepository>>> Handler => new Dictionary<string, ICommand<IDomainRepositoryCollection<IConfiguratorRepository>>>() 
        {
            { ConfiguratorCommandKey.WriteConsole.ToString(), new WriteConsoleCommand() },
        };

        public ConfiguratorCommandExecuter(IDomainRepositoryCollection<IConfiguratorRepository> database) : base(database)
        {
        }

        public Response Invoke(ConfiguratorCommandKey key)
        {
            return Invoke(key.ToString());
        }

    }
}
