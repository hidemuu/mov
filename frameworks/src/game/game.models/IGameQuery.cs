using Mov.Core.Repositories.Services.Cruds;
using Mov.Game.Models.Entities.Schemas;

namespace Mov.Game.Models
{
    public interface IGameQuery
    {
        IPersistenceQuery<Landmark> Landmark { get; }
    }
}