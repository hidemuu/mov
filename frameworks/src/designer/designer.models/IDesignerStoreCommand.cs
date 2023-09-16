using Mov.Core.Stores;
using Mov.Designer.Models.Entities;
using Mov.Designer.Models.Schemas;
using System;

namespace Mov.Designer.Models
{
    public interface IDesignerStoreCommand
    {
        IStoreCommand<DesignerContent, Guid> Contents { get; }

        IStoreCommand<DesignerNode, Guid> Nodes { get; }

        IStoreCommand<DesignerShell, Guid> Shells { get; }

        IStoreCommand<DesignerTheme, Guid> Themes { get; }
    }
}