using Mov.Designer.Models;
using Mov.Designer.Models.Nodes;
using Mov.Designer.Models.Persistences;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Designer.Engine
{
    public class LayoutNodeFactory
    {
        #region フィールド

        private readonly IDesignerQuery query;

        #endregion フィールド

        #region コンストラクター

        /// <summary>
        /// コンストラクター
        /// </summary>
        public LayoutNodeFactory(IDesignerQuery query)
        {
            this.query = query;
        }

        #endregion コンストラクター

        #region メソッド

        public LayoutNodeBase Create(LayoutNode node)
        {
            var content = GetContent(node);
            switch (node.NodeType)
            {
                case NodeType.Region:
                    return new RegionLayoutNode(node, content);
                case NodeType.Content:
                    return new ContentLayoutNode(node, content);
                case NodeType.Group:
                    return new GroupLayoutNode(node, content);
                case NodeType.Expander:
                    return new ExpanderLayoutNode(node, content);
                case NodeType.Scrollbar:
                    return new ScrollbarLayoutNode(node, content);
                case NodeType.Tab:
                    return new TabLayoutNode(node, content);
                default:
                    return new ContentLayoutNode();
            }
        }

        #endregion メソッド

        #region 内部メソッド

        private LayoutContent GetContent(LayoutNode node)
        {
            return query.LayoutContent.Get(node.Code);
        }

        #endregion 内部メソッド

    }
}
