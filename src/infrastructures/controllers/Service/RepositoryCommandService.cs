using Mov.Controllers.Command;
using Mov.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Controllers.Service
{
    public class RepositoryCommandService<TRepository> : ICommandService
    {
        /// <summary>
        /// リポジトリ
        /// </summary>
        private readonly TRepository repository;


        private readonly CommandExecuter<TRepository, DomainResponse> executer;

        /// <summary>
        /// コンストラクター
        /// </summary>
        public RepositoryCommandService(TRepository repository, ICommandFactory<TRepository, DomainResponse> commandFactory)
        {
            this.repository = repository;
            this.executer = new CommandExecuter<TRepository, DomainResponse>(this.repository, commandFactory.Create());
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
            foreach (var commandHelp in this.executer.GetCommandHelps())
            {
                help += commandHelp.Item1 + " : " + commandHelp.Item2 + UtilityConstants.NewLine;
            }
            help = help.TrimEnd(UtilityConstants.NewLine.ToCharArray());
            return help;
        }
    }
}
