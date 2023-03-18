using Mov.Accessors;
using Mov.Analizer.Models.Resas;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Analizer.Models.Apis.Resas
{
    public interface IResasRepository
    {
        IEntityRepositoryAsync<ResasResponse<Prefecture>> Prefectures { get; }

        IEntityRepositoryAsync<ResasResponse<City>> Cities { get; }
    }
}
