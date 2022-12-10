using Mov.Utilities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Layouts.Nodes.ValueObjects
{
    public sealed class NodeType : ValueObjectBase<NodeType>
    {
        #region オブジェクト

        public static readonly NodeType Region = new NodeType("Region");

        public static readonly NodeType Content = new NodeType("Content");

        public static readonly NodeType Group = new NodeType("Group");

        public static readonly NodeType Expander = new NodeType("Expander");

        public static readonly NodeType Scroll = new NodeType("Scroll");

        public static readonly NodeType Tree = new NodeType("Tree");

        public static readonly NodeType Table = new NodeType("Table");

        #endregion オブジェクト

        #region プロパティ

        public string Value { get; }

        #endregion プロパティ

        #region コンストラクター

        public NodeType(string nodeType)
        {
            this.Value = nodeType;
        }

        #endregion コンストラクター

        #region メソッド

        protected override bool EqualCore(NodeType other)
        {
            return Value.Equals(other.Value, StringComparison.Ordinal);
        }

        public bool IsRegion => this == Region;

        public bool IsContent => this == Content;

        public bool IsGroup => this == Group;

        public bool IsExpander => this == Expander;

        public bool IsScroll => this == Scroll;

        public bool IsTree => this == Tree;

        public bool IsTable => this == Table;

        #endregion メソッド
    }
}
