using Mov.Core.Stores;
using Mov.Designer.Models.Entities;

namespace Mov.Designer.Models
{
    public interface IDesignerStoreCommand
    {
        IStoreCommand<DesignerContent> Contents { get; }

        IStoreCommand<DesignerNode> Nodes { get; }

        IStoreCommand<DesignerShell> Shells { get; }

        IStoreCommand<DesignerTheme> Themes { get; }
    }
}