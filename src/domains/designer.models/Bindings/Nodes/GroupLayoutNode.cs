using Mov.Designer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Designer.Models.Nodes
{
    public class GroupLayoutNode : LayoutNodeBase
    {
        #region コンストラクター

        /// <summary>
        /// コンストラクター
        /// </summary>
        public GroupLayoutNode()
        {

        }

        /// <summary>
        /// コンストラクター
        /// </summary>
        public GroupLayoutNode(LayoutNode layout, LayoutContent content) : base(layout, content)
        {

        }

        #endregion コンストラクター
    }
}
