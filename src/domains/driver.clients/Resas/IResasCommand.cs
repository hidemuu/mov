using Mov.Controllers;
using Mov.Driver.Clients.Resas.Entities.Results;
using Mov.Driver.Clients.Resas.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Driver.Clients.Resas
{
    public interface IResasCommand
    {
        IPersistenceCommand<ResasResponse<Prefecture>> Prefectures { get; }

        IPersistenceCommand<ResasResponse<City>> Cities { get; }
    }
}
