using Mov.Core.Templates.Crud;
using Mov.Game.Models.Schemas;

namespace Mov.Game.Models
{
    public interface IGameQuery
    {
        IPersistenceQuery<LandmarkSchema> Landmark { get; }
    }
}