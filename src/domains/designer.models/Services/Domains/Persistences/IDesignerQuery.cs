using Mov.Accessors;
using Mov.Controllers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Designer.Models.Persistences
{
    public interface IDesignerQuery
    {
        IPersistenceQuery<Content> Contents { get; }

        IPersistenceQuery<Node> Nodes { get; }

        IPersistenceQuery<Shell> Shells { get; }

        IPersistenceQuery<Theme> Themes { get; }
    }
}
