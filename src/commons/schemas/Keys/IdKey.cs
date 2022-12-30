using Mov.Utilities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Schemas.Keys
{
    public sealed class IdKey : ValueObjectBase<IdKey>
    {
        #region プロパティ

        public string Value { get; }

        #endregion プロパティ

        #region コンストラクター

        public IdKey(string id)
        {
            this.Value = id;
        }

        #endregion コンストラクター

        #region メソッド

        protected override bool EqualCore(IdKey other)
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
