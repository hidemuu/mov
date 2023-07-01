using Mov.Core.Repositories.Cruds;
using Mov.Core.Templates.Crud;
using Mov.Designer.Models;
using Mov.Designer.Models.Schemas;

namespace Mov.Designer.Engine.Cruds
{
    public class RepositoryDesignerQuery : IDesignerQuery
    {
        public IPersistenceQuery<ContentSchema> Contents { get; }

        public IPersistenceQuery<NodeSchema> Nodes { get; }

        public IPersistenceQuery<ShellSchema> Shells { get; }

        public IPersistenceQuery<ThemeSchema> Themes { get; }

        public RepositoryDesignerQuery(IDesignerRepository repository)
        {
            Nodes = new DbObjectRepositoryQuery<NodeSchema, NodeCollection>(repository.Nodes);
            Contents = new DbObjectRepositoryQuery<ContentSchema, ContentCollection>(repository.Contents);
            Shells = new DbObjectRepositoryQuery<ShellSchema, ShellCollection>(repository.Shells);
            Themes = new DbObjectRepositoryQuery<ThemeSchema, ThemeCollection>(repository.Themes);
        }
    }
}