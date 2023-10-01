using Mov.Core.Repositories;
using Mov.Game.Models.Schemas;
using System;

namespace Mov.Game.Models
{
    public interface IGameRepository
    {
        IDbRepository<LandmarkSchema, Guid> Landmarks { get; }
    }
}