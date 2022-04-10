using Mov.Accessors;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Designer.Models.interfaces
{
    public interface IDesignerRepositoryCollection
    {
        FileRepositoryBase<LayoutTable, LayoutTableCollection> LayoutTables { get; }
        FileRepositoryBase<PartsLayout, PartsLayoutCollection> PartsLayouts { get; }
        FileRepositoryBase<ShellLayout, ShellLayoutCollection> ShellLayouts { get; }
    }
}
