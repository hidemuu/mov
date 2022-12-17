using Mov.Accessors;
using Mov.Controllers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Designer.Models.Persistences
{
    public interface IDesignerCommand
    {
        IPersistenceCommand<Content> Contents { get; }

        IPersistenceCommand<Node> Nodes { get; }

        IPersistenceCommand<Shell> Shells { get; }

        IPersistenceCommand<Theme> Themes { get; }
    }
}
