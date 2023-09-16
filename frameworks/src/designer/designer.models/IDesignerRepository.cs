using Mov.Core.Repositories;
using Mov.Designer.Models.Schemas;
using System;

namespace Mov.Designer.Models
{
    public interface IDesignerRepository
    {
        string Endpoint { get; }

        IDbRepository<ContentSchema, Guid> Contents { get; }
        IDbRepository<NodeSchema, Guid> Nodes { get; }
        IDbRepository<ShellSchema, Guid> Shells { get; }
        IDbRepository<ThemeSchema, Guid> Themes { get; }
    }
}