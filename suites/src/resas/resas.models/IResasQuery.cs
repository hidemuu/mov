using Mov.Core.Templates.Crud;
using Mov.Suite.Resas.Models.Schemas;
using Mov.Suite.Resas.Models.Schemas.Results;

namespace Mov.Suite.Resas.Models
{
    public interface IResasQuery
    {
        IPersistenceQuery<ResasResponse<Prefecture>> Prefectures { get; }

        IPersistenceQuery<ResasResponse<City>> Cities { get; }
    }
}