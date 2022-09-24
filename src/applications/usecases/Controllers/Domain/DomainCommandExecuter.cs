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
    internal class DomainCommandExecuter : CommandExecuterBase<IDomainRepository, Response>
    {
        protected override IDictionary<string, ICommand<IDomainRepository, Response>> Handler 
            => new Dictionary<string, ICommand<IDomainRepository, Response>>() 
        {
            { "WriteConsole", new WriteConsoleCommand() },
        };

        public DomainCommandExecuter(IDomainRepository repository) : base(repository)
        {
        }
    }
}
