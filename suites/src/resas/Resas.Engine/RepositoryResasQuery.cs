using Mov.Core.Templates.Crud;
using Mov.Driver.Clients.Resas;
using Mov.Driver.Clients.Resas.Entities;
using Mov.Driver.Clients.Resas.Entities.Results;
using System;

namespace Mov.Suite.Driver.Engine.Resas
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