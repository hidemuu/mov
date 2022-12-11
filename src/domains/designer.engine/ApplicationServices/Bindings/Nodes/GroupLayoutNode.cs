using Mov.Designer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Designer.Models.Nodes
{
    public class GroupLayoutNode : LayoutNode
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
        public GroupLayoutNode(Node layout, Content content) : base(layout, content)
        {

        }

        #endregion コンストラクター
    }
}
