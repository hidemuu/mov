using Mov.Accessors.Repository;
using Mov.Accessors.Repository.Domain;
using Mov.BaseModel;
using Mov.Controllers;
using Mov.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Driver.Models.Commands
{
    internal class WriteConsoleCommand : ICommand<IDriverService, CommandResponse>
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
