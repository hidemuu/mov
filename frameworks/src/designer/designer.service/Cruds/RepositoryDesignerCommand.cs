using Mov.Core.Repositories.Cruds;
using Mov.Core.Templates.Crud;
using Mov.Designer.Models;
using Mov.Designer.Models.Schemas;

namespace Mov.Designer.Engine.Cruds
{
    public class RepositoryDesignerCommand : IDesignerCommand
    {
        public IPersistenceCommand<ContentSchema> Contents { get; }

        public IPersistenceCommand<NodeSchema> Nodes { get; }

        public IPersistenceCommand<ShellSchema> Shells { get; }

        public IPersistenceCommand<ThemeSchema> Themes { get; }

        public RepositoryDesignerCommand(IDesignerRepository repository)
        {
            Nodes = new DbObjectRepositoryCommand<NodeSchema, NodeSchemaCollection>(repository.Nodes);
            Contents = new DbObjectRepositoryCommand<ContentSchema, ContentSchemaCollection>(repository.Contents);
            Shells = new DbObjectRepositoryCommand<ShellSchema, ShellSchemaCollection>(repository.Shells);
            Themes = new DbObjectRepositoryCommand<ThemeSchema, ThemeSchemaCollection>(repository.Themes);
        }
    }
}