using Mov.Accessors;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Analizer.Models.Resas
{
    public interface IResasRepository
    {
        IRepository<ResasResponse<Prefecture>> Prefectures { get; }
    }
}
