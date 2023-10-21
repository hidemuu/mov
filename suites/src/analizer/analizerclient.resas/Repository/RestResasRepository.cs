using Mov.Core.Accessors.Models;
using Mov.Core.Repositories;
using Mov.Core.Repositories.Schemas.Requests;
using Mov.Core.Repositories.Services;
using Mov.Suite.AnalizerClient.Resas.Repository.Schemas;
using Mov.Suite.AnalizerClient.Resas.Repository.Schemas.Requests;
using Mov.Suite.AnalizerClient.Resas.Repository.Schemas.Results;
using System.Collections.Generic;
using System.IO;

namespace Mov.Suite.AnalizerClient.Resas.Repository
{
    public class RestResasRepository : IResasRepository
    {
        #region constants

        private const string DEFAULT_END_POINT = "https://opendata.resas-portal.go.jp/api/v1/";

        private readonly static string HEADER_API_KEY = @"X-API-KEY";

        #endregion constants

        #region field

        #endregion field

        #region property

        public IDbRepository<ResasResponseSchema<PrefectureResultSchema>, string, DbRequestSchemaString> Prefectures { get; }

        public IDbRepository<ResasResponseSchema<CityResultSchema>, string, DbRequestSchemaString> Cities { get; }

        public IDbRepository<ResasCompositionResponseSchema<PopulationPerYearResultSchema>, string, PopulationPerYearRequestSchema> PopulationPerYears { get; }

        public IDbRepository<ResasCompositionResponseSchema<PopulationPyramidResultSchema>, string, PopulationPyramidRequestSchema> PopulationPyramids { get; }

        #endregion property

        #region constructor

        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="apiKey">APIキー</param>
        public RestResasRepository(string apiKey)
        {
            var endpoint = DEFAULT_END_POINT;
            var header = new RequestHeaderSchema(new Dictionary<string, string>()
            {
                { HEADER_API_KEY, apiKey },
            });

            Prefectures = new RestDbRepository<ResasResponseSchema<PrefectureResultSchema>, string, DbRequestSchemaString>
                (Path.Combine(endpoint, PrefectureResultSchema.URI), EncodingValue.UTF8, header);
            Cities = new RestDbRepository<ResasResponseSchema<CityResultSchema>, string, DbRequestSchemaString>
                (Path.Combine(endpoint, CityResultSchema.URI), EncodingValue.UTF8, header);
            PopulationPerYears = new RestDbRepository<ResasCompositionResponseSchema<PopulationPerYearResultSchema>, string, PopulationPerYearRequestSchema>
                (Path.Combine(endpoint, PopulationPerYearResultSchema.URI), EncodingValue.UTF8, header);
			PopulationPyramids = new RestDbRepository<ResasCompositionResponseSchema<PopulationPyramidResultSchema>, string, PopulationPyramidRequestSchema>
				(Path.Combine(endpoint, PopulationPyramidResultSchema.URI), EncodingValue.UTF8, header);
		}

        #endregion constructor

    }
}