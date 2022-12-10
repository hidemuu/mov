using Mov.Utilities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Layouts.Contents.ValueObjects
{
    public sealed class ContentEnable : ValueObjectBase<ContentEnable>
    {
        #region プロパティ

        public bool Value { get; }

        #endregion プロパティ

        #region コンストラクター

        public ContentEnable(bool isEnabled)
        {
            this.Value = isEnabled;
        }

        #endregion コンストラクター

        #region メソッド

        protected override bool EqualCore(ContentEnable other)
        {
            throw new NotImplementedException();
        }

        #endregion メソッド
    }
}
