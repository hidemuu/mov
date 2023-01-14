using Mov.Utilities.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Schemas.Resources.Keys
{
    public sealed class CodeKey : ValueObjectBase<CodeKey>
    {
        public static CodeKey Empty = new CodeKey("");

        #region プロパティ

        public string Value { get; }

        #endregion プロパティ

        #region コンストラクター

        public CodeKey(string code)
        {
            Value = code;
        }

        #endregion コンストラクター

        #region メソッド

        protected override bool EqualCore(CodeKey other)
        {
            return Value.Equals(other.Value, StringComparison.Ordinal);
        }

        protected override int GetHashCodeCore()
        {
            return Value.GetHashCode();
        }

        #endregion メソッド
    }
}
