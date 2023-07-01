using Mov.Core.Models;
using System;
using System.Collections.Generic;

namespace Mov.Core.Contexts.Layouts.ValueObjects
{
    public sealed class NodeStyle : ValueObjectBase<NodeStyle>
    {
        #region オブジェクト

        public static readonly NodeStyle Region = new NodeStyle("Region");

        public static readonly NodeStyle Content = new NodeStyle("Content");

        public static readonly NodeStyle Group = new NodeStyle("Group");

        public static readonly NodeStyle Expander = new NodeStyle("Expander");

        public static readonly NodeStyle Scroll = new NodeStyle("Scroll");

        public static readonly NodeStyle Tab = new NodeStyle("Tab");

        public static readonly NodeStyle Tree = new NodeStyle("Tree");

        public static readonly NodeStyle Table = new NodeStyle("Table");

        #endregion オブジェクト

        #region プロパティ

        public string Value { get; set; }

        public bool IsRegion => this == Region;

        public bool IsContent => this == Content;

        public bool IsGroup => this == Group;

        public bool IsExpander => this == Expander;

        public bool IsScroll => this == Scroll;

        public bool IsTab => this == Tab;

        public bool IsTree => this == Tree;

        public bool IsTable => this == Table;

        #endregion プロパティ

        #region コンストラクター

        public NodeStyle(string nodeType)
        {
            Value = nodeType;
        }

        #endregion コンストラクター

        #region メソッド

        protected override bool EqualCore(NodeStyle other)
        {
            return Value.Equals(other.Value, StringComparison.Ordinal);
        }

        protected override int GetHashCodeCore()
        {
            return Value.GetHashCode();
        }

        #endregion メソッド

        #region 静的メソッド

        public static IEnumerable<string> GetStrings()
        {
            return new string[]
            {
                Region.Value,
                Content.Value,
                Group.Value,
                Expander.Value,
                Scroll.Value,
                Tab.Value,
                Tree.Value,
                Table.Value,
            };
        }

        #endregion 静的メソッド
    }
}
