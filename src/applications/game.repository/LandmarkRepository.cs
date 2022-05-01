using Mov.Accessors;
using Mov.Game.Models.Maps;
using System;

namespace Mov.Game.Repository
{
    public class LandmarkRepository : FileRepositoryBase<Landmark, LandmarkCollection>
    {
        public LandmarkRepository(string path, string encoding = "utf-8") : base(path, encoding) { }
    }
}
