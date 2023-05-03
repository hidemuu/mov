using Mov.Accessors;
using Mov.Accessors.Crud.Persistence.Implement;
using Mov.Controllers;
using Mov.Designer.Models;
using Mov.Designer.Models.Schemas;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Designer.Engine
{
    public class RepositoryDesignerQuery : IDesignerQuery
    {
        public IPersistenceQuery<ContentSchema> Contents { get; }

        public IPersistenceQuery<NodeSchema> Nodes { get; }

        public IPersistenceQuery<ShellSchema> Shells { get; }

        public IPersistenceQuery<ThemeSchema> Themes { get; }

        public RepositoryDesignerQuery(IDesignerRepository repository)
        {
            Nodes = new DbObjectRepositoryQuery<NodeSchema, NodeCollection>(repository.Nodes);
            Contents = new DbObjectRepositoryQuery<ContentSchema, ContentCollection>(repository.Contents);
            Shells = new DbObjectRepositoryQuery<ShellSchema, ShellCollection>(repository.Shells);
            Themes = new DbObjectRepositoryQuery<ThemeSchema, ThemeCollection>(repository.Themes);
        }
    }
}
