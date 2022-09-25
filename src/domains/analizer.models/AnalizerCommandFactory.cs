using Mov.Controllers;
using Mov.Controllers.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Analizer.Models
{
    public class AnalizerCommandFactory : ICommandFactory<IAnalizerRepository, DomainResponse>
    {
        public IDictionary<string, ICommand<IAnalizerRepository, DomainResponse>> Create()
        {
            return new Dictionary<string, ICommand<IAnalizerRepository, DomainResponse>>()
            {
                { "WriteConsole", new WriteConsoleCommand() },
            };
        }
    }
}
