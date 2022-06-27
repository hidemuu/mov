using Mov.Accessors;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Designer.Models.interfaces
{
    public interface IDesignerRepositoryCollection
    {
        DbObjectRepositoryBase<ContentTable, ContentTableCollection> ContentTables { get; }
        DbObjectRepositoryBase<LayoutTree, LayoutTreeCollection> LayoutTrees { get; }
        DbObjectRepositoryBase<ShellLayout, ShellLayoutCollection> ShellLayouts { get; }
    }
}
