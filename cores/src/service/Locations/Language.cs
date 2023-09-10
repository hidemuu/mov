using Mov.Core.Models;

namespace Mov.Core.Locations
{
    public sealed class Language : ValueObjectBase<Language>
    {
        #region property

        public int Value { get; }

        #endregion property

        #region constructor

        public Language(int value)
        {
            Value = value;
        }

        public static readonly Language Empty = new Language(-1);

        public static readonly Language EN = new Language(0);

        public static readonly Language JP = new Language(1);

        public static readonly Language CN = new Language(2);

        #endregion constructor

        #region method

        public bool IsNan => !IsEN && !IsJP && !IsCN;

        public bool IsEmpty => Equals(Empty);

        public bool IsEN => Equals(EN);

        public bool IsJP => Equals(JP);

        public bool IsCN => Equals(CN);

        #endregion method

        #region protected method

        protected override bool EqualCore(Language other)
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
