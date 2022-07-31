using Mov.Configurator.Models;
using Mov.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Configurator.Service.Commands
{
    public class WriteConsoleCommand : ICommand<IConfiguratorDatabase>
    {
        public Response Invoke(IConfiguratorDatabase parameter)
        {
            Console.WriteLine(parameter.Configs.ToString());
            return Response.Success;
        }
    }
}
