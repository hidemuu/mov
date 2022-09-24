using Mov.Accessors.Repository.Domain;
using Mov.BaseModel;
using Mov.Configurator.Models;
using Mov.Configurator.Models.Commands;
using Mov.Controllers;
using Mov.Controllers.Service;
using Mov.Utilities;
using System;
using System.Collections.Generic;

namespace Mov.Configurator.Service
{
    /// <summary>
    /// コンフィグレーションのサービス
    /// </summary>
    public class ConfiguratorService : IService
    {
        /// <summary>
        /// リポジトリ
        /// </summary>
        private readonly IConfiguratorRepository repository;

        
        private readonly CommandExecuter<IConfiguratorRepository, DomainResponse> executer;

        /// <summary>
        /// コンストラクター
        /// </summary>
        public ConfiguratorService(IConfiguratorRepository repository)
        {
            this.repository = repository;
            this.executer = new CommandExecuter<IConfiguratorRepository, DomainResponse>(this.repository, ConfiguratorCommandFactory.Create());
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
