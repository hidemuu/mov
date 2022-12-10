using Mov.Utilities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Layouts.Nodes.ValueObjects
{
    public sealed class NodeExpand : ValueObjectBase<NodeExpand>
    {
        #region プロパティ

        public bool Value { get; set; }

        #endregion プロパティ

        #region コンストラクター

        public NodeExpand(bool isExpanded)
        {
            this.Value = isExpanded;
        }

        #endregion コンストラクター

        #region メソッド

        protected override bool EqualCore(NodeExpand other)
        {
            return this.Value == other.Value;
        }

        #endregion メソッド
    }
}
