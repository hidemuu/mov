using Mov.Utilities.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Schemas.Units
{
    public sealed class MarginUnit : ValueObjectBase<MarginUnit>
    {
        public static MarginUnit Default = new MarginUnit(0);

        #region プロパティ

        public int Value { get; }

        #endregion プロパティ

        #region コンストラクター

        public MarginUnit(int indent)
        {
            Value = indent;
        }

        #endregion コンストラクター

        #region メソッド

        protected override bool EqualCore(MarginUnit other)
        {
            return Value.Equals(other.Value);
        }

        protected override int GetHashCodeCore()
        {
            return Value.GetHashCode();
        }

        #endregion メソッド
    }
}
