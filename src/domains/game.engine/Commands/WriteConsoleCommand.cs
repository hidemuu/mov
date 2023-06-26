using Mov.Game.Models;
using Mov.Utilities.Models.ValueObjects.Commands;
using Mov.Utilities.Templates;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Game.Engine.Commands
{
    internal class WriteConsoleCommand : IUiCommand<IGameFacade, CommandResponse>
    {
        public string Name => GameCommandType.WriteConsole.ToString();

        public string ShortName => "wc";

        public CommandResponse Invoke(IGameFacade service, string[] args)
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
