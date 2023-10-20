using Mov.Core.Repositories;
using Mov.Core.Repositories.Schemas.Requests;
using Mov.Suite.AnalizerClient.Resas.Schemas;
using Mov.Suite.AnalizerClient.Resas.Schemas.Requests;
using Mov.Suite.AnalizerClient.Resas.Schemas.Results;

namespace Mov.Suite.AnalizerClient.Resas
{
    public interface IResasRepository
    {
        IDbRepository<ResasResponseSchema<PrefectureResultSchema>, string, DbRequestSchemaString> Prefectures { get; }

        IDbRepository<ResasResponseSchema<CityResultSchema>, string, DbRequestSchemaString> Cities { get; }

        IDbRepository<ResasResponseSchema<PopulationPerYearResultSchema>, string, PopulationPerYearRequestSchema> PopulationPerYears { get; }

        IDbRepository<ResasResponseSchema<PopulationPyramidResultSchema>, string, PopulationPyramidRequestSchema> PopulationPyramids { get; }
    }
}