using Mov.Core.Stores;
using Mov.Game.Models.Schemas;
using System;

namespace Mov.Game.Models
{
    public interface IGameQuery
    {
        IStoreQuery<LandmarkSchema, Guid> Landmark { get; }
    }
}