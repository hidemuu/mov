using Mov.Accessors.Repository;
using Mov.Accessors.Repository.Domain;
using Mov.Controllers;
using Mov.Game.Models;
using Mov.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Game.Engine.Commands
{
    internal class WriteConsoleCommand : IUiCommand<IGameService, CommandResponse>
    {
        public string Name => GameCommandType.WriteConsole.ToString();

        public string ShortName => "wc";

        public CommandResponse Invoke(IGameService service, string[] args)
        {
            Console.WriteLine(service.ToString());
            return CommandResponse.Success;
        }

        public string Help()
        {
            return "コンソールに書き込む";
        }
    }
}
