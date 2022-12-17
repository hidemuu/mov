using Mov.Accessors;
using Mov.Accessors.Crud.Persistence.Implement;
using Mov.Controllers;
using Mov.Designer.Models;
using Mov.Designer.Models.Persistences;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Designer.Engine.Persistences
{
    public class RepositoryDesignerQuery : IDesignerQuery
    {
        public IPersistenceQuery<Content> Contents { get; }

        public IPersistenceQuery<Node> Nodes { get; }

        public IPersistenceQuery<Shell> Shells { get; }

        public IPersistenceQuery<Theme> Themes { get; }

        public RepositoryDesignerQuery(IDesignerRepository repository)
        {
            this.Nodes = new DbObjectRepositoryQuery<Node, NodeCollection>(repository.Nodes);
            this.Contents = new DbObjectRepositoryQuery<Content, ContentCollection>(repository.Contents);
            this.Shells = new DbObjectRepositoryQuery<Shell, ShellCollection>(repository.Shells);
            this.Themes = new DbObjectRepositoryQuery<Theme, ThemeCollection>(repository.Themes);
        }
    }
}
