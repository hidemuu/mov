using Mov.Designer.Models;
using Mov.Layouts;
using Mov.Layouts.Contents.ValueObjects;
using Mov.Layouts.Nodes.ValueObjects;
using Reactive.Bindings;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Mov.Designer.Models
{
    public class DesignLayoutNode : DesignLayoutContent
    {
        #region フィールド

        /// <summary>
        /// 子階層
        /// </summary>
        private List<DesignLayoutNode> children = new List<DesignLayoutNode>();

        #endregion フィールド

        #region プロパティ

        public NodeStyle NodeType { get; }

        public EnableStyle Expand { get; }

        /// <summary>
        /// 子階層
        /// </summary>
        public List<DesignLayoutNode> Children => children;

        #endregion プロパティ

        #region コンストラクター

        /// <summary>
        /// コンストラクター
        /// </summary>
        public DesignLayoutNode() : this(new Node(), new Content())
        {
            
        }

        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="node"></param>
        /// <param name="content"></param>
        public DesignLayoutNode(Node node, Content content) : base(content)
        {
            this.NodeType = new NodeStyle(node.NodeType);
            this.Expand = new EnableStyle(true);
        }

        #endregion コンストラクター

        #region メソッド

        
        public void Add(DesignLayoutNode layout)
        {
            children.Add(layout);
        }

        public void AddRange(IEnumerable<DesignLayoutNode> layouts)
        {
            children.AddRange(layouts);
        }

        public override string ToString()
        {
            return base.ToString() + " [ControlType] " + this.LayoutKey.ControlType.Value + " [Macro] " + this.LayoutValue.Macro.Value;
        }

        #endregion メソッド

        #region 内部メソッド

        #endregion 内部メソッド
    }
}
