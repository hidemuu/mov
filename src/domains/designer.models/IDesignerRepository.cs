using Mov.Accessors;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Designer.Models
{
    public interface IDesignerRepository
    {
        IRepository<Content, ContentCollection> Contents { get; }
        IRepository<LayoutNode, LayoutNodeCollection> LayoutNodes { get; }
        IRepository<Shell, ShellCollection> Shells { get; }
    }
}
