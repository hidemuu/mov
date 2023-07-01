using System;

namespace Mov.Core.Models.Units
{
    public sealed class Variable : ValueObjectBase<Variable>
    {
        public static Variable Empty = new Variable("");

        #region プロパティ

        public string Value { get; }

        #endregion プロパティ

        #region コンストラクター

        public Variable(string parameter)
        {
            Value = parameter;
        }

        #endregion コンストラクター

        #region メソッド

        protected override bool EqualCore(Variable other)
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
