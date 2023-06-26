using Mov.Designer.Models.Schemas;
using Mov.Repositories.Services;

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