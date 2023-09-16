using Mov.Core.Models;
using System;

namespace Mov.Core.Valuables
{
    public sealed class Variable : ValueObjectBase<Variable>
    {
        public static Variable Empty = new Variable("");

        #region property

        public string Value { get; }

        #endregion property

        #region constructor

        public Variable(string parameter)
        {
            Value = parameter;
        }

        #endregion constructor

        #region method

        protected override bool EqualCore(Variable other)
        {
            return Value.Equals(other.Value, StringComparison.Ordinal);
        }

        protected override int GetHashCodeCore()
        {
            return Value.GetHashCode();
        }

        #endregion method
    }
}
