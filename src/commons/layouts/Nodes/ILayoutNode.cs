using Mov.Layouts.Nodes.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Layouts
{
    public interface ILayoutNode : ILayoutContent
    {
        NodeExpand Expand { get; }

        IEnumerable<ILayoutNode> Children { get; }
    }
}
