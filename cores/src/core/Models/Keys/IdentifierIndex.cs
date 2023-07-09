using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Core.Models.Keys
{
    public sealed class IdentifierIndex : ValueObjectBase<IdentifierIndex>
    {
        #region property

        public int Value { get; }

        #endregion property

        #region constructor

        public IdentifierIndex(int index)
        {
            this.Value = index;
        }

        public static readonly IdentifierIndex Empty = new IdentifierIndex(0);

        #endregion constructor

        #region protected method

        protected override bool EqualCore(IdentifierIndex other)
        {
            return this.Value.Equals(other.Value);
        }

        protected override int GetHashCodeCore()
        {
            return Value.GetHashCode();
        }

        #endregion protected method
    }
}
