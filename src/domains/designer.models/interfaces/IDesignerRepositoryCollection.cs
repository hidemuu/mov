using Mov.Accessors;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Designer.Models.interfaces
{
    public interface IDesignerRepositoryCollection
    {
        FileRepositoryBase<ContentTable, ContentTableCollection> ContentTables { get; }
        FileRepositoryBase<LayoutTree, LayoutTreeCollection> LayoutTrees { get; }
        FileRepositoryBase<ShellLayout, ShellLayoutCollection> ShellLayouts { get; }
    }
}
