using Mov.Designer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Designer.Models.Nodes
{
    public class TreeLayoutNode : LayoutNode
    {

        #region コンストラクター

        /// <summary>
        /// コンストラクター
        /// </summary>
        public TreeLayoutNode()
        {

        }

        /// <summary>
        /// コンストラクター
        /// </summary>
        public TreeLayoutNode(Node layout, Content content) : base(layout, content)
        {

        }

        #endregion コンストラクター
    }
}
