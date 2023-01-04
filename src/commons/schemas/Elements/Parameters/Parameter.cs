using Mov.Utilities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Schemas.Elements.Parameters
{
    public sealed class Parameter : ValueObjectBase<Parameter>
    {
        public static Parameter Empty = new Parameter("");

        #region プロパティ

        public string Value { get; }

        #endregion プロパティ

        #region コンストラクター

        public Parameter(string parameter)
        {
            Value = parameter;
        }

        #endregion コンストラクター

        #region メソッド

        protected override bool EqualCore(Parameter other)
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
