using Mov.Accessors.Repository;
using Mov.Accessors.Repository.Domain;
using Mov.Configurator.Models;
using Mov.Controllers;
using Mov.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.UseCases
{
    internal class WriteConsoleCommand : ICommand<IDomainRepository, Response>
    {
        public Response Invoke(IDomainRepository repository, string[] args)
        {
            if(repository is IConfiguratorRepository configrator)
            {
                Console.WriteLine(configrator.Configs.ToString());
            }
            return Response.Success;
        }
    }
}
