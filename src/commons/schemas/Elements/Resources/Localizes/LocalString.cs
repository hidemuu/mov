using Mov.Utilities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Schemas.Elements.Resources.Localizes
{
    public sealed class LocalString : ValueObjectBase<LocalString>
    {
        public static LocalString Empty = new LocalString("");

        #region プロパティ

        public string Value { get; }

        #endregion プロパティ

        #region コンストラクター

        public LocalString(string info)
        {
            Value = info;
        }

        #endregion コンストラクター

        #region メソッド

        protected override bool EqualCore(LocalString other)
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
