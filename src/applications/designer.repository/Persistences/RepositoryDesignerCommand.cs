using Mov.Accessors;
using Mov.Accessors.Crud.Persistence.Implement;
using Mov.Designer.Models;
using Mov.Designer.Models.Persistences;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Designer.Repository.Persistences
{
    public class RepositoryDesignerCommand : IDesignerCommand
    {
        public IPersistenceCommand<LayoutContent> LayoutContent { get; }

        public IPersistenceCommand<LayoutNode> LayoutNode { get; }

        public IPersistenceCommand<Shell> Shell { get; }

        public IPersistenceCommand<Theme> Theme { get; }

        public RepositoryDesignerCommand(IDesignerRepository repository)
        {
            this.LayoutNode = new DbObjectRepositoryCommand<LayoutNode, LayoutNodeCollection>(repository.Nodes);
            this.LayoutContent = new DbObjectRepositoryCommand<LayoutContent, LayoutContentCollection>(repository.Contents);
            this.Shell = new DbObjectRepositoryCommand<Shell, ShellCollection>(repository.Shells);
            this.Theme = new DbObjectRepositoryCommand<Theme, ThemeCollection>(repository.Themes);
        }

    }
}
