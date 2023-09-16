using System;

namespace Mov.Core.Models
{
    public sealed class Identifier<T> : ValueObjectBase<Identifier<T>>
    {
        #region property

        public T Value { get; }

        #endregion property

        #region constructor

        public Identifier(T id)
        {
            Value = id;
        }

        public static readonly Identifier<T> Empty = new Identifier<T>(default);

        #endregion constructor

        #region method

        public bool IsEmpty() => Equals(Empty);

        #endregion method

        #region protected method

        protected override bool EqualCore(Identifier<T> other)
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
