using Mov.Accessors;
using Mov.Designer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Designer.Repository
{
    public class ShellLayoutRepository : FileRepositoryBase<ShellLayout>, IShellLayoutRepository
    {
        public ShellLayoutRepository(string path, string encoding = "utf-8") : base(path, encoding)
        {
        }

        public override IEnumerable<ShellLayout> Gets() => base.Get().Items;

        public override string ToString() => base.Get().ToStrings();

    }
}
