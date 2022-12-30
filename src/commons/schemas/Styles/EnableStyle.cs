using Mov.Utilities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Layouts.Contents.ValueObjects
{
    public sealed class EnableStyle : ValueObjectBase<EnableStyle>
    {
        public static EnableStyle Enable = new EnableStyle(true);

        public static EnableStyle Disable = new EnableStyle(false);

        #region プロパティ

        public bool Value { get; }

        #endregion プロパティ

        #region コンストラクター

        public EnableStyle(bool isEnabled)
        {
            this.Value = isEnabled;
        }

        #endregion コンストラクター

        #region メソッド

        protected override bool EqualCore(EnableStyle other)
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
