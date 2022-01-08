using Accessors;
using Designer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Designer.Repository
{
    public class LayoutRepository : FileAccessor<LayoutTree>, ILayoutRepository
    {
        public readonly static string FILE_NAME = "layout";
        public LayoutRepository(IFileHelper fileHelper) : base(fileHelper)
        {
        }
    }
}
