using Mov.Accessors;
using Mov.Designer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Designer.Repository
{
    public class ThemeRepository : FileRepositoryBase<Theme, ThemeCollection>
    {
        public ThemeRepository(string path, string encoding = "utf-8") : base(path, encoding)
        {
        }
    }
}
