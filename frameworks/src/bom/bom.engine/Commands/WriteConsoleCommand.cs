using Mov.Bom.Models;
using Mov.Core.Models.Commands;
using Mov.Core.Templates.Controllers;

namespace Mov.Bom.Engine.Commands
{
    internal class WriteConsoleCommand : IUiCommand<IBomRepository, CommandResponse>
    {
        public string Name => "WriteConsole";

        public string ShortName => "wc";

        public CommandResponse Invoke(IBomRepository repository, string[] args)
        {
            return CommandResponse.Success;
        }

        public string Help()
        {
            return "コンソールに書き込む";
        }
    }
}