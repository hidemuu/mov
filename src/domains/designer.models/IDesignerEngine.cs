using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Designer.Models
{
    public interface IDesignerEngine
    {
        IEnumerable<LayoutNodeBase> GetNodes();

        LayoutNodeBase GetCenterNode();

        LayoutNodeBase GetTopNode();

        LayoutNodeBase GetBottomNode();

        LayoutNodeBase GetLeftNode();

        LayoutNodeBase GetRightNode();

        Shell GetCenterShell();

        Shell GetTopShell();

        Shell GetBottomShell();

        Shell GetLeftShell();

        Shell GetRightShell();
    }
}
