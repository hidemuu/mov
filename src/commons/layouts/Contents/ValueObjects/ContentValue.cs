using Mov.Utilities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Layouts.ValueObjects
{
    public sealed class ContentValue : ValueObjectBase<ContentValue>
    {
        #region プロパティ

        public string Value { get; }

        #endregion プロパティ

        #region コンストラクター

        public ContentValue(string value)
        {
            this.Value = value;
        }

        #endregion コンストラクター

        #region メソッド

        protected override bool EqualCore(ContentValue other)
        {
            return this.Value.Equals(other.Value, StringComparison.Ordinal);
        }

        #endregion メソッド
    }
}
