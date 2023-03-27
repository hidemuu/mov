using Mov.Controllers;
using Mov.Driver.Clients.Resas;
using Mov.Driver.Clients.Resas.Entities;
using Mov.Driver.Clients.Resas.Entities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Driver.Engine.Resas
{
    public class RepositoryResasCommand : IResasCommand
    {
        public RepositoryResasCommand(IResasRepository repository)
        {

        }

        public IPersistenceCommand<ResasResponse<Prefecture>> Prefectures => throw new NotImplementedException();

        public IPersistenceCommand<ResasResponse<City>> Cities => throw new NotImplementedException();
    }
}
