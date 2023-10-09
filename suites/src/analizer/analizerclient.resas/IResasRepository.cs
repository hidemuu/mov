using Mov.Core.Repositories;
using Mov.Suite.AnalizerClient.Resas.Schemas;
using Mov.Suite.AnalizerClient.Resas.Schemas.Results;

namespace Mov.Suite.AnalizerClient.Resas
{
    public interface IResasRepository
    {
        IDbRepository<ResasResponseSchema<PrefectureResultSchema>, string> Prefectures { get; }

        IDbRepository<ResasResponseSchema<CityResultSchema>, string> Cities { get; }

        IDbRepository<ResasResponseSchema<PopulationPerYearResultSchema>, string> PopulationPerYears { get; }

        IDbRepository<ResasResponseSchema<PopulationPyramidResultSchema>, string> PopulationPyramids { get; }
    }
}