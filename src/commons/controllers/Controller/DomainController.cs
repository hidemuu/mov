using Mov.Controllers;
using Mov.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Mov.Controllers
{
    /// <summary>
    /// ドメイン単位のコントローラー
    /// </summary>
    public class DomainController<TService> : IController
    {

        private readonly TService service;

        private readonly CommandExecuter<TService, CommandResponse> executer;


        public DomainController(TService service, string endpoint)
        {
            this.service = service;
            this.executer = new CommandExecuter<TService, CommandResponse>(service, endpoint);
        }

        public bool Execute()
        {
            return true;
        }

        public bool ExecuteCommand(string command, string[] args)
        {
            var response = this.executer.Invoke(command, args);
            return true;
        }

        public IEnumerable<string> GetCommands()
        {
            return this.executer.GetCommands();
        }

        public bool ExistsCommand(string command)
        {
            return this.executer.Exists(command);
        }

        public virtual string GetCommandHelp()
        {
            return this.executer.GetHelp();
        }
    }
}
