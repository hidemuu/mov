using Mov.Utilities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Layouts.ValueObjects
{
    public sealed class ContentStyle : ValueObjectBase<ContentStyle>
    {
        #region プロパティ

        public string Value { get; }

        #endregion プロパティ

        #region コンストラクター

        public ContentStyle(string style)
        {
            this.Value = style;
        }

        #endregion コンストラクター

        #region メソッド

        protected override bool EqualCore(ContentStyle other)
        {
            throw new NotImplementedException();
        }

        #endregion メソッド
    }
}
