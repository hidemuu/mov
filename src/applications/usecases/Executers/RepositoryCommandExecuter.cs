using Mov.Accessors.Repository;
using Mov.Accessors.Repository.Domain;
using Mov.Configurator.Models;
using Mov.Controllers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Mov.UseCases
{
    public class RepositoryCommandExecuter : CommandExecuterBase<IDomainRepositoryCollection<IDomainRepository>, Response>
    {
        protected override IDictionary<string, ICommand<IDomainRepositoryCollection<IDomainRepository>, Response>> Handler => new Dictionary<string, ICommand<IDomainRepositoryCollection<IDomainRepository>, Response>>() 
        {
            { "WriteConsole", new WriteConsoleCommand() },
        };

        public RepositoryCommandExecuter(IDomainRepositoryCollection<IDomainRepository> database) : base(database)
        {
        }
    }
}
