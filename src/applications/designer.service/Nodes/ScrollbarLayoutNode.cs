using Mov.Designer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Designer.Service.Nodes
{
    public class ScrollbarLayoutNode : LayoutNodeBase
    {
        public override LayoutNodeType LayoutNodeType => LayoutNodeType.Scrollbar;

        #region コンストラクター

        /// <summary>
        /// コンストラクター
        /// </summary>
        public ScrollbarLayoutNode()
        {

        }

        /// <summary>
        /// コンストラクター
        /// </summary>
        public ScrollbarLayoutNode(LayoutNode layout, LayoutContent content) : base(layout, content)
        {

        }

        #endregion コンストラクター
    }
}
