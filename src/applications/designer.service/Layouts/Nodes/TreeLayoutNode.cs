using Mov.Designer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Designer.Service.Layouts.Nodes
{
    public class TreeLayoutNode : LayoutNodeBase
    {
        public override LayoutNodeType LayoutNodeType => LayoutNodeType.Tree;

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
        public TreeLayoutNode(LayoutTree layout) : base(layout)
        {

        }

        #endregion コンストラクター
    }
}
