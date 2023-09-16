using Mov.Core.Stores;
using Mov.Designer.Models.Schemas;

namespace Mov.Designer.Models
{
    public interface IDesignerQuery
    {
        IStoreQuery<ContentSchema> Contents { get; }

        IStoreQuery<NodeSchema> Nodes { get; }

        IStoreQuery<ShellSchema> Shells { get; }

        IStoreQuery<ThemeSchema> Themes { get; }
    }
}