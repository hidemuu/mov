using Mov.Designer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Designer.Service.Layouts.Nodes
{
    public class HeaderLayoutNode : LayoutNodeBase
    {
        public override LayoutNodeType LayoutNodeType => LayoutNodeType.Header;

        #region コンストラクター

        /// <summary>
        /// コンストラクター
        /// </summary>
        public HeaderLayoutNode()
        {

        }

        /// <summary>
        /// コンストラクター
        /// </summary>
        public HeaderLayoutNode(LayoutTree layout) : base(layout)
        {

        }

        #endregion コンストラクター
    }
}
