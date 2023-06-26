using Mov.Layouts.Services.Commands;
using Mov.Utilities;
using Mov.Utilities.Templates;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Mov.Layouts.Services
{
    /// <summary>
    /// ドメイン単位のコントローラー
    /// </summary>
    public class DomainController<TService, TResponse> : IController
    {

        private readonly TService service;

        private readonly UiCommandExecuter<TService, TResponse> executer;


        public DomainController(TService service, string endpoint)
        {
            this.service = service;
            executer = new UiCommandExecuter<TService, TResponse>(service, endpoint);
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
