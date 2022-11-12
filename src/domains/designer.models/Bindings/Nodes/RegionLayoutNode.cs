using Mov.Designer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Designer.Models.Nodes
{
    public class RegionLayoutNode : LayoutNodeBase
    {
        #region 定数

        public const string REGION_CENTER = "Center";

        public const string REGION_TOP = "Top";

        public const string REGION_BOTTOM = "Bottom";

        public const string REGION_LEFT = "Left";

        public const string REGION_RIGHT = "Right";

        #endregion 定数

        #region コンストラクター

        /// <summary>
        /// コンストラクター
        /// </summary>
        public RegionLayoutNode()
        {

        }

        /// <summary>
        /// コンストラクター
        /// </summary>
        public RegionLayoutNode(LayoutNode node, LayoutContent content) : base(node, content)
        {

        }

        #endregion コンストラクター
    }
}
