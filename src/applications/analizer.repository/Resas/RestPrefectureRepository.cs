using Mov.Accessors;
using Mov.Analizer.Models.Resas;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Analizer.Repository.Resas
{
    public class RestPrefectureRepository : RestRepositoryBase<Prefecture>
    {
        public RestPrefectureRepository() : base("api/v1/prefectures", "")
        {

        }
    }
}
