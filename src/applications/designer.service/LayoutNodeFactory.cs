using Mov.Designer.Models;
using Mov.Designer.Service.Nodes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Designer.Service
{
    public class LayoutNodeFactory
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

        public LayoutNodeBase Create(LayoutNode node)
        {
            var content = GetContent(node);
            switch (node.LayoutNodeType)
            {
                case LayoutNodeType.Content:
                    return new ContentLayoutNode(node, content);
                case LayoutNodeType.Expander:
                    return new ExpanderLayoutNode(node, content);
                case LayoutNodeType.Scrollbar:
                    return new ScrollbarLayoutNode(node, content);
                case LayoutNodeType.Tab:
                    return new TabLayoutNode(node, content);
                default:
                    return new ContentLayoutNode();
            }
        }

        #endregion メソッド

        #region 内部メソッド

        private LayoutContent GetContent(LayoutNode node)
        {
            return repository.Contents.Get(node.Code);
        }

        #endregion 内部メソッド

    }
}
