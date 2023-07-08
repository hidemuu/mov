using Mov.Core.Templates.Repositories;
using Mov.Game.Models.Schemas;

namespace Mov.Game.Models
{
    public interface IGameRepository : IDomainRepository
    {
        IDbObjectRepository<LandmarkSchema, LandmarkSchemaCollection> Landmarks { get; }
    }
}