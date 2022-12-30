using Mov.Schemas.Resources.Images;
using Mov.Utilities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Schemas.Resources.Localizes
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
            this.Value = info;
        }

        #endregion コンストラクター

        #region メソッド

        protected override bool EqualCore(LocalString other)
        {
            return this.Value.Equals(other.Value, StringComparison.Ordinal);
        }

        protected override int GetHashCodeCore()
        {
            return this.Value.GetHashCode();
        }

        #endregion メソッド
    }
}
