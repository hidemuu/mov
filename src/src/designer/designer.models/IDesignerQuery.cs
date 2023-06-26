using Mov.Designer.Models.Schemas;
using Mov.Repositories.Services.Cruds;

namespace Mov.Designer.Models
{
    public interface IDesignerQuery
    {
        IPersistenceQuery<ContentSchema> Contents { get; }

        IPersistenceQuery<NodeSchema> Nodes { get; }

        IPersistenceQuery<ShellSchema> Shells { get; }

        IPersistenceQuery<ThemeSchema> Themes { get; }
    }
}