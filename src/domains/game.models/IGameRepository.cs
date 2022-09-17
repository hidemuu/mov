using Mov.Accessors;
using Mov.BaseModel;
using Mov.Game.Models.Maps;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Game.Models
{
    public interface IGameRepository
    {
        IDbObjectRepository<Landmark> Landmarks { get; }
    }
}
