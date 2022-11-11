using Mov.Accessors;
using Mov.Accessors.Repository.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Designer.Models
{
    public interface IDesignerRepository : IDomainRepository
    {
        IDbObjectRepository<LayoutContent, LayoutContentCollection> Contents { get; }
        IDbObjectRepository<LayoutNode, LayoutNodeCollection> Nodes { get; }
        IDbObjectRepository<Shell, ShellCollection> Shells { get; }
        IDbObjectRepository<Theme, ThemeCollection> Themes { get; }
    }
}
