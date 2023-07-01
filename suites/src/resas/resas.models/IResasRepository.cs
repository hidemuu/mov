using Mov.Core.Templates.Repositories;
using Mov.Driver.Clients.Resas.Entities;
using Mov.Driver.Clients.Resas.Entities.Results;

namespace Mov.Driver.Clients.Resas
{
    public interface IResasRepository
    {
        IEntityRepositoryAsync<ResasResponse<Prefecture>> Prefectures { get; }

        IEntityRepositoryAsync<ResasResponse<City>> Cities { get; }
    }
}