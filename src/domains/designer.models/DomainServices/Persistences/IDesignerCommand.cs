using Mov.Accessors;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Designer.Models.Persistences
{
    public interface IDesignerCommand
    {
        IPersistenceCommand<Content> LayoutContent { get; }

        IPersistenceCommand<Node> LayoutNode { get; }

        IPersistenceCommand<Shell> Shell { get; }

        IPersistenceCommand<Theme> Theme { get; }
    }
}
