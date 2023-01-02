using Mov.Accessors;
using Mov.Accessors.Crud.Persistence.Implement;
using Mov.Controllers;
using Mov.Designer.Models;
using Mov.Designer.Models.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Designer.Engine.Persistences
{
    public class RepositoryDesignerCommand : IDesignerCommand
    {
        public IPersistenceCommand<Content> Contents { get; }

        public IPersistenceCommand<Node> Nodes { get; }

        public IPersistenceCommand<Shell> Shells { get; }

        public IPersistenceCommand<Theme> Themes { get; }

        public RepositoryDesignerCommand(IDesignerRepository repository)
        {
            this.Nodes = new DbObjectRepositoryCommand<Node, NodeCollection>(repository.Nodes);
            this.Contents = new DbObjectRepositoryCommand<Content, ContentCollection>(repository.Contents);
            this.Shells = new DbObjectRepositoryCommand<Shell, ShellCollection>(repository.Shells);
            this.Themes = new DbObjectRepositoryCommand<Theme, ThemeCollection>(repository.Themes);
        }

    }
}
