using Mov.Designer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Designer.Models.Nodes
{
    public class TabLayoutNode : LayoutNodeBase
    {

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
        public TabLayoutNode(Node layout, Content content) : base(layout, content)
        {

        }

        #endregion コンストラクター
    }
}
