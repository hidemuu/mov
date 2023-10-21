using Mov.Core.Repositories;
using Mov.Core.Repositories.Schemas.Requests;
using Mov.Suite.AnalizerClient.Resas.Repository.Schemas;
using Mov.Suite.AnalizerClient.Resas.Repository.Schemas.Requests;
using Mov.Suite.AnalizerClient.Resas.Repository.Schemas.Results;

namespace Mov.Suite.AnalizerClient.Resas
{
    public interface IResasRepository
    {
        IDbRepository<ResasResponseSchema<PrefectureResultSchema>, string, DbRequestSchemaString> Prefectures { get; }

        IDbRepository<ResasResponseSchema<CityResultSchema>, string, DbRequestSchemaString> Cities { get; }

        IDbRepository<ResasCompositionResponseSchema<PopulationPerYearResultSchema>, string, PopulationPerYearRequestSchema> PopulationPerYears { get; }

        IDbRepository<ResasCompositionResponseSchema<PopulationPyramidResultSchema>, string, PopulationPyramidRequestSchema> PopulationPyramids { get; }
    }
}