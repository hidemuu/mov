using Mov.Layouts.Models.Contents.Entities;
using Mov.Layouts.Models.Contents.ValueObjects;
using Mov.Layouts.Models.Nodes.ValueObjects;
using Mov.Utilities.Models.ValueObjects.Keys;
using System.Collections.Generic;

namespace Mov.Layouts.Models.Nodes.Entities
{
    public class LayoutNode
    {
        #region field

        private List<LayoutNode> children = new List<LayoutNode>();

        private LayoutContent content;

        #endregion field

        #region property

        public CodeKey Code { get; }

        public NodeStyle NodeType { get; }

        public EnableStyle Expand { get; }

        public LayoutContent Content => content;

        /// <summary>
        /// 子階層
        /// </summary>
        public List<LayoutNode> Children => children;

        #endregion property

        #region constructor

        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="content"></param>
        public LayoutNode(CodeKey code, NodeStyle nodeStyle, EnableStyle expandStyle, LayoutContent content)
        {
            Code = code;
            NodeType = nodeStyle;
            Expand = expandStyle;
            this.content = content;
        }

        public static LayoutNode Empty => new LayoutNode(CodeKey.Empty, NodeStyle.Content, EnableStyle.Enable, LayoutContent.Empty);

        #endregion constructor

        #region method

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

        #endregion method
    }
}