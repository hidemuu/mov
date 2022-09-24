using Mov.Accessors.Repository.Domain;
using Mov.Controllers;
using System.Collections.Generic;

namespace Mov.Configurator.Models.Commands
{
    public class ConfiguratorCommandFactory
    {
        public static IDictionary<string, ICommand<IConfiguratorRepository, DomainResponse>> Create()
        {
            return new Dictionary<string, ICommand<IConfiguratorRepository, DomainResponse>>()
            {
                { "WriteConsole", new WriteConsoleCommand() },
            };
        }
    }
}