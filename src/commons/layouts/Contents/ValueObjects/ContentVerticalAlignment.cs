using Mov.Utilities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Layouts.ValueObjects
{
    public sealed class ContentVerticalAlignment : ValueObjectBase<ContentVerticalAlignment>
    {
        #region プロパティ

        public string Value { get; }

        #endregion プロパティ

        #region コンストラクター

        public ContentVerticalAlignment(string alignment)
        {
            this.Value = alignment;
        }

        #endregion コンストラクター

        #region メソッド

        protected override bool EqualCore(ContentVerticalAlignment other)
        {
            throw new NotImplementedException();
        }

        #endregion メソッド
    }
}
