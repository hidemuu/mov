using Mov.Accessors;
using Mov.Designer.Models;
using Mov.Designer.Models.Persistences;
using Mov.Designer.Repository.Persistences.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Designer.Repository.Persistences
{
    public class DesignerQuery : IDesignerQuery
    {
        public IPersistenceQuery<LayoutContent> LayoutContent { get; }

        public IPersistenceQuery<LayoutNode> LayoutNode { get; }

        public IPersistenceQuery<Shell> Shell { get; }

        public IPersistenceQuery<Theme> Theme { get; }

        public DesignerQuery(IDesignerRepository repository)
        {
            this.LayoutContent = new LayoutContentQuery(repository);
            this.LayoutNode = new LayoutNodeQuery(repository);
            this.Shell = new ShellQuery(repository);
            this.Theme = new ThemeQuery(repository);
        }
    }
}
