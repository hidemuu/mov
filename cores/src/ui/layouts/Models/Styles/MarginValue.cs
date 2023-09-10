namespace Mov.Core.Models.Styles
{
    public sealed class MarginValue : ValueObjectBase<MarginValue>
    {
        public static MarginValue Default = new MarginValue(0);

        #region プロパティ

        public int Value { get; }

        #endregion プロパティ

        #region コンストラクター

        public MarginValue(int indent)
        {
            Value = indent;
        }

        #endregion コンストラクター

        #region メソッド

        protected override bool EqualCore(MarginValue other)
        {
            return Value.Equals(other.Value);
        }

        protected override int GetHashCodeCore()
        {
            return Value.GetHashCode();
        }

        #endregion メソッド
    }
}
