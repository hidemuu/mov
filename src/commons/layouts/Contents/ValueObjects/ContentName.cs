using Mov.Utilities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Layouts.ValueObjects
{
    public sealed class ContentName : ValueObjectBase<ContentName>
    {
        #region プロパティ

        public string Value { get; }

        #endregion プロパティ

        #region コンストラクター

        public ContentName(string name)
        {
            this.Value = name;
        }

        #endregion コンストラクター

        #region メソッド

        protected override bool EqualCore(ContentName other)
        {
            return this.Value.Equals(other.Value, StringComparison.Ordinal);
        }

        protected override int GetHashCodeCore()
        {
            return this.Value.GetHashCode();
        }

        #endregion メソッド
    }
}
