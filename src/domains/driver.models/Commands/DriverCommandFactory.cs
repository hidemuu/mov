using Mov.Controllers;
using Mov.Controllers.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Driver.Models
{
    public class DriverCommandFactory : ICommandFactory<IDriverRepository, DomainResponse>
    {
        public IDictionary<string, ICommand<IDriverRepository, DomainResponse>> Create()
        {
            return new Dictionary<string, ICommand<IDriverRepository, DomainResponse>>()
            {
                { "WriteConsole", new WriteConsoleCommand() },
            };
        }
    }
}
