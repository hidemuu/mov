using Mov.Accessors.Repository;
using Mov.Accessors.Repository.Domain;
using Mov.Controllers;
using Mov.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Designer.Models.Commands
{
    internal class WriteConsoleCommand : IUiCommand<IDesignerRepository, CommandResponse>
    {
        public string Name => "WriteConsole";

        public string ShortName => "wc";

        public CommandResponse Invoke(IDesignerRepository repository, string[] args)
        {
            Console.WriteLine(repository.Nodes.ToString());
            return CommandResponse.Success;
        }

        public string Help()
        {
            return "コンソールに書き込む";
        }
    }
}
