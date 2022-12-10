using Mov.Layouts.Nodes.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Layouts
{
    public interface ILayoutNode : ILayoutContent
    {
        NodeType NodeType { get; }

        NodeExpand Expand { get; }

        NodeControlType ControlType { get; }

        IEnumerable<ILayoutNode> Children { get; }
    }
}
