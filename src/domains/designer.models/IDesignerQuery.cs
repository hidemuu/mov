using Mov.Accessors;
using Mov.Controllers;
using Mov.Designer.Models.Schemas;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Designer.Models
{
    public interface IDesignerQuery
    {
        IPersistenceQuery<ContentSchema> Contents { get; }

        IPersistenceQuery<NodeSchema> Nodes { get; }

        IPersistenceQuery<ShellSchema> Shells { get; }

        IPersistenceQuery<ThemeSchema> Themes { get; }
    }
}
