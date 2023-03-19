using Mov.Accessors;
using Mov.Accessors.Crud.Persistence.Implement;
using Mov.Controllers;
using Mov.Designer.Models;
using Mov.Designer.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Designer.Engine
{
    public class RepositoryDesignerCommand : IDesignerCommand
    {
        public IPersistenceCommand<Content> Contents { get; }

        public IPersistenceCommand<Node> Nodes { get; }

        public IPersistenceCommand<Shell> Shells { get; }

        public IPersistenceCommand<Theme> Themes { get; }

        public RepositoryDesignerCommand(IDesignerRepository repository)
        {
            Nodes = new DbObjectRepositoryCommand<Node, NodeCollection>(repository.Nodes);
            Contents = new DbObjectRepositoryCommand<Content, ContentCollection>(repository.Contents);
            Shells = new DbObjectRepositoryCommand<Shell, ShellCollection>(repository.Shells);
            Themes = new DbObjectRepositoryCommand<Theme, ThemeCollection>(repository.Themes);
        }

    }
}
