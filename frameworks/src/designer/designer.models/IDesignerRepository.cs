using Mov.Core.Templates.Repositories;
using Mov.Designer.Models.Schemas;

namespace Mov.Designer.Models
{
    public interface IDesignerRepository : IDomainRepository
    {
        IDbObjectRepository<ContentSchema, ContentSchemaCollection> Contents { get; }
        IDbObjectRepository<NodeSchema, NodeSchemaCollection> Nodes { get; }
        IDbObjectRepository<ShellSchema, ShellSchemaCollection> Shells { get; }
        IDbObjectRepository<ThemeSchema, ThemeSchemaCollection> Themes { get; }
    }
}