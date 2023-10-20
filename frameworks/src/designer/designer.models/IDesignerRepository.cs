using Mov.Core.Repositories;
using Mov.Core.Repositories.Schemas.Requests;
using Mov.Designer.Models.Schemas;
using System;

namespace Mov.Designer.Models
{
    public interface IDesignerRepository
    {
        string Endpoint { get; }

        IDbRepository<ContentSchema, Guid, DbRequestSchemaString> Contents { get; }
        IDbRepository<NodeSchema, Guid, DbRequestSchemaString> Nodes { get; }
        IDbRepository<ShellSchema, Guid, DbRequestSchemaString> Shells { get; }
        IDbRepository<ThemeSchema, Guid, DbRequestSchemaString> Themes { get; }
    }
}