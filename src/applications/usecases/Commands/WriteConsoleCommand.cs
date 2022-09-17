using Mov.Configurator.Models;
using Mov.Controllers;
using Mov.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.UseCases
{
    public class WriteConsoleCommand : ICommand<IConfiguratorDatabase>
    {
        public Response Invoke(IConfiguratorDatabase parameter)
        {
            Console.WriteLine(parameter.Repositories[""].UserSettings.ToString());
            return Response.Success;
        }
    }
}
