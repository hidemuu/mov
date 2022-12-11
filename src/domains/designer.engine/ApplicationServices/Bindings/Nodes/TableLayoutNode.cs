using Mov.Designer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Designer.Models.Nodes
{
    public class TableLayoutNode : LayoutNode
    {


        #region コンストラクター

        /// <summary>
        /// コンストラクター
        /// </summary>
        public TableLayoutNode()
        {

        }

        /// <summary>
        /// コンストラクター
        /// </summary>
        public TableLayoutNode(Node layout, Content content) : base(layout, content)
        {

        }

        #endregion コンストラクター
    }
}
