using Mov.Utilities.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Schemas.Implements.Bodies
{
    public sealed class LayoutSchema : ValueObjectBase<LayoutSchema>
    {
        public static LayoutSchema Empty = new LayoutSchema("");

        #region プロパティ

        public string Value { get; }

        #endregion プロパティ

        #region コンストラクター

        public LayoutSchema(string schema)
        {
            Value = schema;
        }

        #endregion コンストラクター

        #region メソッド

        protected override bool EqualCore(LayoutSchema other)
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
