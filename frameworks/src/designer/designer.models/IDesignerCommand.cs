using Mov.Core.Templates.Crud;
using Mov.Designer.Models.Schemas;

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