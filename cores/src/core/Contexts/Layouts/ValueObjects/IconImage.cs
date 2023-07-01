using Mov.Core.Models;
using System;

namespace Mov.Core.Contexts.Layouts.ValueObjects
{
    public sealed class IconImage : ValueObjectBase<IconImage>
    {
        public static IconImage Empty = new IconImage("");

        #region プロパティ

        public string Value { get; }

        #endregion プロパティ

        #region コンストラクター

        public IconImage(string url)
        {
            Value = url;
        }

        #endregion コンストラクター

        #region メソッド

        protected override bool EqualCore(IconImage other)
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
