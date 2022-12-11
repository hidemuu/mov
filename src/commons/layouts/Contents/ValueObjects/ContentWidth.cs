using Mov.Utilities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Layouts.ValueObjects
{
    public sealed class ContentWidth : ValueObjectBase<ContentWidth>
    {
        #region プロパティ

        public double Value { get; }

        #endregion プロパティ

        #region コンストラクター

        public ContentWidth(double width)
        {
            this.Value = width;
        }

        #endregion コンストラクター

        #region メソッド

        protected override bool EqualCore(ContentWidth other)
        {
            return this.Value.Equals(other.Value);
        }

        #endregion メソッド
    }
}
