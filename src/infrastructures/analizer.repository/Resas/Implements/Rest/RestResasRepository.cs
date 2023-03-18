using Mov.Accessors;
using Mov.Analizer.Models.Apis.Resas;
using Mov.Analizer.Models.Resas;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Mov.Analizer.Repository.Resas
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

        public IEntityRepositoryAsync<ResasResponse<Prefecture>> Prefectures => 
            new RestEntityRepository<ResasResponse<Prefecture>>(Path.Combine(this.endpoint, Prefecture.URI), this.auth);

        public IEntityRepositoryAsync<ResasResponse<City>> Cities =>
            new RestEntityRepository<ResasResponse<City>>(Path.Combine(this.endpoint, City.URI), this.auth);

    }
}
