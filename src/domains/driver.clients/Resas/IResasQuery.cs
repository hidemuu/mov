using Mov.Controllers;
using Mov.Driver.Clients.Resas.Entities.Results;
using Mov.Driver.Clients.Resas.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Driver.Clients.Resas
{
    public interface IResasQuery
    {
        IPersistenceQuery<ResasResponse<Prefecture>> Prefectures { get; }

        IPersistenceQuery<ResasResponse<City>> Cities { get; }
    }
}
