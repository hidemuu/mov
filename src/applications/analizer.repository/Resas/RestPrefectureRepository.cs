using Mov.Accessors;
using Mov.Analizer.Models.Resas;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Analizer.Repository.Resas
{
    public class RestPrefectureRepository : RestRepositoryBase<ResasResult<Prefecture>>, IPrefectureRepository
    {
        public RestPrefectureRepository(string endpoint, string auth) : base(endpoint + "prefectures", auth)
        {

        }
    }
}
