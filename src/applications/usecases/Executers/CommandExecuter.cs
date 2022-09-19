using Mov.Accessors.Repository;
using Mov.Configurator.Models;
using Mov.Controllers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Mov.UseCases
{
    public class CommandExecuter : CommandExecuterBase<IDomainRepositoryCollection<IConfiguratorRepository>, Response>
    {
        protected override IDictionary<string, ICommand<IDomainRepositoryCollection<IConfiguratorRepository>, Response>> Handler => new Dictionary<string, ICommand<IDomainRepositoryCollection<IConfiguratorRepository>, Response>>() 
        {
            { "WriteConsole", new WriteConsoleCommand() },
        };

        public CommandExecuter(IDomainRepositoryCollection<IConfiguratorRepository> database) : base(database)
        {
        }
    }
}
