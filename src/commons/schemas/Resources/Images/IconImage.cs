using Mov.Utilities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Schemas.Resources.Images
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
            this.Value = url;
        }

        #endregion コンストラクター

        #region メソッド

        protected override bool EqualCore(IconImage other)
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
