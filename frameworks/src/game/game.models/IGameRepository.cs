using Mov.Game.Models.Entities.Schemas;
using Mov.Repositories.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Game.Models
{
    public interface IGameRepository : IDomainRepository
    {
        IDbObjectRepository<Landmark, LandmarkCollection> Landmarks { get; }
    }
}
