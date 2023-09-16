using System.Collections.Generic;

namespace Mov.Core.Commands.Implements
{
    /// <summary>
    /// ドメイン単位のコントローラー
    /// </summary>
    public class UiCommandController<TService> : IController
    {

        private readonly TService service;

        private readonly UiCommandExecuter<TService, UiCommandResponse> executer;


        public UiCommandController(TService service, string endpoint)
        {
            this.service = service;
            executer = new UiCommandExecuter<TService, UiCommandResponse>(service, endpoint);
        }

        public bool Execute()
        {
            return true;
        }

        public bool ExecuteCommand(string command, string[] args)
        {
            executer.Invoke(command, args);
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
