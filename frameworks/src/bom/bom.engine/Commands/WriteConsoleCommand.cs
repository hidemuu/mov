using Mov.Core.Models.ValueObjects.Commands;
using Mov.Core.Templates.Commands;

namespace Mov.Bom.Models.Commands
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