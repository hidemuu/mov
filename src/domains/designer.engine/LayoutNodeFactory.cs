using Mov.Designer.Models;
using Mov.Designer.Models.Nodes;
using Mov.Designer.Models.Persistences;
using Mov.Layouts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Designer.Engine
{
    internal class LayoutNodeFactory
    {
        #region フィールド

        private readonly IDesignerRepository repository;

        #endregion フィールド

        #region コンストラクター

        /// <summary>
        /// コンストラクター
        /// </summary>
        public LayoutNodeFactory(IDesignerRepository repository)
        {
            this.repository = repository;
        }

        #endregion コンストラクター

        #region メソッド

        public LayoutNodeBase Create(Node node)
        {
            var content = GetContent(node);
            switch (node.NodeType)
            {
                case NodeTypes.Region:
                    return new RegionLayoutNode(node, content);
                case NodeTypes.Content:
                    return new ContentLayoutNode(node, content);
                case NodeTypes.Group:
                    return new GroupLayoutNode(node, content);
                case NodeTypes.Expander:
                    return new ExpanderLayoutNode(node, content);
                case NodeTypes.Scrollbar:
                    return new ScrollbarLayoutNode(node, content);
                case NodeTypes.Tab:
                    return new TabLayoutNode(node, content);
                default:
                    return new ContentLayoutNode();
            }
        }

        #endregion メソッド

        #region 内部メソッド

        private Content GetContent(Node node)
        {
            return this.repository.Contents.Get(node.Code);
        }

        #endregion 内部メソッド

    }
}
