using Mov.Layouts.Contents;
using Mov.Layouts.Contents.ValueObjects;
using Mov.Layouts.Nodes.ValueObjects;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Mov.Layouts
{
    public class LayoutNode : LayoutContent
    {
        #region フィールド

        /// <summary>
        /// 子階層
        /// </summary>
        private List<LayoutNode> children = new List<LayoutNode>();

        #endregion フィールド

        #region プロパティ

        public NodeStyle NodeType { get; }

        public EnableStyle Expand { get; }

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
        public LayoutNode(NodeStyle nodeType, EnableStyle isExpand, LayoutKey key, LayoutParameter parameter, LayoutDesign design, LayoutValue value)
            : base(key, parameter, design, value)
        {
            NodeType = nodeType;
            Expand = isExpand;
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
            return base.ToString() + " [ControlType] " + LayoutKey.ControlType.Value + " [Macro] " + LayoutValue.Macro.Value;
        }

        #endregion メソッド

        #region 内部メソッド

        #endregion 内部メソッド
    }
}
