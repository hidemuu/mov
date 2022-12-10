using Mov.Utilities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Layouts.ValueObjects
{
    public sealed class ContentHorizontalAlignment : ValueObjectBase<ContentHorizontalAlignment>
    {
        #region プロパティ

        public string Value { get; }

        #endregion プロパティ

        #region コンストラクター

        public ContentHorizontalAlignment(string alignment)
        {
            this.Value = alignment;
        }

        #endregion コンストラクター

        #region メソッド

        protected override bool EqualCore(ContentHorizontalAlignment other)
        {
            throw new NotImplementedException();
        }

        #endregion メソッド
    }
}
