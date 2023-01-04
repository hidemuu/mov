using Mov.Utilities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Schemas.Elements.Resources.Localizes
{
    public sealed class Info : ValueObjectBase<Info>
    {
        public static Info Empty = new Info("");

        #region プロパティ

        public string Value { get; }

        #endregion プロパティ

        #region コンストラクター

        public Info(string info)
        {
            Value = info;
        }

        #endregion コンストラクター

        #region メソッド

        protected override bool EqualCore(Info other)
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
