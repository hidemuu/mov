using Mov.Accessors;
using Mov.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Designer.Models
{
    public interface IDesignerRepository
    {
        IDbObjectRepository<LayoutContent> Contents { get; }
        IDbObjectRepository<LayoutNode> Nodes { get; }
        IDbObjectRepository<Shell> Shells { get; }
        IDbObjectRepository<Theme> Themes { get; }
    }
}
