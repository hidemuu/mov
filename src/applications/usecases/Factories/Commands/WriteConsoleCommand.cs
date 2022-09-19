using Mov.Accessors.Repository;
using Mov.Configurator.Models;
using Mov.Controllers;
using Mov.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.UseCases
{
    public class WriteConsoleCommand : ICommand<IDomainRepositoryCollection<IConfiguratorRepository>, Response>
    {
        public Response Invoke(IDomainRepositoryCollection<IConfiguratorRepository> parameter)
        {
            Console.WriteLine(parameter.Repositories[""].Configs.ToString());
            return Response.Success;
        }
    }
}
