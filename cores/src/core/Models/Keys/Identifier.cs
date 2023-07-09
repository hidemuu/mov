using System;

namespace Mov.Core.Models.Keys
{
    public sealed class Identifier : ValueObjectBase<Identifier>
    {
        #region property

        public Guid Value { get; }

        #endregion property

        #region constructor

        public Identifier(Guid id)
        {
            Value = id;
        }

        public static readonly Identifier Empty = new Identifier(Guid.Empty);

        #endregion constructor

        #region method

        public bool IsEmpty() => this.Equals(Empty);

        #endregion method

        #region protected method

        protected override bool EqualCore(Identifier other)
        {
            return Value.Equals(other.Value);
        }

        protected override int GetHashCodeCore()
        {
            return Value.GetHashCode();
        }

        #endregion protected method
    }
}
