using Mov.Accessors;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Designer.Models.Persistences
{
    public interface IDesignerCommand
    {
        IPersistenceCommand<Icon> Icon { get; }

        IPersistenceCommand<LayoutContent> LayoutContent { get; }

        IPersistenceCommand<LayoutNode> LayoutNode { get; }

        IPersistenceCommand<Shell> Shell { get; }

        IPersistenceCommand<Theme> Theme { get; }
    }
}
