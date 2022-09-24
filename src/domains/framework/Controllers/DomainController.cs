using Mov.Accessors.Repository;
using Mov.Accessors.Repository.Domain;
using Mov.Configurator.Models;
using Mov.Controllers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Mov.Framework
{
    public class DomainController : IController
    {
        private readonly IDomainRepository repository;
        private readonly DomainCommandExecuter executer;

        public DomainController(IDomainRepository repository)
        {
            this.repository = repository;
            this.executer = new DomainCommandExecuter(repository);
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
            var help = string.Empty;
            var newLine = Environment.NewLine;
            var commands = GetCommands();
            foreach(var command in commands)
            {
                help += command + newLine;
            }
            help = help.TrimEnd(newLine.ToCharArray());
            return help;
        }
    }
}
