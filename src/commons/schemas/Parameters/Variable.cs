using Mov.Utilities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Schemas.Parameters
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
            this.Value = parameter;
        }

        #endregion コンストラクター

        #region メソッド

        protected override bool EqualCore(Variable other)
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
