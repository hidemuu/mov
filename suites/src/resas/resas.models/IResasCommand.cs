using Mov.Core.Templates.Crud;
using Mov.Suite.Resas.Models.Schemas;
using Mov.Suite.Resas.Models.Schemas.Results;

namespace Mov.Suite.Resas.Models
{
    public interface IResasCommand
    {
        IPersistenceCommand<ResasResponse<Prefecture>> Prefectures { get; }

        IPersistenceCommand<ResasResponse<City>> Cities { get; }
    }
}