using Mov.Accessors;
using Mov.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Designer.Models
{
    public interface IDesignerRepository
    {
        IDbObjectRepository<LayoutContent, LayoutContentCollection> Contents { get; }
        IDbObjectRepository<LayoutNode, LayoutNodeCollection> Nodes { get; }
        IDbObjectRepository<Shell, ShellCollection> Shells { get; }
        IDbObjectRepository<Theme, ThemeCollection> Themes { get; }
    }
}
