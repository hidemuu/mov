using Mov.Core.Models;

namespace Mov.Framework.Models
{
    public sealed class DomainType : ValueObjectBase<DomainType>
    {
        #region property

        public string Name { get; }

        #endregion property

        #region constructor

        public DomainType(string name)
        {
            this.Name = name;
        }

        public static DomainType Analize => new DomainType("Analize");

        public static DomainType Bom => new DomainType("Bom");

        public static DomainType Config => new DomainType("Config");

        public static DomainType Design => new DomainType("Design");

        public static DomainType Draw => new DomainType("Draw");

        public static DomainType Driver => new DomainType("Driver");

        public static DomainType Game => new DomainType("Game");

        #endregion constructor

        #region method

        public bool IsEmpty()
        {
            return string.IsNullOrEmpty(this.Name);
        }

        #endregion method

        #region protected method

        protected override bool EqualCore(DomainType other)
        {
            return this.Name.Equals(other.Name, System.StringComparison.Ordinal);
        }

        protected override int GetHashCodeCore()
        {
            return this.Name.GetHashCode();
        }

        #endregion protected method
    }

}