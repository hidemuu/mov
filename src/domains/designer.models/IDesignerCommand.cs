using Mov.Accessors;
using Mov.Controllers;
using Mov.Designer.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Designer.Models
{
    public interface IDesignerCommand
    {
        IPersistenceCommand<Content> Contents { get; }

        IPersistenceCommand<Node> Nodes { get; }

        IPersistenceCommand<Shell> Shells { get; }

        IPersistenceCommand<Theme> Themes { get; }
    }
}
