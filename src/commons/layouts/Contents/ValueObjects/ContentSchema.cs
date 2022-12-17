using Mov.Utilities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Layouts.ValueObjects
{
    public sealed class ContentSchema : ValueObjectBase<ContentSchema>
    {
        #region プロパティ

        public string Value { get; }

        #endregion プロパティ

        #region コンストラクター

        public ContentSchema(string schema)
        {
            this.Value = schema;
        }

        #endregion コンストラクター

        #region メソッド

        protected override bool EqualCore(ContentSchema other)
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
