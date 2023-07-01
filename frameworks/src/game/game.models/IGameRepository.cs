using Mov.Core.Repositories.Services;
using Mov.Game.Models.Entities.Schemas;

namespace Mov.Game.Models
{
    public interface IGameRepository : IDomainRepository
    {
        IDbObjectRepository<Landmark, LandmarkCollection> Landmarks { get; }
    }
}