using Mov.Driver.Clients.Resas.Entities;
using Mov.Driver.Clients.Resas.Entities.Results;
using Mov.Schemas.EntityObject;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Driver.Clients.Resas
{
    public interface IResasRepository
    {
        IEntityRepositoryAsync<ResasResponse<Prefecture>> Prefectures { get; }

        IEntityRepositoryAsync<ResasResponse<City>> Cities { get; }
    }
}
