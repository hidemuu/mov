using Mov.Accessors;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Designer.Models
{
    public interface IDesignerRepository
    {
        IDbObjectRepository<LayoutContent, LayoutContentCollection> Contents { get; }
        IDbObjectRepository<LayoutNode, LayoutNodeCollection> LayoutNodes { get; }
        IDbObjectRepository<Shell, ShellCollection> Shells { get; }
    }
}
