using Mov.Accessors;
using Mov.Designer.Models;
using Mov.Designer.Models.Persistences;
using Mov.Designer.Repository.Persistences.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Designer.Repository.Persistences
{
    public class DesignerCommand : IDesignerCommand
    {
        public IPersistenceCommand<LayoutContent> LayoutContent { get; }

        public IPersistenceCommand<LayoutNode> LayoutNode { get; }

        public IPersistenceCommand<Shell> Shell { get; }

        public IPersistenceCommand<Theme> Theme { get; }

        public DesignerCommand(IDesignerRepository repository)
        {
            this.LayoutContent = new LayoutContentCommand(repository);
            this.LayoutNode = new LayoutNodeCommand(repository);
            this.Shell = new ShellCommand(repository);
            this.Theme = new ThemeCommand(repository);
        }

    }
}
