using Mov.Designer.Models;
using Reactive.Bindings;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Designer.Models.Nodes
{
    public class ContentLayoutNode : LayoutNode
    {
        #region プロパティ

        #endregion プロパティ

        #region コンストラクター

        /// <summary>
        /// コンストラクター
        /// </summary>
        public ContentLayoutNode()
        {

        }

        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="node"></param>
        /// <param name="content"></param>
        public ContentLayoutNode(Node node, Content content) : base(node, content)
        {
            
        }

        #endregion コンストラクター

        #region メソッド

        public override string ToString()
        {
            return base.ToString() + " [ControlType] " + ControlType.Value + " [Macro] " + Macro.Value;
        }

        #endregion メソッド

    }
}
