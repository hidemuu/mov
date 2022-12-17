using Mov.Designer.Models;
using Mov.Layouts;
using Mov.Layouts.Nodes.ValueObjects;
using Mov.Layouts.ValueObjects;
using Reactive.Bindings;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Mov.Designer.Models
{
    public class LayoutNode : LayoutContent, ILayoutNode
    {
        #region フィールド

        /// <summary>
        /// 子階層
        /// </summary>
        private List<LayoutNode> children = new List<LayoutNode>();

        #endregion フィールド

        #region プロパティ

        public NodeType NodeType { get; }

        public NodeExpand Expand { get; }

        /// <summary>
        /// 子階層
        /// </summary>
        public List<LayoutNode> Children => children;

        #endregion プロパティ

        #region コンストラクター

        /// <summary>
        /// コンストラクター
        /// </summary>
        public LayoutNode() : this(new Node(), new Content())
        {
            
        }

        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="node"></param>
        /// <param name="content"></param>
        public LayoutNode(Node node, Content content) : base(content)
        {
            this.NodeType = new NodeType(node.NodeType);
            this.Expand = new NodeExpand(true);
        }

        #endregion コンストラクター

        #region メソッド

        
        public void Add(LayoutNode layout)
        {
            children.Add(layout);
        }

        public void AddRange(IEnumerable<LayoutNode> layouts)
        {
            children.AddRange(layouts);
        }

        public override string ToString()
        {
            return base.ToString() + " [ControlType] " + ControlType.Value + " [Macro] " + Macro.Value;
        }

        #endregion メソッド

        #region 内部メソッド

        #endregion 内部メソッド
    }
}
