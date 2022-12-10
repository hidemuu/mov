using Mov.Utilities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Layouts.ValueObjects
{
    public sealed class ContentCode : ValueObjectBase<ContentCode>
    {
        #region プロパティ

        public string Value { get; }

        #endregion プロパティ

        #region コンストラクター

        public ContentCode(string code)
        {
            this.Value = code;
        }

        #endregion コンストラクター

        #region メソッド

        protected override bool EqualCore(ContentCode other)
        {
            throw new NotImplementedException();
        }

        #endregion メソッド
    }
}
