using Mov.Accessors;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Designer.Models.Persistences
{
    public interface IDesignerCommand
    {
        IPersistenceCommand<Content> Content { get; }

        IPersistenceCommand<Node> Node { get; }

        IPersistenceCommand<Shell> Shell { get; }

        IPersistenceCommand<Theme> Theme { get; }
    }
}
