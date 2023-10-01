using Mov.Core.Repositories;
using Mov.Suite.AnalizerClient.Resas.Schemas;
using Mov.Suite.AnalizerClient.Resas.Schemas.Results;

namespace Mov.Suite.AnalizerClient.Resas
{
    public interface IResasRepository
    {
        IDbRepository<ResasResponse<Prefecture>, string> Prefectures { get; }

        IDbRepository<ResasResponse<City>, string> Cities { get; }
    }
}