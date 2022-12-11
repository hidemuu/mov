using Mov.Utilities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Layouts.ValueObjects
{
    public sealed class ContentHeight : ValueObjectBase<ContentHeight>
    {
        #region プロパティ

        public double Value { get; }

        #endregion プロパティ

        #region コンストラクター

        public ContentHeight(double height)
        {
            this.Value = height;
        }

        #endregion コンストラクター

        #region メソッド

        protected override bool EqualCore(ContentHeight other)
        {
            return this.Value.Equals(other.Value);
        }

        #endregion メソッド
    }
}
