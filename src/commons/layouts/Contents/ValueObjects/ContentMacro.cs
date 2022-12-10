using Mov.Utilities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Layouts.ValueObjects
{
    public sealed class ContentMacro : ValueObjectBase<ContentMacro>
    {
        #region プロパティ

        public string Value { get; }

        #endregion プロパティ

        #region コンストラクター

        public ContentMacro(string macro)
        {
            this.Value = macro;
        }

        #endregion コンストラクター

        #region メソッド

        protected override bool EqualCore(ContentMacro other)
        {
            return this.Value.Equals(other.Value, StringComparison.Ordinal);
        }

        #endregion メソッド
    }
}
