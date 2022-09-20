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
    internal class WriteConsoleCommand : ICommand<IDomainRepositoryCollection<IDomainRepository>, Response>
    {
        public Response Invoke(IDomainRepositoryCollection<IDomainRepository> parameter)
        {
            var repository = parameter.Repositories[""];
            if(repository is IConfiguratorRepository configrator)
            {
                Console.WriteLine(configrator.Configs.ToString());
            }
            return Response.Success;
        }
    }
}
