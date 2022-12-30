using Mov.Utilities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Schemas.Keys
{
    public sealed class CodeKey : ValueObjectBase<CodeKey>
    {
        #region プロパティ

        public string Value { get; }

        #endregion プロパティ

        #region コンストラクター

        public CodeKey(string code)
        {
            this.Value = code;
        }

        #endregion コンストラクター

        #region メソッド

        protected override bool EqualCore(CodeKey other)
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
