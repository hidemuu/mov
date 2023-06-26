using Mov.Driver.Clients.Resas;
using Mov.Driver.Clients.Resas.Entities;
using Mov.Driver.Clients.Resas.Entities.Results;
using Mov.Repositories.Services.Cruds;
using System;

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