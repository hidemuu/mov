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

        public override LayoutNodeType LayoutNodeType => LayoutNodeType.Content;



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
            return base.ToString() + " [ControlType] " + ControlType + " [Macro] " + Macro;
        }

        #endregion メソッド

    }
}
