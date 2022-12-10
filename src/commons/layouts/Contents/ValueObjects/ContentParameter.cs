using Mov.Utilities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Layouts.ValueObjects
{
    public sealed class ContentParameter : ValueObjectBase<ContentParameter>
    {
        #region プロパティ

        public string Value { get; }

        #endregion プロパティ

        #region コンストラクター

        public ContentParameter(string parameter)
        {
            this.Value = parameter;
        }

        #endregion コンストラクター

        #region メソッド

        protected override bool EqualCore(ContentParameter other)
        {
            throw new NotImplementedException();
        }

        #endregion メソッド
    }
}
