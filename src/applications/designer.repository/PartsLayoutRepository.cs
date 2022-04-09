using Mov.Accessors;
using Mov.Designer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Designer.Repository
{
    public class PartsLayoutRepository : FileRepositoryBase<PartsLayout>, IPartsLayoutRepository
    {
        public PartsLayoutRepository(string path, string encoding = "utf-8") : base(path, encoding)
        {
        }

        public override IEnumerable<PartsLayout> Gets() => base.Get().Children;

        public override string ToString() => base.Get().ToStrings();
    }
}
