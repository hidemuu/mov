using Mov.Core.Stores;
using Mov.Designer.Models.Schemas;

namespace Mov.Designer.Models
{
    public interface IDesignerCommand
    {
        IStoreCommand<ContentSchema> Contents { get; }

        IStoreCommand<NodeSchema> Nodes { get; }

        IStoreCommand<ShellSchema> Shells { get; }

        IStoreCommand<ThemeSchema> Themes { get; }
    }
}