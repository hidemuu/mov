using Mov.Accessors;
using Mov.Accessors.Repository.Domain;
using Mov.Designer.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Designer.Models
{
    public interface IDesignerRepository : IDomainRepository
    {
        IDbObjectRepository<Content, ContentCollection> Contents { get; }
        IDbObjectRepository<Node, NodeCollection> Nodes { get; }
        IDbObjectRepository<Shell, ShellCollection> Shells { get; }
        IDbObjectRepository<Theme, ThemeCollection> Themes { get; }
    }
}
