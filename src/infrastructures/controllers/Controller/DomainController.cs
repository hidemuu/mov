using Mov.Controllers;
using Mov.Controllers.Service;
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
    public class DomainController<TRepository> : IController
    {

        private readonly TRepository repository;

        private readonly ICommandService service;

        public DomainController(TRepository repository, ICommandService service)
        {
            this.repository = repository;
            this.service = service;
        }

        public bool Execute()
        {
            return true;
        }

        public bool ExecuteCommand(string command, string[] args)
        {
            var response = this.service.ExecuteCommand(command, args);
            return true;
        }

        public IEnumerable<string> GetCommands()
        {
            return this.service.GetCommands();
        }

        public bool ExistsCommand(string command)
        {
            return this.service.ExistsCommand(command);
        }

        public virtual string GetCommandHelp()
        {
            return this.service.GetCommandHelp();
        }
    }
}
