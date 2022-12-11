using Mov.Accessors;
using Mov.Accessors.Crud.Persistence.Implement;
using Mov.Designer.Models;
using Mov.Designer.Models.Persistences;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Designer.Engine.Persistences
{
    public class RepositoryDesignerQuery : IDesignerQuery
    {
        public IPersistenceQuery<Content> LayoutContent { get; }

        public IPersistenceQuery<Node> LayoutNode { get; }

        public IPersistenceQuery<Shell> Shell { get; }

        public IPersistenceQuery<Theme> Theme { get; }

        public RepositoryDesignerQuery(IDesignerRepository repository)
        {
            this.LayoutNode = new DbObjectRepositoryQuery<Node, NodeCollection>(repository.Nodes);
            this.LayoutContent = new DbObjectRepositoryQuery<Content, ContentCollection>(repository.Contents);
            this.Shell = new DbObjectRepositoryQuery<Shell, ShellCollection>(repository.Shells);
            this.Theme = new DbObjectRepositoryQuery<Theme, ThemeCollection>(repository.Themes);
        }
    }
}
