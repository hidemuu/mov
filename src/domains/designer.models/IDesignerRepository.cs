using Mov.Accessors.Repository.Domain;
using Mov.Designer.Models.Schemas;
using Mov.Schemas.EntityObjects.DbObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Designer.Models
{
    public interface IDesignerRepository : IDomainRepository
    {
        IDbObjectRepository<ContentSchema, ContentCollection> Contents { get; }
        IDbObjectRepository<NodeSchema, NodeCollection> Nodes { get; }
        IDbObjectRepository<ShellSchema, ShellCollection> Shells { get; }
        IDbObjectRepository<ThemeSchema, ThemeCollection> Themes { get; }
    }
}
