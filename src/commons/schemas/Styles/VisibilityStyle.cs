using Mov.Utilities.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Schemas.Styles
{
    public sealed class VisibilityStyle : ValueObjectBase<VisibilityStyle>
    {
        public static VisibilityStyle Visible = new VisibilityStyle("Visible");

        public static VisibilityStyle Collapse = new VisibilityStyle("Collapse");

        public static VisibilityStyle Hidden = new VisibilityStyle("Hidden");

        #region プロパティ

        public string Value { get; }

        #endregion プロパティ

        #region コンストラクター

        public VisibilityStyle(string isVisible)
        {
            Value = isVisible;
        }

        #endregion コンストラクター

        #region メソッド

        protected override bool EqualCore(VisibilityStyle other)
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
