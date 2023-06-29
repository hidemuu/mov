namespace Mov.Core.Models.ValueObjects.Units
{
    public sealed class MoneyUnit
    {
        public double Value { get; }

        public MoneyUnit(double value)
        {
            Value = value;
        }
    }
}
