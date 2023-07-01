using Mov.Core.Controllers.Services.Commands;
using Mov.Core.Models.ValueObjects.Commands;
using Mov.Core.Templates.Commands;
using System.Collections.Generic;

namespace Mov.Core.Controllers.Services.Controllers
{
    /// <summary>
    /// ドメイン単位のコントローラー
    /// </summary>
    public class DomainController<TService> : IController
    {

        private readonly TService service;

        private readonly UiCommandExecuter<TService, CommandResponse> executer;


        public DomainController(TService service, string endpoint)
        {
            this.service = service;
            executer = new UiCommandExecuter<TService, CommandResponse>(service, endpoint);
        }

        public bool Execute()
        {
            return true;
        }

        public bool ExecuteCommand(string command, string[] args)
        {
            var response = executer.Invoke(command, args);
            return true;
        }

        public IEnumerable<string> GetCommands()
        {
            return executer.GetCommands();
        }

        public bool ExistsCommand(string command)
        {
            return executer.Exists(command);
        }

        public virtual string GetCommandHelp()
        {
            return executer.GetHelp();
        }
    }
}
