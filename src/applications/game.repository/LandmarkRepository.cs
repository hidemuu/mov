using Mov.Accessors;
using Mov.Game.Models;
using Mov.Game.Models.Maps;
using System;

namespace Mov.Game.Repository
{
    public class LandmarkRepository : DbObjectRepositoryBase<Landmark, LandmarkCollection>
    {
        public LandmarkRepository(string path, string encoding = DbConstants.ENCODE_NAME_UTF8) : base(path, encoding) { }
    }
}
