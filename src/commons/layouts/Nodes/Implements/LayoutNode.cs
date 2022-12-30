using Mov.Layouts;
using Mov.Layouts.Contents.ValueObjects;
using Mov.Layouts.Nodes.ValueObjects;
using Mov.Layouts.ValueObjects;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Mov.Layouts
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

        public LayoutNode()
        {

        }

        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="node"></param>
        /// <param name="content"></param>
        public LayoutNode(string nodeType, bool isExpand, ILayoutKey key, ILayoutParameter parameter, ILayoutDesign design, ILayoutValue value) 
            : base(key, parameter, design, value)
        {
            this.NodeType = new NodeType(nodeType);
            this.Expand = new NodeExpand(isExpand);
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
            return base.ToString() + " [ControlType] " + this.LayoutKey.ControlType.Value + " [Macro] " + this.LayoutValue.Macro.Value;
        }

        #endregion メソッド

        #region 内部メソッド

        #endregion 内部メソッド
    }
}
