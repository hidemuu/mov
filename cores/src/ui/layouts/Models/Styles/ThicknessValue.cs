using Mov.Core.Models;

namespace Mov.Core.Layouts.Models.Styles
{
    public sealed class ThicknessValue : ValueObjectBase<ThicknessValue>
    {
        public static ThicknessValue Default = new ThicknessValue(0);

        public double Value { get; }

        public ThicknessValue(double value)
        {
            Value = value;
        }

        protected override bool EqualCore(ThicknessValue other)
        {
            return Value.Equals(other.Value); ;
        }

        protected override int GetHashCodeCore()
        {
            return Value.GetHashCode();
        }
    }
}
