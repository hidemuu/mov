using Mov.Accessors;
using Mov.Controllers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Designer.Models.Persistences
{
    public interface IDesignerQuery
    {
        IPersistenceQuery<Content> LayoutContent { get; }

        IPersistenceQuery<Node> LayoutNode { get; }

        IPersistenceQuery<Shell> Shell { get; }

        IPersistenceQuery<Theme> Theme { get; }
    }
}
