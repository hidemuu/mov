using Mov.Designer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Designer.Service.Nodes
{
    public class RootLayoutNode : LayoutNodeBase
    {
        public override LayoutNodeType LayoutNodeType => LayoutNodeType.Root;

        #region コンストラクター

        /// <summary>
        /// コンストラクター
        /// </summary>
        public RootLayoutNode()
        {

        }

        /// <summary>
        /// コンストラクター
        /// </summary>
        public RootLayoutNode(LayoutNode layout) : base(layout)
        {

        }

        #endregion コンストラクター
    }
}
