using Mov.Core.Templates.Crud;
using Mov.Suite.Resas.Models;
using Mov.Suite.Resas.Models.Schemas;
using Mov.Suite.Resas.Models.Schemas.Results;
using System;

namespace Mov.Suite.Resas.Engine
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