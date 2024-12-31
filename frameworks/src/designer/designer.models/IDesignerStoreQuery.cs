using Mov.Core.Stores;
using Mov.Designer.Models.Entities;
using System;

namespace Mov.Designer.Models
{
    public interface IDesignerStoreQuery
    {
        IStoreQuery<DesignerContent, Guid> Contents { get; }

        IStoreQuery<DesignerNode, Guid> Nodes { get; }

        IStoreQuery<DesignerShell, Guid> Shells { get; }

        IStoreQuery<DesignerTheme, Guid> Themes { get; }
    }
}