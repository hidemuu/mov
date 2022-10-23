using Mov.Designer.Models;
using Reactive.Bindings;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Designer.Service.Nodes
{
    public class ContentLayoutNode : LayoutNodeBase
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
        public ContentLayoutNode(LayoutNode node, LayoutContent content) : base(node, content)
        {
            
        }

        #endregion コンストラクター

        #region メソッド

        public override string ToString()
        {
            return base.ToString() + " [ControlType] " + Content.ControlType + " [Macro] " + Content.Macro;
        }

        #endregion メソッド

    }
}
