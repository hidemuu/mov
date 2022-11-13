using Mov.Accessors;
using Mov.Designer.Models;
using Mov.Designer.Models.Persistences;
using Mov.Designer.Repository.Persistences.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Designer.Repository.Persistences
{
    public class RepositoryDesignerQuery : IDesignerQuery
    {
        public IPersistenceQuery<LayoutContent> LayoutContent { get; }

        public IPersistenceQuery<LayoutNode> LayoutNode { get; }

        public IPersistenceQuery<Shell> Shell { get; }

        public IPersistenceQuery<Theme> Theme { get; }

        public RepositoryDesignerQuery(IDesignerRepository repository)
        {
            this.LayoutContent = new RepositoryLayoutContentQuery(repository);
            this.LayoutNode = new RepositoryLayoutNodeQuery(repository);
            this.Shell = new RepositoryShellQuery(repository);
            this.Theme = new RepositoryThemeQuery(repository);
        }
    }
}
