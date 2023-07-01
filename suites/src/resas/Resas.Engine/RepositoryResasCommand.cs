using Mov.Core.Templates.Crud;
using Mov.Suite.Resas.Models;
using Mov.Suite.Resas.Models.Schemas;
using Mov.Suite.Resas.Models.Schemas.Results;
using System;

namespace Mov.Suite.Resas.Engine
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