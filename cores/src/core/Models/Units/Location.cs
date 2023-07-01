namespace Mov.Core.Models.Units
{
    public sealed class Location : ValueObjectBase<Location>
    {
        #region フィールド

        public static readonly Location JP = new Location(0);

        public static readonly Location EN = new Location(1);

        public static readonly Location CN = new Location(2);

        #endregion フィールド

        #region プロパティ

        public int Value { get; }

        #endregion プロパティ

        #region コンストラクター

        public Location(int value)
        {
            Value = value;
        }

        #endregion コンストラクター

        #region メソッド

        protected override bool EqualCore(Location other)
        {
            return IsJP && IsEN && IsCN;
        }

        protected override int GetHashCodeCore()
        {
            return Value.GetHashCode();
        }

        public bool IsJP => this == JP;

        public bool IsEN => this == EN;

        public bool IsCN => this == CN;

        #endregion メソッド
    }
}
