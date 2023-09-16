using Mov.Core.Models;

namespace Mov.Core.Maths
{
    public sealed class WeightValue : ValueObjectBase<WeightValue>
    {
        public decimal Value { get; }

        public WeightValue(decimal value)
        {
            Value = value;
        }

        protected override bool EqualCore(WeightValue other)
        {
            return Value.Equals(other.Value); ;
        }

        protected override int GetHashCodeCore()
        {
            return Value.GetHashCode();
        }
    }
}
