using Mov.Accessors;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Designer.Models
{
    public interface IDesignerDatabase
    {
        DbObjectRepository<Content, ContentCollection> Contents { get; }
        DbObjectRepository<LayoutNode, LayoutNodeCollection> LayoutNodes { get; }
        DbObjectRepository<Shell, ShellCollection> Shells { get; }
    }
}
