using Mov.Accessors;
using Mov.Controllers.Repository.Entity;
using Mov.Driver.Clients;
using Mov.Driver.Clients.Resas;
using Mov.Driver.Clients.Resas.Entities;
using Mov.Driver.Clients.Resas.Entities.Results;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Driver.Clients.Resas
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
            new RestEntityRepository<ResasResponse<Prefecture>>(Path.Combine(endpoint, Prefecture.URI), auth);

        public IEntityRepositoryAsync<ResasResponse<City>> Cities =>
            new RestEntityRepository<ResasResponse<City>>(Path.Combine(endpoint, City.URI), auth);

    }
}
