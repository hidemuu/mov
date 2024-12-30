using Mov.Core.Models;
using System;

namespace Mov.Core.Valuables
{
    public sealed class Variable : ValueObjectBase<Variable>
    {
        #region property

        public string Value { get; }

        #endregion property

        #region constructor

        public Variable(string value)
        {
            Value = value;
        }

        public static Variable Empty = new Variable("");

        #endregion constructor

        #region inner method

        protected override bool EqualCore(Variable other)
        {
            return Value.Equals(other.Value, StringComparison.Ordinal);
        }

        protected override int GetHashCodeCore()
        {
            return Value.GetHashCode();
        }

        #endregion inner method
    }
}
