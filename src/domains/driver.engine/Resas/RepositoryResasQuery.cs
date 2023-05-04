using Mov.Controllers.Repository.Persistences;
using Mov.Driver.Clients.Resas;
using Mov.Driver.Clients.Resas.Entities;
using Mov.Driver.Clients.Resas.Entities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Driver.Engine.Resas
{
    public class RepositoryResasQuery : IResasQuery
    {
        public RepositoryResasQuery(IResasRepository repository)
        {

        }

        public IPersistenceQuery<ResasResponse<Prefecture>> Prefectures => throw new NotImplementedException();

        public IPersistenceQuery<ResasResponse<City>> Cities => throw new NotImplementedException();
    }
}
