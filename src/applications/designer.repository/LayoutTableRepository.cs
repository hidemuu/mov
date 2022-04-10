using Mov.Accessors;
using Mov.Designer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Designer.Repository
{
    public class LayoutTableRepository : FileRepositoryBase<LayoutTable, LayoutTableCollection>
    {
        public LayoutTableRepository(string path, string encoding = "utf-8") : base(path, encoding)
        {
        }
    }
}
