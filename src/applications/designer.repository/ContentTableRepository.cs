using Mov.Accessors;
using Mov.Designer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Designer.Repository
{
    public class ContentTableRepository : DbObjectRepositoryBase<ContentTable, ContentTableCollection>
    {
        public ContentTableRepository(string path, string encoding = "utf-8") : base(path, encoding)
        {
        }
    }
}
