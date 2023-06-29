using System;

namespace Mov.Core.Models.ValueObjects.Keys
{
    public sealed class IdKey : ValueObjectBase<IdKey>
    {
        #region プロパティ

        public string Value { get; }

        #endregion プロパティ

        #region コンストラクター

        public IdKey(string id)
        {
            Value = id;
        }

        #endregion コンストラクター

        #region メソッド

        protected override bool EqualCore(IdKey other)
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
