using Mov.Accessors.Repository;
using Mov.Configurator.Models;
using Mov.Controllers;
using Mov.UseCases;
using Mov.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mov.ConsoleApp
{
    internal class ConsoleCommandExecuter
    {
        private readonly CommandExecuter configurator;

        public ConsoleCommandExecuter(IDomainRepositoryCollection<IConfiguratorRepository> configuratorDatabase)
        {
            this.configurator = new CommandExecuter(configuratorDatabase);
        }

        public Response Invoke(string parameter)
        {
            return configurator.Invoke(parameter);
        }

    }
}
