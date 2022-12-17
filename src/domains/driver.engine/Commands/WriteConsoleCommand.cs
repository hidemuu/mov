using Mov.Controllers;
using System;

namespace Mov.Driver.Models.Commands
{
    internal class WriteConsoleCommand : IUiCommand<IDriverService, CommandResponse>
    {
        public string Name => DriverCommandType.WriteConsole.ToString();

        public string ShortName => "wc";

        public CommandResponse Invoke(IDriverService service, string[] args)
        {
            Console.WriteLine(service.Repository.Commands.ToString());
            return CommandResponse.Success;
        }

        public string Help()
        {
            return "コンソールに書き込む";
        }
    }
}
