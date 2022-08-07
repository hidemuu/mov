using Mov.Accessors;
using Mov.Game.Models.Maps;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Game.Models
{
    public interface IGameRepository
    {
        IRepository<Landmark, LandmarkCollection> Landmarks { get; }
    }
}
