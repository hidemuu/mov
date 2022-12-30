using Mov.Utilities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Schemas.Bodies
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
            this.Value = schema;
        }

        #endregion コンストラクター

        #region メソッド

        protected override bool EqualCore(LayoutSchema other)
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
