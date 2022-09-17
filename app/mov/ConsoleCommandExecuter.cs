using Mov.Configurator.Models;
using Mov.Configurator.Service.Commands;
using Mov.Controllers;
using Mov.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mov
{
    internal class ConsoleCommandExecuter
    {
        private readonly ConfiguratorCommandExecuter configurator;

        public ConsoleCommandExecuter(IConfiguratorDatabase configuratorDatabase)
        {
            this.configurator = new ConfiguratorCommandExecuter(configuratorDatabase);
        }

        public Response Invoke()
        {
            return configurator.Invoke(ConfiguratorCommandKey.WriteConsole);
        }

    }
}
