using Mov.Utilities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Layouts.ValueObjects
{
    public sealed class ContentIndent : ValueObjectBase<ContentIndent>
    {
        #region プロパティ

        public int Value { get; }

        #endregion プロパティ

        #region コンストラクター

        public ContentIndent(int indent)
        {
            this.Value = indent;
        }

        #endregion コンストラクター

        #region メソッド

        protected override bool EqualCore(ContentIndent other)
        {
            return this.Value.Equals(other.Value);
        }

        #endregion メソッド
    }
}
