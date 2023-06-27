using Mov.Driver.Clients.Resas.Entities;
using Mov.Driver.Clients.Resas.Entities.Results;
using Mov.Repositories.Services.Cruds;

namespace Mov.Driver.Clients.Resas
{
    public interface IResasQuery
    {
        IPersistenceQuery<ResasResponse<Prefecture>> Prefectures { get; }

        IPersistenceQuery<ResasResponse<City>> Cities { get; }
    }
}