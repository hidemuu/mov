using Mov.Core.Accessors.Models;
using Mov.Core.Repositories;
using Mov.Core.Repositories.Services;
using Mov.Suite.AnalizerClient.Resas.Schemas;
using Mov.Suite.AnalizerClient.Resas.Schemas.Results;
using System.IO;

namespace Mov.Suite.AnalizerClient.Resas.Repository
{
    public class RestResasRepository : IResasRepository
    {
        #region field

        private const string DEFAULT_END_POINT = "https://opendata.resas-portal.go.jp/api/v1/";

        private readonly string endpoint;
        private readonly string auth;

        #endregion field

        #region property

        public string DomainPath => "api/v1/";

        public IDbRepository<ResasResponseSchema<PrefectureResultSchema>, string> Prefectures =>
            new RestDbRepository<ResasResponseSchema<PrefectureResultSchema>, string>(Path.Combine(endpoint, PrefectureResultSchema.URI), auth, EncodingValue.UTF8);

        public IDbRepository<ResasResponseSchema<CityResultSchema>, string> Cities =>
            new RestDbRepository<ResasResponseSchema<CityResultSchema>, string>(Path.Combine(endpoint, CityResultSchema.URI), auth, EncodingValue.UTF8);

        #endregion property

        #region constructor

        public RestResasRepository(string endpoint, string auth)
        {
            this.endpoint = string.IsNullOrEmpty(endpoint) ? DEFAULT_END_POINT : endpoint;
            this.auth = auth;
        }

        #endregion constructor

    }
}