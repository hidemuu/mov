using Mov.Core.Layouts.Models.Contents;
using Mov.Core.Layouts.Models.Nodes;
using Mov.Core.Models;
using Mov.Core.Styles.Models;

namespace Mov.Designer.Models.Entities
{
    public class DesignerNode : LayoutNode
    {
        public DesignerNode(Identifier<string> code, NodeStyle nodeStyle, EnableStyle expandStyle, LayoutContent content)
            : base(code, nodeStyle, expandStyle, content)
        {
        }
    }
}
