using Mov.Accessors.Repository.Domain;
using Mov.Controllers;
using Mov.Controllers.Command;
using System.Collections.Generic;

namespace Mov.Configurator.Models.Commands
{
    public class ConfiguratorCommandFactory : ICommandFactory<IConfiguratorRepository, DomainResponse>
    {
        public IDictionary<string, ICommand<IConfiguratorRepository, DomainResponse>> Create()
        {
            return new Dictionary<string, ICommand<IConfiguratorRepository, DomainResponse>>()
            {
                { "WriteConsole", new WriteConsoleCommand() },
            };
        }
    }
}