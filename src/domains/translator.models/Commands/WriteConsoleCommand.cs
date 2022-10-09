using Mov.Accessors.Repository;
using Mov.Accessors.Repository.Domain;
using Mov.BaseModel;
using Mov.Controllers;
using Mov.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Translator.Models.Commands
{
    internal class WriteConsoleCommand : ICommand<ITranslatorRepository, CommandResponse>
    {
        public string Name => "WriteConsole";

        public string ShortName => "wc";

        public CommandResponse Invoke(ITranslatorRepository repository, string[] args)
        {
            return CommandResponse.Success;
        }

        public string Help()
        {
            return "コンソールに書き込む";
        }
    }
}
