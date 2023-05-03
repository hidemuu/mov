using Mov.Accessors;
using Mov.Controllers;
using Mov.Designer.Models.Schemas;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Designer.Models
{
    public interface IDesignerCommand
    {
        IPersistenceCommand<ContentSchema> Contents { get; }

        IPersistenceCommand<NodeSchema> Nodes { get; }

        IPersistenceCommand<ShellSchema> Shells { get; }

        IPersistenceCommand<ThemeSchema> Themes { get; }
    }
}
