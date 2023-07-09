namespace Mov.Core.Models.Units
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

        public bool IsEmpty => this.Equals(Empty);

        public bool IsEN => this.Equals(EN);

        public bool IsJP => this.Equals(JP);

        public bool IsCN => this.Equals(CN);

        #endregion method

        #region protected method

        protected override bool EqualCore(Location other)
        {
            return this.Value.Equals(other.Value);
        }

        protected override int GetHashCodeCore()
        {
            return this.Value.GetHashCode();
        }

        #endregion protected method
    }
}
