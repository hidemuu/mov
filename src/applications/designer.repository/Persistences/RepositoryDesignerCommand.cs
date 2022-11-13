using Mov.Accessors;
using Mov.Designer.Models;
using Mov.Designer.Models.Persistences;
using Mov.Designer.Repository.Persistences.Entities;
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
            this.LayoutContent = new RepositoryLayoutContentCommand(repository);
            this.LayoutNode = new RepositoryLayoutNodeCommand(repository);
            this.Shell = new RepositoryShellCommand(repository);
            this.Theme = new RepositoryThemeCommand(repository);
        }

    }
}
