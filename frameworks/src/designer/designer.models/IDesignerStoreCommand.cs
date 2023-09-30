using Mov.Core.Stores;
using Mov.Designer.Models.Entities;
using Mov.Designer.Models.Schemas;
using System;

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