using Mov.Core.Accessors.Models;
using Mov.Core.Repositories;
using Mov.Core.Repositories.Services;
using Mov.Suite.AnalizerClient.Resas.Schemas;
using Mov.Suite.AnalizerClient.Resas.Schemas.Requests;
using Mov.Suite.AnalizerClient.Resas.Schemas.Results;
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

        public IDbRepository<ResasResponseSchema<PrefectureResultSchema>, string> Prefectures { get; }

        public IDbRepository<ResasResponseSchema<CityResultSchema>, string> Cities { get; }

        public IDbRepository<ResasResponseSchema<PopulationPerYearResultSchema>, string> PopulationPerYears { get; }

        public IDbRepository<ResasResponseSchema<PopulationPyramidResultSchema>, string> PopulationPyramids { get; }

        #endregion property

        #region constructor

        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="apiKey">APIキー</param>
        public RestResasRepository(string apiKey)
        {
            var endpoint = DEFAULT_END_POINT;
            var headers = new Dictionary<string, string>()
            {
                { HEADER_API_KEY, apiKey },
            };

            Prefectures = new RestDbRepository<ResasResponseSchema<PrefectureResultSchema>, string>
                (Path.Combine(endpoint, PrefectureResultSchema.URI), EncodingValue.UTF8, headers);
            Cities = new RestDbRepository<ResasResponseSchema<CityResultSchema>, string>
                (Path.Combine(endpoint, CityResultSchema.URI), EncodingValue.UTF8, headers);
            PopulationPerYears = new RestDbRepository<ResasResponseSchema<PopulationPerYearResultSchema>, string>
                (Path.Combine(endpoint, PopulationPerYearResultSchema.URI), EncodingValue.UTF8, headers);
			PopulationPyramids = new RestDbRepository<ResasResponseSchema<PopulationPyramidResultSchema>, string>
				(Path.Combine(endpoint, PopulationPyramidResultSchema.URI), EncodingValue.UTF8, headers);
		}

        #endregion constructor

    }
}