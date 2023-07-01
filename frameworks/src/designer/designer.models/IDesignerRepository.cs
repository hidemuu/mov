using Mov.Core.Repositories.Services;
using Mov.Designer.Models.Schemas;

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