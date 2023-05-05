using Mov.Driver.Clients.Resas.Entities.Results;
using Mov.Driver.Clients.Resas.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Mov.Schemas.EntityObject;

namespace Mov.Driver.Clients
{
    public interface IResasClient
    {
        IEntityRepositoryAsync<ResasResponse<Prefecture>> Prefectures { get; }

        IEntityRepositoryAsync<ResasResponse<City>> Cities { get; }
    }
}
