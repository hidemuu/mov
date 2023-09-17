using Mov.Core.Models;

namespace Mov.Core.Valuables
{
    public sealed class Money : ValueObjectBase<Money>
    {
        #region property

        public double Value { get; }

        #endregion property

        #region constructor

        public Money(double value)
        {
            Value = value;
        }

        #endregion constructor

        #region inner method

        protected override bool EqualCore(Money other)
        {
            return this.Value.Equals(other.Value);
        }

        protected override int GetHashCodeCore()
        {
            return this.Value.GetHashCode();
        }

        #endregion inner method
    }
}
