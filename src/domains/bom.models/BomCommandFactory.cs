using Mov.Controllers;
using Mov.Controllers.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Bom.Models
{
    public class BomCommandFactory : ICommandFactory<IBomRepository, DomainResponse>
    {
        public IDictionary<string, ICommand<IBomRepository, DomainResponse>> Create()
        {
            return new Dictionary<string, ICommand<IBomRepository, DomainResponse>>()
            {
                { "WriteConsole", new WriteConsoleCommand() },
            };
        }
    }
}
