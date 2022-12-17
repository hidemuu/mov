using Mov.Accessors.Repository;
using Mov.Accessors.Repository.Domain;
using Mov.Controllers;
using Mov.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Analizer.Models.Commands
{
    internal class WriteConsoleCommand : IUiCommand<IAnalizerRepository, CommandResponse>
    {
        public string Name => "WriteConsole";

        public string ShortName => "wc";

        public CommandResponse Invoke(IAnalizerRepository repository, string[] args)
        {
            return CommandResponse.Success;
        }

        public string Help()
        {
            return "コンソールに書き込む";
        }
    }
}
