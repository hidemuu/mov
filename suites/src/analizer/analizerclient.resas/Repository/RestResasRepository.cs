using Mov.Core.Accessors.Models;
using Mov.Core.Repositories;
using Mov.Core.Repositories.Services;
using Mov.Suite.AnalizerClient.Resas.Schemas;
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

        public string DomainPath => "api/v1/";

        public IDbRepository<ResasResponseSchema<PrefectureResultSchema>, string> Prefectures { get; }

        public IDbRepository<ResasResponseSchema<CityResultSchema>, string> Cities { get; }

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

            Prefectures = new RestDbRepository<ResasResponseSchema<PrefectureResultSchema>, string>(Path.Combine(endpoint, PrefectureResultSchema.URI), string.Empty, EncodingValue.UTF8, headers);
            Cities = new RestDbRepository<ResasResponseSchema<CityResultSchema>, string>(Path.Combine(endpoint, CityResultSchema.URI), string.Empty, EncodingValue.UTF8, headers);
        }

        #endregion constructor

    }
}