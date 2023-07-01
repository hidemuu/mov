using Mov.Core.Templates.Repositories;
using Mov.Game.Models.Entities.Schemas;

namespace Mov.Game.Models
{
    public interface IGameRepository : IDomainRepository
    {
        IDbObjectRepository<Landmark, LandmarkCollection> Landmarks { get; }
    }
}