using Mov.Core.Repositories;
using Mov.Suite.Resas.Models.Schemas;
using Mov.Suite.Resas.Models.Schemas.Results;

namespace Mov.Suite.Resas.Models
{
    public interface IResasRepository
    {
        IDbRepository<ResasResponse<Prefecture>, string> Prefectures { get; }

        IDbRepository<ResasResponse<City>, string> Cities { get; }
    }
}