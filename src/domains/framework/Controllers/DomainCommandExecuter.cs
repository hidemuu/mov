using Mov.Accessors.Repository;
using Mov.Accessors.Repository.Domain;
using Mov.Configurator.Models;
using Mov.Controllers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Mov.Framework
{
    internal class DomainCommandExecuter : CommandExecuterBase<IDomainRepository, DomainResponse>
    {
        protected override IDictionary<string, ICommand<IDomainRepository, DomainResponse>> Handler 
            => new Dictionary<string, ICommand<IDomainRepository, DomainResponse>>() 
        {
            { "WriteConsole", new WriteConsoleCommand() },
        };

        public DomainCommandExecuter(IDomainRepository repository) : base(repository)
        {
        }
    }
}
