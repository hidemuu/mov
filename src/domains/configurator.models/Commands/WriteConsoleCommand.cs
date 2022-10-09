using Mov.Accessors.Repository;
using Mov.Accessors.Repository.Domain;
using Mov.BaseModel;
using Mov.Configurator.Models;
using Mov.Controllers;
using Mov.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Configurator.Models.Commands
{
    internal class WriteConsoleCommand : ICommand<IConfiguratorService, CommandResponse>
    {
        public string Name => ConfiguratorCommandType.WriteConsole.ToString();

        public string ShortName => "wc";

        public CommandResponse Invoke(IConfiguratorService service, string[] args)
        {
            Console.WriteLine(service.Repository.UserSettings.ToString());
            Console.WriteLine(service.Repository.Errors.ToString());
            Console.WriteLine(service.Repository.Schemas.ToString());
            return CommandResponse.Success;
        }

        public string Help()
        {
            return "コンソールに書き込む";
        }
    }
}
