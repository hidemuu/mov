using Mov.Core.Accessors.Models;
using Mov.Core.Repositories;
using Mov.Core.Repositories.Services;
using Mov.Suite.Resas.Models;
using Mov.Suite.Resas.Models.Schemas;
using Mov.Suite.Resas.Models.Schemas.Results;
using System.IO;

namespace Mov.Suite.Resas.Client.Repository
{
    public class RestResasRepository : IResasRepository
    {
        private const string DEFAULT_END_POINT = "https://opendata.resas-portal.go.jp/api/v1/";

        private readonly string endpoint;
        private readonly string auth;

        public string DomainPath => "api/v1/";

        public RestResasRepository(string endpoint, string auth)
        {
            this.endpoint = string.IsNullOrEmpty(endpoint) ? DEFAULT_END_POINT : endpoint;
            this.auth = auth;
        }

        public IDbRepository<ResasResponse<Prefecture>, string> Prefectures =>
            new RestDbRepository<ResasResponse<Prefecture>, string>(Path.Combine(endpoint, Prefecture.URI), auth, EncodingValue.UTF8);

        public IDbRepository<ResasResponse<City>, string> Cities =>
            new RestDbRepository<ResasResponse<City>, string>(Path.Combine(endpoint, City.URI), auth, EncodingValue.UTF8);
    }
}