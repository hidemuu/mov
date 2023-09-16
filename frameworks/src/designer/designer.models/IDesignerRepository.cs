using Mov.Core.Repositories;
using Mov.Designer.Models.Schemas;
using System;

namespace Mov.Designer.Models
{
    public interface IDesignerRepository
    {
        IDbObjectRepository<ContentSchema, Guid> Contents { get; }
        IDbObjectRepository<NodeSchema, Guid> Nodes { get; }
        IDbObjectRepository<ShellSchema, Guid> Shells { get; }
        IDbObjectRepository<ThemeSchema, Guid> Themes { get; }
    }
}