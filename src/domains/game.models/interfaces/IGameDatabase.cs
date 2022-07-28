using Mov.Accessors;
using Mov.Game.Models.Maps;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Game.Models.interfaces
{
    public interface IGameDatabase
    {
        DbObjectRepository<Landmark, LandmarkCollection> Landmarks { get; }
        DbObjectRepository<DrawItem, DrawItemCollection> DrawItems { get; }
    }
}
