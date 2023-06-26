using Mov.Schemas.Layouts.Styles;
using Mov.Schemas.Parameters.Keys;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Mov.Layouts.Contexts
{
    public class LayoutNode
    {
        public static LayoutNode Empty = new LayoutNode(CodeKey.Empty, NodeStyle.Content, EnableStyle.Enable, LayoutContent.Default);

        #region フィールド

        private List<LayoutNode> children = new List<LayoutNode>();

        private LayoutContent content;

        #endregion フィールド

        #region プロパティ

        public CodeKey Code { get; }

        public NodeStyle NodeType { get; }

        public EnableStyle Expand { get; }

        public LayoutContent Content => content;

        /// <summary>
        /// 子階層
        /// </summary>
        public List<LayoutNode> Children => children;

        #endregion プロパティ

        #region コンストラクター

        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="content"></param>
        public LayoutNode(CodeKey code, NodeStyle nodeStyle, EnableStyle expandStyle, LayoutContent content)
        {
            this.Code = code;
            this.NodeType = nodeStyle;
            this.Expand = expandStyle;
            this.content = content;
        }

        #endregion コンストラクター

        #region メソッド


        public void Add(LayoutNode node)
        {
            children.Add(node);
        }

        public void AddRange(IEnumerable<LayoutNode> nodes)
        {
            children.AddRange(nodes);
        }

        public void SetContent(LayoutContent content)
        {
            this.content = content;
        }

        public override string ToString()
        {
            return base.ToString() + " [ControlType] " + Content.Keys.ControlType.Value + " [Macro] " + Content.Schemas.Macro.Value;
        }

        #endregion メソッド

        #region 内部メソッド

        #endregion 内部メソッド
    }
}
