using Mov.Designer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Designer.Service.Nodes
{
    public class TableLayoutNode : LayoutNodeBase
    {
        public override LayoutNodeType LayoutNodeType => LayoutNodeType.Table;



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
        public TableLayoutNode(LayoutNode layout) : base(layout)
        {

        }

        #endregion コンストラクター
    }
}
