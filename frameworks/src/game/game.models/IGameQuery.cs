using Mov.Core.Templates.Crud;
using Mov.Game.Models.Entities.Schemas;

namespace Mov.Game.Models
{
    public interface IGameQuery
    {
        IPersistenceQuery<Landmark> Landmark { get; }
    }
}