﻿using System;

namespace Mov.Core.Models.Keys
{
    public sealed class IdentifierCode : ValueObjectBase<IdentifierCode>
    {
        public static IdentifierCode Empty = new IdentifierCode("");

        #region プロパティ

        public string Value { get; }

        #endregion プロパティ

        #region コンストラクター

        public IdentifierCode(string code)
        {
            Value = code;
        }

        #endregion コンストラクター

        #region メソッド

        protected override bool EqualCore(IdentifierCode other)
        {
            return Value.Equals(other.Value, StringComparison.Ordinal);
        }

        protected override int GetHashCodeCore()
        {
            return Value.GetHashCode();
        }

        #endregion メソッド
    }
}