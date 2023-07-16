namespace Mov.Core.Models.Worlds
{
    public sealed class Location : ValueObjectBase<Location>
    {
        #region property

        public int Value { get; }

        #endregion property

        #region constructor

        public Location(int value)
        {
            Value = value;
        }

        public static readonly Location Empty = new Location(-1);

        public static readonly Location EN = new Location(0);

        public static readonly Location JP = new Location(1);

        public static readonly Location CN = new Location(2);

        #endregion constructor

        #region method

        public bool IsNan => !IsEN && !IsJP && !IsCN;

        public bool IsEmpty => Equals(Empty);

        public bool IsEN => Equals(EN);

        public bool IsJP => Equals(JP);

        public bool IsCN => Equals(CN);

        #endregion method

        #region protected method

        protected override bool EqualCore(Location other)
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
