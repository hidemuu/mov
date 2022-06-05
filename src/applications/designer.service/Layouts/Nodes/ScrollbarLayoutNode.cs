using Mov.Designer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Designer.Service.Layouts.Nodes
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
        public ScrollbarLayoutNode(LayoutTree layout) : base(layout)
        {

        }

        #endregion コンストラクター
    }
}
