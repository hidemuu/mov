using Mov.Analizer.Models.Resas;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Analizer.Repository.Resas
{
    public class RestResasRepository : IResasRepository
    {
        private const string DEFAULT_END_POINT = "https://opendata.resas-portal.go.jp/api/v1/";

        private readonly string endpoint;
        private readonly string auth;

        public RestResasRepository(string endpoint, string auth)
        {
            this.endpoint = string.IsNullOrEmpty(endpoint) ? DEFAULT_END_POINT : endpoint;
            this.auth = auth;
        }

        public IPrefectureRepository Prefectures => new RestPrefectureRepository(this.endpoint, this.auth);
    }
}
