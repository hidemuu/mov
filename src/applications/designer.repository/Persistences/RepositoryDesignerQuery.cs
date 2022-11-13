using Mov.Accessors;
using Mov.Accessors.Crud.Persistence.Implement;
using Mov.Designer.Models;
using Mov.Designer.Models.Persistences;
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
            this.LayoutNode = new DbObjectRepositoryQuery<LayoutNode, LayoutNodeCollection>(repository.Nodes);
            this.LayoutContent = new DbObjectRepositoryQuery<LayoutContent, LayoutContentCollection>(repository.Contents);
            this.Shell = new DbObjectRepositoryQuery<Shell, ShellCollection>(repository.Shells);
            this.Theme = new DbObjectRepositoryQuery<Theme, ThemeCollection>(repository.Themes);
        }
    }
}
