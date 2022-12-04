using Mov.Accessors;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Designer.Models.Persistences
{
    public interface IDesignerQuery
    {
        IPersistenceQuery<LayoutContent> LayoutContent { get; }

        IPersistenceQuery<LayoutNode> LayoutNode { get; }

        IPersistenceQuery<Shell> Shell { get; }

        IPersistenceQuery<Theme> Theme { get; }
    }
}
