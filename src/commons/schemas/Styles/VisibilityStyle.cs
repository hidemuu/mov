using Mov.Utilities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Layouts.Contents.ValueObjects
{
    public sealed class VisibilityStyle : ValueObjectBase<VisibilityStyle>
    {
        #region プロパティ

        public bool Value { get; }

        #endregion プロパティ

        #region コンストラクター

        public VisibilityStyle(bool isVisible)
        {
            this.Value = isVisible;
        }

        #endregion コンストラクター

        #region メソッド

        protected override bool EqualCore(VisibilityStyle other)
        {
            return this.Value.Equals(other.Value);
        }

        protected override int GetHashCodeCore()
        {
            return this.Value.GetHashCode();
        }

        #endregion メソッド
    }
}
