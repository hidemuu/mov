using Mov.Designer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Designer.Service.Layouts.Nodes
{
    public class TabLayoutNode : LayoutNodeBase
    {
        public override LayoutNodeType LayoutNodeType => LayoutNodeType.Tab;

        #region コンストラクター

        /// <summary>
        /// コンストラクター
        /// </summary>
        public TabLayoutNode()
        {

        }

        /// <summary>
        /// コンストラクター
        /// </summary>
        public TabLayoutNode(LayoutNode layout) : base(layout)
        {

        }

        #endregion コンストラクター
    }
}
