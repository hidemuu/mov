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
            throw new NotImplementedException();
        }

        #endregion メソッド
    }
}
