using Mov.Accessors;
using Mov.Accessors.Crud.Persistence.Implement;
using Mov.Designer.Models;
using Mov.Designer.Models.Persistences;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Designer.Engine.Persistences
{
    public class RepositoryDesignerCommand : IDesignerCommand
    {
        public IPersistenceCommand<Content> Content { get; }

        public IPersistenceCommand<Node> Node { get; }

        public IPersistenceCommand<Shell> Shell { get; }

        public IPersistenceCommand<Theme> Theme { get; }

        public RepositoryDesignerCommand(IDesignerRepository repository)
        {
            this.Node = new DbObjectRepositoryCommand<Node, NodeCollection>(repository.Nodes);
            this.Content = new DbObjectRepositoryCommand<Content, ContentCollection>(repository.Contents);
            this.Shell = new DbObjectRepositoryCommand<Shell, ShellCollection>(repository.Shells);
            this.Theme = new DbObjectRepositoryCommand<Theme, ThemeCollection>(repository.Themes);
        }

    }
}
