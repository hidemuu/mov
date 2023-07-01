using Mov.Core.Models.ValueObjects.Commands;
using Mov.Core.Templates.Controllers;
using System;

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