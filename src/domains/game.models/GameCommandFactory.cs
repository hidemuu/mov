using Mov.Controllers;
using Mov.Controllers.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Game.Models
{
    public class GameCommandFactory : ICommandFactory<IGameRepository, DomainResponse>
    {
        public IDictionary<string, ICommand<IGameRepository, DomainResponse>> Create()
        {
            return new Dictionary<string, ICommand<IGameRepository, DomainResponse>>()
            {
                { "WriteConsole", new WriteConsoleCommand() },
            };
        }
    }
}
