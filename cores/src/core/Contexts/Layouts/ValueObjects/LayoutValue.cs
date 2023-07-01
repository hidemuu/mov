using Mov.Core.Models;
using System;

namespace Mov.Core.Contexts.Layouts.ValueObjects
{
    public sealed class LayoutValue : ValueObjectBase<LayoutValue>
    {
        #region property

        public string Value { get; }

        #endregion property

        #region constructor

        public LayoutValue(string schema)
        {
            Value = schema;
        }

        public static LayoutValue Empty => new LayoutValue("");

        #endregion constructor

        #region protected method

        protected override bool EqualCore(LayoutValue other)
        {
            return Value.Equals(other.Value, StringComparison.Ordinal);
        }

        protected override int GetHashCodeCore()
        {
            return Value.GetHashCode();
        }

        #endregion protected method
    }
}
