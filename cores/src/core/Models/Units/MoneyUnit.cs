namespace Mov.Core.Models.Units
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
