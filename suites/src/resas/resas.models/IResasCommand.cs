using Mov.Core.Templates.Crud;
using Mov.Driver.Clients.Resas.Entities;
using Mov.Driver.Clients.Resas.Entities.Results;

namespace Mov.Driver.Clients.Resas
{
    public interface IResasCommand
    {
        IPersistenceCommand<ResasResponse<Prefecture>> Prefectures { get; }

        IPersistenceCommand<ResasResponse<City>> Cities { get; }
    }
}