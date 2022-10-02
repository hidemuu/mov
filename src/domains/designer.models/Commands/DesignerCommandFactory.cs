using Mov.Controllers;
using Mov.Controllers.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Designer.Models
{
    public class DesignerCommandFactory : ICommandFactory<IDesignerRepository, DomainResponse>
    {
        public IDictionary<string, ICommand<IDesignerRepository, DomainResponse>> Create()
        {
            return new Dictionary<string, ICommand<IDesignerRepository, DomainResponse>>()
            {
                { "WriteConsole", new WriteConsoleCommand() },
            };
        }
    }
}
