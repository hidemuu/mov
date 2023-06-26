using Mov.Designer.Models.Schemas;
using Mov.Repositories.Services.Cruds;

namespace Mov.Designer.Models
{
    public interface IDesignerCommand
    {
        IPersistenceCommand<ContentSchema> Contents { get; }

        IPersistenceCommand<NodeSchema> Nodes { get; }

        IPersistenceCommand<ShellSchema> Shells { get; }

        IPersistenceCommand<ThemeSchema> Themes { get; }
    }
}